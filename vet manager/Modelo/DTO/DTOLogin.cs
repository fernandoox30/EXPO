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

        public bool V { get; }

        public DTOLogin() { }

        public DTOLogin(bool v, string Usuario, string contraseña)
        {
            V = v;

            this.Usuario = Usuario;
            this.Contraseña = contraseña;
        }
    }
}
