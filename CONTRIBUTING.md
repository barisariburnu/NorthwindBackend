# Contributing to NorthwindBackend

First off, thank you for considering contributing to NorthwindBackend! It's people like you that make this project better.

## Code of Conduct

This project and everyone participating in it is governed by our commitment to fostering an open and welcoming environment. Please be respectful and constructive in your interactions.

## How Can I Contribute?

### Reporting Bugs

Before creating bug reports, please check the existing issues to avoid duplicates. When you create a bug report, include as many details as possible:

- **Use a clear and descriptive title**
- **Describe the exact steps to reproduce the problem**
- **Provide specific examples to demonstrate the steps**
- **Describe the behavior you observed and what you expected**
- **Include screenshots if relevant**
- **Include your environment details** (OS, .NET version, etc.)

### Suggesting Enhancements

Enhancement suggestions are tracked as GitHub issues. When creating an enhancement suggestion:

- **Use a clear and descriptive title**
- **Provide a detailed description of the suggested enhancement**
- **Explain why this enhancement would be useful**
- **List any alternatives you've considered**

### Pull Requests

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

#### Pull Request Guidelines

- Follow the existing code style and architecture patterns
- Update documentation as needed
- Add tests for new functionality
- Ensure all tests pass
- Keep pull requests focused on a single feature or fix
- Write clear, descriptive commit messages

## Development Setup

1. **Prerequisites**
   - .NET Core SDK 3.1 or later
   - SQL Server or SQL Server LocalDB
   - Visual Studio 2019+ or Visual Studio Code
   - Git

2. **Clone the repository**
   ```bash
   git clone https://github.com/barisariburnu/NorthwindBackend.git
   cd NorthwindBackend
   ```

3. **Configure the database**
   - Update the connection string in `WebAPI/appsettings.json`
   - Run database migrations (if applicable)

4. **Build the solution**
   ```bash
   dotnet build
   ```

5. **Run the application**
   ```bash
   dotnet run --project WebAPI
   ```

## Project Structure

- **Core**: Shared utilities, cross-cutting concerns, and base classes
- **Entities**: Domain entities and DTOs
- **DataAccess**: Repository implementations and database context
- **Business**: Business logic and validation rules
- **WebAPI**: REST API controllers and configuration

## Coding Standards

- Follow C# naming conventions
- Use meaningful variable and method names
- Add XML documentation comments for public APIs
- Keep methods focused and concise
- Follow SOLID principles
- Use async/await for I/O operations

## Architecture Patterns

This project follows:
- **Clean Architecture** (N-tier architecture)
- **Repository Pattern**
- **Unit of Work Pattern**
- **Dependency Injection**
- **Aspect-Oriented Programming**

When contributing, please maintain these patterns and principles.

## Testing

- Write unit tests for business logic
- Ensure all existing tests pass before submitting PR
- Aim for meaningful test coverage

## Documentation

- Update README.md if you change functionality
- Add XML comments for new public APIs
- Update CHANGELOG.md following [Keep a Changelog](https://keepachangelog.com/) format

## Questions?

Feel free to open an issue with the `question` label or reach out to the maintainers.

Thank you for your contributions! 🎉
