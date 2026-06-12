using System;
using System.Data.SqlClient;

public class UsuariosController
{
    // ❌ VIOLACIÓN: Credencial Hardcodeada
    private const string AdminToken = "secret_api_token_xyz123abc!!";

    public void ObtenerDatosUsuario(string id)
    {
        string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // ❌ VIOLACIÓN: Inyección SQL Potencial (Concatenación directa)
            string query = "SELECT * FROM Usuarios WHERE Id = '" + id + "' AND Activo = 1";
            
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                Console.WriteLine(reader["Nombre"]);
            }
        }
    }
}
