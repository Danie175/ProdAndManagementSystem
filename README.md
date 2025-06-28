# Production & Management System

A comprehensive enterprise-level WPF application designed to streamline and automate concrete batching industry operations. This system manages the complete workflow from customer order intake to final batch production and delivery, providing real-time operational visibility and data integrity.

## 🎯 Project Overview

The Production & Management System is a robust Windows desktop application that addresses critical needs in concrete manufacturing facilities. It provides efficient management of:

- **Customer Relationship Management** - Complete customer data with GST compliance
- **Order Processing** - From intake to fulfillment tracking
- **Material Inventory** - Real-time stock levels and transaction history
- **Recipe Management** - Concrete mix formulations and compositions
- **Supplier Coordination** - Vendor management and procurement tracking
- **Batch Production** - Complete production workflow and dispatch management
- **Transport Management** - Vehicle and driver assignment tracking
- **Site Management** - Multiple location operations support

### Key Features

- 🖥️ **Modern WPF Interface** - Card-based layout with intuitive navigation
- 🗄️ **Robust Data Persistence** - SQL Server with Entity Framework Core
- 🔄 **Complete CRUD Operations** - Full create, read, update, delete functionality
- 📊 **Real-time Dashboard** - Live operational metrics and KPIs
- 🔍 **Advanced Search & Filtering** - Multi-field search capabilities
- 📈 **Scalable Architecture** - Modular design for future enhancements
- ✅ **Data Validation** - Client and server-side validation strategies
- 🔒 **Transaction Management** - ACID compliance for data integrity

## 🛠️ Technologies Used

- **Frontend**: C# WPF (.NET 8) with XAML
- **Backend**: Entity Framework Core 8.0
- **Database**: Microsoft SQL Server (LocalDB/Express/Full)
- **Architecture**: MVVM Pattern with Repository Pattern
- **Query Language**: LINQ with Method & Query Syntax
- **IDE**: Visual Studio 2022 or later
- **Additional**: Windows Presentation Foundation (WPF), Fluent API Configuration

## 📋 Prerequisites

Before running the application, ensure you have:

- **Visual Studio 2022** or later with WPF workload
- **.NET 8 SDK** or later
- **SQL Server** (LocalDB, Express, or Full edition)
- **SQL Server Management Studio (SSMS)** - Optional but recommended
- **Windows 10/11** operating system

## 🚀 Installation Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/ProductionManagementSystem.git
cd ProductionManagementSystem
```

### 2. Configure Database Connection

Open `appsettings.json` or locate the connection string in your DbContext configuration:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ProductionManagementDB;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

**For SQL Server Express:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=ProductionManagementDB;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

**For Full SQL Server:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ProductionManagementDB;Integrated Security=true;MultipleActiveResultSets=true"
  }
}
```

### 3. Apply Entity Framework Migrations

Open **Package Manager Console** in Visual Studio or use Command Line:

```bash
# Via Package Manager Console
Update-Database

# Via Command Line (.NET CLI)
dotnet ef database update
```

### 4. Create Database Manually (Alternative)

If you prefer creating the database manually:

1. Open **SQL Server Management Studio (SSMS)**
2. Connect to your SQL Server instance
3. Create a new database named `ProductionManagementDB`
4. Run the migration command above

## ▶️ How to Run the Application

### Via Visual Studio
1. Open `ProductionManagementSystem.sln` in Visual Studio 2022
2. Set the WPF project as the startup project
3. Build the solution (`Ctrl + Shift + B`)
4. Run the application (`F5` or `Ctrl + F5`)

### Via Command Line
```bash
dotnet build
dotnet run
```

### First Launch
- The application will start with the **Dashboard** as the main screen
- Navigate through different modules using the card-based navigation tiles
- The database will be automatically created if it doesn't exist (with migrations applied)

## 📋 Modules & Features

### 🏠 Dashboard
- **Real-time Metrics**: Customer count, recent orders, material status
- **Quick Navigation**: Direct access to all system modules
- **Activity Notifications**: Recent orders and batch production updates

### 👥 Customer Management (`CustomerView.xaml`)
- **CRUD Operations**: Add, view, edit, delete customer records
- **Data Fields**: Customer ID, Name, Address, Phone, GST Number
- **Search Functionality**: Multi-field search across customer data
- **Validation**: Real-time form validation and duplicate prevention

### 📦 Order Management
- **Order Processing**: Complete order lifecycle management
- **Filtering System**: By customer, site, recipe, date range
- **Integration**: Links customers, sites, recipes, and suppliers
- **Export/Print**: Generate reports and documentation

### 🏭 Batch Management
- **Production Tracking**: Record actual batch production events
- **Dispatch Management**: Link batches to vehicles and drivers
- **Traceability**: End-to-end tracking from order to delivery
- **Quality Control**: Batch quantity and cycle data recording

### 📋 Recipe Management
- **Mix Design**: Define concrete formulations and compositions
- **Material Components**: Aggregates and cement specifications
- **Flexibility**: Support for simple and complex mix designs
- **Standardization**: Ensure consistency in batching operations

### 📊 Material Management
- **Inventory Tracking**: Real-time stock levels and movements
- **Transaction History**: Complete material IN/OUT records
- **Supplier Integration**: Track material sources and costs
- **Analytics**: Material consumption and forecasting

### 🚛 Transport Management
- **Vehicle Registration**: Complete vehicle and driver data
- **Assignment Tracking**: Link drivers to vehicles
- **Compliance**: Transport regulation adherence
- **Contact Management**: Driver communication details

### 🏢 Site Management
- **Location Management**: Multiple operational sites
- **Address Tracking**: Complete site information
- **Contact Details**: Site-specific communication
- **Search Capability**: Quick site location and retrieval

### 🏪 Supplier Management
- **Vendor Data**: Complete supplier information
- **GST Compliance**: Tax identification tracking
- **Procurement Support**: Streamlined vendor management
- **Search & Filter**: Quick supplier location

## 🔧 Customization Notes

### Adding New Views/Modules

1. **Create XAML View:**
   ```xml
   <UserControl x:Class="YourNamespace.Views.NewModuleView"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
       <!-- Your UI here -->
   </UserControl>
   ```

2. **Add Navigation Button:**
   ```xml
   <Button Content="New Module" Click="NewModule_Click" Style="{StaticResource ModuleButtonStyle}"/>
   ```

3. **Update DbContext:**
   ```csharp
   public DbSet<NewEntity> NewEntities { get; set; }
   ```

### Modifying Database Schema

1. **Update Entity Models:**
   ```csharp
   public class Customer
   {
       // Add new properties
       public string NewProperty { get; set; }
   }
   ```

2. **Create Migration:**
   ```bash
   Add-Migration AddNewPropertyToCustomer
   Update-Database
   ```

### Customizing UI Styles

Modify styles in `App.xaml` or create new resource dictionaries:
```xml
<Style x:Key="CustomButtonStyle" TargetType="Button">
    <Setter Property="Background" Value="#Your_Color"/>
    <!-- Additional styling -->
</Style>
```

## 🐛 Troubleshooting

### Common Entity Framework Issues

**IDENTITY_INSERT Error:**
```sql
-- Disable identity insert if manually setting IDs
SET IDENTITY_INSERT [TableName] ON
-- Your INSERT statements
SET IDENTITY_INSERT [TableName] OFF
```

**Migration Issues:**
```bash
# Reset migrations
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### SQL Connection Issues

**LocalDB Connection Problems:**
1. Verify LocalDB is installed: `sqllocaldb info`
2. Start LocalDB instance: `sqllocaldb start MSSQLLocalDB`
3. Check connection string format

**SQL Server Authentication:**
```json
"Server=server_name;Database=db_name;User Id=username;Password=password;"
```

**Trust Server Certificate (for newer SQL Server):**
```json
"Server=server_name;Database=db_name;Trusted_Connection=true;TrustServerCertificate=true;"
```

### Application Startup Issues

**Missing Dependencies:**
- Ensure all NuGet packages are restored
- Verify .NET 8 runtime is installed
- Check WPF workload in Visual Studio

**Database Not Found:**
- Run `Update-Database` command
- Verify connection string points to correct server
- Check SQL Server service is running

## 🚀 Future Improvements

### Planned Enhancements
- **🌐 Web Interface**: Browser-based access for remote operations
- **📱 Mobile App**: Field operations support for delivery tracking
- **☁️ Cloud Integration**: Azure/AWS deployment options
- **🤖 Analytics & AI**: Predictive modeling for demand forecasting
- **🔐 Advanced Security**: Role-based access control and audit trails
- **📊 Advanced Reporting**: Crystal Reports or Power BI integration
- **🔄 API Development**: REST API for external system integration
- **📡 IoT Connectivity**: Real-time equipment monitoring

### Technical Improvements
- **Unit Testing**: Comprehensive test coverage
- **CI/CD Pipeline**: Automated deployment workflows
- **Performance Optimization**: Query optimization and caching
- **Microservices Architecture**: Service decomposition for scalability
- **Event-Driven Architecture**: Real-time notifications and updates

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Developer

**Lloyd Noronha**  
  
Email: lloyd.noronha11@gmail.com  

---
