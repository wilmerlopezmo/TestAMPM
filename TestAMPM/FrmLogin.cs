using Entidades;
using Entidades.Utilidades;
using SIGE.Entidades.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TestAMPM
{
    public partial class FrmLogin : Form
    {

        Entidades.TESTAMPMEntities db = new Entidades.TESTAMPMEntities(Conexion.CnxEntidades());

        public string Usuario;
        public string Pass;

        public FrmLogin()
        {

            InitializeComponent();
            this.Icon = Properties.Resources.icono;

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            VerificarUsuarios();
        }

        public void VerificarUsuarios()
        {


            List<Usuarios> us = new List<Usuarios>();
            us = db.Usuarios.ToList();

            if (us.Count() > 0)
            {
                btnNuevo.Visible = false;
            }
            else
            {
                btnNuevo.Visible = true;
            }
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtUsuario.Text.Trim() == "")
                {
                    MessageBox.Show("Digitar el Usuario con el que desea acceder al sistema.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                varUser = this.txtUsuario.Text.Trim();
                varPass = Funciones.Deco(this.txtPassword.Text.Trim());
                //// Validar datos del Usuario
                var UsrDatos = db.Usuarios.Where(C => C.NombreUsuario == varUser && C.Contrasena == varPass).ToList();


                if (UsrDatos != null)
                {
                    if (UsrDatos.Count == 0)
                    {
                        MessageBox.Show("El USUARIO NO EXISTE, FAVOR VERIFIQUE.", "Test AM / PM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("El USUARIO NO EXISTE, FAVOR VERIFIQUE.", "Test AM / PM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(Funciones.GetMessageExceptions(ex));
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                FrmUsuario us = new FrmUsuario();
                us.Owner = this;
                us.IsNuevo = true;
                us.Primero = true;
                us.ShowInTaskbar = false;
                us.ShowDialog();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(Funciones.GetMessageExceptions(ex));
            }
        }
    }
}
