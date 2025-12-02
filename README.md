# MySql.DB ![DLL Release](https://img.shields.io/github/v/release/fahmirizalbudi/mysqldb?label=DLL%20Release)

A lightweight and minimal helper library for interacting with **MySQL databases in C# (.NET)**. **MySql.DB** provides a simple API for executing SQL commands and retrieving rows as dynamic objects without the complexity of an ORM.

## Features

-   Simple API with clean, easy-to-understand structure
-   Lightweight and minimal implementation
-   Direct MySQL access using MySql.Data
-   Dynamic result mapping (`List<dynamic>`)
-   No ORM overhead

## Installation

### 1. Install MySql.Data

    Install-Package MySql.Data

### 2. Add the MySql.DB.dll file

You can download the DLL from the Releases page.

## Usage Example

### Configure Connection

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

``` csharp
var db = new MySqlDB(config);
```

### Fetch Rows

``` csharp
var users = db.Rows("SELECT * FROM users");

foreach (var row in users)
{
    Console.WriteLine($"{row.id} - {row.name}");
}
```

### Execute Non-Query SQL

``` csharp
db.Execute("INSERT INTO users (name) VALUES ('Rizal')");
```

## Usage

The latest version of MySql.DB is available here:
[Download](https://github.com/fahmirizalbudi/mysqldb/releases/latest)

## License

Released under the MIT License.
