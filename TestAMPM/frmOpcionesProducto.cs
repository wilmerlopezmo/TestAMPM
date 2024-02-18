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
using Entidades;
using Entidades.Utilidades;

namespace TestAMPM
{
    public partial class frmOpcionesProducto : DevExpress.XtraEditors.XtraForm
    {
        Entidades.TESTAMPMEntities db = new Entidades.TESTAMPMEntities(Conexion.CnxEntidades());
        List<OpcionesProducto> OpcioneEliminadas = new List<OpcionesProducto>();


        private List<OpcionesProducto> OP = new List<OpcionesProducto>();
        internal int IdProducto;

        public List<OpcionesProducto> DetalleOP
        {
            get { return OP; }
            set
            {
                OP = value;
                this.bdsDetalle.DataSource = this.OP;
            }
        }
        public frmOpcionesProducto()
        {
            InitializeComponent();
            this.IconOptions.Icon = Properties.Resources.icono;
        }

        private void frmOpcionesProducto_Load(object sender, EventArgs e)
        {
            try
            {
                OP = db.OpcionesProducto.Where(c => c.IdProducto == IdProducto).ToList();

                this.bdsDetalle.DataSource = this.DetalleOP;
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
                btnEditar.Visible = false;
                btnCancelar.Visible = true;
                btnGuardar.Visible = true;
                gvopciones.OptionsBehavior.Editable = true;
                gvopciones.OptionsBehavior.ReadOnly = false;
                gvopciones.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(ex.InnerException.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Controles()
        {

            btnEditar.Visible = true;
            btnCancelar.Visible = false;
            btnGuardar.Visible = false;
            gvopciones.OptionsBehavior.Editable = false;
            gvopciones.OptionsBehavior.ReadOnly = true;
            gvopciones.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                OpcioneEliminadas = db.OpcionesProducto.Where(c => c.IdProducto == IdProducto).ToList();
                foreach (var item in OpcioneEliminadas)
                {

                    OpcionesProducto nw = new OpcionesProducto();
                    nw.IdOpcion = item.IdOpcion;
                    nw.IdProducto = item.IdProducto;
                    nw.Nombre = item.Nombre;
                    nw.Estado = item.Estado;
                    db.OpcionesProducto.SingleDelete(nw);

                    db.SaveChanges();

                }

                foreach (var item in DetalleOP)
                {
                    db.GuardarOpciones(IdProducto, item.Nombre, item.Estado);
                }
                Controles();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(ex.InnerException.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Controles();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(ex.InnerException.Message);
            }
        }

        private void gvopciones_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {

                    if (e.KeyCode == Keys.Down)
                    {
                        e.Handled = true;
                        base.OnKeyUp(e);
                    }

                    if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.OemMinus)
                    {

                        DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)this.gridopciones.DefaultView;
                        int RowHandle = view.FocusedRowHandle;

                        if (RowHandle >= 0)
                        {
                            view.DeleteRow(view.FocusedRowHandle);

                        }

                    }

                    if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)this.gridopciones.DefaultView;
                        view.AddNewRow();
                    }
                

            }
            catch (Exception ex)
            {
                Funciones.MensajeError(Funciones.GetMessageExceptions(ex));
            }
        }
    }
}