using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_manager.Vista.Login;
using vet_manager.Modelo;
using System.Windows.Forms;
using vet_manager.Modelo.DAO;
using vet_manager.Vista.IngregarEmpleado;

namespace vet_manager.Controlador.Login
{
    public class ControladorLogin
    {
        FrmLogin ObjLogin;

        /// <summary>
        /// Constructor de la clase ControladorLogin que inicia los eventos de la vista
        /// </summary>
        /// <param name="Vista"></param>

        public ControladorLogin(FrmLogin Vista)
        {
            ObjLogin = Vista;
            ObjLogin.btnIngresar.Click += new EventHandler(acceso);
            ObjLogin.btnCancelar.Click += new EventHandler(QuitarVentana);

            ObjLogin.txtUsuario.Enter += new EventHandler(IngresarUsuario);
            ObjLogin.txtUsuario.Leave += new EventHandler(dejarUsuario);

            ObjLogin.txtContraseña.Enter += new EventHandler(IngresarContra);
            ObjLogin.txtContraseña.Leave += new EventHandler(DejarContra);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void acceso(object sender, EventArgs e)
        {
            try
            {
                DAOLogin DAODATA = new DAOLogin();

                DAODATA.Usuario1 = ObjLogin.txtUsuario.Text;
                DAODATA.Contraseña1 = ObjLogin.txtContraseña.Text;

                int respuesta = DAODATA.Login();
                    
                if (respuesta == 1)
                {
                    frmAgregarUsuario AgregarEmpleado = new frmAgregarUsuario();
                    AgregarEmpleado.Show();
                    
                    ObjLogin.Hide();
                }
                else
                {
                    MessageBox.Show("Error de inicio de sesión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void IngresarUsuario(object sender, EventArgs e)
        {
            if(ObjLogin.txtUsuario.Text.Trim().Equals(""))
            {
                ObjLogin.txtUsuario.Text = "Usuario";
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void dejarUsuario(object sender, EventArgs e)
        {
            if (ObjLogin.txtUsuario.Text.Trim().Equals(""))
            {
                ObjLogin.txtUsuario.Text = "Usuario";
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void IngresarContra(object sender, EventArgs e)
        {
            if (ObjLogin.txtContraseña.Text.Trim().Equals("Contraseña"))
            {
                ObjLogin.txtContraseña.Clear();
                ObjLogin.txtContraseña.UseSystemPasswordChar = true;
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DejarContra(object sender, EventArgs e)
        {
            if (ObjLogin.txtContraseña.Text.Trim().Equals(""))
            {
                ObjLogin.txtContraseña.Text = "Contraseña";
                ObjLogin.txtContraseña.PasswordChar = '\0';
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void QuitarVentana(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
