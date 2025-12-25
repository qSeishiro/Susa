using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curs
{
    public partial class Form2 : Form
    {
        private GraphCore graph;
        private bool allowEdit;

        public Form2(GraphCore g, bool allowEdit)
        {
            InitializeComponent();
            graph = g;
            this.allowEdit = allowEdit;
            InitGrid();
        }

        private void InitGrid()
        {
            int n = graph.n;

            dgvMatrix.RowHeadersVisible = false;
            dgvMatrix.ColumnHeadersVisible = false;
            dgvMatrix.AllowUserToAddRows = false;

            dgvMatrix.Columns.Clear();
            dgvMatrix.Rows.Clear();

            dgvMatrix.ColumnCount = n;
            dgvMatrix.RowCount = n;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    dgvMatrix[j, i].Value = graph.vertex[i][j];
            for (int c = 0; c < dgvMatrix.ColumnCount; c++)
                dgvMatrix.Columns[c].Width = 25;
            dgvMatrix.RowTemplate.Height = 25;

            dgvMatrix.ReadOnly = !allowEdit;

        }





        private void btnRunSearch_Click(object sender, EventArgs e)
        {
            int n = graph.n;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    graph.vertex[i][j] = Convert.ToInt32(dgvMatrix[i, j].Value);

            graph.FindMaximumMatching();

            Form3 f3 = new Form3(graph);
            f3.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }

}
