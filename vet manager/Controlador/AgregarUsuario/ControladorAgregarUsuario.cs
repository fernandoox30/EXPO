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
using vet_manager.Modelo.DAO;
using vet_manager.Vista.IngregarEmpleado;

namespace vet_manager.Controlador.AgregarUsuario
{
    

    internal class ControladorAgregarUsuario
    {

        frmAgregarUsuario ObjAgregarUsuario;

        public ControladorAgregarUsuario(frmAgregarUsuario vista)
        {
            ObjAgregarUsuario = vista;
        }

        public void DatosEmpleados()
        {
            DAOAgregarEmpleado objEmpleado = new DAOAgregarEmpleado();
            DataSet ds = new DataSet();
            
        }
    }
}
