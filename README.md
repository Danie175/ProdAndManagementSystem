# Production & Management System

A comprehensive WPF-based enterprise application designed to streamline and automate concrete batching industry operations. This system provides complete workflow management from customer order intake to final batch production and delivery.

## 📋 Project Overview

The Production & Management System is a robust desktop application that digitizes and simplifies the flow of production data in concrete batching operations. The system integrates various core modules including:

## 🛠️ Technologies Used

- **Frontend**: C# with WPF (.NET Core/Framework)
- **Backend**: Entity Framework Core (Code-First approach)
- **Database**: Microsoft SQL Server (LocalDB/Express/Full)
- **UI Framework**: XAML with custom styling and MVVM pattern
- **Development Environment**: Visual Studio 2022 or later
- **Query Technology**: LINQ for data operations
- **Architecture**: Layered architecture with dependency injection

## 📦 Installation Instructions

### Prerequisites

Ensure you have the following software installed:

1. **Visual Studio 2022** (Community, Professional, or Enterprise)
   - Workloads: ".NET desktop development" and "Data storage and processing"
2. **.NET 8 SDK** or later
3. **Microsoft SQL Server** (LocalDB, Express, or Full version)
4. **SQL Server Management Studio (SSMS)** - Optional but recommended

### Step-by-Step Setup

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/production-management-system.git
   cd production-management-system
   ```

2. **Open the Solution**
   - Launch Visual Studio 2022
   - Open `ProdAndManagementSystem.sln`

3. **Configure Database Connection**
   
   Update the connection string in `appsettings.json` or `App.config`:
   
   **For LocalDB:**
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=SQLEXPRESS;Trusted_Connection=true;TrustServerCertificate=true;"
     }
   }
   ```
   
   **For SQL Server Express:**
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.\\SQLEXPRESS;Database=SQLEXPRESS;Integrated Security=true;TrustServerCertificate=true;"
     }
   }
   ```
   
   **For SQL Server with Authentication:**
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=your-server;Database=SQLEXPRESS;User Id=your-username;Password=your-password;TrustServerCertificate=true;"
     }
   }
   ```

4. **Database Setup**
   
   **Option A: Using Entity Framework Migrations**
   ```bash
   # Open Package Manager Console in Visual Studio
   # Run the following commands:
   
   Add-Migration InitialCreate
   Update-Database
   ```
   
   **Option B: Manual Database Creation**
   - Open SQL Server Management Studio (SSMS)
   - Connect to your SQL Server instance
   - Create a new database named `SQLEXPRESS`
   - Run the provided SQL scripts (if available) or let EF Core create the schema

5. **Restore NuGet Packages**
   ```bash
   # In Package Manager Console
   Update-Package -reinstall
   ```

## 🚀 How to Run the Application

### Running from Visual Studio

1. **Set Startup Project**
   - Right-click on the main project in Solution Explorer
   - Select "Set as StartUp Project"

2. **Build the Solution**
   - Press `Ctrl + Shift + B` or go to Build → Build Solution
   - Ensure no compilation errors

3. **Run the Application**
   - Press `F5` or click the "Start" button
   - The WPF application window should launch

### Running from Command Line

```bash
# Navigate to the project directory
cd ProdAndManagementSystem

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
```

### Common Startup Issues

- **Connection String Error**: Verify SQL Server is running and connection string is correct
- **Migration Error**: Run `Update-Database` in Package Manager Console
- **Missing Dependencies**: Run `dotnet restore` or update NuGet packages
- **Port Conflicts**: Ensure SQL Server default ports (1433) are available

## 📊 Modules & Features

### 1. **Dashboard Module**
- Central control panel with navigation tiles
- Real-time metrics display (customers, orders, batches)
- Quick access to all system modules
- System status indicators

### 2. **Customer Management (`CustomerView.xaml`)**
- **CRUD Operations**: Create, Read, Update, Delete customer records
- **Data Fields**: Customer ID, Name, Address, Contact, GST Number
- **Features**: 
  - Auto-generated unique Code IDs
  - Advanced search and filtering
  - Data validation and duplicate prevention
  - Export and print capabilities

### 3. **Order Management (`OrderView.xaml`)**
- **Order Processing**: Complete order lifecycle management
- **Integration**: Links customers, sites, recipes, and suppliers
- **Features**:
  - Order status tracking
  - Priority management
  - Date range filtering
  - Delivery scheduling

### 4. **Material Management (`MaterialView.xaml`)**
- **Inventory Control**: Real-time stock tracking
- **Transaction Logging**: IN/OUT material movements
- **Features**:
  - Material master data management
  - Supplier integration
  - Cost tracking and analytics
  - Automated reorder notifications

### 5. **Recipe Management (`RecipeView.xaml`)**
- **Mix Design**: Digital concrete formulation
- **Composition Control**: Aggregate and cement ratios
- **Features**:
  - Recipe templates
  - Quality consistency
  - Version control
  - Performance analytics

### 6. **Batch Management (`BatchView.xaml`)**
- **Production Tracking**: Real-time batch monitoring
- **Traceability**: Complete production audit trail
- **Features**:
  - Batch numbering system
  - Quality control checkpoints
  - Production scheduling
  - Delivery coordination

### 7. **Transport Management (`TransportView.xaml`)**
- **Vehicle Registration**: Fleet management
- **Driver Assignment**: Resource allocation
- **Features**:
  - Vehicle-driver linking
  - Contact management
  - Compliance tracking
  - Route optimization

### 8. **Site Management (`SiteView.xaml`)**
- **Location Management**: Multi-site operations
- **Site Configuration**: Address and contact details
- **Features**:
  - Site-specific settings
  - Geographic tracking
  - Operational status
  - Resource allocation

### 9. **Supplier Management (`SupplierView.xaml`)**
- **Vendor Management**: Complete supplier lifecycle
- **Procurement Integration**: Material sourcing
- **Features**:
  - GST compliance tracking
  - Performance monitoring
  - Contract management
  - Quality assessments

## 📚 Required Modules Installation

### Core NuGet Packages

Install the following packages via Package Manager Console:

```powershell
# Entity Framework Core
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools

# Additional EF Core packages
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Proxies

# Configuration
Install-Package Microsoft.Extensions.Configuration
Install-Package Microsoft.Extensions.Configuration.Json

# Dependency Injection
Install-Package Microsoft.Extensions.DependencyInjection
Install-Package Microsoft.Extensions.Hosting

# Logging
Install-Package Microsoft.Extensions.Logging
Install-Package Microsoft.Extensions.Logging.Console
```

### Manual Package Installation

If you prefer installing via NuGet Package Manager UI:

1. Right-click on the project → "Manage NuGet Packages"
2. Go to "Browse" tab
3. Search and install each package listed above
4. Ensure "Include prerelease" is unchecked for stable versions

### Package Versions Compatibility

```xml
<!-- Example PackageReference entries for .csproj file -->
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
```

## 🔗 SQL Server Configuration

### SQL Server Authentication

#### Windows Authentication (Recommended for Development)
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=SQLEXPRESS;Integrated Security=true;TrustServerCertificate=true;"
  }
}
```

#### SQL Server Authentication
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=SQLEXPRESS;User Id=sa;Password=YourPassword123;TrustServerCertificate=true;"
  }
}
```

### Trust Server Certificates

For development environments, add `TrustServerCertificate=true` to bypass SSL certificate validation:

```csharp
// In DbContext configuration
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer(connectionString, options =>
    {
        options.EnableRetryOnFailure();
        options.TrustServerCertificate();
    });
}
```

### Connection String Components

| Parameter | Description | Example |
|-----------|-------------|---------|
| `Server` | SQL Server instance | `.\\SQLEXPRESS`, `localhost`, `(localdb)\\MSSQLLocalDB` |
| `Database` | Database name | `SQLEXPRESS`, `ProductionDB` |
| `Integrated Security` | Windows Authentication | `true`, `SSPI` |
| `User Id` | SQL Login username | `sa`, `dbuser` |
| `Password` | SQL Login password | `YourPassword123` |
| `TrustServerCertificate` | Bypass SSL validation | `true` (development only) |
| `Encrypt` | Enable encryption | `false` (for local development) |

## 🔧 Development Notes

### MVVM Pattern Implementation
The application follows the Model-View-ViewModel pattern:
- **Models**: Entity classes representing database tables
- **Views**: XAML files with UI layouts
- **ViewModels**: Business logic and data binding (if implemented)

### Data Binding Examples
```csharp
// Loading data to DataGrid
private void LoadData()
{
    using (JustDbContext context = new JustDbContext())
    {
        var customers = context.Customers.ToList();
        dgCustomers.ItemsSource = customers;
    }
}
```

### LINQ Query Patterns
```csharp
// Customer search functionality
var results = context.Customers.Where(c =>
    (!string.IsNullOrEmpty(c.Customername) && c.Customername.Contains(searchTerm)) ||
    (!string.IsNullOrEmpty(c.Customernumber) && c.Customernumber.Contains(searchTerm))
).ToList();
```

## 📄 License

This project is part of an academic internship program and is intended for educational and industrial training purposes.

## 👨‍💻 Developer Information

**Student**: Lloyd Noronha  
**SRN**: 01fe21bar006  
**Institution**: Department of Automation & Robotics  
**Project**: Industry Internship Project - 17EARW494  
**Company**: Sprint Consys Pvt. Ltd.

## 🤝 Contributing

This is an internship project. For suggestions or improvements, please contact the development team or create an issue in the repository.

## 📞 Support

For technical support or questions:
- Email: lloyd.noronha11@gmail.com
- Phone: +91 8792568060

---

*This Production & Management System represents a foundational step toward smarter, more connected industrial management, serving as a platform for future enhancements including analytics, cloud integration, and IoT connectivity.*
