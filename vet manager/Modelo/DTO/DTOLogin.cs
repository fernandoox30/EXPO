using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_manager.Modelo.DTO
{
    public class DTOLogin : dbConexion
    {
        private string Usuario;
        private string Contraseña;

        public string Usuario1 { get => Usuario; set => Usuario = value; }
        public string Contraseña1 { get => Contraseña; set => Contraseña = value; }
    }
}
