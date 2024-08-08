using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vet_manager.Controlador.validar;
using vet_manager.Modelo;
using vet_manager.Modelo.DTO;



namespace vet_manager.Modelo.DAO
{
    public class DAOLogin : DTOLogin
    {
        SqlCommand Command = new SqlCommand();

        public bool Login()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT Usuario, Contraseña, Nombre FROM Empleado WHERE Usuario = @Usuario AND Contraseña = @Contraseña";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@Usuario", Usuario1);
                cmd.Parameters.AddWithValue("@Contraseña", Contraseña1);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    acesso.Usuario = rd.GetString(rd.GetOrdinal("Usuario"));
                    acesso.Contraseña = rd.GetString(rd.GetOrdinal("Contraseña"));
                    acesso.Nombre = rd.GetString(rd.GetOrdinal("Nombre"));
                }
                return rd.HasRows;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
    }
}
