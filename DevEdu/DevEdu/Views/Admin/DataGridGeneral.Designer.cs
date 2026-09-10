namespace DevEdu
{
    partial class DataGridGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGridGeneral));
            this.DgvGeneral = new System.Windows.Forms.DataGridView();
            this.btnAsignarAlumnos = new System.Windows.Forms.Button();
            this.btnQuitarRol = new System.Windows.Forms.Button();
            this.btnAsignarMaestro = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAsignarAdmin = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvGeneral
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.DgvGeneral.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvGeneral.BackgroundColor = System.Drawing.Color.White;
            this.DgvGeneral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvGeneral.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGeneral.Location = new System.Drawing.Point(257, 87);
            this.DgvGeneral.Name = "DgvGeneral";
            this.DgvGeneral.Size = new System.Drawing.Size(517, 329);
            this.DgvGeneral.TabIndex = 0;
            // 
            // btnAsignarAlumnos
            // 
            this.btnAsignarAlumnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.btnAsignarAlumnos.ForeColor = System.Drawing.Color.White;
            this.btnAsignarAlumnos.Location = new System.Drawing.Point(12, 119);
            this.btnAsignarAlumnos.Name = "btnAsignarAlumnos";
            this.btnAsignarAlumnos.Size = new System.Drawing.Size(204, 34);
            this.btnAsignarAlumnos.TabIndex = 2;
            this.btnAsignarAlumnos.Text = "  Asignar Alumno";
            this.btnAsignarAlumnos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarAlumnos.UseVisualStyleBackColor = false;
            this.btnAsignarAlumnos.Click += new System.EventHandler(this.btnAsignarAlumnos_Click);
            // 
            // btnQuitarRol
            // 
            this.btnQuitarRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.btnQuitarRol.ForeColor = System.Drawing.Color.White;
            this.btnQuitarRol.Location = new System.Drawing.Point(12, 239);
            this.btnQuitarRol.Name = "btnQuitarRol";
            this.btnQuitarRol.Size = new System.Drawing.Size(204, 34);
            this.btnQuitarRol.TabIndex = 3;
            this.btnQuitarRol.Text = "  Quitar Rol";
            this.btnQuitarRol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitarRol.UseVisualStyleBackColor = false;
            this.btnQuitarRol.Click += new System.EventHandler(this.btnQuitarRol_Click);
            // 
            // btnAsignarMaestro
            // 
            this.btnAsignarMaestro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.btnAsignarMaestro.ForeColor = System.Drawing.Color.White;
            this.btnAsignarMaestro.Location = new System.Drawing.Point(12, 159);
            this.btnAsignarMaestro.Name = "btnAsignarMaestro";
            this.btnAsignarMaestro.Size = new System.Drawing.Size(204, 34);
            this.btnAsignarMaestro.TabIndex = 3;
            this.btnAsignarMaestro.Text = "  Asignar Maestro";
            this.btnAsignarMaestro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarMaestro.UseVisualStyleBackColor = false;
            this.btnAsignarMaestro.Click += new System.EventHandler(this.btnAsignarMaestro_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(12, 306);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(204, 34);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "  Eliminar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(12, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 34);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.pictureBox1.Location = new System.Drawing.Point(-2, -8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(813, 50);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(337, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 40);
            this.label5.TabIndex = 15;
            this.label5.Text = "DevEdu";
            // 
            // btnAsignarAdmin
            // 
            this.btnAsignarAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.btnAsignarAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAsignarAdmin.Location = new System.Drawing.Point(12, 199);
            this.btnAsignarAdmin.Name = "btnAsignarAdmin";
            this.btnAsignarAdmin.Size = new System.Drawing.Size(204, 34);
            this.btnAsignarAdmin.TabIndex = 16;
            this.btnAsignarAdmin.Text = "  Asignar Admin";
            this.btnAsignarAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarAdmin.UseVisualStyleBackColor = false;
            this.btnAsignarAdmin.Click += new System.EventHandler(this.btnAsignarAdmin_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(12, 59);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(204, 34);
            this.btnAgregar.TabIndex = 17;
            this.btnAgregar.Text = "  Agregar Usuario";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnAsignarAlumnos);
            this.groupBox1.Controls.Add(this.btnAsignarMaestro);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAsignarAdmin);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.btnQuitarRol);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 390);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestion";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(84)))));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(117, 21);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(99, 34);
            this.btnActualizar.TabIndex = 25;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 39);
            this.label3.TabIndex = 24;
            this.label3.Text = "Selecciona un usuario en la tabla para \r\nver/editar sus datos en el panel izquier" +
    "do\r\nY en la tabla.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "_Peligro_______________________";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "_Roles________________________";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(244, 51);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(544, 387);
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // txtCount
            // 
            this.txtCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCount.Location = new System.Drawing.Point(257, 66);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(100, 15);
            this.txtCount.TabIndex = 22;
            // 
            // DataGridGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DgvGeneral);
            this.Controls.Add(this.pictureBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataGridGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevEdu";
            this.Load += new System.EventHandler(this.DataDridGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvGeneral;
        private System.Windows.Forms.Button btnAsignarAlumnos;
        private System.Windows.Forms.Button btnQuitarRol;
        private System.Windows.Forms.Button btnAsignarMaestro;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAsignarAdmin;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button btnActualizar;
    }
}