# NorthwindBackend

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
[![.NET Core](https://img.shields.io/badge/.NET%20Core-3.1+-purple.svg)](https://dotnet.microsoft.com/download)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](CONTRIBUTING.md)

A production-ready RESTful Web API built with .NET Core, demonstrating Clean Architecture principles and enterprise-level development patterns using the classic Northwind database.

## 🌟 Features

- **Clean Architecture**: Separation of concerns with distinct layers (Core, Business, DataAccess, Entities, WebAPI)
- **JWT Authentication**: Secure token-based authentication and authorization
- **Role-Based Access Control**: Fine-grained permission management with operation claims
- **Aspect-Oriented Programming**: Cross-cutting concerns handled elegantly with custom aspects
- **FluentValidation**: Robust input validation
- **Autofac Integration**: Advanced dependency injection container
- **Entity Framework Core**: Modern ORM with SQL Server support
- **Repository Pattern**: Abstraction over data access layer
- **CORS Support**: Configurable cross-origin resource sharing
- **Comprehensive Logging**: Built-in logging with log4net

## 📋 Prerequisites

Before you begin, ensure you have the following installed:

- [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet/3.1) or later
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) or SQL Server LocalDB
- [Visual Studio 2019+](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/barisariburnu/NorthwindBackend.git
cd NorthwindBackend
```

### 2. Configure Database Connection

Update the connection string in `WebAPI/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=true"
  }
}
```

For production, use environment-specific configuration files:
- `appsettings.development.json` - Development environment
- `appsettings.production.json` - Production environment

### 3. Configure Application Settings

Update `WebAPI/appsettings.json` with your settings:

```json
{
  "TokenOptions": {
    "Audience": "yourdomain.com",
    "Issuer": "yourdomain.com",
    "AccessTokenExpiration": 10,
    "SecurityKey": "your-very-secure-secret-key-min-16-characters"
  },
  "CorsOrigins": ["http://localhost:3000", "https://yourdomain.com"]
}
```

⚠️ **Security Note**: Never commit sensitive keys to version control. Use environment variables or secure key vaults in production.

### 4. Set Up the Northwind Database

You can download the Northwind database script from Microsoft's official samples:
- [Northwind Database for SQL Server](https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs)

Run the SQL script to create the database, then add the authentication tables by running migrations or creating them manually (see [Database Schema](#database-schema)).

### 5. Build the Solution

```bash
dotnet build
```

### 6. Run the Application

```bash
dotnet run --project WebAPI
```

The API will be available at:
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`

## 📚 Project Structure

```
NorthwindBackend/
├── Core/                          # Core layer with shared utilities
│   ├── Aspects/                   # AOP aspects (caching, validation, etc.)
│   ├── CrossCuttingConcerns/      # Logging, caching, validation
│   ├── DataAccess/                # Generic repository base classes
│   ├── DependencyResolvers/       # Core module dependencies
│   ├── Entities/                  # Base entity classes
│   ├── Extensions/                # Extension methods
│   └── Utilities/                 # Helper utilities (JWT, IoC, etc.)
│
├── Entities/                      # Domain entities and DTOs
│   ├── Concrete/                  # Domain entities (Product, Category, User)
│   └── Dtos/                      # Data Transfer Objects
│
├── DataAccess/                    # Data access layer
│   ├── Abstract/                  # Repository interfaces
│   └── Concrete/
│       └── EntityFramework/       # EF Core implementations
│           ├── Contexts/          # DbContext
│           └── Ef*.Dal.cs         # Repository implementations
│
├── Business/                      # Business logic layer
│   ├── Abstract/                  # Service interfaces
│   ├── Concrete/                  # Service implementations
│   ├── BusinessAspects/           # Business-specific aspects
│   ├── Constants/                 # Business constants and messages
│   ├── DependencyResolvers/       # Autofac modules
│   └── ValidationRules/           # FluentValidation validators
│
└── WebAPI/                        # Presentation layer
    ├── Controllers/               # API controllers
    ├── appsettings.json          # Configuration
    ├── Program.cs                # Application entry point
    └── Startup.cs                # Service configuration
```

## 🔧 Configuration

### Database Connection

The database connection can be configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=Northwind;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
  }
}
```

### CORS Configuration

Configure allowed origins in `appsettings.json` and update `Startup.cs`:

```json
{
  "CorsOrigins": [
    "http://localhost:3000",
    "https://yourfrontend.com"
  ]
}
```

```csharp
// In Startup.cs
var corsOrigins = Configuration.GetSection("CorsOrigins").Get<string[]>();
services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", 
        builder => builder.WithOrigins(corsOrigins)
                         .AllowAnyHeader()
                         .AllowAnyMethod());
});
```

### JWT Configuration

JWT settings in `appsettings.json`:

```json
{
  "TokenOptions": {
    "Audience": "yourdomain.com",
    "Issuer": "yourdomain.com",
    "AccessTokenExpiration": 10,
    "SecurityKey": "your-secret-key-must-be-at-least-16-characters"
  }
}
```

## 🔐 Authentication & Authorization

### Register a New User

```http
POST /api/auth/register
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "SecurePassword123",
  "firstName": "John",
  "lastName": "Doe"
}
```

### Login

```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "SecurePassword123"
}
```

Response:
```json
{
  "success": true,
  "message": "Login successful",
  "data": {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "expiration": "2025-11-25T12:00:00Z"
  }
}
```

### Using the Token

Include the JWT token in subsequent requests:

```http
GET /api/products
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

## 📖 API Endpoints

### Products

- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create new product (requires authentication)
- `PUT /api/products` - Update product (requires authentication)
- `DELETE /api/products/{id}` - Delete product (requires authentication)

### Categories

- `GET /api/categories` - Get all categories
- `GET /api/categories/{id}` - Get category by ID
- `POST /api/categories` - Create new category (requires authentication)
- `PUT /api/categories` - Update category (requires authentication)
- `DELETE /api/categories/{id}` - Delete category (requires authentication)

### Authentication

- `POST /api/auth/register` - Register new user
- `POST /api/auth/login` - User login

## 🏗️ Architecture Patterns

### Clean Architecture

The project follows clean architecture principles with clear separation of concerns:

1. **Core Layer**: Contains abstractions and shared utilities
2. **Entities Layer**: Domain models and DTOs
3. **DataAccess Layer**: Repository pattern implementation
4. **Business Layer**: Business logic and validation
5. **WebAPI Layer**: Controllers and API configuration

### Aspect-Oriented Programming (AOP)

Cross-cutting concerns are handled using aspects:

- **Validation Aspect**: Validates input using FluentValidation
- **Caching Aspect**: Implements caching strategies
- **Transaction Aspect**: Manages database transactions
- **Performance Aspect**: Monitors method execution time
- **Authorization Aspect**: Enforces security policies

### Dependency Injection

The project uses Autofac for advanced dependency injection:

```csharp
public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductManager>().As<IProductService>();
        builder.RegisterType<EfProductDal>().As<IProductDal>();
        // ... other registrations
    }
}
```

## 🗄️ Database Schema

### Core Tables

- **Products**: Product catalog
- **Categories**: Product categories
- **Users**: Application users
- **OperationClaims**: Available permissions/roles
- **UserOperationClaims**: User-role mappings

## 🧪 Testing

Run tests using:

```bash
dotnet test
```

## 📦 Deployment

### Docker (Coming Soon)

A Dockerfile will be provided for containerized deployment.

### IIS Deployment

1. Publish the application:
   ```bash
   dotnet publish -c Release -o ./publish
   ```

2. Configure IIS to host the published application

3. Ensure the application pool uses .NET Core runtime

### Azure App Service

The application can be deployed to Azure App Service:

1. Create an Azure App Service
2. Configure connection strings in Application Settings
3. Deploy using Visual Studio, Azure DevOps, or GitHub Actions

## 🤝 Contributing

Contributions are welcome! Please read our [Contributing Guidelines](CONTRIBUTING.md) for details on our code of conduct and the process for submitting pull requests.

## 📝 License

This project is licensed under the GNU General Public License v3.0 - see the [LICENSE](LICENSE) file for details.

## 👤 Author

**Barış Arıburnu**
- GitHub: [@barisariburnu](https://github.com/barisariburnu)
- Website: [www.barisariburnu.com](https://www.barisariburnu.com)

## 🙏 Acknowledgments

- Microsoft's Northwind Database for the sample data model
- The .NET Core community for excellent tooling and libraries
- All contributors who help improve this project

## 📞 Support

If you have any questions or need help, please:
- Open an issue on GitHub
- Check existing issues for solutions
- Read the [Contributing Guidelines](CONTRIBUTING.md)

## 🗺️ Roadmap

- [ ] Add Docker support
- [ ] Implement integration tests
- [ ] Add API documentation with Swagger/OpenAPI
- [ ] Implement CQRS pattern
- [ ] Add health check endpoints
- [ ] Implement rate limiting
- [ ] Add response caching
- [ ] Implement API versioning
- [ ] Add GraphQL support

---

**Note**: This is a demonstration project showcasing enterprise architecture patterns. For production use, ensure you implement additional security measures, comprehensive testing, and monitoring.
