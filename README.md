# Boca de Drogas API

A RESTful API built with ASP.NET Core for managing customers, products, and sales transactions.

This project was developed as a backend learning exercise focused on C#, Entity Framework Core, database relationships, business rules, and REST API development.

## Technologies

* ASP.NET Core
* C#
* Entity Framework Core
* SQLite
* Swagger / OpenAPI

## Features

### Customers

* Create customers
* List all customers
* Get customer by ID
* Update customer information
* Delete customers

### Products

* Create products
* List all products
* Get product by ID
* Update product information
* Delete products

### Sales

* Register sales
* List all sales
* Get sale by ID

## Business Rules

When a sale is created:

* The customer must exist
* The product must exist
* The available stock must be sufficient
* The total sale value is calculated automatically
* Product stock is updated automatically
* Customer debt is updated automatically

## Project Structure

```text
Controllers/
├── ConsumidorController.cs
├── DrogaController.cs
└── VendaController.cs

Data/
└── AppDbContext.cs

Models/
├── Consumidor.cs
├── Droga.cs
└── Venda.cs
```

## Database

This project uses SQLite as its database provider.

### Create a Migration

```bash
dotnet ef migrations add InitialCreate
```

### Apply Migrations

```bash
dotnet ef database update
```

### Run the Application

```bash
dotnet run
```

## API Documentation

Swagger is enabled by default.

After starting the application, open:

```text
http://localhost:5147/swagger
```

Swagger provides an interactive interface for testing all available endpoints.

## Example Sale Request

### Request

```json
{
  "consumidorId": 1,
  "drogaId": 1,
  "quantidade": 2
}
```

### Response

```json
{
  "message": "Sale completed successfully!"
}
```

## Entity Relationship

```text
Customer (1)
     |
     |
     v
Sale (N)
     ^
     |
     |
Product (1)
```

## Concepts Practiced

* RESTful API Design
* Dependency Injection
* Entity Framework Core
* Database Relationships
* CRUD Operations
* Business Logic Implementation
* Database Migrations
* JSON Serialization
* Swagger/OpenAPI
* Asynchronous Programming

## Future Improvements

* JWT Authentication and Authorization
* DTO Pattern
* AutoMapper Integration
* Repository Pattern
* Unit Testing
* Docker Support
* MySQL/PostgreSQL Support
* Pagination and Filtering
* Logging and Monitoring

## Purpose

This project was created to practice backend development with ASP.NET Core and Entity Framework Core while implementing real-world business logic and database relationships.

## Team

Gustavo Medina, Henrique Funes, Pedro Tomazi, Tales Mácola.
