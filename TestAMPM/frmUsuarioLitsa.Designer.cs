namespace TestAMPM
{
    partial class frmUsuarioLitsa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCerrar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditar = new DevExpress.XtraEditors.SimpleButton();
            this.btnNuevo = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridUsuarios = new DevExpress.XtraGrid.GridControl();
            this.gvUsuarios = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApellido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCorreo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCerrar);
            this.panelControl1.Controls.Add(this.btnEditar);
            this.panelControl1.Controls.Add(this.btnNuevo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 219);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(715, 49);
            this.panelControl1.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.ImageOptions.Image = global::TestAMPM.Properties.Resources.Cerrar;
            this.btnCerrar.Location = new System.Drawing.Point(611, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 28);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.ImageOptions.Image = global::TestAMPM.Properties.Resources.Editar;
            this.btnEditar.Location = new System.Drawing.Point(96, 12);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 28);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.ImageOptions.Image = global::TestAMPM.Properties.Resources.Nuevo;
            this.btnNuevo.Location = new System.Drawing.Point(15, 12);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 28);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridUsuarios);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(715, 219);
            this.panelControl2.TabIndex = 1;
            // 
            // gridUsuarios
            // 
            this.gridUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUsuarios.Location = new System.Drawing.Point(2, 2);
            this.gridUsuarios.MainView = this.gvUsuarios;
            this.gridUsuarios.Name = "gridUsuarios";
            this.gridUsuarios.Size = new System.Drawing.Size(711, 215);
            this.gridUsuarios.TabIndex = 0;
            this.gridUsuarios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUsuarios});
            // 
            // gvUsuarios
            // 
            this.gvUsuarios.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colNombreU,
            this.colPass,
            this.colNombre,
            this.colApellido,
            this.colCorreo,
            this.colTelefono,
            this.colFecha});
            this.gvUsuarios.GridControl = this.gridUsuarios;
            this.gvUsuarios.Name = "gvUsuarios";
            this.gvUsuarios.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvUsuarios.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvUsuarios.OptionsBehavior.Editable = false;
            this.gvUsuarios.OptionsBehavior.ReadOnly = true;
            this.gvUsuarios.OptionsView.ColumnAutoWidth = false;
            this.gvUsuarios.OptionsView.ShowAutoFilterRow = true;
            this.gvUsuarios.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "IdUsuario";
            this.colId.FieldName = "IdUsuario";
            this.colId.Name = "colId";
            // 
            // colNombreU
            // 
            this.colNombreU.Caption = "Nombre Usuario";
            this.colNombreU.FieldName = "NombreUsuario";
            this.colNombreU.Name = "colNombreU";
            this.colNombreU.Visible = true;
            this.colNombreU.VisibleIndex = 0;
            this.colNombreU.Width = 98;
            // 
            // colPass
            // 
            this.colPass.Caption = "Password";
            this.colPass.FieldName = "Contrasena";
            this.colPass.Name = "colPass";
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Nombres";
            this.colNombre.FieldName = "Nombres";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 1;
            this.colNombre.Width = 191;
            // 
            // colApellido
            // 
            this.colApellido.Caption = "Apellidos";
            this.colApellido.FieldName = "Apellidos";
            this.colApellido.Name = "colApellido";
            this.colApellido.Visible = true;
            this.colApellido.VisibleIndex = 2;
            this.colApellido.Width = 158;
            // 
            // colCorreo
            // 
            this.colCorreo.Caption = "Correo";
            this.colCorreo.FieldName = "Correo";
            this.colCorreo.Name = "colCorreo";
            this.colCorreo.Visible = true;
            this.colCorreo.VisibleIndex = 3;
            this.colCorreo.Width = 181;
            // 
            // colTelefono
            // 
            this.colTelefono.Caption = "Telefono";
            this.colTelefono.FieldName = "Telefono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.Visible = true;
            this.colTelefono.VisibleIndex = 4;
            this.colTelefono.Width = 88;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha Creacion";
            this.colFecha.FieldName = "FechaCreacion";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 5;
            this.colFecha.Width = 108;
            // 
            // frmUsuarioLitsa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 268);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::TestAMPM.Properties.Resources.descarga;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuarioLitsa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Usuarios";
            this.Load += new System.EventHandler(this.frmUsuarioLitsa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridUsuarios;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUsuarios;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreU;
        private DevExpress.XtraGrid.Columns.GridColumn colPass;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colApellido;
        private DevExpress.XtraGrid.Columns.GridColumn colCorreo;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraEditors.SimpleButton btnCerrar;
        private DevExpress.XtraEditors.SimpleButton btnEditar;
        private DevExpress.XtraEditors.SimpleButton btnNuevo;
    }
}