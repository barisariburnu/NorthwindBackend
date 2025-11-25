# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Initial open-source release
- Comprehensive README with setup instructions
- CONTRIBUTING guidelines
- CHANGELOG for tracking project changes
- Configurable database connection string via appsettings.json
- Configurable CORS origins via appsettings.json
- English message localization

### Changed
- Converted hardcoded values to configuration-based settings
- Updated Turkish messages to English for international accessibility
- Improved project documentation for open-source community

### Fixed
- Turkish character encoding issues in message constants
- Static path configurations made dynamic

## [1.0.0] - 2025-11-25

### Added
- Core Web API implementation with JWT authentication
- Entity Framework Core integration with SQL Server
- Clean Architecture implementation (Core, Business, DataAccess, Entities, WebAPI layers)
- Autofac dependency injection
- FluentValidation for input validation
- Aspect-Oriented Programming with custom aspects
- Category and Product CRUD operations
- User authentication and authorization system
- Role-based access control with Operation Claims
