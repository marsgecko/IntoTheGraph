using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerticalStackedForm form = new VerticalStackedForm();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdjacentStackedForm form = new AdjacentStackedForm();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BarForm form = new BarForm();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PieForm form = new PieForm();
            form.ShowDialog();
        }
    }
}
