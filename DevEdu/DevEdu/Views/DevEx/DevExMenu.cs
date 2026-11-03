using System;
using System.Drawing;
using System.Windows.Forms;

namespace DevEdu
{
    public sealed class DevExMenu : Form
    {
        private static readonly Color Navy = Color.FromArgb(0, 31, 84);
        private static readonly Color Ink = Color.FromArgb(31, 41, 55);
        private static readonly Color Muted = Color.FromArgb(100, 116, 139);
        private static readonly Color Canvas = Color.FromArgb(245, 247, 251);

        public DevExMenu()
        {
            Text = "DevEx | Ejercicios";
            ClientSize = new Size(1040, 720);
            MinimumSize = new Size(1040, 720);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Canvas;
            Font = new Font("Segoe UI", 10F);

            CrearEncabezado();
            CrearIntroduccion();

            CrearTarjeta(
                "01", "Ciclos y secuencias",
                "Recorre una secuencia y descubre cómo funciona el límite de range.",
                "INICIAL", Color.FromArgb(0, 31, 84), 60, 232,
                () => Abrir(new DevEx1()));

            CrearTarjeta(
                "02", "Acumuladores",
                "Sigue una suma paso a paso y calcula el resultado de cada vuelta.",
                "BÁSICO", Color.FromArgb(20, 52, 101), 540, 232,
                () => Abrir(new DevEx2()));

            CrearTarjeta(
                "03", "Condiciones y pares",
                "Usa una condición para identificar pares y acumular resultados.",
                "INTERMEDIO", Color.FromArgb(37, 99, 235), 60, 432,
                () => Abrir(new DevEx3()));

            CrearTarjeta(
                "04", "Ciclos anidados",
                "Combina filas y columnas para calcular productos en una tabla.",
                "DESAFÍO", Color.FromArgb(59, 130, 246), 540, 432,
                () => Abrir(new DevEx4()));

            var footer = new Label
            {
                Text = "Cada ejercicio incluye una explicación paso a paso.",
                AutoSize = true,
                ForeColor = Muted,
                Font = new Font("Segoe UI", 9.5F),
                Location = new Point(62, 650)
            };
            Controls.Add(footer);
        }

        private void CrearEncabezado()
        {
            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 78,
                BackColor = Navy
            };

            var brand = new Label
            {
                Text = "DevEx",
                AutoSize = true,
                Location = new Point(32, 10),
                ForeColor = Color.White,
                BackColor = Navy,
                Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold)
            };

            var descriptor = new Label
            {
                Text = "PRÁCTICA DE PROGRAMACIÓN",
                AutoSize = true,
                Location = new Point(36, 48),
                ForeColor = Color.FromArgb(191, 219, 254),
                BackColor = Navy,
                Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold)
            };

            var back = new Button
            {
                Text = "←  Menú principal",
                Location = new Point(850, 19),
                Size = new Size(160, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(20, 52, 101),
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            back.FlatAppearance.BorderSize = 0;
            back.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 68, 120);
            back.Click += (_, _) => Close();

            header.Controls.Add(brand);
            header.Controls.Add(descriptor);
            header.Controls.Add(back);
            Controls.Add(header);
        }

        private void CrearIntroduccion()
        {
            Controls.Add(new Label
            {
                Text = "RUTA DE APRENDIZAJE",
                AutoSize = true,
                Location = new Point(62, 103),
                ForeColor = Color.FromArgb(37, 99, 235),
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold)
            });

            Controls.Add(new Label
            {
                Text = "Elige tu próximo reto",
                AutoSize = true,
                Location = new Point(60, 124),
                ForeColor = Navy,
                Font = new Font("Segoe UI Semibold", 25F, FontStyle.Bold)
            });

            Controls.Add(new Label
            {
                Text = "Avanza a tu ritmo: cada ejercicio practica una idea nueva y explica cómo resolverla.",
                AutoSize = true,
                Location = new Point(62, 174),
                ForeColor = Muted,
                Font = new Font("Segoe UI", 10.5F)
            });
        }

        private void CrearTarjeta(
            string numero,
            string titulo,
            string descripcion,
            string nivel,
            Color acento,
            int x,
            int y,
            Action abrir)
        {
            var tarjeta = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(440, 180),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            var franja = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(6, 178),
                BackColor = acento
            };

            var insignia = new Label
            {
                Text = numero,
                Location = new Point(24, 22),
                Size = new Size(48, 48),
                BackColor = Color.FromArgb(239, 246, 255),
                ForeColor = acento,
                Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            var heading = new Label
            {
                Text = titulo,
                Location = new Point(88, 22),
                Size = new Size(320, 31),
                ForeColor = Navy,
                Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            var detail = new Label
            {
                Text = descripcion,
                Location = new Point(88, 59),
                Size = new Size(320, 46),
                ForeColor = Ink,
                Font = new Font("Segoe UI", 9.5F),
                Cursor = Cursors.Hand
            };

            var level = new Label
            {
                Text = nivel,
                Location = new Point(88, 128),
                Size = new Size(118, 25),
                BackColor = Color.FromArgb(241, 245, 249),
                ForeColor = Muted,
                Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            var open = new Button
            {
                Text = "Abrir  →",
                Location = new Point(284, 123),
                Size = new Size(124, 34),
                BackColor = Navy,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            open.FlatAppearance.BorderSize = 0;
            open.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 52, 101);
            open.Click += (_, _) => abrir();

            tarjeta.Controls.Add(franja);
            tarjeta.Controls.Add(insignia);
            tarjeta.Controls.Add(heading);
            tarjeta.Controls.Add(detail);
            tarjeta.Controls.Add(level);
            tarjeta.Controls.Add(open);

            tarjeta.Click += (_, _) => abrir();
            insignia.Click += (_, _) => abrir();
            heading.Click += (_, _) => abrir();
            detail.Click += (_, _) => abrir();
            level.Click += (_, _) => abrir();

            void Resaltar(bool activo)
            {
                tarjeta.BackColor = activo
                    ? Color.FromArgb(249, 251, 255)
                    : Color.White;
            }

            tarjeta.MouseEnter += (_, _) => Resaltar(true);
            tarjeta.MouseLeave += (_, _) => Resaltar(false);
            insignia.MouseEnter += (_, _) => Resaltar(true);
            heading.MouseEnter += (_, _) => Resaltar(true);
            detail.MouseEnter += (_, _) => Resaltar(true);
            level.MouseEnter += (_, _) => Resaltar(true);

            Controls.Add(tarjeta);
        }

        private void InitializeComponent()
        {

        }

        private void Abrir(Form ejercicio)
        {
            Hide();
            using (ejercicio)
            {
                ejercicio.ShowDialog(this);
            }
            Show();
            Activate();
        }
    }
}
