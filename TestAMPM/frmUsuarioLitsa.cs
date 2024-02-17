using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SIGE.Entidades.Conexion;
using Entidades.Utilidades;

namespace TestAMPM
{
    public partial class frmUsuarioLitsa : DevExpress.XtraEditors.XtraForm
    {
        Entidades.TESTAMPMEntities db = new Entidades.TESTAMPMEntities(Conexion.CnxEntidades());
        public frmUsuarioLitsa()
        {
            InitializeComponent();
        }

        private void frmUsuarioLitsa_Load(object sender, EventArgs e)
        {
            try
            {
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(ex.Message);
            }
        }

        public void CargarUsuarios()
        {
            try
            {
                db = new Entidades.TESTAMPMEntities(Conexion.CnxEntidades());
                var cargarlista = db.Usuarios.ToList();
                gridUsuarios.DataSource = cargarlista;
            }
            catch (Exception ex)
            {

                Funciones.MensajeError(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                FrmUsuario us = new FrmUsuario();
                us.Owner = this;
                us.IsNuevo = true;
                us.Primero = false;
                us.ShowInTaskbar = false;
                us.ShowDialog();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(Funciones.GetMessageExceptions(ex));
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                int drow = gvUsuarios.FocusedRowHandle;
                FrmUsuario us = new FrmUsuario();
                us.Owner = this;
                us.IdUsuario = Convert.ToInt32(this.gvUsuarios.GetRowCellValue(drow, "IdUsuario"));
                us.IsNuevo = false;
                us.Primero = false;
                us.ShowInTaskbar = false;
                us.ShowDialog();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(Funciones.GetMessageExceptions(ex));
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}