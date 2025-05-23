# E-Commerce Web API

A robust E-commerce Web API built with ASP.NET Core, featuring secure authentication, product management, order processing, and more.

## Features

### Authentication & Authorization
- JWT-based authentication
- Secure cookie-based token storage
- User registration and login
- Email confirmation for new accounts
- Password reset functionality
- Role-based authorization

### Product Management
- Product CRUD operations
- Category management
- Product image handling
- Product search and filtering
- Pagination support

### Shopping Features
- Shopping cart functionality
- Order processing
- Order history
- Customer basket management using Redis

### Security
- CORS configuration
- HTTPS enforcement
- Secure cookie settings
- Rate limiting
- Exception handling middleware

## Technology Stack

- **Backend Framework**: ASP.NET Core 9.0
- **Database**: SQL Server
- **Caching**: Redis
- **Authentication**: JWT + Cookie-based
- **Email Service**: SMTP (Gmail)
- **Image Processing**: Custom image management service
- **API Documentation**: Swagger/OpenAPI

## Project Structure

```
Ecom/
├── Ecom.API/                 # Web API project
│   ├── Controllers/         # API endpoints
│   ├── Middleware/          # Custom middleware
│   └── Helper/              # Helper classes
├── Ecom.Core/               # Core business logic
│   ├── DTOs/               # Data transfer objects
│   ├── Entities/           # Domain models
│   ├── Interfaces/         # Repository interfaces
│   └── Services/           # Service interfaces
└── Ecom.Infrastructure/     # Data access and external services
    ├── Data/               # Database context
    ├── Repositories/       # Repository implementations
    └── Services/           # Service implementations
```

## Setup Instructions

### Prerequisites
- .NET 9.0 SDK
- SQL Server
- Redis Server
- SMTP Server (Gmail used in this project)

### Configuration
1. Update `appsettings.json` with your settings:
   ```json
   {
     "ConnectionStrings": {
       "EcomDB": "Your_SQL_Server_Connection_String",
       "redis": "localhost"
     },
     "EmailSetting": {
       "Port": 465,
       "From": "your-email@gmail.com",
       "UserName": "your-email@gmail.com",
       "Password": "your-app-password",
       "Smtp": "smtp.gmail.com"
     },
     "Token": {
       "Secret": "your-secret-key",
       "Issure": "https://localhost:44306/"
     }
   }
   ```

### Running the Project
1. Clone the repository
2. Update the connection strings in `appsettings.json`
3. Run the following commands:
   ```bash
   dotnet restore
   dotnet build
   dotnet run --project Ecom.API
   ```

## API Endpoints

### Authentication
- `POST /api/Account/Register` - Register new user
- `POST /api/Account/Login` - User login
- `POST /api/Account/active-account` - Activate account
- `GET /api/Account/send-email-forget-password` - Request password reset
- `POST /api/Account/reset-password` - Reset password

### Products
- `GET /api/Product/get-all` - Get all products (with pagination)
- `GET /api/Product/get-by-id/{id}` - Get product by ID
- `POST /api/Product/Add-Product` - Add new product

### Orders
- `POST /api/Order/create-order` - Create new order

## Security Considerations

### CORS Configuration
The API is configured to accept requests from:
- http://localhost:4200 (Angular app)
- http://127.0.0.1:5500 (Development server)

### Cookie Settings
- Secure: true
- HttpOnly: true
- SameSite: Strict
- Domain: localhost
- Expires: 1 day

## Error Handling
The API uses a custom exception middleware that:
- Handles all unhandled exceptions
- Returns appropriate HTTP status codes
- Provides detailed error messages in development
- Sanitizes error messages in production

## Rate Limiting
The API implements rate limiting to prevent abuse:
- 100 requests per 30 seconds per IP address
- Customizable through configuration

## Contributing
1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License
This project is licensed under the MIT License - see the LICENSE file for details.