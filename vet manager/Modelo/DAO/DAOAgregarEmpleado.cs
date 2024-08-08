using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_manager.Modelo.DTO;

namespace vet_manager.Modelo.DAO
{
    internal class DAOAgregarEmpleado : DTOAgregarUsuario
    {
        readonly SqlCommand Command = new SqlCommand();

        /// <summary>
        /// Registrar usuario corresponde al primer mantenimiento del CRUD
        /// Inserción de datos a la base de datos
        /// </summary>
        /// <returns></returns>

        public int RegistrarUsuario()
        {
            try
            {

                Command.Connection = getConnection();

                string query = "INSERT INTO spRegistrar(Nombre, Apellido, FechaNacimient, Usuario, Contraseña) VALUES (@NombreEmpleado, @ApellidoEmpleado, @Nacimiento, @Usuario, Contraseña)";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                cmd.Parameters.AddWithValue("Nombre", Nombre1);
                cmd.Parameters.AddWithValue("Apellido", Apellido1);
                cmd.Parameters.AddWithValue("FechaNacimiento", FechaNacimient1);
                cmd.Parameters.AddWithValue("Contraseña", Contraseña1);
                cmd.Parameters.AddWithValue("Usuario", Usuario1);

                int rep = cmd.ExecuteNonQuery();
                if (rep == 1) 
                {
                
                }

                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                
                return 0;
            }
        }
    }
}
