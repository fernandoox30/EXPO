using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using vet_manager.Vista.Citas;
using vet_manager.Vista.IngregarEmpleado;
using vet_manager.Vista.IngresarEmpleado;
using vet_manager.Vista.Login;



namespace vet_manager
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}
