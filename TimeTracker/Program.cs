using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using TimeTracker.Core.Interfaces;
using TimeTracker.Data;
using TimeTracker.Data.Repositories;
using TimeTracker.WinForms.Presenters;

namespace TimeTracker.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1) Build our Host with DbContext + repositories + MainForm
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(cfg => cfg
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true))
                .ConfigureServices((ctx, services) =>
                {
                    services.AddDbContextFactory<TimeTrackerContext>(opts =>
                        opts.UseSqlServer(ctx.Configuration.GetConnectionString("Default")));

                    services.AddScoped<ITagRepository, TagRepository>();
                    services.AddScoped<ITimeEntryRepository, TimeEntryRepository>();

                    // We register MainForm so DI can inject its deps:
                    services.AddTransient<MainForm>();
                })
                .Build();

            // 2) Create a scope, pull out MainForm
            using var scope = host.Services.CreateScope();
            var sp = scope.ServiceProvider;
            var form = sp.GetRequiredService<MainForm>();

            // 3) Manually new-up the presenter so it subscribes to StartClicked/EndClicked
            //    (We pass in the SAME form instance, so events wire correctly.)
            var repo = sp.GetRequiredService<ITimeEntryRepository>();
            var tagRepo = sp.GetRequiredService<ITagRepository>();
            var presenter = new MainPresenter(repo, tagRepo, form);

            // 4) Run the WinForms app
            Application.Run(form);
        }
    }
}
