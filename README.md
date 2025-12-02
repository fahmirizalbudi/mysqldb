# MySql.DB ![DLL Release](https://img.shields.io/github/v/release/fahmirizalbudi/mysqldb?label=DLL%20Release)

A lightweight and minimal helper library for interacting with **MySQL databases in C# (.NET)**. **MySql.DB** provides a simple API for executing SQL commands and retrieving rows as dynamic objects without the complexity of an ORM.

## Features

-   Simple library with clean, easy-to-understand structure
-   Lightweight and minimal implementation
-   Direct MySQL access using MySql.Data
-   Dynamic result mapping (`List<dynamic>`)
-   No ORM overhead

## Installation

### 1. Install MySql.Data

    Install-Package MySql.Data

### 2. Add the DLL file to your project by referencing it in your IDE

You can download the latest compiled DLL from the Releases page, then include it as a project reference so your application can access all the classes and methods provided by this library. Once the reference is added, the library will be ready to use throughout your project.

## Usage Example

### Configure Connection

This section defines the database connection settings. The MySqlDBConfig object holds the server address, the username and password used to authenticate with MySQL, and the name of the database you want to access. These values are later used to build the connection string required to communicate with the MySQL server.
``` csharp
var config = new MySqlDBConfig
{
    Server = "localhost",
    Username = "root",
    Password = "",
    Database = "testdb"
};
```

### Initialize the Database Helper

Here, an instance of the MySqlDB class is created using the configuration defined earlier. This object serves as the main database helper and is responsible for executing SQL commands and retrieving query results. After initialization, the db object is ready to handle all database operations.
``` csharp
var db = new MySqlDB(config);
```

### Fetch Rows

This code executes a SELECT query and retrieves the results as a list of dynamic objects. Each row returned from the database becomes a dynamic object where column names can be accessed like properties. The foreach loop then iterates through all returned rows and prints the values of the id and name columns. This section demonstrates how to retrieve and use data from a table.
``` csharp
var users = db.Rows("SELECT * FROM users");

foreach (var row in users)
{
    Console.WriteLine($"{row.id} - {row.name}");
}
```

### Execute Non-Query SQL

This part shows how to execute a SQL command that does not return any result set. The Execute method is used for operations such as INSERT, UPDATE, DELETE, or other SQL commands that modify data or database structure. In this example, the statement inserts a new user into the users table.
``` csharp
db.Execute("INSERT INTO users (name) VALUES ('Rizal')");
```

## Usage

The latest version of MySql.DB is available here:
[Download](https://github.com/fahmirizalbudi/mysqldb/releases/latest)

## License

This project is released under the MIT License, which allows you to freely use, modify, distribute, and integrate the code in both personal and commercial projects. Please refer to the LICENSE file for the full text and details regarding permissions and limitations.
