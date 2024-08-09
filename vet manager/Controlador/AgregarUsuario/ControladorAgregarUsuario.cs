using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vet_manager.Controlador.validar;
using vet_manager.Modelo.DAO;
using vet_manager.Vista.IngregarEmpleado;

namespace vet_manager.Controlador.AgregarUsuario
{
    

    internal class ControladorAgregarUsuario
    {

        frmAgregarUsuario ObjAgregarUsuario;
        private int accion;

        /// <summary>
        /// Constructor para inserción de datos
        /// </summary>
        /// <param name="Vista"></param>
        /// <param name="accion"> INSERCIÓN </param>
        /// 
        public ControladorAgregarUsuario(frmAgregarUsuario vista)
        {
            ObjAgregarUsuario = vista;
            this.accion = accion;
            Accion();
            ObjAgregarUsuario.btnAgregar.Click += new EventHandler(NuegistrarNuevo);
        }

        public void DatosEmpleados()
        {
            DAOAgregarEmpleado objEmpleado = new DAOAgregarEmpleado();
            DataSet ds = new DataSet(); 
            
        }

        public void Accion()
        {
            if (accion == 1)
            {
                ObjAgregarUsuario.btnAgregar.Enabled = true;
                ObjAgregarUsuario.btnActualizar.Enabled = false;
                ObjAgregarUsuario.btnCancelar.Enabled = false;
            }
            else if (accion == 2)
            {
                ObjAgregarUsuario.btnAgregar.Enabled = false;
                ObjAgregarUsuario.btnActualizar.Enabled = true;
                ObjAgregarUsuario.txtUsuario.Enabled = false;
            }
            else if (accion == 3)
            {
                ObjAgregarUsuario.btnAgregar.Enabled = false;
                ObjAgregarUsuario.btnActualizar.Enabled = false;
                ObjAgregarUsuario.txtNombre.Enabled = false;
                ObjAgregarUsuario.txtApellido.Enabled = false;
                ObjAgregarUsuario.dtpFechaNacimiento.Enabled = false;
                ObjAgregarUsuario.txtUsuario.Enabled = false;
            }
        }

        public void NuegistrarNuevo(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(ObjAgregarUsuario.txtNombre.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAgregarUsuario.txtApellido.Text.Trim()) ||
                string.IsNullOrEmpty(ObjAgregarUsuario.txtUsuario.Text.Trim())))
            {
                DAOAgregarEmpleado DAOInsert = new DAOAgregarEmpleado();
                Incriptar commonClasses = new Incriptar();

                DAOInsert.Nombre1 = ObjAgregarUsuario.txtNombre.Text.Trim();
                DAOInsert.Apellido1 = ObjAgregarUsuario.txtApellido.Text.Trim();
                DAOInsert.FechaNacimient1 = ObjAgregarUsuario.dtpFechaNacimiento.Value.Date;
                DAOInsert.Usuario1 = ObjAgregarUsuario.txtUsuario.Text.Trim();
                DAOInsert.Contraseña1 = commonClasses.ComputeSha256Hash(ObjAgregarUsuario.txtUsuario.Text.Trim());

                //Se invoca al método RegistrarUsuario mediante el objeto DAOInsert
                int retornar = DAOInsert.RegistrarUsuario();
                //Se verifica el valor que retornó el metodo anterior y que fue almacenado en la variable valorRetornado
                if (retornar == 1)
                {
                    //SavePhoto();       
                    MessageBox.Show("Los datos han sido registrados correctamente",
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
            else
            {
                MessageBox.Show("Existen campos vacíos, complete cada uno de los apartados y verifique que la fecha seleccionada corresponde a una persona mayor de edad.",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
        }
        public void UpdateRegister(object sender, EventArgs e)
        {
            DAOAgregarEmpleado daoUpdate = new DAOAgregarEmpleado();
            daoUpdate.Nombre1 = ObjAgregarUsuario.txtNombre.Text.Trim();
            daoUpdate.Apellido1 = ObjAgregarUsuario.txtApellido.Text.Trim();
            daoUpdate.FechaNacimient1 = ObjAgregarUsuario.dtpFechaNacimiento.Value;
            daoUpdate.Usuario1 = ObjAgregarUsuario.txtUsuario.Text.Trim();
            int valorRetornado = daoUpdate.actualizarEmpleados();
            if (valorRetornado == 2)
            {
                MessageBox.Show("Los datos han sido actualizado exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else if (valorRetornado == 1)
            {
                MessageBox.Show("Los datos no pudieron ser actualizados completamente",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados debido a un error inesperado",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        public void ChargeValues(int id, string firstName, string lastName, DateTime birthday, string dni, string address, string email, string phone, string username)
        {
            try
            {
                ObjAgregarUsuario.txtId.Text = id.ToString();
                ObjAgregarUsuario.txtNombre.Text = firstName;
                ObjAgregarUsuario.txtApellido.Text = lastName;
                ObjAgregarUsuario.dtpFechaNacimiento.Value = birthday;
                ObjAgregarUsuario.txtUsuario.Text = username;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
