using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_manager.Controlador.validar
{
    internal class acesso
    {
        private static string usuario = string.Empty;
        private static string contraseña = string.Empty;
        private static string nombre = string.Empty;


        public static string Usuario { get => usuario; set => usuario = value; }
        public static string Contraseña { get => contraseña; set => contraseña = value; }
        public static string Nombre { get => nombre; set => nombre = value; }
    }
}
