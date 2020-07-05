namespace WindowsFormsApp1
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.itemMenu_archivo = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPestaña = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.salir = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenu_Compilar = new System.Windows.Forms.ToolStripMenuItem();
            this.analizarLéxicamente = new System.Windows.Forms.ToolStripMenuItem();
            this.generarValla = new System.Windows.Forms.ToolStripMenuItem();
            this.archivosSalida = new System.Windows.Forms.ToolStripMenuItem();
            this.archivoDeTokens = new System.Windows.Forms.ToolStripMenuItem();
            this.archivoDeErrores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_Ayuda = new System.Windows.Forms.ToolStripMenuItem();
            this.manualDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualTécnicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.numeroLabel = new System.Windows.Forms.Label();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMenu_archivo,
            this.itemMenu_Compilar,
            this.menuItem_Ayuda});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(545, 24);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // itemMenu_archivo
            // 
            this.itemMenu_archivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPestaña,
            this.cargarArchivo,
            this.guardarArchivo,
            this.salir});
            this.itemMenu_archivo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.itemMenu_archivo.Name = "itemMenu_archivo";
            this.itemMenu_archivo.Size = new System.Drawing.Size(60, 20);
            this.itemMenu_archivo.Text = "Archivo";
            // 
            // nuevaPestaña
            // 
            this.nuevaPestaña.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nuevaPestaña.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.nuevaPestaña.Name = "nuevaPestaña";
            this.nuevaPestaña.Size = new System.Drawing.Size(160, 22);
            this.nuevaPestaña.Text = "Nueva Pestaña";
            this.nuevaPestaña.Click += new System.EventHandler(this.nuevaPestaña_Click);
            // 
            // cargarArchivo
            // 
            this.cargarArchivo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cargarArchivo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cargarArchivo.Name = "cargarArchivo";
            this.cargarArchivo.Size = new System.Drawing.Size(160, 22);
            this.cargarArchivo.Text = "Cargar Archivo";
            this.cargarArchivo.Click += new System.EventHandler(this.cargarArchivo_Click);
            // 
            // guardarArchivo
            // 
            this.guardarArchivo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guardarArchivo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.guardarArchivo.Name = "guardarArchivo";
            this.guardarArchivo.Size = new System.Drawing.Size(160, 22);
            this.guardarArchivo.Text = "Guardar Archivo";
            this.guardarArchivo.Click += new System.EventHandler(this.guardarArchivoToolStripMenuItem_Click);
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.salir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(160, 22);
            this.salir.Text = "Salir";
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // itemMenu_Compilar
            // 
            this.itemMenu_Compilar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analizarLéxicamente,
            this.generarValla,
            this.archivosSalida});
            this.itemMenu_Compilar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.itemMenu_Compilar.Name = "itemMenu_Compilar";
            this.itemMenu_Compilar.Size = new System.Drawing.Size(68, 20);
            this.itemMenu_Compilar.Text = "Compilar";
            // 
            // analizarLéxicamente
            // 
            this.analizarLéxicamente.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.analizarLéxicamente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.analizarLéxicamente.Name = "analizarLéxicamente";
            this.analizarLéxicamente.Size = new System.Drawing.Size(204, 22);
            this.analizarLéxicamente.Text = "Analizar léxicamente";
            this.analizarLéxicamente.Click += new System.EventHandler(this.analizarLéxicamente_Click);
            // 
            // generarValla
            // 
            this.generarValla.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.generarValla.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.generarValla.Name = "generarValla";
            this.generarValla.Size = new System.Drawing.Size(204, 22);
            this.generarValla.Text = "Generar Valla Publicitaria";
            this.generarValla.Click += new System.EventHandler(this.generarValla_Click);
            // 
            // archivosSalida
            // 
            this.archivosSalida.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.archivosSalida.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoDeTokens,
            this.archivoDeErrores});
            this.archivosSalida.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.archivosSalida.Name = "archivosSalida";
            this.archivosSalida.Size = new System.Drawing.Size(204, 22);
            this.archivosSalida.Text = "Archivos de Salida";
            // 
            // archivoDeTokens
            // 
            this.archivoDeTokens.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.archivoDeTokens.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.archivoDeTokens.Name = "archivoDeTokens";
            this.archivoDeTokens.Size = new System.Drawing.Size(171, 22);
            this.archivoDeTokens.Text = "Archivo de Tokens";
            this.archivoDeTokens.Click += new System.EventHandler(this.archivoDeTokens_Click);
            // 
            // archivoDeErrores
            // 
            this.archivoDeErrores.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.archivoDeErrores.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.archivoDeErrores.Name = "archivoDeErrores";
            this.archivoDeErrores.Size = new System.Drawing.Size(171, 22);
            this.archivoDeErrores.Text = "Archivo de Errores";
            this.archivoDeErrores.Click += new System.EventHandler(this.archivoDeErrores_Click);
            // 
            // menuItem_Ayuda
            // 
            this.menuItem_Ayuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualDeUsuarioToolStripMenuItem,
            this.manualTécnicoToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuItem_Ayuda.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuItem_Ayuda.Name = "menuItem_Ayuda";
            this.menuItem_Ayuda.Size = new System.Drawing.Size(53, 20);
            this.menuItem_Ayuda.Text = "Ayuda";
            // 
            // manualDeUsuarioToolStripMenuItem
            // 
            this.manualDeUsuarioToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.manualDeUsuarioToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.manualDeUsuarioToolStripMenuItem.Name = "manualDeUsuarioToolStripMenuItem";
            this.manualDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.manualDeUsuarioToolStripMenuItem.Text = "Manual de Usuario";
            this.manualDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.manualDeUsuarioToolStripMenuItem_Click);
            // 
            // manualTécnicoToolStripMenuItem
            // 
            this.manualTécnicoToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.manualTécnicoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.manualTécnicoToolStripMenuItem.Name = "manualTécnicoToolStripMenuItem";
            this.manualTécnicoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.manualTécnicoToolStripMenuItem.Text = "Manual técnico";
            this.manualTécnicoToolStripMenuItem.Click += new System.EventHandler(this.manualTécnicoToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.acercaDeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca De";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(29, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(545, 492);
            this.tabControl1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(9, 525);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(545, 85);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // numeroLabel
            // 
            this.numeroLabel.AutoSize = true;
            this.numeroLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.numeroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.numeroLabel.Location = new System.Drawing.Point(6, 49);
            this.numeroLabel.Name = "numeroLabel";
            this.numeroLabel.Size = new System.Drawing.Size(15, 15);
            this.numeroLabel.TabIndex = 3;
            this.numeroLabel.Text = "1";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(545, 613);
            this.Controls.Add(this.numeroLabel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Principal";
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem itemMenu_archivo;
        private System.Windows.Forms.ToolStripMenuItem nuevaPestaña;
        private System.Windows.Forms.ToolStripMenuItem cargarArchivo;
        private System.Windows.Forms.ToolStripMenuItem guardarArchivo;
        private System.Windows.Forms.ToolStripMenuItem salir;
        private System.Windows.Forms.ToolStripMenuItem itemMenu_Compilar;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Ayuda;
        private System.Windows.Forms.ToolStripMenuItem analizarLéxicamente;
        private System.Windows.Forms.ToolStripMenuItem generarValla;
        private System.Windows.Forms.ToolStripMenuItem archivosSalida;
        private System.Windows.Forms.ToolStripMenuItem manualDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualTécnicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem archivoDeTokens;
        private System.Windows.Forms.ToolStripMenuItem archivoDeErrores;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label numeroLabel;
    }
}

