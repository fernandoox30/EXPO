using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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

                string query = "INSERT INTO spRegistrar(Usuario, Contraseña, RoleEmpleado) VALUES (@Usuario, Contraseña, @Role)";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                cmd.Parameters.AddWithValue("Contraseña", Contraseña1);
                cmd.Parameters.AddWithValue("Usuario", Usuario1);
                cmd.Parameters.AddWithValue("Role", IdRole1);

                int rep = cmd.ExecuteNonQuery();
                if (rep == 1) 
                {
                    string query1 = "INSERT INTO Empleado(Nombre, Apellido, FechaNacimient, Usuario) VALUES (@param1, @param2, @param3, @param4, @param5)";
                    //Se crea un comando de tipo sql al cual se le pasa el query y la conexión, esto para que el sistema sepa que hacer y donde hacerlo.
                    SqlCommand cmd1 = new SqlCommand(query, Command.Connection);
                    //Se le da un valor a los parametros contenidos en el query, es importante mencionar que lo que esta entre comillas es el nombre del parametro y lo que esta después de la coma es el valor que se le asignará al parametro, estos valores vienen del DTO
                    cmd.Parameters.AddWithValue("param1", Nombre1);
                    cmd.Parameters.AddWithValue("param2", Apellido1);
                    cmd.Parameters.AddWithValue("param3", FechaNacimient1);
                    cmd.Parameters.AddWithValue("param4", CorreoEmpleado1);
                    cmd.Parameters.AddWithValue("param5", Usuario1);

                    rep = cmd.ExecuteNonQuery();
                    
                    return rep;
                }
                else
                {
                    RollBack();
                    return 0;
                }
            }
            catch (Exception)
            {
                RollBack();
                return -1;
            }
        }

        public void actualizarEmpleados()
        {
            try
            {
                Command.Connection = getConnection();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RollBack()
        {
            string query = "DELETE FROM spRegistrar WHERE Usuario = @Usuario";
            SqlCommand cmddel = new SqlCommand(query, Command.Connection);
            cmddel.Parameters.AddWithValue("Usuario", Usuario1);
            int retorno = cmddel.ExecuteNonQuery();
        }
    }
}
