using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;


namespace curs
{
    public partial class Form3 : Form
    {
        private GraphCore graph;

        public Form3(GraphCore g)
        {
            InitializeComponent();
            graph = g;
            ShowResult();
        }

        private void ShowResult()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Размер наибольшего паросочетания: " + (graph.most_step + 1));
            sb.AppendLine();
            sb.AppendLine("Рёбра паросочетания:");

            if (graph.most_set.Count > 0)
            {
                var best = graph.most_set[0]; 
                for (int k = 0; k < best.Length; k++)
                {
                    int edgeIndex = best[k];
                    int u = graph.num_reb[1][edgeIndex] + 1;
                    int v = graph.num_reb[2][edgeIndex] + 1;
                    sb.AppendLine($"{u} - {v}");
                }
            }
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("Координаты рёбер:");
            for (int e = 0; e < graph.max; e++)
            {
                sb.AppendLine($"{e + 1} {graph.num_reb[1][e] + 1} {graph.num_reb[2][e] + 1}");
            }
            sb.AppendLine();

            sb.AppendLine("Матрица смежности рёбер:");
            for (int i = 0; i < graph.max; i++)
            {
                for (int j = 0; j < graph.max; j++)
                {
                    sb.Append(graph.max_mas[i][j]);
                    if (j < graph.max - 1) sb.Append(" ");
                }
                sb.AppendLine();
            }
            sb.AppendLine();

            sb.AppendLine("Номера рёбер паросочетания:");
            if (graph.most_set.Count > 0)
            {
                var best = graph.most_set[0];
                for (int k = 0; k < best.Length; k++)
                    sb.AppendLine((best[k] + 1).ToString());
            }

            txtResult.Text = sb.ToString();
        }

        private string BuildResultText()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Матрица:");
            int n = graph.n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sb.Append(graph.vertex[i][j]);
                    if (j < n - 1) sb.Append(" ");
                }
                sb.AppendLine();
            }

            sb.AppendLine();
            sb.AppendLine("Размер наибольшего паросочетания: " + (graph.most_step + 1));
            sb.AppendLine();
            sb.AppendLine("Рёбра паросочетания:");

            if (graph.most_set.Count > 0)
            {
                var best = graph.most_set[0];
                for (int k = 0; k < best.Length; k++)
                {
                    int edgeIndex = best[k];
                    int u = graph.num_reb[1][edgeIndex] + 1;
                    int v = graph.num_reb[2][edgeIndex] + 1;
                    sb.AppendLine($"{u} - {v}");
                }
            }
            sb.AppendLine("Координаты рёбер:");
            for (int e = 0; e < graph.max; e++)
            {
                sb.AppendLine($"{e + 1} {graph.num_reb[1][e] + 1} {graph.num_reb[2][e] + 1}");
            }
            sb.AppendLine();

            sb.AppendLine("Матрица смежности рёбер:");
            for (int i = 0; i < graph.max; i++)
            {
                for (int j = 0; j < graph.max; j++)
                {
                    sb.Append(graph.max_mas[i][j]);
                    if (j < graph.max - 1) sb.Append(" ");
                }
                sb.AppendLine();
            }
            sb.AppendLine();

            sb.AppendLine("Номера рёбер паросочетания:");
            if (graph.most_set.Count > 0)
            {
                var best = graph.most_set[0];
                for (int k = 0; k < best.Length; k++)
                    sb.AppendLine((best[k] + 1).ToString());
            }




            return sb.ToString();
        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.Title = "Сохранить результат";
                sfd.FileName = "matching.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string content = BuildResultText();
                    File.WriteAllText(sfd.FileName, content, Encoding.UTF8);
                    MessageBox.Show("Результат сохранён.", "Готово",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}
