Ensek API Consumer Web Application
The EnsekApiConsumer.Web project is a web application for interacting with the Ensek Meter Reading API. It allows users to upload meter reading files, view existing readings, and display paginated data fetched from the API.

Features
File Upload: Upload .csv files containing meter readings to the Ensek API.
View Meter Readings: Display all meter readings retrieved from the Ensek API in a paginated table.
Error Handling: Shows user-friendly error messages for failed operations (e.g., invalid files or API errors).


Setup and Configuration
Prerequisites
.NET 8
An active instance of the Ensek Meter Reading API running (ensure the base URL is configured).

{
  "ApiSettings": {
    "BaseUrl": "https://localhost:7051" // URL for the Ensek API
  }
}




Usage
1. Upload a File
Navigate to the Upload File page.
Select a valid .csv file containing meter readings and click Upload.
On successful upload, a confirmation message will be displayed.
2. View All Meter Readings
Navigate to the All Meter Readings page.
The table will display all meter readings retrieved from the API, with pagination controls.


Project Structure
Controllers: Contains MVC controllers for handling user interactions (HomeController).
Views: Razor views for displaying data and uploading files (Views/Home).
Services: Contains services to interact with the Ensek API using HttpClient.
