using System.Data.SQLite;

namespace SQLiteImp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();

            switch (Console.ReadLine())
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Green;
                    CreateDatabase();
                    Console.WriteLine("\nDatabase created.");
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Green;
                    CreateTables();
                    Console.WriteLine("\nTables created.");
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Green;
                    InsertData();
                    Console.WriteLine("\nData inserted.");
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    UpdateData();
                    Console.WriteLine("\nData updated.");
                    break;
                case "5":
                    Console.ForegroundColor = ConsoleColor.Red;
                    DeleteData();
                    Console.WriteLine("\nData deleted.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "6":
                    Console.ForegroundColor = ConsoleColor.Red;
                    DeleteDatabase();
                    Console.WriteLine("\nDatabase deleted.");
                    break;
                case "7": 
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    ShowDatabase();
                    break;
                case "8":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    ShowTable();
                    break;

                case "9":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nExiting program.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid option.");
                    break;
                    
            }

            Main(null);
        }
        public static void Menu()
        {
            Console.Title = "SQLite Implementation";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n-- SQLite Implementation --");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Create Database");
            Console.WriteLine("2. Create Tables");
            Console.WriteLine("3. Insert Data");
            Console.WriteLine("4. Update Data");
            Console.WriteLine("5. Delete Data");
            Console.WriteLine("6. Delete Database");
            Console.WriteLine("7. Show Database");
            Console.WriteLine("8. Show Table");
            Console.WriteLine("9. Exit");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Select an option: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void CreateDatabase()
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
        } 
        
        public static void CreateTables()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "create table todo (content varchar(40))";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        public static void DeleteDatabase()
        {
            System.IO.File.Delete("MyDatabase.sqlite");
        }
        public static void InsertData()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "insert into todo (content) values ('My todo')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        public static void UpdateData()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "update todo set content = 'My new todo' where content = 'My todo'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        public static void DeleteData()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "delete from todo where content = 'My new todo'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        public static void ShowTable()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "select * from todo";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            Console.WriteLine("Table Contents:");
            while (reader.Read())
            {
                Console.WriteLine(reader["content"]);
            }
            reader.Close();
            m_dbConnection.Close();
        }
        public static void ShowDatabase()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "SELECT name FROM sqlite_master WHERE type='table'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string tableName = reader.GetString(0);
                Console.WriteLine($"Table '{tableName}' contents:");

                // Retrieve the data from the table
                string tableSql = $"SELECT * FROM {tableName}";
                SQLiteCommand tableCommand = new SQLiteCommand(tableSql, m_dbConnection);
                SQLiteDataReader tableReader = tableCommand.ExecuteReader();

                while (tableReader.Read())
                {
                    // Display the data in the console
                    for (int i = 0; i < tableReader.FieldCount; i++)
                    {
                        Console.Write($"{tableReader.GetName(i)}: {tableReader.GetValue(i)}\t");
                    }
                    Console.WriteLine();
                }
                tableReader.Close();
            }

            reader.Close();
            m_dbConnection.Close();
        }




    }
}