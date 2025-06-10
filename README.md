# TimeTracker

A lightweight WinForms time-tracking application in C#/.NET 8 with tagging support and reporting.

## Features

- Start/stop timer per entry  
- Attach multi-line notes  
- Tag entries for easy filtering  
- Automatic elapsed timer display  
- View history in a DataGridView  
- Entity Framework Core with SQL Server (LocalDB)  
- MVP pattern with DI via Microsoft.Extensions.Hosting  

## Prerequisites

- .NET 8.0 SDK  
- Visual Studio 2022 or later (with WinForms and Git tooling)  
- SQL Server LocalDB (installed with VS)  

## Getting Started

1. **Clone** the repo:  
   ```bash
   git clone https://github.com/<your-username>/TimeTracker.git
   cd TimeTracker
   ```  
2. **Open** `TimeTracker.sln` in Visual Studio.  
3. **Update** the connection string in `appsettings.json` if needed.  
4. **Apply migrations** in the Package Manager Console:  
   ```powershell
   # Ensure "Default project" is set to TimeTracker.Data
   Update-Database
   ```  
5. **Run** the app (F5).  

## Usage

1. Click **Start** to begin tracking.  
2. Enter notes, check tags, then click **End** to save.  
3. View all entries in the history grid.  
4. Add new tags via the **Add Tag** button.  

## Contributing

1. Fork the repo.  
2. Create a feature branch (`git checkout -b feature/MyFeature`).  
3. Commit your changes (`git commit -m "Add MyFeature"`).  
4. Push to your branch (`git push origin feature/MyFeature`).  
5. Open a Pull Request.  

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.
