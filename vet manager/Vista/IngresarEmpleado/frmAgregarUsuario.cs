using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vet_manager.Vista.IngregarEmpleado
{
    public partial class frmAgregarUsuario : Form
    {
        public frmAgregarUsuario()
        {
            InitializeComponent();
        }

        private void frmAgregarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }




        bool sidebarExpand;
        bool UsuarioCollapsed;

        public void sidebarTimer_Tick(object sender, EventArgs e)
        {
            

            if (sidebarExpand)
            {
                //si la barra lateral esta expandida, minimiza
                sidebar.Width -= 10;
                if(sidebar.Width == sidebar.MinimumSize.Width) 
                {
                    sidebarExpand = false;
                    sidebarTime.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTime.Stop();
                }
            }
        }

        public void ptbMenuBoton_Click(object sender, EventArgs e)
        {
            //establecer tiempo 
            sidebarTime.Start();
        }

        public void UsuarioTime_Tick(object sender, EventArgs e)
        {
            if(UsuarioCollapsed) 
            {
                pnlContainer.Height += 10;
                if(pnlContainer.Height == pnlContainer.MaximumSize.Height)
                {
                    UsuarioCollapsed = false;
                    UsuarioTime.Stop();
                }
            }
            else
            {
                pnlContainer.Height -= 10;
                if (pnlContainer.Height == pnlContainer.MinimumSize.Height)
                {
                    UsuarioCollapsed = true;
                    UsuarioTime.Stop();
                }
            }
        }

        private void btnAddUsuario_Click(object sender, EventArgs e)
        {

            UsuarioTime.Start();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
