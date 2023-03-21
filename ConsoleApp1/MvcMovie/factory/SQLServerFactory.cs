public interface ISQLServer
{
    public string? GetServer(WebApplicationBuilder builder, string connetString);
}

public class MSSQLServer: ISQLServer
{
    public  string? GetServer(WebApplicationBuilder builder, string connetString){
       return builder.Configuration.GetConnectionString(connetString);
    }
}

public class SQLiteServer: ISQLServer
{
    public string? GetServer(WebApplicationBuilder builder, string connetString){
       return builder.Configuration.GetConnectionString(connetString);
    }
}

// public static class SQLFactory<T>
// {
//     public static ISQLServer GetSQLServer(string ServerName)
//     {

//         switch(ServerName)
//         {
//             case "MSSQL":
//                 return MSSQLServer();
//             case "SQLite":
//                 return SQLiteServer();

//         }

//     }
// }