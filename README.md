# Ensek API Consumer Web Application
The EnsekApiConsumer.Web project is a web application for interacting with the Ensek Meter Reading API. It allows users to upload meter reading files, view existing readings, and display paginated data fetched from the API.

# Features
**File Upload**: Upload .csv files containing meter readings to the Ensek API.
**View Meter Readings**: Display all meter readings retrieved from the Ensek API in a paginated table.
**Error Handling**: Shows user-friendly error messages for failed operations (e.g., invalid files or API errors).


# Setup and Configuration
## Prerequisites
- **.NET 8**
- **An active instance of the Ensek Meter Reading API running (ensure the base URL is configured).**

{
  "ApiSettings": {
    "BaseUrl": "https://localhost:7051" // URL for the Ensek API
  }
}




# Usage
**1. Upload a File**
Navigate to the Upload File page.
Select a valid .csv file containing meter readings and click Upload.
On successful upload, a confirmation message will be displayed.
**2. View All Meter Readings**
Navigate to the Home Page.
The table will display all meter readings retrieved from the API, with pagination controls.


# Project Structure - Clean Architecture
The project is designed following Clean Architecture principles to separate concerns and ensure maintainability, testability, and extensibility. It follows a layered approach, with each layer having its own responsibilities.

# 1. Presentation Layer (Web)
**Location:** EnsekApiConsumer.Web project
**Purpose:** Handles HTTP requests, renders views, and coordinates communication between the user and the API.
## Components:
Controllers: MVC controllers (e.g., HomeController) that handle incoming requests, interact with services, and return responses (views or JSON data).
Views: Razor views (Views/Home) for rendering UI components, displaying data, and handling file uploads.
View Models: Data structures tailored to present information to the view, ensuring data is formatted and ready for display.


# 2. Application Layer
**Location:** EnsekTest.Application project
**Purpose:** Contains business logic, use cases, and service interfaces. This layer is responsible for executing business logic and coordinating tasks between the web and domain layers.
## Components:
Interfaces (Services): Defines the core operations needed by the controller (e.g., IMeterReadingService, ICsvParserService, IDatabaseSeederService).
Services: Implementations of the business logic for handling meter reading uploads, parsing files, and interacting with the database (e.g., MeterReadingService).


# 3. Domain Layer
**Location:** EnsekTest.Domain project
**Purpose:** Represents the core of the application and contains the business rules (domain models). This layer should not depend on any other layers.
## Components:
**Entities:** Represents the core business objects or domain models (e.g., MeterReading, Account). These are the objects that are persisted in the database.
**Value Objects:** Contains small, immutable types used within entities (e.g., MeterReadingDateTime).
**Aggregates:** Grouping of related entities, ensuring business consistency (e.g., MeterReadingAggregate).
**Interfaces:** Contains interfaces for repositories and domain services that interact with the infrastructure layer (e.g., IMeterReadingRepository).


# 4. Infrastructure Layer
**Location:** EnsekTest.Infrastructure project
**Purpose:** Handles the technical details of data access, external API calls, and implementation of domain interfaces.
## Components:
**Repositories:** Implements the persistence logic for entities (e.g., MeterReadingRepository), interacting with a database (e.g., SQL or SQLite).
**Data Access:** Implements data models and EF Core context for interacting with the database (e.g., EnsekDbContext).
**External Services:** Implements services to interact with external APIs, like using HttpClient for calling external services (e.g., ApiService).
**File Handlers:** Deals with reading and writing files (e.g., CsvParser).



