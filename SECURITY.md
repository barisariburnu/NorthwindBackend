# Security Best Practices

This document outlines important security considerations for the NorthwindBackend project.

## Configuration Security

### 1. Protect Sensitive Configuration

**Never commit sensitive data to version control!**

The following files contain sensitive information and should be handled carefully:

- `WebAPI/appsettings.json` - **CAUTION**: Contains connection strings and secret keys
- `WebAPI/appsettings.production.json` - Production-specific settings

### 2. Use Environment-Specific Configuration

For different environments, use separate configuration files:

- **Development**: `appsettings.development.json`
- **Staging**: `appsettings.staging.json`
- **Production**: `appsettings.production.json`

### 3. Configuration Template

Use `WebAPI/appsettings.example.json` as a template. Copy it to create your own `appsettings.json`:

```bash
cd WebAPI
copy appsettings.example.json appsettings.production.json
```

Then update with your actual values.

### 4. Recommended Practices

#### JWT Security Key

- **Minimum length**: 16 characters (128 bits)
- **Recommended**: 32+ characters (256 bits)
- **Generation**: Use a cryptographically secure random generator

Example using PowerShell:
```powershell
# Generate a secure random key
$bytes = New-Object byte[] 32
[System.Security.Cryptography.RandomNumberGenerator]::Create().GetBytes($bytes)
[Convert]::ToBase64String($bytes)
```

Example using C#:
```csharp
using System.Security.Cryptography;

var key = new byte[32];
using (var rng = RandomNumberGenerator.Create())
{
    rng.GetBytes(key);
}
var securityKey = Convert.ToBase64String(key);
```

#### Database Connection Strings

**Development/Testing:**
```json
"Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=true"
```

**Production with SQL Authentication:**
```json
"Server=your-server.database.windows.net;Database=Northwind;User Id=your-user;Password=your-password;Encrypt=true;"
```

**Production with Managed Identity (Azure):**
Use Azure Key Vault or Managed Identity instead of storing credentials directly.

### 5. Environment Variables

For production deployments, consider using environment variables instead of configuration files:

```csharp
// In Startup.cs or Program.cs
var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING") 
    ?? Configuration.GetConnectionString("DefaultConnection");
```

### 6. Azure Deployment

When deploying to Azure App Service:

1. Go to **Configuration** → **Application Settings**
2. Add connection strings and app settings
3. These will override values in `appsettings.json`
4. Connection strings are encrypted at rest

### 7. Docker Secrets

If using Docker, use Docker secrets or environment variables:

```yaml
# docker-compose.yml
services:
  api:
    image: northwindbackend
    environment:
      - ConnectionStrings__DefaultConnection=${DB_CONNECTION_STRING}
      - TokenOptions__SecurityKey=${JWT_SECRET_KEY}
```

### 8. .gitignore Configuration

Ensure sensitive files are in `.gitignore`:

```gitignore
# Sensitive configuration files
appsettings.production.json
appsettings.staging.json
*.secrets.json

# Environment files
.env
.env.local
.env.production
```

## Authentication & Authorization

### 1. Password Policies

Implement strong password requirements:
- Minimum 8 characters
- Mix of uppercase, lowercase, numbers, and special characters
- Password hashing with bcrypt or PBKDF2

### 2. JWT Token Expiration

- **Access Token**: Short-lived (10-15 minutes recommended)
- **Refresh Token**: Longer-lived (7-30 days)
- Implement token refresh mechanism

### 3. HTTPS Only

Always use HTTPS in production:

```csharp
// In Startup.cs
app.UseHttpsRedirection();

// Force HTTPS
services.AddHsts(options =>
{
    options.MaxAge = TimeSpan.FromDays(365);
    options.IncludeSubDomains = true;
});
```

### 4. CORS Configuration

Be specific with CORS origins in production:

```json
{
  "CorsOrigins": [
    "https://yourdomain.com",
    "https://www.yourdomain.com"
  ]
}
```

Never use `"*"` in production!

## Data Protection

### 1. SQL Injection Prevention

- Use parameterized queries (Entity Framework handles this)
- Never concatenate user input into SQL
- Validate and sanitize all input

### 2. Input Validation

- Use FluentValidation for all DTOs
- Validate on both client and server
- Implement model state validation

### 3. Output Encoding

- Entity Framework handles parameterization
- Be careful with raw SQL queries

## Monitoring & Auditing

### 1. Logging

- Log authentication attempts
- Log authorization failures
- Log sensitive operations
- **Never log passwords or tokens**

### 2. Error Handling

- Don't expose stack traces in production
- Use generic error messages for users
- Log detailed errors server-side

```csharp
// In Startup.cs
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}
```

## Dependency Security

### 1. Keep Dependencies Updated

Regularly update NuGet packages:

```bash
dotnet list package --outdated
dotnet add package <PackageName>
```

### 2. Security Scanning

Use security scanning tools:
- GitHub Dependabot
- Snyk
- OWASP Dependency Check

## Checklist for Production Deployment

- [ ] Change all default passwords and keys
- [ ] Use strong JWT secret key (32+ characters)
- [ ] Configure production connection string
- [ ] Enable HTTPS only
- [ ] Configure specific CORS origins
- [ ] Remove development error pages
- [ ] Enable logging and monitoring
- [ ] Set up database backups
- [ ] Configure rate limiting
- [ ] Enable authentication on all sensitive endpoints
- [ ] Review and test authorization rules
- [ ] Scan for security vulnerabilities
- [ ] Configure firewall rules
- [ ] Set up SSL/TLS certificates

## Reporting Security Issues

If you discover a security vulnerability, please email the maintainer directly rather than opening a public issue.

---

**Remember**: Security is an ongoing process, not a one-time setup. Regularly review and update your security practices.
