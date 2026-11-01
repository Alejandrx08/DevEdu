namespace DevEdu
{
    partial class FrmMainMenu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel cardTrivia;
        private System.Windows.Forms.Panel cardEx;
        private System.Windows.Forms.Panel cardVis;
        private System.Windows.Forms.Panel cardBot;
        private System.Windows.Forms.Panel cardHub;
        private System.Windows.Forms.Button btn_DevTrivia;
        private System.Windows.Forms.Button btn_DevEx;
        private System.Windows.Forms.Button btn_DevVis;
        private System.Windows.Forms.Button btn_DevBot;
        private System.Windows.Forms.Button btn_DevHub;
        private System.Windows.Forms.Label Exp_Trivia;
        private System.Windows.Forms.Label Exp_Ex;
        private System.Windows.Forms.Label Exp_Vis;
        private System.Windows.Forms.Label Exp_Bot;
        private System.Windows.Forms.Label Exp_Hub;
        private System.Windows.Forms.Label Trivia_Txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maestrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bItacoraToolStripMenuItem;
        private System.Windows.Forms.Button button1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainMenu));
            panelHeader = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            maestrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            alumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            bItacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            button1 = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            cardTrivia = new System.Windows.Forms.Panel();
            btn_DevTrivia = new System.Windows.Forms.Button();
            Trivia_Txt = new System.Windows.Forms.Label();
            Exp_Trivia = new System.Windows.Forms.Label();
            cardEx = new System.Windows.Forms.Panel();
            btn_DevEx = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            Exp_Ex = new System.Windows.Forms.Label();
            cardVis = new System.Windows.Forms.Panel();
            btn_DevVis = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            Exp_Vis = new System.Windows.Forms.Label();
            cardBot = new System.Windows.Forms.Panel();
            btn_DevBot = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            Exp_Bot = new System.Windows.Forms.Label();
            cardHub = new System.Windows.Forms.Panel();
            btn_DevHub = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            Exp_Hub = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            panelHeader.SuspendLayout();
            menuStrip1.SuspendLayout();
            cardTrivia.SuspendLayout();
            cardEx.SuspendLayout();
            cardVis.SuspendLayout();
            cardBot.SuspendLayout();
            cardHub.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(menuStrip1);
            panelHeader.Controls.Add(button1);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1180, 82);
            panelHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(30, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(131, 45);
            label1.TabIndex = 0;
            label1.Text = "DevEdu";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.Color.White;
            menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { usuariosToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(875, 28);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            menuStrip1.Size = new System.Drawing.Size(92, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "Administración";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { maestrosToolStripMenuItem, alumnosToolStripMenuItem, generalToolStripMenuItem, bItacoraToolStripMenuItem });
            usuariosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            usuariosToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            usuariosToolStripMenuItem.Text = "Administrar";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // maestrosToolStripMenuItem
            // 
            maestrosToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            maestrosToolStripMenuItem.Name = "maestrosToolStripMenuItem";
            maestrosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            maestrosToolStripMenuItem.Text = "Maestros";
            maestrosToolStripMenuItem.Click += maestrosToolStripMenuItem_Click;
            // 
            // alumnosToolStripMenuItem
            // 
            alumnosToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            alumnosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            alumnosToolStripMenuItem.Text = "Alumnos";
            alumnosToolStripMenuItem.Click += alumnosToolStripMenuItem_Click_1;
            // 
            // generalToolStripMenuItem
            // 
            generalToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            generalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            generalToolStripMenuItem.Text = "General";
            generalToolStripMenuItem.Click += generalToolStripMenuItem_Click;
            // 
            // bItacoraToolStripMenuItem
            // 
            bItacoraToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            bItacoraToolStripMenuItem.Name = "bItacoraToolStripMenuItem";
            bItacoraToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            bItacoraToolStripMenuItem.Text = "Bitácora";
            bItacoraToolStripMenuItem.Click += bItacoraToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.White;
            button1.Cursor = System.Windows.Forms.Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            button1.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            button1.Location = new System.Drawing.Point(1028, 28);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(93, 24);
            button1.TabIndex = 2;
            button1.Text = "Cerrar sesión";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 21F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            label2.Location = new System.Drawing.Point(80, 100);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(1020, 42);
            label2.TabIndex = 3;
            label2.Text = "¡Bienvenido! ¿Qué te gustaría aprender hoy?";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardTrivia
            // 
            cardTrivia.BackColor = System.Drawing.Color.White;
            cardTrivia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cardTrivia.Controls.Add(btn_DevTrivia);
            cardTrivia.Controls.Add(Trivia_Txt);
            cardTrivia.Controls.Add(Exp_Trivia);
            cardTrivia.Location = new System.Drawing.Point(42, 190);
            cardTrivia.Name = "cardTrivia";
            cardTrivia.Size = new System.Drawing.Size(320, 230);
            cardTrivia.TabIndex = 4;
            // 
            // btn_DevTrivia
            // 
            btn_DevTrivia.BackColor = System.Drawing.Color.White;
            btn_DevTrivia.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_DevTrivia.FlatAppearance.BorderSize = 0;
            btn_DevTrivia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_DevTrivia.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            btn_DevTrivia.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            btn_DevTrivia.Location = new System.Drawing.Point(18, 48);
            btn_DevTrivia.Name = "btn_DevTrivia";
            btn_DevTrivia.Size = new System.Drawing.Size(284, 50);
            btn_DevTrivia.TabIndex = 0;
            btn_DevTrivia.Text = "DevTrivia";
            btn_DevTrivia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_DevTrivia.UseVisualStyleBackColor = false;
            btn_DevTrivia.Click += btn_DevTrivia_Click;
            // 
            // Trivia_Txt
            // 
            Trivia_Txt.BackColor = System.Drawing.Color.White;
            Trivia_Txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            Trivia_Txt.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            Trivia_Txt.Location = new System.Drawing.Point(22, 108);
            Trivia_Txt.Name = "Trivia_Txt";
            Trivia_Txt.Size = new System.Drawing.Size(276, 54);
            Trivia_Txt.TabIndex = 1;
            Trivia_Txt.Text = "¡Ponte a prueba con preguntas de programación divertidas y desafiantes!";
            // 
            // Exp_Trivia
            // 
            Exp_Trivia.BackColor = System.Drawing.Color.FromArgb(232, 239, 249);
            Exp_Trivia.Cursor = System.Windows.Forms.Cursors.Hand;
            Exp_Trivia.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            Exp_Trivia.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            Exp_Trivia.Location = new System.Drawing.Point(22, 180);
            Exp_Trivia.Name = "Exp_Trivia";
            Exp_Trivia.Size = new System.Drawing.Size(276, 36);
            Exp_Trivia.TabIndex = 2;
            Exp_Trivia.Text = "Explorar módulo →";
            Exp_Trivia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Exp_Trivia.Click += label3_Click;
            // 
            // cardEx
            // 
            cardEx.BackColor = System.Drawing.Color.White;
            cardEx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cardEx.Controls.Add(btn_DevEx);
            cardEx.Controls.Add(label4);
            cardEx.Controls.Add(Exp_Ex);
            cardEx.Location = new System.Drawing.Point(430, 190);
            cardEx.Name = "cardEx";
            cardEx.Size = new System.Drawing.Size(320, 230);
            cardEx.TabIndex = 5;
            // 
            // btn_DevEx
            // 
            btn_DevEx.BackColor = System.Drawing.Color.White;
            btn_DevEx.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_DevEx.FlatAppearance.BorderSize = 0;
            btn_DevEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_DevEx.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            btn_DevEx.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            btn_DevEx.Location = new System.Drawing.Point(18, 48);
            btn_DevEx.Name = "btn_DevEx";
            btn_DevEx.Size = new System.Drawing.Size(284, 50);
            btn_DevEx.TabIndex = 0;
            btn_DevEx.Text = "DevEx";
            btn_DevEx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_DevEx.UseVisualStyleBackColor = false;
            btn_DevEx.Click += btn_DevEx_Click;
            // 
            // label4
            // 
            label4.BackColor = System.Drawing.Color.White;
            label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            label4.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            label4.Location = new System.Drawing.Point(22, 108);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(276, 54);
            label4.TabIndex = 1;
            label4.Text = "Explora ejercicios prácticos y desafíos para mejorar tus habilidades.";
            // 
            // Exp_Ex
            // 
            Exp_Ex.BackColor = System.Drawing.Color.FromArgb(232, 239, 249);
            Exp_Ex.Cursor = System.Windows.Forms.Cursors.Hand;
            Exp_Ex.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            Exp_Ex.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            Exp_Ex.Location = new System.Drawing.Point(22, 180);
            Exp_Ex.Name = "Exp_Ex";
            Exp_Ex.Size = new System.Drawing.Size(276, 36);
            Exp_Ex.TabIndex = 2;
            Exp_Ex.Text = "Explorar módulo →";
            Exp_Ex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Exp_Ex.Click += Exp_Ex_Click;
            // 
            // cardVis
            // 
            cardVis.BackColor = System.Drawing.Color.White;
            cardVis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cardVis.Controls.Add(btn_DevVis);
            cardVis.Controls.Add(label5);
            cardVis.Controls.Add(Exp_Vis);
            cardVis.Location = new System.Drawing.Point(818, 190);
            cardVis.Name = "cardVis";
            cardVis.Size = new System.Drawing.Size(320, 230);
            cardVis.TabIndex = 6;
            // 
            // btn_DevVis
            // 
            btn_DevVis.BackColor = System.Drawing.Color.White;
            btn_DevVis.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_DevVis.FlatAppearance.BorderSize = 0;
            btn_DevVis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_DevVis.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            btn_DevVis.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            btn_DevVis.Location = new System.Drawing.Point(18, 48);
            btn_DevVis.Name = "btn_DevVis";
            btn_DevVis.Size = new System.Drawing.Size(284, 50);
            btn_DevVis.TabIndex = 0;
            btn_DevVis.Text = "DevVis";
            btn_DevVis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_DevVis.UseVisualStyleBackColor = false;
            btn_DevVis.Click += btn_DevVis_Click;
            // 
            // label5
            // 
            label5.BackColor = System.Drawing.Color.White;
            label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            label5.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            label5.Location = new System.Drawing.Point(22, 108);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(276, 54);
            label5.TabIndex = 1;
            label5.Text = "Visualiza conceptos de programación con animaciones interactivas.";
            // 
            // Exp_Vis
            // 
            Exp_Vis.BackColor = System.Drawing.Color.FromArgb(232, 239, 249);
            Exp_Vis.Cursor = System.Windows.Forms.Cursors.Hand;
            Exp_Vis.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            Exp_Vis.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            Exp_Vis.Location = new System.Drawing.Point(22, 180);
            Exp_Vis.Name = "Exp_Vis";
            Exp_Vis.Size = new System.Drawing.Size(276, 36);
            Exp_Vis.TabIndex = 2;
            Exp_Vis.Text = "Explorar módulo →";
            Exp_Vis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Exp_Vis.Click += Exp_Vis_Click;
            // 
            // cardBot
            // 
            cardBot.BackColor = System.Drawing.Color.White;
            cardBot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cardBot.Controls.Add(btn_DevBot);
            cardBot.Controls.Add(label6);
            cardBot.Controls.Add(Exp_Bot);
            cardBot.Location = new System.Drawing.Point(236, 452);
            cardBot.Name = "cardBot";
            cardBot.Size = new System.Drawing.Size(320, 230);
            cardBot.TabIndex = 7;
            // 
            // btn_DevBot
            // 
            btn_DevBot.BackColor = System.Drawing.Color.White;
            btn_DevBot.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_DevBot.FlatAppearance.BorderSize = 0;
            btn_DevBot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_DevBot.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            btn_DevBot.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            btn_DevBot.Location = new System.Drawing.Point(18, 48);
            btn_DevBot.Name = "btn_DevBot";
            btn_DevBot.Size = new System.Drawing.Size(284, 50);
            btn_DevBot.TabIndex = 0;
            btn_DevBot.Text = "DevBot";
            btn_DevBot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_DevBot.UseVisualStyleBackColor = false;
            btn_DevBot.Click += btn_DevBot_Click;
            // 
            // label6
            // 
            label6.BackColor = System.Drawing.Color.White;
            label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            label6.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            label6.Location = new System.Drawing.Point(22, 108);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(276, 54);
            label6.TabIndex = 1;
            label6.Text = "Chatea con un bot inteligente que te ayuda a programar.";
            // 
            // Exp_Bot
            // 
            Exp_Bot.BackColor = System.Drawing.Color.FromArgb(232, 239, 249);
            Exp_Bot.Cursor = System.Windows.Forms.Cursors.Hand;
            Exp_Bot.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            Exp_Bot.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            Exp_Bot.Location = new System.Drawing.Point(22, 180);
            Exp_Bot.Name = "Exp_Bot";
            Exp_Bot.Size = new System.Drawing.Size(276, 36);
            Exp_Bot.TabIndex = 2;
            Exp_Bot.Text = "Explorar módulo →";
            Exp_Bot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Exp_Bot.Click += label6_Click;
            // 
            // cardHub
            // 
            cardHub.BackColor = System.Drawing.Color.White;
            cardHub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cardHub.Controls.Add(btn_DevHub);
            cardHub.Controls.Add(label7);
            cardHub.Controls.Add(Exp_Hub);
            cardHub.Location = new System.Drawing.Point(624, 452);
            cardHub.Name = "cardHub";
            cardHub.Size = new System.Drawing.Size(320, 230);
            cardHub.TabIndex = 8;
            // 
            // btn_DevHub
            // 
            btn_DevHub.BackColor = System.Drawing.Color.White;
            btn_DevHub.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_DevHub.FlatAppearance.BorderSize = 0;
            btn_DevHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_DevHub.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            btn_DevHub.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            btn_DevHub.Location = new System.Drawing.Point(18, 48);
            btn_DevHub.Name = "btn_DevHub";
            btn_DevHub.Size = new System.Drawing.Size(284, 50);
            btn_DevHub.TabIndex = 0;
            btn_DevHub.Text = "DevHub";
            btn_DevHub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_DevHub.UseVisualStyleBackColor = false;
            btn_DevHub.Click += btn_DevHub_Click;
            // 
            // label7
            // 
            label7.BackColor = System.Drawing.Color.White;
            label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            label7.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            label7.Location = new System.Drawing.Point(22, 108);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(276, 54);
            label7.TabIndex = 1;
            label7.Text = "Conéctate con otros estudiantes, comparte y aprende en comunidad.";
            // 
            // Exp_Hub
            // 
            Exp_Hub.BackColor = System.Drawing.Color.FromArgb(232, 239, 249);
            Exp_Hub.Cursor = System.Windows.Forms.Cursors.Hand;
            Exp_Hub.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            Exp_Hub.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            Exp_Hub.Location = new System.Drawing.Point(22, 180);
            Exp_Hub.Name = "Exp_Hub";
            Exp_Hub.Size = new System.Drawing.Size(276, 36);
            Exp_Hub.TabIndex = 2;
            Exp_Hub.Text = "Explorar módulo →";
            Exp_Hub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Exp_Hub.Click += Exp_Hub_Click;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            label3.Location = new System.Drawing.Point(0, 775);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(1180, 24);
            label3.TabIndex = 9;
            label3.Text = "DevEdu · Aprende, practica y comparte";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMainMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            ClientSize = new System.Drawing.Size(1180, 820);
            Controls.Add(label3);
            Controls.Add(cardHub);
            Controls.Add(cardBot);
            Controls.Add(cardVis);
            Controls.Add(cardEx);
            Controls.Add(cardTrivia);
            Controls.Add(label2);
            Controls.Add(panelHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimumSize = new System.Drawing.Size(1180, 820);
            Name = "FrmMainMenu";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DevEdu | Menú principal";
            Load += FrmMainMenu_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            cardTrivia.ResumeLayout(false);
            cardEx.ResumeLayout(false);
            cardVis.ResumeLayout(false);
            cardBot.ResumeLayout(false);
            cardHub.ResumeLayout(false);
            ResumeLayout(false);
        }

    }
}