using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using ConsoleTables;
using System.Collections;

namespace AdoDataReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args).ConfigureAppConfiguration(
                (hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();
                    IHostEnvironment env = hostingContext.HostingEnvironment;
                    var configFilePath = Path.Combine(DirectoryProvider.TrySlnDirectory().FullName, "AdoDataReader", "appsettings.json");
                    var configXmlFilePath = Path.Combine(DirectoryProvider.TrySlnDirectory().FullName, "AdoDataReader", "App.config");

                    configuration.AddJsonFile(configFilePath, optional: false, reloadOnChange: true);
                    configuration.AddXmlFile(configXmlFilePath, optional: false);

                    IConfigurationRoot configurationRoot = configuration.Build();
                }
                ).Build();

            IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
            //Console.WriteLine(config.GetConnectionString("MSSQL"));
            string? connStrings = config.GetConnectionString("MSSQL");
            //Console.WriteLine(connStrings);
            //Console.WriteLine("pubs {0}", config.GetConnectionString("add:pubs:connectionString"));
            //foreach (var i in ConfigurationExtensions.AsEnumerable(config)) {
            //    Console.WriteLine(i.Key);
            //    Console.WriteLine(i.Value);
            //}
            //Console.WriteLine(config.GetConnectionString("pubs"));
            //Console.WriteLine(config.GetChildren());
            //foreach (IEnumerable i in config.GetChildren()) {
            //    Console.WriteLine(i);
            //}

            //Page_Load(connStrings);
            //Exec_Stored_Procedure(connStrings);
            //Exec_NextResult(connStrings);
            //Exec_Depth(connStrings);
            //Exec_FieldCount(connStrings);
            //Exec_RecordsAffected(connStrings);
            //Exec_GetName(connStrings); 
            Exec_GetValue(connStrings);
        }

        protected static void Page_Load(string? connStrings)
        {
            string SqlQuery = "select * from discounts";
            using (
                SqlConnection conn = new SqlConnection(connStrings)
            )
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    Console.WriteLine(dr.FieldCount);
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["discounttype"] + "," + dr[1]);
                    }
                    cmd.Cancel();
                }
            }
        }

        protected static void Exec_Stored_Procedure(string? connStrings)
        {
            using (SqlConnection conn = new SqlConnection(connStrings))
            {
                SqlDataReader dr = null;
                SqlCommand cmd;
                // setting store procedure
                cmd = new SqlCommand("test_homepage", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    using (dr = cmd.ExecuteReader())
                    {
                        Console.WriteLine(dr[0]);
                        Console.WriteLine(dr[1]);
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                cmd.Cancel();
            }
        }

        protected static void Exec_NextResult(string? connStrings)
        {
            string queryString = "select * from jobs; select * from pub_info";
            using (SqlConnection conn = new SqlConnection(connStrings))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(queryString, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    do
                    {
                        Console.WriteLine("table column name: " + dr.GetName(0));
                        while (dr.Read())
                        {
                            Console.WriteLine("<hr>" + dr[0] + "<br>" + dr[1]);
                        }
                    } while (dr.NextResult());
                    cmd.Cancel();
                }
            }
        }

        protected static void Exec_Depth(string? connStrings)
        {
            // .net framework data provider 不支援巢狀
            string queryString = "select * from jobs";
            using (SqlConnection Conn = new SqlConnection(connStrings))
            {
                Conn.Open();
                SqlCommand cmd = new SqlCommand(queryString, Conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    Console.WriteLine("SqlDataReader's Depth Attrubute: " + dr.Depth);
                    cmd.Cancel();
                }
            }
        }

        protected static void Exec_FieldCount(string? connStrings)
        {
            string queryString = "select * from jobs";
            using (SqlConnection Conn = new SqlConnection(connStrings))
            {
                Conn.Open();
                SqlCommand cmd = new SqlCommand(queryString, Conn);
                var table = new ConsoleTable();
                //string[] i = new string[] { "1","2","3"};
                //table.AddColumn(i);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    Console.WriteLine($"how many total column does table have?\t {dr.FieldCount.ToString()}");

                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            Console.Write(dr[i].ToString() + "\t");
                        }
                        Console.WriteLine();
                    }
                    cmd.Cancel();
                }
            }
        }

        protected static void Exec_HasRows(string? connStrings)
        {
            string queryString = "select * from authors";
            using (SqlConnection Conn = new SqlConnection(connStrings))
            {
                Conn.Open();
                SqlCommand cmd = new SqlCommand(queryString, Conn);
                var table = new ConsoleTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    Console.WriteLine($"how many total column does table have?\t {dr.FieldCount.ToString()}");

                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            Console.Write(dr[i].ToString() + "\t");
                        }
                        Console.WriteLine();
                    }
                    cmd.Cancel();
                }
            }
        }

        protected static void Exec_RecordsAffected(string connStrings)
        {
            string queryString = "Update Employees set City='Seattle' where EmployeeID=1";
            using (SqlConnection Conn = new SqlConnection(connStrings))
            {
                Conn.Open();
                SqlCommand cmd = new SqlCommand(queryString, Conn);
                int RecordsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("execute Update's Sql cmd, affect " + RecordsAffected + " records.");
                if (RecordsAffected > 0)
                {
                    Console.WriteLine("data have affected。total: " + RecordsAffected + " row record is affected");
                }
                cmd.Cancel();
            }
        }

        protected static void Exec_GetName(string connStrings)
        {
            string queryString = "select * from Employees";
            SqlDataReader dr = null;
            using (SqlConnection Conn = new SqlConnection(connStrings))
            {
                SqlCommand cmd = new SqlCommand(queryString, Conn);
                Conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.Write(dr.GetName(i).ToString() + "\t");
                        Console.Write(dr[i].ToString() + "\n");
                    }
                    Console.WriteLine();
                }
                cmd.Cancel();
            }
        }

        // 6-14
        protected static void Exec_GetValue(string connStrings)
        {
            SqlDataReader dr = null;
            using (SqlConnection Conn = new SqlConnection(connStrings))
            {
                SqlCommand cmd = new SqlCommand("select * from Employees", Conn);
                Conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.Write(dr.GetName(i).ToString() + "\t");
                        // 回傳 System.Object，代表隊 null 的資料行，會傳回 DBNull
                        Console.Write(dr.GetValue(i).ToString() + "\r\n");
                    }
                    Console.WriteLine();
                }
                cmd.Cancel();
            }
        }

        // 6-16
        protected static void Exec_GetValues(string connStrings)
        {
            

        }
    }
}