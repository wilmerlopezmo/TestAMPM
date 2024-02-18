
using Entidades.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAMPM
{
    public partial class frmVerFoto : Form
    {
        
        public Byte[] Logo
        {
            get
            {
                if (picLogo.Image == null) return null;
                else return Funciones.ImageToBytes(picLogo.Image);
            }
            set
            {
                if (value == null) picLogo.Image = null;
                else picLogo.Image = Funciones.BytesToImage(value);
            }
        }
        public frmVerFoto()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icono;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
