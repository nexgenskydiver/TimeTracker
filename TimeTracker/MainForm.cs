using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TimeTracker.Core.Models;

namespace TimeTracker.WinForms
{
    public partial class MainForm : Form
    {
        // Events the presenter will subscribe to
        public event EventHandler? StartClicked;
        public event EventHandler? EndClicked;
        public event EventHandler? AddTagRequested;
        public event EventHandler? SettingsRequested;

        public MainForm()
        {
            InitializeComponent();

            // Wire the UI buttons to our events
            btnStart.Click += (s, e) => StartClicked?.Invoke(this, e);
            btnEnd.Click += (s, e) => EndClicked?.Invoke(this, e);

            // Initial state
            btnEnd.Enabled = false;

            // Add Button Tag
            btnAddTag.Click += (s, e) => AddTagRequested?.Invoke(this, e);

            // Add Settings Button
            btnSettings.Click += (s, e) => SettingsRequested?.Invoke(this, e);
        }

        /// <summary>
        /// Populate the tag list (CheckedListBox) with the given names.
        /// </summary>
        public void SetTagList(IEnumerable<string> tags)
        {
            checkedListBox1.Items.Clear();
            foreach (var t in tags)
                checkedListBox1.Items.Add(t);
        }

        /// <summary>
        /// Return the tags the user has checked.
        /// </summary>
        public IEnumerable<string> GetSelectedTags() =>
            checkedListBox1.CheckedItems.OfType<string>();

        /// <summary>
        /// Return whatever the user typed into the notes box.
        /// </summary>
        public string GetNotes() => richTextBoxNotes.Text;

        /// <summary>
        /// Clear the notes box for the next entry.
        /// </summary>
        public void ClearNotes() => richTextBoxNotes.Clear();

        /// <summary>
        /// Enable/disable Start & End buttons depending on whether a timer is running.
        /// </summary>
        public void ToggleButtons(bool isRunning)
        {
            btnStart.Enabled = !isRunning;
            btnEnd.Enabled = isRunning;
        }

        /// <summary>
        /// Update the “Elapsed” label every second.
        /// </summary>
        public void UpdateElapsedLabel(TimeSpan span)
        {
            lblElapsed.Text = $"Elapsed: {span:hh\\:mm\\:ss}";
        }

        public void BindEntries(IEnumerable<TimeTracker.Core.ViewModels.TimeEntryViewModel> rows)
        {
            // Clear out any old binding
            dataGridViewEntries.DataSource = null;

            // Bind the list of strongly-typed view models
            dataGridViewEntries.DataSource = rows;

            // (Optional) auto-resize columns
            dataGridViewEntries.AutoResizeColumns();
        }

        /// <summary>
        /// Pops up the AddTagForm and returns the new tag, or null if canceled.
        /// </summary>
        public string? PromptForNewTag()
        {
            using var dlg = new AddTagForm();
            return dlg.ShowDialog(this) == DialogResult.OK
                ? dlg.TagName
                : null;
        }

        /// <summary>
        /// Show the settings dialog; returns false if canceled.
        /// </summary>
        public bool PromptForSettings(out string server, out string database)
        {
            using var dlg = new SettingsForm();

            // Load current values from appsettings.json
            var configJson = System.IO.File.ReadAllText("appsettings.json");
            var node = System.Text.Json.Nodes.JsonNode.Parse(configJson)!;
            var current = node["ConnectionStrings"]!["Default"]!.ToString();
            // very simple parse: assume "Server=...;Database=...;..."
            var parts = current.Split(';')
                               .Select(p => p.Split('=', 2))
                               .Where(p => p.Length == 2)
                               .ToDictionary(kv => kv[0].Trim(), kv => kv[1].Trim());
            if (parts.TryGetValue("Server", out var s)) dlg.Server = s;
            if (parts.TryGetValue("Database", out var d)) dlg.Database = d;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                server = dlg.Server;
                database = dlg.Database;
                return true;
            }

            server = string.Empty;
            database = string.Empty;
            return false;
        }


    }
}
