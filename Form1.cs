using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace curs
{
    public partial class Form1 : Form
    {
        private GraphCore graph;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox(
                "Введите размер матрицы (n):", "Ручной ввод", "5");
            if (int.TryParse(input, out int n) && n > 0)
            {
                graph = new GraphCore(n);
                Form2 f2 = new Form2(graph, true);
                f2.ShowDialog();
            }
        }

        private void btnFromFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var lines = System.IO.File.ReadAllLines(ofd.FileName);
                    int n = int.Parse(lines[0]);
                    graph = new GraphCore(n);

                    for (int i = 0; i < n; i++)
                    {
                        var parts = lines[i + 1].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < n; j++)
                            graph.vertex[i][j] = int.Parse(parts[j]);
                    }

                    Form2 f2 = new Form2(graph, false);
                    f2.ShowDialog();
                }
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox(
                "Введите размер матрицы (n):", "Случайная генерация", "5");
            if (int.TryParse(input, out int n) && n > 0)
            {
                graph = new GraphCore(n);
                Random rnd = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = i; j < n; j++)
                    {
                        if (i == j)
                        {
                            graph.vertex[i][j] = 0;
                        }
                        else
                        {
                            int v = (rnd.Next(100) < 25) ? 1 : 0; 
                            graph.vertex[i][j] = v;
                            graph.vertex[j][i] = v;
                        }
                    }
                }

                Form2 f2 = new Form2(graph, false);
                f2.ShowDialog();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void closeMenu_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Goodbye mate");
            this.Close();
        }
    }
}
