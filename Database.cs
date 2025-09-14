using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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

    public static void HacerBackup(string ruta)
    {
        using (SqlConnection con = GetConnection())
        {
            string query = $@"
            BACKUP DATABASE [Operador911] 
            TO DISK = N'{ruta}' 
            WITH NOFORMAT, NOINIT,  
            NAME = N'Operador911-Backup', 
            SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
    }

    public static void RestoreBackup(string ruta)
    {
      string conexion = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";

        using (SqlConnection con = new SqlConnection(conexion))
        {
            con.Open();
            string query = $@"
            ALTER DATABASE [Operador911] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            RESTORE DATABASE [Operador911] 
            FROM DISK = N'{ruta}' 
            WITH REPLACE, STATS = 5;
            ALTER DATABASE [Operador911] SET MULTI_USER;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

    public static void HacerBackupSemanal()
    {
        string archivoControl = @"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup\ultimo_backup.txt";

        // Verificamos si hoy es domingo
        if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
        {
            string fechaHoy = DateTime.Now.ToString("yyyyMMdd");

            
            if (File.Exists(archivoControl))
            {
                string ultimaFecha = File.ReadAllText(archivoControl).Trim();

               
                if (ultimaFecha == fechaHoy)
                {
                    
                    return;
                }
            }

            // Armamos la ruta para el backup con la fecha de hoy
            string ruta = $@"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup\Operador911_{fechaHoy}.bak";
            HacerBackup(ruta);

            
            File.WriteAllText(archivoControl, fechaHoy);
        }
        
    }
}


