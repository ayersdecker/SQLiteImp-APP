# SQLiteImp-Console

## Program Summary
This program implements basic CRUD operations on an SQLite database. It allows the user to create a database, create tables, insert, update and delete data, show the contents of a table or the entire database, and delete the database.

## Menu()
This method displays the main menu for the user to select an option.

## CreateDatabase()
This method creates a new SQLite database file named MyDatabase.sqlite.

## CreateTables()
This method creates a new table named todo in the database with a single column named content.

## DeleteDatabase()
This method deletes the MyDatabase.sqlite file.

## InsertData()
This method inserts a new row into the todo table with the content value of 'My todo'.

## UpdateData()
This method updates the content value of the row in the todo table with the content value of 'My new todo' where the content value is 'My todo'.

## DeleteData()
This method deletes the row in the todo table where the content value is 'My new todo'.

## ShowTable()
This method displays all the rows in the todo table and their content values.

## ShowDatabase()
This method displays all the tables in the database and their contents.

## Conclusion
This program demonstrates basic operations in an SQLite database using C# and the System.Data.SQLite library. It can serve as a starting point for building more complex database applications.
