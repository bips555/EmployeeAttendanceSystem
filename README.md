# Employee Attendance Management System

A comprehensive ASP.NET Core 8.0 web application for managing employee attendance records with role-based access control and modern UI components.

## 🚀 Features

### User Authentication & Authorization
- **Secure Registration** - Employee registration with detailed profile information
- **Login/Logout** - Robust authentication system
- **Role-Based Access** - Separate Admin and Employee access levels

### Employee Management
- **CRUD Operations** - Complete employee lifecycle management
- **Comprehensive Profiles** - Name, age, gender, salary, date of birth tracking
- **Live Preview** - Real-time employee data preview using KnockoutJS
- **Data Validation** - Form validation and error handling

### Attendance Tracking
- **Daily Attendance** - Mark and track daily employee attendance
- **Attendance History** - View historical attendance records
- **Date Filtering** - Filter attendance by specific dates
- **Status Management** - Present/Absent status tracking

### Admin Dashboard
- **Employee Overview** - Manage all employee records
- **Bulk Attendance** - Take attendance for multiple employees
- **Reporting** - View comprehensive attendance reports
- **System Administration** - Full system control and monitoring

## 🛠️ Technologies Used

### Backend
- **ASP.NET Core 8.0** - Modern web framework
- **Entity Framework Core 9.0** - Object-relational mapping
- **Identity Framework** - Authentication and authorization
- **SQL Server** - Production database
- **SQLite** - Development database

### Frontend
- **Razor Pages** - Server-side rendering
- **Bootstrap 5** - Responsive UI framework
- **KnockoutJS** - Dynamic data binding and preview functionality
- **Toastr** - User-friendly notifications
- **jQuery** - DOM manipulation and AJAX

## 📋 Prerequisites

Before running this application, ensure you have:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQLite for development)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) (recommended)
- [Git](https://git-scm.com/) for version control

## ⚡ Quick Start

### 1. Clone the Repository
```bash
git clone https://github.com/your-username/employee-attendance-system.git
cd employee-attendance-system
```

### 2. Configure Database Connection
Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=EmployeeAttendanceDB;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### 3. Apply Database Migrations
```bash
dotnet ef database update
```

### 4. Run the Application
```bash
dotnet run
```

### 5. Access the Application
Navigate to `https://localhost:5001` in your web browser.

## 🔐 Default Credentials

**Admin Account**
- **Email:** `Admin@gmail.com`
- **Password:** `Admin@123`

> ⚠️ **Important:** Change the default admin credentials after first login for security.

## 📁 Project Structure

```
EmployeeAttendance/
├── Areas/
│   └── Identity/              # Identity UI pages (login, register, etc.)
├── Controllers/
│   ├── AttendanceController.cs    # Attendance management
│   ├── EmployeeController.cs      # Employee CRUD operations
│   └── HomeController.cs          # Dashboard and home pages
├── Data/
│   ├── ApplicationDbContext.cs    # EF Core database context
│   └── Migrations/                # Database migration files
├── Models/
│   ├── Employee.cs                # Employee entity model
│   ├── Attendance.cs              # Attendance entity model
│   └── ViewModels/                # View model classes
├── Views/
│   ├── Employee/                  # Employee management views
│   ├── Attendance/                # Attendance tracking views
│   └── Shared/                    # Shared layouts and partials
├── wwwroot/
│   ├── css/                       # Custom stylesheets
│   ├── js/                        # JavaScript files
│   └── lib/                       # Third-party libraries
├── Program.cs                     # Application entry point
├── appsettings.json              # Configuration settings
└── README.md                     # This file
```

## 👥 User Roles & Permissions

### Admin Users
- ✅ Create, edit, and delete employee records
- ✅ Mark attendance for all employees
- ✅ View comprehensive attendance reports
- ✅ Manage system settings
- ✅ Access admin dashboard

### Employee Users
- ✅ View personal profile information
- ✅ View personal attendance history
- ✅ Update basic profile details
- ❌ Cannot access other employees' data
- ❌ Cannot mark attendance for others

## 🔧 Configuration

### Database Configuration
The application supports both SQL Server and SQLite. Configure your preferred database in `appsettings.json`:

**SQL Server (Production):**
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your-server;Database=EmployeeAttendanceDB;Trusted_Connection=true;"
}
```

**SQLite (Development):**
```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=employeeattendance.db"
}
```

### Identity Configuration
Customize password requirements and lockout settings in `Program.cs`:

```csharp
services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Lockout.MaxFailedAccessAttempts = 5;
});
```

## 🚀 Deployment

### IIS Deployment
1. Publish the application:
```bash
dotnet publish -c Release -o ./publish
```

2. Configure IIS with the published files
3. Update connection strings for production database

### Docker Deployment
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "EmployeeAttendance.dll"]
```


## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Support

If you encounter any issues or have questions:

- Create an [Issue](https://github.com/your-username/employee-attendance-system/issues)
- Email: support@yourcompany.com
- Documentation: [Wiki](https://github.com/your-username/employee-attendance-system/wiki)



**Made with ❤️ using ASP.NET Core**
