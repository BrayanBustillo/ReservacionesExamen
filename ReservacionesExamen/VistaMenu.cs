using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservacionesExamen
{
    public partial class VistaMenu : Form
    {
        public VistaMenu()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaClientes vista = new VistaClientes();
            vista.MdiParent = this;
            vista.Show();
        }

        private void teatrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaTeatros vista = new VistaTeatros();
            vista.MdiParent = this;
            vista.Show();
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaReservas vista = new VistaReservas();
            vista.MdiParent = this;
            vista.Show();
        }
    }
}
