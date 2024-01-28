# Technical Assignment

Welcome! Follow the steps below to get started.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)

## Setup

1. Clone the repository:

    ```bash
    git clone https://github.com/omar3awwad/TechnicalAssignment.git
    cd TechnicalAssignment
    ```

2. Open the `appsettings.json` file and update the connection string:

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "your_updated_connection_string"
    },
    ```

## Run the Application

1. Open a terminal in the project directory and run the following command:

    ```bash
    dotnet run --environment "Development" --urls "http://localhost:8090"
    ```

2. The application will insert car make data into the database.
   Alternatively, you can manually run the SQL script (Seeding/CarMake.sql) to seed the car make data.

## Explore the API with Swagger

1. Open your web browser and navigate to [Swagger](http://localhost:8090/swagger/index.html).
   ```http
   GET http://localhost:8090/swagger/index.html
   
2. You can test the API by trying different car makes.

    - If you pass a car make that exists, the API will return an "Ok" response.
    - If you pass a car make that does not exist, the API will return a "No Content" response.

3. Example API Request:

   Make a GET request to the following API endpoint:

   ```http
   GET http://localhost:8090/api/Models?make=Lincoln&modelyear=2015

Example Response:

```Success (200 OK) ```
```json
{
  "Models": [
    "MKZ",
    "MKS",
    "MKT",
    "MKT",
    "MKX",
    "Navigator",
    "MKC"
  ]
}
```

