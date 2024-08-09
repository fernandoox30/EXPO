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
using vet_manager.Vista.Agregar_ClienteMascota;



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
<<<<<<< HEAD
            Application.Run(new FrmClienteRegister());
=======
            Application.Run(new FrmLogin());
>>>>>>> 9d21f75b8b20a30a99b2948d83c83967c4ec8116
        }
    }
}
