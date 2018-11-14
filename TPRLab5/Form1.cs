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
            dgvInput.Rows[dgvInput.RowCount - 1].HeaderCell.Value = ("a" + dgvInput.RowCount);
            Input();
        }


        private void nuCriteries_ValueChanged(object sender, EventArgs e)
        {
            dgvInput.ColumnCount = (int)nuCriteries.Value + 1;
            dgvCrits.ColumnCount = (int)nuCriteries.Value;
            dgvCrits.Columns[dgvCrits.ColumnCount - 1].HeaderText = "w" + dgvCrits.ColumnCount;
            dgvInput.Columns[dgvInput.ColumnCount - 1].HeaderText = "f" + (dgvInput.ColumnCount - 1);
            Input();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvCrits.RowCount = 2;
            dgvInput.ColumnCount = (int)nuAlternatives.Value + 1;
            dgvCrits.ColumnCount = (int)nuAlternatives.Value;
            dgvInput.RowCount = (int)nuCriteries.Value;
            dgvCrits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvInput.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCrits.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvInput.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCrits.AllowUserToAddRows = false;
            dgvInput.AllowUserToAddRows = false;
            dgvInput.RowCount = 1;
            dgvCrits.Columns[dgvCrits.ColumnCount - 1].HeaderText = "w" + dgvCrits.ColumnCount;
            dgvInput.Rows[dgvInput.RowCount - 1].HeaderCell.Value = ("a" + dgvInput.RowCount);
            dgvInput.Columns[dgvInput.ColumnCount - 1].HeaderText = "f" + (dgvInput.ColumnCount - 1);
            dgvInput.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }
        delegate double P(double d);

        P createP1()
        {
            return ((double d) => d <= 0 ? 0 : 1);
        }
        P createP2(double q)
        {
            return ((double d) => d <= q ? 0 : 1);
        }
        P createP3(double s)
        {
            return (double d) => d <= 0 ? 0 : d < s ? d / s : 1;
        }
        P createP4(double q, double s)
        {
            return (double d) => d <= q ? 0 : d <= s ? 0.5 : 1;
        }
        P createP5(double q, double s)
        {
            return (double d) => d <= q ? 0 : d <= s ? (d - q) / (s - q) : 1;
        }
        P createP6(double q, double s)
        {
            return (double d) => d <= q ? 0 : d <= s ? 1 - Math.Exp(-d * d / (2 * s * s)) : 1;
        }
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


        string[] altNames;
        int crits;
        int alts;
        Matrix critMat;
        Matrix[] d;
        double[] w;
        void Input()
        {
            crits = (int)nuCriteries.Value;
            alts = (int)nuAlternatives.Value;
            altNames = new string[alts];
            for (int i = 0; i < alts && i < dgvInput.RowCount; i++)
                if (dgvInput[0, i] != null && dgvInput[0, i].Value != null)
                    altNames[i] = dgvInput[0, i].Value.ToString();
                else
                    altNames[i] = "не задано";

            critMat = new Matrix(alts, crits);
            for (int i = 0; i < alts && i < dgvInput.RowCount; i++)
                for (int j = 0; j < crits && j + 1 < dgvInput.ColumnCount; j++)
                {
                    if (dgvInput[j + 1, i] != null && dgvInput[j + 1, i].Value != null &&
                           double.TryParse(dgvInput[j + 1, i].Value.ToString(), out double d))
                        critMat[i, j] = d;
                    else
                        critMat[i, j] = 0;
                }

            w = new double[crits];
            for (int crit = 0; crit < crits && crit < dgvCrits.ColumnCount; crit++)
                if (dgvCrits[crit, 0] != null && dgvCrits[crit, 0].Value != null
                    && double.TryParse(dgvCrits[crit, 0].Value.ToString(), out double d))
                    w[crit] = d;
                else
                    w[crit] = 0;
        }
        double[] F_min, F_plus, F;
        Matrix pi;
        Matrix mat2;
        void Calculate()
        {

            P[] p = { P1, P2, P3, P1, P2, P3, P1, P2, P3, P1 };

            d = new Matrix[crits];
            for (int c = 0; c < crits; c++)
            {
                Matrix mat = new Matrix(alts, alts);
                for (int i = 0; i < alts; i++)
                    for (int j = 0; j < alts; j++)
                        mat[i, j] = critMat[i, c] - critMat[j, c];


                d[c] = mat;
            }

            mat2 = new Matrix(alts * crits, alts);

            for (int alt1 = 0; alt1 < alts; alt1++)
                for (int alts2 = 0; alts2 < alts; alts2++)
                {
                    for (int crit = 0; crit < crits; crit++)
                        mat2[crit * alts + alt1, alts2] = p[crit](d[crit][alt1, alts2]);
                }


            pi = new Matrix(alts, alts);

            for (int i = 0; i < alts; i++)
                for (int j = 0; j < alts; j++)
                {
                    double sum = 0;
                    for (int crit = 0; crit < crits; crit++)
                        sum += w[crit] * p[crit](d[crit][i, j]);
                    pi[i, j] = sum;
                }


            F_min = new double[alts]; F_plus = new double[alts]; F = new double[alts];

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


            F_alts = new SortedDictionary<double, string>();
            for (int i = 0; i < alts; i++)
                F_alts.Add(F[i], altNames[i]);

        }
        SortedDictionary<double, string> F_alts;
        DataGridView newDGV(int x, int y, int cols, int rows)
        {
            var dgv = new DataGridView();
            dgv.Top = y;
            dgv.Left = x;

            dgv.ColumnCount = cols;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgv.RowCount = rows;
            return dgv;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);

                sw.WriteLine(alts);
                sw.WriteLine(crits);

                for (int i = 0; i < alts; i++)
                    sw.WriteLine(altNames[i]);

                critMat.Save(sw);

                for (int i = 0; i < crits; i++)
                    sw.WriteLine(w[i]);

                sw.Close();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            FileDialog sfd = new OpenFileDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sw = new StreamReader(sfd.FileName);

                int alts = int.Parse(sw.ReadLine());
                int crits = int.Parse(sw.ReadLine());
                var altNames = new string[alts];
                for (int i = 0; i < alts; i++)
                    altNames[i] = sw.ReadLine();

                var critMat = new Matrix(alts, crits);
                critMat.Load(sw);

                var w = new double[crits];
                for (int i = 0; i < crits; i++)
                {
                    w[i] = double.Parse(sw.ReadLine());
                }
                sw.Close();

                nuAlternatives.Value = alts;
                nuCriteries.Value = crits;

                for (int i = 0; i < crits; i++)
                    dgvCrits[i, 0].Value = w[i];

                for (int i = 0; i < alts; i++)
                    dgvInput[0, i].Value = altNames[i];

                for (int i = 0; i < alts; i++)
                    for (int j = 0; j < crits; j++)
                        dgvInput[j + 1, i].Value = critMat[i, j];

            }

            Input();

        }

        private void dgvInput_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Input();
        }

        private void dgvCrits_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Input();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Input();
                Calculate();
                Output();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void Output()
        {
            int x = dgvInput.Left, y = dgvInput.Top + dgvInput.Height + 20;

            DataGridView dgv = null;
            //////////////////////////////////////
            ///матрицы сравнений по критериям
            /////////////////////////////////////
            for (int c = 0; c < crits; c++)
            {

                dgv = newDGV(x, y, alts, alts);
                dgv.TopLeftHeaderCell.Value = "Критерий" + (c + 1).ToString();

                for (int i = 0; i < alts; i++)
                {
                    dgv.Rows[i].HeaderCell.Value = altNames[i];
                    dgv.Columns[i].HeaderText = altNames[i];
                }
                for (int i = 0; i < alts; i++)
                    for (int j = 0; j < alts; j++)
                        dgv[j, i].Value = d[c][i, j];

                this.Controls.Add(dgv);

                x += dgv.Width + 50;
            }
            //////////////////////////////////
            x = dgvInput.Left;
            y += 50 + dgv.Height;

            ///////////////////////////////////
            ///матрицы с p 
            /////////////////////
            dgv = newDGV(x, y, alts + 1, crits * alts);

            for (int i = 0; i < dgv.RowCount - 1; i++)
                dgv.Rows[i + 1].HeaderCell.Value = "P" + (i / alts + 1).ToString();

            for (int i = 0; i < dgv.RowCount - 1; i++)
                dgv[0, i].Value = "a" + (i % alts + 1).ToString();

            for (int i = 0; i < alts; i++)
                dgv.Columns[i + 1].HeaderText = "a" + (i + 1).ToString();

            for (int i = 0; i < mat2.n; i++)
                for (int j = 0; j < mat2.m; j++)
                    dgv[j + 1, i].Value = mat2[i, j];



            this.Controls.Add(dgv);
            this.AutoScroll = true;


            //////////////////////////
            x += dgv.Width + 20;


            ////////////////////////
            ///матрица пи и Ф+, Ф-
            //////////////////////////////
            dgv = newDGV(x, y, alts + 1, alts + 1);

            for (int i = 0; i < alts; i++)
                dgv.Columns[i].HeaderText = "pi(ai, a" + (i + 1).ToString() + ")";
            dgv.Columns[alts].HeaderText = "Ф+";

            for (int i = 0; i < alts; i++)
                dgv.Rows[i].HeaderCell.Value = "pi(a" + (i + 1).ToString() + ", aj)";
            dgv.Rows[alts].HeaderCell.Value = "Ф-";

            for (int i = 0; i < alts; i++)
                for (int j = 0; j < alts; j++)
                    dgv[j, i].Value = pi[i, j];

            for (int i = 0; i < alts; i++)
                dgv[alts, i].Value = F_plus[i];

            for (int i = 0; i < alts; i++)
                dgv[i, alts].Value = F_min[i];

            this.Controls.Add(dgv);

            ////////////////////////////////
            ///результаты
            ///////////////////////////////

            dgvEndResult.RowCount = 2;
            dgvEndResult.ColumnCount = alts;
            dgvEndResult.Rows[0].HeaderCell.Value = "a";
            dgvEndResult.Rows[1].HeaderCell.Value = "F";

            int iter = 0;
            foreach (var par in F_alts.Reverse())
            {
                dgvEndResult[iter, 0].Value = par.Value;
                dgvEndResult[iter, 1].Value = par.Key;
                iter++;
            }
        }

    }
}
