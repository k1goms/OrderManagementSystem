# 🍔 Order Management System

A console-based order management system built with **C# .NET**, designed with a layered architecture inspired by real-world REST APIs.

---

## 📋 About

This project simulates a restaurant order management system where you can manage products (menu items) and customer orders. It was built as a study project to practice **Object-Oriented Programming**, **SOLID principles**, and **clean architecture** patterns in C#.

---

## 🏗️ Architecture

The project follows a layered architecture separating concerns across distinct layers:

```
Program.cs          → Composition root, starts the application
UI/Menu.cs          → User interface, reads input and displays output
Services/           → Business logic and validations
Repositories/       → Data access (in-memory lists)
Models/             → Domain entities
DTOs/               → Data Transfer Objects (records)
Enums/              → Fixed named values
SampleData/         → Seed data for initial products
```

### Flow

```
Program.cs → Menu → creates DTO
  → Service validates → instantiates Model
    → Repository saves to list
      → Service returns ResponseDto
        → Menu displays to user
```

---

## 📁 Project Structure

```
OrderManagementSystem/
├── DTOs/
│   ├── CreateProductDto.cs
│   ├── ProductResponseDto.cs
│   ├── CreateOrderDto.cs
│   ├── CreateOrderItemDto.cs
│   └── OrderResponseDto.cs
├── Enums/
│   ├── ProductCategory.cs
│   └── OrderStatus.cs
├── Models/
│   ├── Product.cs
│   ├── Order.cs
│   └── OrderItem.cs
├── Repositories/
│   ├── IProductRepository.cs
│   ├── ProductRepository.cs
│   ├── IOrderRepository.cs
│   └── OrderRepository.cs
├── Services/
│   ├── ProductService.cs
│   └── OrderService.cs
├── SampleData/
│   └── SampleProducts.cs
├── UI/
│   └── Menu.cs
└── Program.cs
```

---

## ✨ Features

### Products
- List all products
- Add a new product with name, price and category
- Remove a product by ID

### Orders
- List all orders with items and total
- Create a new order with customer name
- Add items to an existing order
- Update order status
- Cancel an order

---

## 🔄 Order Status Flow

```
Pending → Preparing → Ready → Delivered
                                  ↑
                              (cannot change after this)

Any status → Cancelled (except Delivered)
```

---

## 🗂️ Enums

**ProductCategory**
- `Drink`
- `Snack`
- `Dessert`
- `Combo`

**OrderStatus**
- `Pending`
- `Preparing`
- `Ready`
- `Delivered`
- `Cancelled`

---

## 🧱 Design Patterns & Principles

- **Repository Pattern** — isolates data access from business logic
- **Service Layer** — centralizes business rules and validations
- **DTO Pattern** — separates input/output data from domain models
- **Dependency Injection** — services receive repositories through constructors
- **Interface Segregation** — services depend on interfaces, not concrete classes
- **Single Responsibility** — each class has one clear purpose
- **DRY** — `ToDto()` and `PrintProduct()` helper methods avoid repetition

---

## 🚀 Getting Started

### Requirements
- [.NET 6+](https://dotnet.microsoft.com/download)

### Running the project

```bash
git clone https://github.com/k1goms/OrderManagementSystem.git
cd OrderManagementSystem
dotnet run
```

---

## 📚 Concepts Practiced

- Object-Oriented Programming (encapsulation, inheritance, polymorphism, abstraction)
- SOLID principles
- Repository and Service layer patterns
- DTO pattern with C# records
- Exception handling with specific exception types
- LINQ for collection manipulation
- Dependency injection through constructors
- Interface-based programming
