# User Management API Using ASP.NET Core

## Project Overview

The User Management API is a RESTful web application developed using C# and ASP.NET Core. It provides functionality for creating, retrieving, updating, and deleting user information.

The project demonstrates backend development concepts, REST API design, data validation, middleware implementation, and debugging with GitHub Copilot.

## Project Objectives

- Develop a functional RESTful API.
- Implement CRUD operations for managing users.
- Validate user information before processing requests.
- Implement middleware for logging and error handling.
- Use GitHub Copilot to assist with code development and debugging.

## Technologies Used

- C#
- ASP.NET Core Web API
- Visual Studio
- Git and GitHub
- GitHub Copilot
- Swagger / OpenAPI

## API Features

### 1. CRUD Operations

The API supports the following HTTP methods:

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/users` | Retrieve all users |
| GET | `/api/users/{id}` | Retrieve a user by ID |
| POST | `/api/users` | Create a new user |
| PUT | `/api/users/{id}` | Update an existing user |
| DELETE | `/api/users/{id}` | Delete a user |

### 2. Data Validation

The application uses validation to ensure that user information is valid before it is processed.

Examples include:
- Required name fields.
- Valid email addresses.
- Appropriate validation for submitted user information.

### 3. Middleware Implementation

Middleware improves the API request-processing pipeline.

The project includes:
- Logging middleware to record incoming requests.
- Error-handling middleware to manage unexpected application errors.

### 4. GitHub Copilot Debugging

GitHub Copilot is used to assist with:
- Identifying coding errors.
- Suggesting code improvements.
- Debugging API functionality.
- Improving code readability.

*Add screenshots or examples showing your actual Copilot debugging process.*

## Getting Started

### Prerequisites

Install the following:
- .NET SDK
- Visual Studio or Visual Studio Code
- Git

### Installation

1. Clone the repository:

   ```bash
   git clone YOUR_GITHUB_REPOSITORY_URL
  
