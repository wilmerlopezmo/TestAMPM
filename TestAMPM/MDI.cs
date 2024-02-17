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
    public partial class MDI : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MDI()
        {
            InitializeComponent();
            this.IconOptions.Icon = Properties.Resources.icono;
        }

        private void btnProducto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var w = (frmProductoLista)Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProductoLista);
                if (w != null)
                {
                    if (w.Name == "frmProductoLista")
                    {
                        w.BringToFront();
                        return;
                    }
                }
                var wnd = new frmProductoLista
                {
                    MdiParent = this
                };
                wnd.Show();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(ex.Message);
                throw;
            }

        }

        private void btnUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var w = (frmUsuarioLitsa)Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmUsuarioLitsa);
                if (w != null)
                {
                    if (w.Name == "frmUsuarioLitsa")
                    {
                        w.BringToFront();
                        return;
                    }
                }
                var wnd = new frmUsuarioLitsa
                {
                    MdiParent = this
                };
                wnd.Show();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(ex.Message);
                throw;
            }

        }
    }
}
