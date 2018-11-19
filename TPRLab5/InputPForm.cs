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
    public partial class InputPForm : Form
    {
        public InputPForm()
        {
            InitializeComponent();
            rbs = new RadioButton[] { radioButton1, radioButton2, radioButton3, radioButton4, radioButton5, radioButton6 };
        }

        RadioButton[] rbs;

        public PFunc result;

        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var rb1 = rbs
                .Where(r => r.Checked)
                .First();

            int ind = rbs.ToList().IndexOf(rb1);
            double q = 0, s = 0, sigma = 0;
            switch(ind)
            {
                case 0:  break;
                case 1: q=double.Parse(tbP2q.Text); break;
                case 2: s=double.Parse(tbP3s.Text); break;
                case 3: q = double.Parse(tbP4q.Text); s= double.Parse(tbP4s.Text); break;
                case 4: q = double.Parse(tbP5q.Text);s= double.Parse(tbP5s.Text); break;
                case 5: sigma = double.Parse(tbP6sigma.Text); break;
                default:throw new Exception("Не выбран радиобаттон");
            }
            result = new PFunc(ind, q, s, sigma);
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
