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
using Entidades;

namespace TestAMPM
{
    public partial class frmProductoLista : DevExpress.XtraEditors.XtraForm
    {
        Entidades.TESTAMPMEntities db = new Entidades.TESTAMPMEntities(Conexion.CnxEntidades());
        List<Productos> Lst = new List<Productos>();
        public frmProductoLista()
        {
            InitializeComponent();
            this.IconOptions.Icon = Properties.Resources.icono;
        }
        public class Estado
        {
            public bool Id { get; set; }
            public string Nombre { get; set; }
        }

        public void CargarProductos()
        {
            try
            {
                bool estado = Convert.ToBoolean(lkEstado.EditValue);
                db = new Entidades.TESTAMPMEntities(Conexion.CnxEntidades());
                if (txtNombre.Text != "")
                {
                    Lst = db.Productos.Where(c => c.Estado == estado && c.NombreProducto.Contains(txtNombre.Text)).ToList();
                }
                else
                {
                    Lst = db.Productos.Where(c => c.Estado == estado).ToList();
                }
                if (estado == false)
                {
                    btnNuevo.Visible = false;
                    btnEditar.Visible = false;
                    btnInactivar.Visible = false;
                    btnActivar.Visible = true;
                }
                else
                {
                    btnNuevo.Visible = true;
                    btnEditar.Visible = true;
                    btnInactivar.Visible = true;
                    btnActivar.Visible = false;
                }
                gridProducto.DataSource = Lst;

                btnver.Buttons[0].ImageOptions.Image = Properties.Resources.Guardar;
            }
            catch (Exception ex)
            {

                Funciones.MensajeError(ex.Message);
            }
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmProductoLista_Load(object sender, EventArgs e)
        {
            try
            {
                List<Estado> est = new List<Estado>();
                est.Add(new Estado { Id = true, Nombre = "Activo" });
                est.Add(new Estado { Id = false, Nombre = "InActivo" });

                lkEstado.Properties.DataSource = est.ToList();
                lkEstado.Properties.ValueMember = "Id";
                lkEstado.Properties.DisplayMember = "Nombre";
                lkEstado.EditValue = true;
                CargarProductos();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(ex.Message);
            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnver_Click(object sender, EventArgs e)
        {
            try
            {

                int drow = gvProducto.FocusedRowHandle;

                db = new Entidades.TESTAMPMEntities(Conexion.CnxEntidades());
                int idproducto = Convert.ToInt32(this.gvProducto.GetRowCellValue(drow, "IdProducto"));
                var Foto = db.Productos.Where(c => c.IdProducto == idproducto).ToList();

                if (Foto.FirstOrDefault().Imagen == null)
                {
                    Funciones.MensajeError("Producto sin Foto Asignada");
                    return;
                }

                frmVerFoto FotoP = new frmVerFoto();
                FotoP.Owner = this;
                FotoP.Text = "Foto " + " del Producto :  " + (this.gvProducto.GetRowCellValue(drow, "CodigoProducto").ToString() + " - " + this.gvProducto.GetRowCellValue(drow, "NombreProducto").ToString());
                FotoP.ShowInTaskbar = false;
                FotoP.Logo = Foto.FirstOrDefault().Imagen;
                FotoP.ShowDialog();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(Funciones.GetMessageExceptions(ex));
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmProducto pr = new frmProducto();
                pr.Text = "Nuevo Producto";
                pr.isNuevo = true;
                pr.Owner = this;
                pr.ShowInTaskbar = false;
                pr.ShowDialog();
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
                int drow = gvProducto.FocusedRowHandle;
                frmProducto pr = new frmProducto();
                pr.Owner = this;
                pr.IdProducto = Convert.ToInt32(this.gvProducto.GetRowCellValue(drow, "IdProducto"));
                pr.isNuevo = false;
                pr.ShowInTaskbar = false;
                pr.Text = "Editar Producto";
                pr.ShowDialog();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(Funciones.GetMessageExceptions(ex));
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarProductos();
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

        private void btnInactivar_Click(object sender, EventArgs e)
        {

            try
            {
                int drow = gvProducto.FocusedRowHandle;

                if (this.gvProducto.RowCount == 0)
                {
                    Funciones.MensajeError("No se Encontraron Registros que Inactivar.");
                    return;
                }
                frmProducto pr = new frmProducto();
                pr.Owner = this;
                pr.IdProducto = Convert.ToInt32(this.gvProducto.GetRowCellValue(drow, "IdProducto"));
                pr.isNuevo = false;
                pr.ShowInTaskbar = false;
                pr.Text = "Inactivar Producto";
                pr.txtCodigo.ReadOnly = true;
                pr.txtProducto.ReadOnly = true;
                pr.txtProveedor.ReadOnly = true;
                pr.spExistencia.ReadOnly = true;
                pr.btnCargarImagen.Enabled = false;
                pr.picLogo.ReadOnly = true;
                pr.btnGuardar.Visible = false;
                pr.btnInactivar.Visible = true;
                pr.btnActivar.Visible = false;
                pr.ShowDialog();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(Funciones.GetMessageExceptions(ex));
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {

            try
            {
                int drow = gvProducto.FocusedRowHandle;

                if (this.gvProducto.RowCount == 0)
                {
                    Funciones.MensajeError("No se Encontraron Registros que Activar.");
                    return;
                }
                frmProducto pr = new frmProducto();
                pr.Owner = this;
                pr.IdProducto = Convert.ToInt32(this.gvProducto.GetRowCellValue(drow, "IdProducto"));
                pr.isNuevo = false;
                pr.ShowInTaskbar = false;
                pr.Text = "Activar Producto";
                pr.txtCodigo.ReadOnly = true;
                pr.txtProducto.ReadOnly = true;
                pr.txtProveedor.ReadOnly = true;
                pr.spExistencia.ReadOnly = true;
                pr.btnCargarImagen.Enabled = true;
                pr.picLogo.ReadOnly = true;
                pr.btnActivar.Visible = true;
                pr.ShowDialog();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(Funciones.GetMessageExceptions(ex));
            }
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            try
            {
                int drow = gvProducto.FocusedRowHandle;

                int idproducto = Convert.ToInt32(this.gvProducto.GetRowCellValue(drow, "IdProducto"));
                
                frmOpcionesProducto OP = new frmOpcionesProducto();
                OP.Owner = this;
                OP.Text = "Opciones del Producto : " + (this.gvProducto.GetRowCellValue(drow, "CodigoProducto").ToString() + " - " + this.gvProducto.GetRowCellValue(drow, "NombreProducto").ToString());
                OP.ShowInTaskbar = false;
                OP.IdProducto = idproducto;
                OP.ShowDialog();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(Funciones.GetMessageExceptions(ex));
            }
        }
    }
}