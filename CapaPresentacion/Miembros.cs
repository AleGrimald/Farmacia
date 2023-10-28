using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Miembros : Form
    {
        public Miembros()
        {
            InitializeComponent();
        }

        private void btnPPrincipal_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ventanaPrincipal = new Form1();
            ventanaPrincipal.Show();
        }
    }
}
