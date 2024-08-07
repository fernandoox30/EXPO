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
                string query = "SELECT * FROM FrmLogin WHERE Usuario = @NombreUsuario AND Contraseña = @Contra";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("Usuario", Usuario1);
                cmd.Parameters.AddWithValue("Contraseña", Contraseña1);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    acesso.Usuario = rd.GetString(0);
                    acesso.Contraseña = rd.GetString(1);
                    acesso.Nombre = rd.GetString(2);
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

            finally { getConnection().Close(); }
        }
    }
}
