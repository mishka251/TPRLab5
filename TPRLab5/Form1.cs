using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPRLab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void nuAlternatives_ValueChanged(object sender, EventArgs e)
        {
            dgvInput.RowCount = (int)nuAlternatives.Value;
        }


        

        private void nuCriteries_ValueChanged(object sender, EventArgs e)
        {
            

            dgvInput.ColumnCount = (int)nuCriteries.Value + 1;
            dgvCrits.ColumnCount = (int)nuCriteries.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvCrits.RowCount = 1;
            dgvInput.ColumnCount = (int)nuAlternatives.Value + 1;
            dgvCrits.ColumnCount = (int)nuAlternatives.Value;
            dgvInput.RowCount = (int)nuCriteries.Value;
        }
        delegate double P(double d);

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                double q = 0, s=1;
                P[] p =
                 {
                 (double d) => d > 0 ? 1 : 0,
                    (double d) => d > q ? 1 : 0,
                    (double d)=>d<=0?0:d<=s?d/s:1,
                    (double d)=>d<=0?0:d<=s?0.5:1
               };


                int crits = (int)nuCriteries.Value;
                int alts = (int)nuAlternatives.Value;
                int x = 10, y = dgvInput.Top + dgvInput.Height + 20;

                Matrix critMat = new Matrix(alts, crits);
                for (int i = 0; i < alts; i++)
                    for (int j = 0; j < crits; j++)
                        critMat[i, j] = double.Parse(dgvInput[j + 1, i].Value.ToString());

                for (int c = 0; c < crits; c++)
                {
                    Matrix mat = new Matrix(alts, alts);
                    for (int i = 0; i < alts; i++)
                        for (int j = 0; j < alts; j++)
                            mat[i, j] = critMat[i, c] - critMat[j, c];

                    DataGridView dgv = new DataGridView();
                    dgv.Top = y;
                    dgv.Left = x;

                    dgv.ColumnCount = alts + 1;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgv.RowCount = alts + 1;
                    dgv[0, 0].Value = "Критерий"+c;
                    for (int i = 1; i <= alts; i++)
                        dgv[0, i].Value = dgv[i, 0].Value = dgvInput[0, i - 1].Value;

                    for (int i = 0; i < alts; i++)
                        for (int j = 0; j < alts; j++)
                            dgv[j+1, i+1].Value = mat[i, j];

                    this.Controls.Add(dgv);

                    x += dgv.Width + 50;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
