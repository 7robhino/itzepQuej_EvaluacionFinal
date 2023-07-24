using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anaisisVisualizacionDatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool alternateColor = false;
        private Random random = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //caputrar paosicion y tama;o antes de maximizar pra restaurar
        int lx, ly;
        int ancho, alto;

        private void btnNormal_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnNormal.Visible = false;
            this.Size = new Size(ancho, alto);
            this.Location = new Point(lx, ly);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox2.Text, out float result))
            {
                string label = textBox3.Text;

                chart1.Series["f1"].Points.AddXY(chart1.Series["f1"].Points.Count, result); // Agregar el punto en la gráfica con coordenadas (x, result)
                chart1.Series["f1"].Points[chart1.Series["f1"].Points.Count - 1].AxisLabel = label;
                textBox2.Clear(); // Limpiar el TextBox para permitir nuevas entradas
                textBox3.Clear();

                // Cambiar el color de la última columna agregada
                if (chart1.Series["f1"].Points.Count > 0)
                {

                    int lastIndex = chart1.Series["f1"].Points.Count - 1;
                    chart1.Series["f1"].Points[lastIndex].Color = GetRandomColor();
                    alternateColor = !alternateColor;
                }
            }
            else
            {

                MessageBox.Show("Ingresa un valor válido en el TextBox."); // Mostrar un mensaje de error si el valor ingresado no es válido
            }
        }

        private Color GetRandomColor()
        {
            List<Color> colorsList = new List<Color>
    {
        RGBColors.color1,
        RGBColors.color2,
        RGBColors.color3,
        RGBColors.color4,
        RGBColors.color5,
        RGBColors.color6
    };

            int randomIndex = random.Next(colorsList.Count);
            return colorsList[randomIndex];
        }

        public static class RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox4.Text);
            string b = textBox1.Text;
            

            int n = dataGridView1.Rows.Add();

            if (textBox1.Text != " " && textBox4.Text != " ")
            {
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox4.Text;
            


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            ancho = this.Size.Width;
            alto = this.Size.Height;
            btnMaximizar.Visible = false;
            btnNormal.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;//Obtener tamanio de pantalla
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
