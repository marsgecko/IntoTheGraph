using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Graph
{
    public partial class PieForm : Graph.GraphForm
    {
        public PieForm()
        {
            InitializeComponent();
        }

        protected override void WriteSubTypeSettings(XmlTextWriter xml)
        {

        }

        protected override void ReadSubTypeSettings(XmlTextReader xml)
        {

        }
    }
}
