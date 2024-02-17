﻿using System;
using SIGE.Entidades.Conexion;
using System.Data.Entity.Core.Objects;
using Entidades.Utilidades;
using System.Text.RegularExpressions;

namespace TestAMPM
{
    public partial class FrmUsuario : DevExpress.XtraEditors.XtraForm
    {
        internal bool IsNuevo;
        public int IdUsuario;

        Entidades.TESTAMPMEntities db = new Entidades.TESTAMPMEntities(Conexion.CnxEntidades());
        internal bool Primero;

        public FrmUsuario()
        {
            InitializeComponent();
            this.IconOptions.Icon = Properties.Resources.icono;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text == string.Empty)
                {
                    Funciones.MensajeError("El Nombre de Usuario es Requerido.");
                    txtUsuario.Focus();
                    return;

                }


                if (txtPas.Text == string.Empty)
                {
                    Funciones.MensajeError("El Password es Requerido.");
                    txtPas.Focus();
                    return;

                }

                if (txtNombre.Text == string.Empty)
                {
                    Funciones.MensajeError("El Nombre del Usuario es Requerido.");
                    txtNombre.Focus();
                    return;

                }

                if (txtApellido.Text == string.Empty)
                {
                    Funciones.MensajeError("El Apellido del Usuario es Requerido.");
                    txtApellido.Focus();
                    return;

                }
                if (txtCorreo.Text == string.Empty)
                {
                    Funciones.MensajeError("El Correo del Usuario es Requerido.");
                    txtCorreo.Focus();
                    return;

                }
                if (txtTelefono.Text == string.Empty)
                {
                    Funciones.MensajeError("El Telefono del Usuario es Requerido.");
                    txtTelefono.Focus();
                    return;

                }

                if (ComprobarFormatoEmail(txtCorreo.Text) == false)
                {
                    Funciones.MensajeError("El Formato de Correo es Incorrecto, Por Favor Corrigalo.");
                    return;
                }

                ObjectParameter idOutput = new ObjectParameter("Id", typeof(string));
                var Pass = Funciones.Deco(txtPas.Text);
                if (IsNuevo)
                {
                    idOutput.Value = null;
                    var te = db.GuardarUsuario(idOutput, txtUsuario.Text, Pass, txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtTelefono.Text);
                    Funciones.MensajeInformacion("!El Usuario fue Registrado, Con éxito!");
                }
                else
                {
                    idOutput.Value = IdUsuario;
                    var te = db.GuardarUsuario(idOutput, txtUsuario.Text, Pass, txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtTelefono.Text);
                    Funciones.MensajeInformacion("!El Usuario fue Modificado, Con éxito!");

                }
                this.Close();
                if (Primero)
                {
                    FrmLogin frm = (FrmLogin)this.Owner;
                    frm.VerificarUsuarios();
                }
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(ex.InnerException.Message);
            }
        }
        public static bool ComprobarFormatoEmail(string seMailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(seMailAComprobar, sFormato))
            {
                if (Regex.Replace(seMailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmUsuario_Shown(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}