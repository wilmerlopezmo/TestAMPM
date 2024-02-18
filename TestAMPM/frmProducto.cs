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
using Entidades.Utilidades;
using System.Data.Entity.Core.Objects;
using SIGE.Entidades.Conexion;
using Entidades;

namespace TestAMPM
{
    public partial class frmProducto : DevExpress.XtraEditors.XtraForm
    {
        Entidades.TESTAMPMEntities db = new Entidades.TESTAMPMEntities(Conexion.CnxEntidades());
        internal bool isNuevo;
        public int IdProducto;
        private Byte[] Foto
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
        public frmProducto()
        {
            InitializeComponent();
            this.IconOptions.Icon = Properties.Resources.icono;
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            if (isNuevo == false)
            {
                var pr = db.Productos.Where(c => c.IdProducto == IdProducto).FirstOrDefault();
                txtCodigo.Text = pr.CodigoProducto;
                txtProducto.Text = pr.NombreProducto;
                txtProveedor.Text = pr.NombreProveedor;
                spExistencia.Value = pr.Existencia;
                Foto = pr.Imagen;
            }
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (openImagen.ShowDialog() == DialogResult.OK)
                {
                    var archivo = openImagen.FileNames[0];
                    Foto = Funciones.ImageToBytes(Image.FromFile(archivo));

                }
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text == string.Empty)
                {
                    Funciones.MensajeError("El Codigo del Producto es Requerido.");
                    txtCodigo.Focus();
                    return;
                }


                if (txtProducto.Text == string.Empty)
                {
                    Funciones.MensajeError("El Nombre del Producto es Requerido.");
                    txtProducto.Focus();
                    return;
                }


                if (spExistencia.EditValue == null)
                {
                    Funciones.MensajeError("La Existencia del Producto no puede ser Nula.");
                    spExistencia.Focus();
                    return;
                }


                if (txtProveedor.Text == string.Empty)
                {
                    Funciones.MensajeError("El Nombre del Proveedor es Requerido.");
                    txtProveedor.Focus();
                    return;
                }

                if (Foto == null)
                {

                    Funciones.MensajeError("La Foto del Producto es Requerida.");
                    return;
                }

                ObjectParameter idOutput = new ObjectParameter("IdProducto", typeof(int));
                if (isNuevo)
                {
                    idOutput.Value = null;
                    var regpr = db.GuardarProducto(idOutput, txtCodigo.Text, txtProducto.Text, spExistencia.Value, txtProveedor.Text, Foto);

                }
                else
                {

                    idOutput.Value = IdProducto;
                    var regpr = db.GuardarProducto(idOutput, txtCodigo.Text, txtProducto.Text, spExistencia.Value, txtProveedor.Text, Foto);
                }
                this.Close();

                frmProductoLista frm = (frmProductoLista)this.Owner;
                frm.CargarProductos();
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

        private void picLogo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea InActivar el Producto Seleccionado?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                Productos pr = new Productos();
                pr = db.Productos.Where(c => c.IdProducto == IdProducto).FirstOrDefault();

                if (pr == null)
                {
                    Funciones.MensajeError("El Producto seleccionado no Existe.");
                    return;
                }

                if (pr.Estado == false)
                {

                    Funciones.MensajeError("El Producto seleccionado esta Inactivo.");
                    return;
                }
                pr.Estado = false;

                db.SaveChanges();
                this.Close();
                frmProductoLista frm = (frmProductoLista)this.Owner;
                frm.CargarProductos();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(ex.InnerException.Message);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Desea Activar el Producto Seleccionado?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                Productos pr = new Productos();
                pr = db.Productos.Where(c => c.IdProducto == IdProducto).FirstOrDefault();

                if (pr == null)
                {
                    Funciones.MensajeError("El Producto seleccionado no Existe.");
                    return;
                }

                if (pr.Estado == true)
                {

                    Funciones.MensajeError("El Producto seleccionado esta Activo.");
                    return;
                }
                pr.Estado = true;

                db.SaveChanges();
                this.Close();
                frmProductoLista frm = (frmProductoLista)this.Owner;
                frm.CargarProductos();
            }
            catch (Exception ex)
            {
                Funciones.MensajeError(ex.InnerException.Message);
            }
        }
    }
}