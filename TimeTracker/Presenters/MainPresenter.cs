﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTracker.Core.Interfaces;
using TimeTracker.Core.Models;
using TimeTracker.Core.ViewModels;

using Timer = System.Windows.Forms.Timer;

namespace TimeTracker.WinForms.Presenters
{
    public class MainPresenter
    {
        private readonly ITimeEntryRepository _timeRepo;
        private readonly ITagRepository _tagRepo;
        private readonly MainForm _view;
        private TimeEntry? _currentEntry;
        private readonly Timer _timer;

        public MainPresenter(ITimeEntryRepository timeRepo,
                             ITagRepository tagRepo,
                             MainForm view)
        {
            _timeRepo = timeRepo;
            _tagRepo = tagRepo;
            _view = view;

            // Wire view events
            _view.StartClicked += OnStart;
            _view.EndClicked += OnEnd;
            _view.AddTagRequested += OnAddTagRequested;
            _view.SettingsRequested += OnSettingsRequested;

            // Setup timer to update elapsed label every second
            _timer = new Timer { Interval = 1000 };
            _timer.Tick += (s, e) => UpdateElapsed();

            // Load tags into the CheckedListBox
            _ = LoadTagsAsync();
            _ = LoadHistoryAsync();
        }

        private async Task LoadTagsAsync()
        {
            var tags = await _tagRepo.ListAllAsync();
            _view.SetTagList(tags.Select(t => t.Name));
        }

        private async void OnStart(object? sender, EventArgs e)
        {
            _currentEntry = new TimeEntry { StartTime = DateTimeOffset.Now, Notes = string.Empty };
            await _timeRepo.AddAsync(_currentEntry);
            _view.ToggleButtons(isRunning: true);
            _timer.Start();
        }

        private async void OnEnd(object? sender, EventArgs e)
        {
            if (_currentEntry == null) return;

            _timer.Stop();

            // Grab the raw multi-line text
            var rawNotes = _view.GetNotes();

            // Split on any newline sequence, drop empty lines
            var lines = rawNotes
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Join them back together with comma+space
            var notesWithCommas = string.Join(", ", lines);

            // Grab selected tags
            var selectedTags = _view.GetSelectedTags();

            // Persit using your repository
            await _timeRepo.EndAsync(
                _currentEntry.TimeEntryId,
                DateTimeOffset.Now,
                notesWithCommas,
                selectedTags
            );

            _view.ToggleButtons(isRunning: false);
            _view.ClearNotes();

            await LoadHistoryAsync();
        }

        private void UpdateElapsed()
        {
            if (_currentEntry == null) return;
            var span = DateTimeOffset.Now - _currentEntry.StartTime;
            _view.UpdateElapsedLabel(span);
        }

        private async Task LoadHistoryAsync()
        {
            var history = await _timeRepo.ListAllAsync();
            var rows = history.Select(te => new TimeEntryViewModel
            {
                Date = te.StartTime.Date,
                Start = te.StartTime.TimeOfDay,
                End = te.EndTime?.TimeOfDay ?? TimeSpan.Zero,
                Duration = te.EndTime.HasValue
                             ? (te.EndTime.Value - te.StartTime).ToString(@"hh\:mm\:ss")
                             : "",
                Notes = te.Notes,
                Tags = string.Join(", ", te.Tags.Select(t => t.Name))
            }).ToList();

            _view.BindEntries(rows);
        }

        private async void OnAddTagRequested(object? s, EventArgs e)
        {
            // Ask the view to show the modal dialog:
            var name = _view.PromptForNewTag();
            if (string.IsNullOrWhiteSpace(name)) return;

            // Create or ignore if it already exists:
            await _tagRepo.CreateAsync(new Tag { Name = name });

            // Refresh the checklist in the view:
            var tags = await _tagRepo.ListAllAsync();
            _view.SetTagList(tags.Select(t => t.Name));
        }

        private void OnSettingsRequested(object? sender, EventArgs e)
        {
            if (_view.PromptForSettings(out var server, out var database))
            {
                // Build the connection string
                var newConn = $"Server={server};Database={database};Trusted_Connection=True;";

                // Read & update appsettings.json
                var path = "appsettings.json";
                var json = System.IO.File.ReadAllText(path);
                var node = System.Text.Json.Nodes.JsonNode.Parse(json)!;
                node["ConnectionStrings"]!["Default"] = newConn;
                System.IO.File.WriteAllText(path,
                    node.ToJsonString(new System.Text.Json.JsonSerializerOptions { WriteIndented = true })
                );

                MessageBox.Show("Settings updated. Please restart the application.",
                                "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
