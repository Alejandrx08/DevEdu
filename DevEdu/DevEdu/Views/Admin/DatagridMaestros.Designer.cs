namespace DevEdu
{
    partial class DatagridMaestros
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatagridMaestros));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbox_Correo = new System.Windows.Forms.TextBox();
            this.btn_Mostrar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.txtbox_Apellido = new System.Windows.Forms.TextBox();
            this.txtbox_Nombre = new System.Windows.Forms.TextBox();
            this.txtbox_ID = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtFiltroMaestros = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.label3.Location = new System.Drawing.Point(6, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Apellido";
            // 
            // DataGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.DataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGrid.BackgroundColor = System.Drawing.Color.White;
            this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Location = new System.Drawing.Point(291, 81);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.Size = new System.Drawing.Size(486, 346);
            this.DataGrid.TabIndex = 11;
            this.DataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellClick);
            this.DataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtbox_Correo);
            this.groupBox1.Controls.Add(this.btn_Mostrar);
            this.groupBox1.Controls.Add(this.btn_Editar);
            this.groupBox1.Controls.Add(this.btn_eliminar);
            this.groupBox1.Controls.Add(this.txtbox_Apellido);
            this.groupBox1.Controls.Add(this.txtbox_Nombre);
            this.groupBox1.Controls.Add(this.txtbox_ID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 394);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 358);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 26);
            this.label8.TabIndex = 25;
            this.label8.Text = "Selecciona un usuario en la tabla para ver/editar \r\nsus datos en el panel izquier" +
    "do.\r\n";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1, 296);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(254, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "_Peligro________________________________________";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(255, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "_Edicion________________________________________";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.label4.Location = new System.Drawing.Point(6, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Correo";
            // 
            // txtbox_Correo
            // 
            this.txtbox_Correo.Location = new System.Drawing.Point(6, 196);
            this.txtbox_Correo.Name = "txtbox_Correo";
            this.txtbox_Correo.Size = new System.Drawing.Size(249, 22);
            this.txtbox_Correo.TabIndex = 20;
            // 
            // btn_Mostrar
            // 
            this.btn_Mostrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.btn_Mostrar.ForeColor = System.Drawing.Color.White;
            this.btn_Mostrar.Location = new System.Drawing.Point(141, 257);
            this.btn_Mostrar.Name = "btn_Mostrar";
            this.btn_Mostrar.Size = new System.Drawing.Size(114, 23);
            this.btn_Mostrar.TabIndex = 19;
            this.btn_Mostrar.Text = "Actualizar";
            this.btn_Mostrar.UseVisualStyleBackColor = false;
            this.btn_Mostrar.Click += new System.EventHandler(this.btn_Mostrar_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.btn_Editar.ForeColor = System.Drawing.Color.White;
            this.btn_Editar.Location = new System.Drawing.Point(6, 257);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(114, 23);
            this.btn_Editar.TabIndex = 18;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.UseVisualStyleBackColor = false;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_eliminar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.ForeColor = System.Drawing.Color.Red;
            this.btn_eliminar.Location = new System.Drawing.Point(9, 330);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(114, 23);
            this.btn_eliminar.TabIndex = 17;
            this.btn_eliminar.Text = "Eliminar Rol";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // txtbox_Apellido
            // 
            this.txtbox_Apellido.Location = new System.Drawing.Point(6, 145);
            this.txtbox_Apellido.Name = "txtbox_Apellido";
            this.txtbox_Apellido.Size = new System.Drawing.Size(249, 22);
            this.txtbox_Apellido.TabIndex = 15;
            // 
            // txtbox_Nombre
            // 
            this.txtbox_Nombre.Location = new System.Drawing.Point(6, 87);
            this.txtbox_Nombre.Name = "txtbox_Nombre";
            this.txtbox_Nombre.Size = new System.Drawing.Size(249, 22);
            this.txtbox_Nombre.TabIndex = 14;
            // 
            // txtbox_ID
            // 
            this.txtbox_ID.Location = new System.Drawing.Point(6, 34);
            this.txtbox_ID.Name = "txtbox_ID";
            this.txtbox_ID.Size = new System.Drawing.Size(249, 22);
            this.txtbox_ID.TabIndex = 13;
            this.txtbox_ID.TextChanged += new System.EventHandler(this.txtbox_ID_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.pictureBox1.Location = new System.Drawing.Point(-7, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(813, 50);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(343, -2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 40);
            this.label5.TabIndex = 14;
            this.label5.Text = "DevEdu";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(279, 44);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(509, 394);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // txtCount
            // 
            this.txtCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCount.Location = new System.Drawing.Point(291, 60);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(100, 15);
            this.txtCount.TabIndex = 23;
            // 
            // DatagridMaestros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.txtFiltroMaestros);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DatagridMaestros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevEdu";
            this.Load += new System.EventHandler(this.DatagripMaestros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 251); this.ClientSize = new System.Drawing.Size(1240, 780); this.MinimumSize = new System.Drawing.Size(1080, 680); this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; this.Text = "Gestión de maestros | DevEdu";
            this.pictureBox1.Location = new System.Drawing.Point(0, 0); this.pictureBox1.Size = new System.Drawing.Size(1240, 92); this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right; this.label5.Text = "Gestión de maestros"; this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold); this.label5.Location = new System.Drawing.Point(32, 20); this.label5.AutoSize = true; this.pictureBox2.Visible = false; this.pictureBox1.SendToBack();
            this.groupBox1.Text = "Información del maestro"; this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold); this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84); this.groupBox1.Location = new System.Drawing.Point(28, 116); this.groupBox1.Size = new System.Drawing.Size(330, 610); this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.label1.Location = new System.Drawing.Point(20, 46); this.txtbox_ID.Location = new System.Drawing.Point(20, 68); this.txtbox_ID.Size = new System.Drawing.Size(286, 28); this.label2.Location = new System.Drawing.Point(20, 111); this.txtbox_Nombre.Location = new System.Drawing.Point(20, 133); this.txtbox_Nombre.Size = new System.Drawing.Size(286, 28); this.label3.Location = new System.Drawing.Point(20, 176); this.txtbox_Apellido.Location = new System.Drawing.Point(20, 198); this.txtbox_Apellido.Size = new System.Drawing.Size(286, 28); this.label4.Location = new System.Drawing.Point(20, 241); this.txtbox_Correo.Location = new System.Drawing.Point(20, 263); this.txtbox_Correo.Size = new System.Drawing.Size(286, 28);
            this.label8.Text = "Selecciona una fila de la tabla para cargar sus datos."; this.label8.Location = new System.Drawing.Point(20, 310); this.label8.Size = new System.Drawing.Size(286, 42); this.label8.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); this.label8.Font = new System.Drawing.Font("Segoe UI", 9F); this.label6.Text = "ACCIONES"; this.label6.Location = new System.Drawing.Point(20, 372); this.label6.Size = new System.Drawing.Size(286, 22); this.label6.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128); this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.btn_Editar.Location = new System.Drawing.Point(20, 410); this.btn_Editar.Size = new System.Drawing.Size(136, 42); this.btn_Editar.Text = "Guardar cambios"; this.btn_Mostrar.Location = new System.Drawing.Point(170, 410); this.btn_Mostrar.Size = new System.Drawing.Size(136, 42); this.btn_Mostrar.Text = "Actualizar lista"; this.label7.Text = "ELIMINAR"; this.label7.Location = new System.Drawing.Point(20, 474); this.label7.Size = new System.Drawing.Size(286, 22); this.label7.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28); this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold); this.btn_eliminar.Location = new System.Drawing.Point(20, 510); this.btn_eliminar.Size = new System.Drawing.Size(286, 42); this.btn_eliminar.Text = "Eliminar rol de maestro";
            this.txtCount.Location = new System.Drawing.Point(388, 119); this.txtCount.Size = new System.Drawing.Size(280, 25); this.txtCount.Font = new System.Drawing.Font("Segoe UI", 10F); this.txtCount.BackColor = this.BackColor; this.txtCount.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81); this.DataGrid.Location = new System.Drawing.Point(382, 154); this.DataGrid.Size = new System.Drawing.Size(824, 572); this.DataGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None; this.DataGrid.BackgroundColor = System.Drawing.Color.White; this.DataGrid.GridColor = System.Drawing.Color.FromArgb(229, 234, 242); this.DataGrid.EnableHeadersVisualStyles = false; this.DataGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 31, 84); this.DataGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White; this.DataGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold); this.DataGrid.ColumnHeadersHeight = 42; this.DataGrid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F); this.DataGrid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254); this.DataGrid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(17, 24, 39); this.DataGrid.RowTemplate.Height = 34; this.DataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ClientSize = new System.Drawing.Size(1240, 780); this.MinimumSize = new System.Drawing.Size(1080, 680); this.BackColor = System.Drawing.Color.FromArgb(245,247,251);
            this.pictureBox1.Location = new System.Drawing.Point(0,0); this.pictureBox1.Size = new System.Drawing.Size(1240,92); this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(0,31,84); this.pictureBox2.Location = new System.Drawing.Point(-200,-200); this.pictureBox2.Size = new System.Drawing.Size(1,1);
            this.label5.Text = "Gestión de maestros"; this.label5.Location = new System.Drawing.Point(32,20); this.label5.Font = new System.Drawing.Font("Segoe UI Semibold",22F,System.Drawing.FontStyle.Bold); this.label5.ForeColor = System.Drawing.Color.White; this.label5.BackColor = System.Drawing.Color.FromArgb(0,31,84);
            this.groupBox1.Text = "Información del maestro"; this.groupBox1.Location = new System.Drawing.Point(28,116); this.groupBox1.Size = new System.Drawing.Size(330,610); this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold",10F,System.Drawing.FontStyle.Bold); this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(0,31,84);
            this.txtbox_ID.Location = new System.Drawing.Point(20,68); this.txtbox_ID.Size = new System.Drawing.Size(286,28); this.txtbox_ID.Font = new System.Drawing.Font("Segoe UI",10F); this.txtbox_ID.BackColor = System.Drawing.Color.FromArgb(249,250,252); this.txtbox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(20,46); this.label1.ForeColor = System.Drawing.Color.FromArgb(0,31,84);
            this.txtbox_Nombre.Location = new System.Drawing.Point(20,133); this.txtbox_Nombre.Size = new System.Drawing.Size(286,28); this.txtbox_Nombre.Font = new System.Drawing.Font("Segoe UI",10F); this.txtbox_Nombre.BackColor = System.Drawing.Color.FromArgb(249,250,252); this.txtbox_Nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(20,111); this.label2.ForeColor = System.Drawing.Color.FromArgb(0,31,84);
            this.txtbox_Apellido.Location = new System.Drawing.Point(20,198); this.txtbox_Apellido.Size = new System.Drawing.Size(286,28); this.txtbox_Apellido.Font = new System.Drawing.Font("Segoe UI",10F); this.txtbox_Apellido.BackColor = System.Drawing.Color.FromArgb(249,250,252); this.txtbox_Apellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(20,176); this.label3.ForeColor = System.Drawing.Color.FromArgb(0,31,84);
            this.txtbox_Correo.Location = new System.Drawing.Point(20,263); this.txtbox_Correo.Size = new System.Drawing.Size(286,28); this.txtbox_Correo.Font = new System.Drawing.Font("Segoe UI",10F); this.txtbox_Correo.BackColor = System.Drawing.Color.FromArgb(249,250,252); this.txtbox_Correo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(20,241); this.label4.ForeColor = System.Drawing.Color.FromArgb(0,31,84);
            this.label8.Text = "Selecciona una fila de la tabla para cargar sus datos."; this.label8.Location = new System.Drawing.Point(20,310); this.label8.Size = new System.Drawing.Size(286,42); this.label8.ForeColor = System.Drawing.Color.FromArgb(100,116,139);
            this.label6.Text = "ACCIONES"; this.label6.Location = new System.Drawing.Point(20,372); this.label6.Size = new System.Drawing.Size(286,22); this.label6.ForeColor = System.Drawing.Color.FromArgb(100,116,139);
            this.btn_Editar.Text = "Guardar cambios"; this.btn_Editar.Location = new System.Drawing.Point(20,410); this.btn_Editar.Size = new System.Drawing.Size(136,42);
            this.btn_Mostrar.Text = "Actualizar lista"; this.btn_Mostrar.Location = new System.Drawing.Point(170,410); this.btn_Mostrar.Size = new System.Drawing.Size(136,42);
            this.label7.Text = "ELIMINAR"; this.label7.Location = new System.Drawing.Point(20,474); this.label7.Size = new System.Drawing.Size(286,22); this.label7.ForeColor = System.Drawing.Color.FromArgb(185,28,28);
            this.btn_eliminar.Text = "Eliminar rol de maestro"; this.btn_eliminar.Location = new System.Drawing.Point(20,510); this.btn_eliminar.Size = new System.Drawing.Size(286,42); this.btn_eliminar.BackColor = System.Drawing.Color.FromArgb(254,226,226); this.btn_eliminar.ForeColor = System.Drawing.Color.FromArgb(185,28,28); this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btn_eliminar.FlatAppearance.BorderSize = 0;
            this.txtCount.Location = new System.Drawing.Point(388,119); this.txtCount.Size = new System.Drawing.Size(280,25); this.txtCount.Font = new System.Drawing.Font("Segoe UI",10F); this.txtCount.BackColor = System.Drawing.Color.FromArgb(245,247,251);
            this.DataGrid.Location = new System.Drawing.Point(382,154); this.DataGrid.Size = new System.Drawing.Size(824,572); this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None; this.DataGrid.BackgroundColor = System.Drawing.Color.White; this.DataGrid.GridColor = System.Drawing.Color.FromArgb(229,234,242); this.DataGrid.EnableHeadersVisualStyles = false; this.DataGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0,31,84); this.DataGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White; this.DataGrid.ColumnHeadersHeight = 42; this.DataGrid.RowTemplate.Height = 34;
             this.txtFiltroMaestros.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
             this.txtFiltroMaestros.Location = new System.Drawing.Point(700, 116);
             this.txtFiltroMaestros.Name = "txtFiltroMaestros";
             this.txtFiltroMaestros.PlaceholderText = "Filtrar por ID, nombre, apellido, correo o rango";
             this.txtFiltroMaestros.Size = new System.Drawing.Size(506, 22);
             this.txtFiltroMaestros.TabIndex = 23;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtbox_Apellido;
        private System.Windows.Forms.TextBox txtbox_Nombre;
        private System.Windows.Forms.TextBox txtbox_ID;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Mostrar;
        private System.Windows.Forms.TextBox txtbox_Correo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtFiltroMaestros;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}