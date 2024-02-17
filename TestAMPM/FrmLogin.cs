using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TestAMPM
{
    public partial class FrmLogin : Form
    {
       

        public string Usuario;
        public string Pass;

        public FrmLogin()
        {

            InitializeComponent();
           

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
    

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            //try
            //{
            if (this.txtUsuario.Text.Trim() == "")
            {
                MessageBox.Show("Digitar el Usuario con el que desea acceder al sistema.","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtUsuario.Focus();
                return;
            }

            if (this.txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Digite el Password del Usuario.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPassword.Focus();
                return;
            }

            string varUser;
            string varPass;
            string rpta;
            string VarVersion;
            string VarNameApp;

            //varUser = this.txtUsuario.Text.Trim();
            //varPass = Funciones.Deco(this.txtPassword.Text.Trim());
            //VarVersion = Application.ProductVersion;
            //VarNameApp = Conexion.NameApplication;
            //// Validar datos del Usuario
            //var UsrDatos = repositorioU.BuscarUsuario(varUser);


            //if (UsrDatos != null)
            //{
            //    if (UsrDatos.Count == 0)
            //    {
            //        MessageBox.Show("El USUARIO NO EXISTE, FAVOR VERIFIQUE.", General.TituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    if (UsrDatos.Count() > 0)
            //    {
            //        rpta = repositorioU.ValidarAcceso(varUser, varPass, VarNameApp, VarVersion);

            //        if (!rpta.Equals("OK"))
            //        {
            //            MessageBox.Show(rpta, General.TituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //    }

            //    bool Activo = Convert.ToBoolean(UsrDatos.FirstOrDefault().Activo);

            //    if (!Activo)
            //    {
            //        MessageBox.Show("EL USUARIO SE ENCUENTRA DE BAJA, FAVOR VERIFIQUE.", General.TituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}
            
            this.DialogResult = DialogResult.Yes;
            this.Close();
            //}
            //catch (Exception ex)
            //{
            //    Funciones.MensajeError(Funciones.GetMessageExceptions(ex));
            //}
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
