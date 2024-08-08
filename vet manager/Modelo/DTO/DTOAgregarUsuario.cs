using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_manager.Modelo.DTO
{
    internal class DTOAgregarUsuario : dbConexion
    {
        private int IdEmpleados;
        private string Nombre;
        private string Apellido;
        private DateTime FechaNacimient;
        private string Usuario;
        private string Contraseña;


        public int IdEmpleados1 { get => IdEmpleados; set => IdEmpleados = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellido1 { get => Apellido; set => Apellido = value; }
        public DateTime FechaNacimient1 { get => FechaNacimient; set => FechaNacimient = value; }
        public string Usuario1 { get => Usuario; set => Usuario = value; }
        public string Contraseña1 { get => Contraseña; set => Contraseña = value; }
    }
}
