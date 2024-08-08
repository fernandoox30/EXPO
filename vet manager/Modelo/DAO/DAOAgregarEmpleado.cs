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

                string query = "INSERT INTO Empleado(Nombre, Apellido, FechaNacimient, Usuario, Contraseña) VALUES (@NombreEmpleado, @ApellidoEmpleado, @Nacimiento, @Usuario, Contraseña)";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                cmd.Parameters.AddWithValue("Nombre", Nombre1);
                cmd.Parameters.AddWithValue("Apellido", Apellido1);
                cmd.Parameters.AddWithValue("FechaNacimiento", FechaNacimient1);
                cmd.Parameters.AddWithValue("Contraseña", Contraseña1);
                cmd.Parameters.AddWithValue("Usuario", Usuario1);

                int rep = cmd.ExecuteNonQuery();
                if (rep == 1) 
                {
                    string query1 = "INSERT INTO spPersonas (Nombre, Apellido, FechaNacimient, Usuario) VALUES (@param1, param2, param3, param4)";

                    cmd.Parameters.AddWithValue("param1", Nombre1);
                    cmd.Parameters.AddWithValue("param2", Apellido1);
                    cmd.Parameters.AddWithValue("param3", FechaNacimient1);
                    cmd.Parameters.AddWithValue("param4", Usuario1);
                    rep = cmd.ExecuteNonQuery();
                    
                    return rep;
                }else
                {
                    Elminar();
                    return 0;
                }
            }
            catch (Exception)
            {
                Elminar();
                return -1;
            }
        }

        public void Elminar()
        {
            string query = "DELETE FROM Empleado WHERE Usario = NombreEmpleado";
            SqlCommand cmddel = new SqlCommand(query, Command.Connection);
            cmddel.Parameters.AddWithValue("usename", Usuario1);
            int retorno = cmddel.ExecuteNonQuery();
        }

        public int actualizarEmpleados()
        {
            try
            {
                Command.Connection = getConnection();

                string query = "UPDATE Empleado SET" +
                    "Nombre = @param1, Apellido = @param2," +
                    "FechaNacimient = @param3," +
                    "WHERE IdEmpleado = @param5";

                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                cmd.Parameters.AddWithValue("param1", Nombre1);
                cmd.Parameters.AddWithValue("param2", Apellido1);
                cmd.Parameters.AddWithValue("param3", FechaNacimient1);
                cmd.Parameters.AddWithValue("param5", IdEmpleados1);

                int rep = cmd.ExecuteNonQuery();
                if (rep == 1)
                {
                    string query1 = "UPDATE spRegistrar SET " +
                        "IdEmpleado = @param5 WHERE Usuario = @param4";
                   
                }
                return rep;
            }
            catch (Exception)
            {

                return -1;
            }
            finally
            {
                getConnection().Close();
            }
        }

        public int eliminarEmpleado()
        {
            try
            {
                Command.Connection = getConnection();

                string query = "DELETE Empleado WHERE IdEmpleado = param1";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", IdEmpleados1);
                int rep = cmd.ExecuteNonQuery();

                if (rep == 1)
                {
                    string queryupdate = "UPDATE tbUser SET userStatus = @status WHERE username = @username";
                    SqlCommand cmdupdate = new SqlCommand(queryupdate, Command.Connection);
                    cmdupdate.Parameters.AddWithValue("Usuario", Usuario1);
                    rep += cmdupdate.ExecuteNonQuery();
                }
                return rep;
            }
            catch (Exception)
            {

                return -1;
            }finally
            {
                getConnection().Close();
            }


        }
    }
}
