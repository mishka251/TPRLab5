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
            dgvCrits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvInput.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCrits.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvInput.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        delegate double P(double d);

        double P1(double d)
        {
            double q = 5;
            return d <= q ? 0 : 1;
        }
        double P2(double d)
        {
            double q = 1, s = 3;
            return d <= q ? 0 : d <= s ? 0.5 : 1;
        }
        double P3(double d)
        {
            double q = 3, s = 5;
            return d <= q ? 0 : d <= s ? (d - q) / (s - q) : 1;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                P[] p =
                 {
                    P1, P2, P3
                };

                int crits = (int)nuCriteries.Value;
                int alts = (int)nuAlternatives.Value;
                int x = 10, y = dgvInput.Top + dgvInput.Height + 20;

                Matrix critMat = new Matrix(alts, crits);
                for (int i = 0; i < alts; i++)
                    for (int j = 0; j < crits; j++)
                        critMat[i, j] = double.Parse(dgvInput[j + 1, i].Value.ToString());
                DataGridView dgv = null;
                Matrix[] d = new Matrix[crits];
                for (int c = 0; c < crits; c++)
                {
                    Matrix mat = new Matrix(alts, alts);
                    for (int i = 0; i < alts; i++)
                        for (int j = 0; j < alts; j++)
                            mat[i, j] = critMat[i, c] - critMat[j, c];

                    dgv = new DataGridView();
                    dgv.Top = y;
                    dgv.Left = x;

                    dgv.ColumnCount = alts + 1;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgv.RowCount = alts + 1;
                    dgv[0, 0].Value = "Критерий" + c;
                    for (int i = 1; i <= alts; i++)
                        dgv[0, i].Value = dgv[i, 0].Value = dgvInput[0, i - 1].Value;

                    for (int i = 0; i < alts; i++)
                        for (int j = 0; j < alts; j++)
                            dgv[j + 1, i + 1].Value = mat[i, j];

                    this.Controls.Add(dgv);

                    x += dgv.Width + 50;
                    d[c] = mat;
                }

                Matrix mat2 = new Matrix(alts * crits, alts);

                for (int alt1 = 0; alt1 < alts; alt1++)
                    for (int alts2 = 0; alts2 < alts; alts2++)
                    {
                        for (int crit = 0; crit < crits; crit++)
                            mat2[crit * alts + alt1, alts2] = p[crit](d[crit][alt1, alts2]);
                    }
                x = 10;
                y += 50 + dgv.Height;
                dgv = new DataGridView();
                dgv.Top = y;
                dgv.Left = x;

                dgv.ColumnCount = alts + 2;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv.RowCount = crits * alts + 1;

                for (int i = 0; i < dgv.RowCount - 1; i++)
                    dgv[0, i + 1].Value = "P" + (i / alts + 1).ToString();

                for (int i = 0; i < dgv.RowCount - 1; i++)
                    dgv[1, i + 1].Value = "a" + (i % alts + 1).ToString();

                for (int i = 0; i < alts; i++)
                    dgv[i + 2, 0].Value = "a" + (i + 1).ToString();

                for (int i = 0; i < mat2.n; i++)
                    for (int j = 0; j < mat2.m; j++)
                        dgv[j + 2, i + 1].Value = mat2[i, j];

                this.Controls.Add(dgv);
                this.AutoScroll = true;

                double[] w = new double[crits];
                for (int crit = 0; crit < crits; crit++)
                    w[crit] = double.Parse(dgvCrits[crit, 0].Value.ToString());

                x += dgv.Width + 20;

                Matrix pi = new Matrix(alts, alts);
                double[] F_min = new double[alts], F_plus = new double[alts], F = new double[alts];
                for (int i = 0; i < alts; i++)
                    for (int j = 0; j < alts; j++)
                    {
                        double sum = 0;
                        for (int crit = 0; crit < crits; crit++)
                            sum += w[crit] * p[crit](d[crit][i, j]);
                        pi[i, j] = sum;
                    }

                for (int i = 0; i < alts; i++)
                {
                    F_min[i] = 0;
                    F_plus[i] = 0;
                    for (int j = 0; j < alts; j++)
                        F_min[i] += pi[j, i];
                    for (int j = 0; j < alts; j++)
                        F_plus[i] += pi[i, j];
                    F[i] = F_plus[i] - F_min[i];
                }

                dgv = new DataGridView();
                dgv.Top = y;
                dgv.Left = x;

                dgv.ColumnCount = alts + 2;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv.RowCount = alts + 2;

                for (int i = 0; i < alts; i++)
                    dgv[i + 1, 0].Value = "pi(ai, a" + (i + 1).ToString() + ")";
                dgv[alts + 1, 0].Value = "Ф+";

                for (int i = 0; i < alts; i++)
                    dgv[0, i + 1].Value = "pi(a" + (i + 1).ToString() + ", aj)";
                dgv[0, alts + 1].Value = "Ф-";

                for (int i = 0; i < alts; i++)
                    for (int j = 0; j < alts; j++)
                        dgv[j + 1, i + 1].Value = pi[i, j];

                for (int i = 0; i < alts; i++)
                    dgv[alts + 1, i + 1].Value = F_plus[i];

                for (int i = 0; i < alts; i++)
                    dgv[i + 1, alts + 1].Value = F_min[i];

                this.Controls.Add(dgv);

                x += dgv.Width;
                dgv = new DataGridView();
                dgv.Top = y;
                dgv.Left = x;

                dgv.ColumnCount = alts + 1;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv.RowCount =  2;

                dgv[0, 0].Value = "a";
                dgv[0, 1].Value = "F";
                
                SortedDictionary<double, string> F_alts = new SortedDictionary<double, string>();
                for (int i = 0; i < alts; i++)
                    F_alts.Add(F[i], dgvInput[0, i].Value.ToString());

                int iter = 1;
                foreach(var par in F_alts.Reverse())
                {
                    dgv[iter, 0].Value = par.Value;
                    dgv[iter, 1].Value = par.Key;
                    iter++;
                }
                this.Controls.Add(dgv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
