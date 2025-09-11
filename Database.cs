using System;
using System.Data.SqlClient;

public static class Database
{
    // Cadena de conexión (ajustar servidor, base de datos, usuario y contraseña)
    private static readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=Operador911;Trusted_Connection=True";


    // Método para obtener la conexión abierta
    public static SqlConnection GetConnection()
    {
        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open(); // Abrir la conexión
        return conn;
    }
}
