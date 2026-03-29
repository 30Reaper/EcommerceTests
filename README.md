# 🛒 Ecommerce UI Automation Tests

Automated UI test suite for an eCommerce web application built with **.NET 8**, **Selenium WebDriver**, and **xUnit**.

The project demonstrates a scalable and maintainable test framework using **Page Object Model (POM)**, parallel execution, and structured logging.

---

## 📌 Overview

This repository contains end-to-end UI tests covering key user flows:

* Authentication (login)
* Product interactions (favorites)
* Product sorting

The framework is designed to follow real-world QA automation practices with focus on readability, stability, and extensibility.

---

## 🧰 Tech Stack

* **.NET 8**
* **Selenium WebDriver**
* **xUnit**
* **FluentAssertions**
* **NLog**
* **C#**

---

## 🏗️ Architecture

The project follows the **Page Object Model (POM)** pattern:

* Test logic is separated from UI interaction logic
* Each page is represented as a class
* Reusable utilities are centralized

---

## 📂 Project Structure

```text
EcommerceTests/
│
├── Core/
│   ├── BaseTest.cs                # Test setup/teardown
│   └── Driver/
│       └── DriverFactory.cs       # Thread-safe WebDriver management
│
├── Pages/
│   ├── BasePage.cs               # Common page functionality
│   ├── LoginPage.cs              # Login actions and validations
│   ├── ProductsPage.cs           # Product interactions and sorting
│   └── FavoritesPage.cs          # Favorites page logic
│
├── Tests/
│   ├── LoginTests.cs             # Negative login scenarios
│   ├── FavoritesTests.cs         # Favorites functionality
│   └── SortingTests.cs           # Sorting validation
│
├── Utilities/
│   ├── WaitHelper.cs             # Explicit waits
│   └── LoggerHelper.cs           # Logging wrapper (NLog)
│
├── Models/
│   └── UserModel.cs              # Test data models
│
└── testdata.json                 # Test data (users)
```

---

## ✅ Test Coverage

### 🔐 Login Tests

* Verify error messages for invalid credentials
* Validate authentication behavior

### ❤️ Favorites Tests

* Add products to favorites
* Verify correct number of items in Favorites page

### 📊 Sorting Tests

* Sort products by price (Low → High)
* Validate sorting order using price comparison

---

## ⚙️ Key Features

* ✔ Page Object Model (POM)
* ✔ Thread-safe WebDriver (parallel execution)
* ✔ Explicit waits (no hardcoded delays)
* ✔ Structured logging (NLog)
* ✔ Clean test design (AAA pattern)

---

## 🧠 Design Principles

* Separation of concerns
* Reusability of components
* Readable and maintainable test code
* Stability over speed (proper waits instead of sleeps)

---
