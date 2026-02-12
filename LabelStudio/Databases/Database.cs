using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace LabelStudio.Databases
{
    public class Database
    {
        //Folder where databases are stored.
        public static string dbFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "databases");
        private string _dbPath;
        public string _dbName { get; private set; }

        // Database Constructor
        public Database(string dbName)
        {
            _dbPath = Path.Combine(dbFolder, dbName + ".db");
            _dbName = dbName;

            //Creating database folder.
            if (!Directory.Exists(dbFolder))
            {
                Directory.CreateDirectory(dbFolder);
                Debug.WriteLine("[INFO] Database folder doesnt exist, creating...");
            }

            CreateDatabase(dbName);
        }
        //Create a Database
        public void CreateDatabase(string dbName)
        {
            if (File.Exists(_dbPath))
            {
                Debug.WriteLine("[ERROR] Cannot create database, it already exists: " + dbFolder + "\\" + dbName + ".db");
                return;
            }
            
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_dbPath}"))
                {
                    connection.Open();
                    using var cmd = connection.CreateCommand();
                    cmd.CommandText =
                    @"
                CREATE TABLE ""Plants"" (
	                ""ID""	INTEGER NOT NULL UNIQUE,
	                ""Type""	TEXT NOT NULL,
	                ""Family""	TEXT,
	                ""Species""	TEXT,
	                ""Variety""	TEXT,
	                ""CommonName""	TEXT,
	                ""Description""	TEXT,
	                ""PlantCode""	TEXT,
	                PRIMARY KEY(""ID"" AUTOINCREMENT)
                );
                ";
                    cmd.ExecuteNonQuery();
                }
            } catch (Exception ex)
            {
                Debug.WriteLine("[ERROR] " + ex.Message);
            }
        }

        //Load a Database
        public DataTable LoadDB()
        {
            DataTable table = new DataTable();

            if (!File.Exists(_dbPath))
            {
                Debug.WriteLine("[ERROR] Cannot load database, doesn't exist: " + _dbPath);
                return table;
            }
            
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_dbPath}"))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Plants";
                    using (var adapter = new SQLiteDataAdapter(sql, connection))
                    {
                        adapter.Fill(table);
                    }
                }
            } catch (Exception ex)
            {
                Debug.WriteLine("[ERROR] " + ex.Message);
            }

            return table;
        }
        //Add a record to the Database
        public void AddRecord(Plant plantToAdd)
        {
            if (!File.Exists(_dbPath))
            {
                Debug.WriteLine("[ERROR] Cannot load database, doesn't exist: " + _dbPath);
                return;
            }

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_dbPath}"))
                {
                    connection.Open();
                    using var cmd = connection.CreateCommand();

                    // Add all values from the plant to add
                    cmd.CommandText =
                    @"INSERT INTO Plants (Type)
                      VALUES ($type)";

                    cmd.Parameters.AddWithValue("$type", plantToAdd.Type);

                    cmd.ExecuteNonQuery();
                }
            } catch (Exception ex)
            {
                Debug.WriteLine("[ERROR] " + ex.Message);
            }
        }
        //Delete a record
        public void DeleteRecord(int id)
        {
            if (!File.Exists(_dbPath))
            {
                Debug.WriteLine("[ERROR] Cannot load database, doesn't exist: " + _dbPath);
                return;
            }

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_dbPath}"))
                {
                    connection.Open();
                    using var cmd = connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM Plants WHERE ID = $id";
                    cmd.Parameters.AddWithValue("$id", id);
                    cmd.ExecuteNonQuery();
                    /* For debug only - 1 is success, 0 is fail. 
                    int result = cmd.ExecuteNonQuery();
                    MessageBox.Show(Convert.ToString(result));
                    */
                }
            } catch (Exception ex)
            {
                Debug.WriteLine("[ERROR] " + ex.Message);
            }
        }

        public string GetColumnValueByID(int id, string column)
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_dbPath}"))
                {
                    connection.Open();
                    using var cmd = connection.CreateCommand();
                    cmd.CommandText = $@"SELECT [{column}] FROM [Plants] WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    return (string)cmd.ExecuteScalar();
                }
            } catch (Exception ex)
            {
                Debug.WriteLine("[ERROR] " + ex.Message);
                return null;
            }
        }
    }
}