using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vet_manager.Modelo.DAO;
using vet_manager.Vista.IngregarEmpleado;

namespace vet_manager.Controlador.AgregarUsuario
{
    internal class ControladorAgregarUsuario
    {
        frmAgregarUsuario ObjAgregarUsuario;
        private int accion;
        private string rol;

        /// <summary>
        /// Constructor para inserción de datos
        /// </summary>
        /// <param name="Vista"></param>
        /// <param name="accion"> INSERCIÓN </param>
        /// 

        public ControladorAgregarUsuario(frmAgregarUsuario Vista, int accion) 
        {
        ObjAgregarUsuario = Vista;
           this.accion = accion;

            
        }

        /// <summary>
        /// Constructor para inserción de datos
        /// </summary>
        /// <param name="Vista"></param>
        /// <param name="accion"> INSERCIÓN </param>
        /// 

        public void NuevoResgistro(object sender, EventArgs e)
        {
            DAOAgregarEmpleado daoAgregar = new DAOAgregarEmpleado();
            daoAgregar.Nombre1 = ObjAgregarUsuario.txtNombre.Text.Trim();
            daoAgregar.Apellido1 = ObjAgregarUsuario.txtApellido.Text.Trim();
            daoAgregar.Contraseña1 = ObjAgregarUsuario.txtContraseña.Text.Trim();
            daoAgregar.FechaNacimient1 = ObjAgregarUsuario.dtpFechaNacimiento.Value.Date; 
            daoAgregar.Usuario1 = ObjAgregarUsuario.txtUsuario.Text.Trim();
            daoAgregar.Contraseña1 = ObjAgregarUsuario.txtContraseña.Text.Trim();

            int retornar = daoAgregar.RegistrarUsuario();
            if (retornar == 1)
            {
                //SavePhoto();       
                MessageBox.Show("Los datos han sido registrados exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser registrados",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void lineasmenu(object sender, EventArgs e)
        {

        }
    }
}
