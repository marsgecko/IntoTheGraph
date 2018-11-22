using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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

        private GraphForm CreateGraphForm(String graphType)
        {
            GraphForm result = null;
            if (graphType.Equals("VerticalStackedGraph"))
            {
                result = new VerticalStackedForm();
            }
            else if (graphType.Equals("AdjacentStackedGraph"))
            {
                result = new AdjacentStackedForm();
            }
            else if (graphType.Equals("BarGraph"))
            {
                result = new BarForm();
            }
            else if (graphType.Equals("PieGraph"))
            {
                result = new PieForm();
            }

            return result;
        }

        private bool IsSupportedGraphType(String graphType)
        {
            bool result = false;
            if(graphType.Equals("VerticalStackedGraph"))
            {
                result = true;
            }
            else if (graphType.Equals("AdjacentStackedGraph"))
            {
                result = true;
            }
            else if (graphType.Equals("BarGraph"))
            {
                result = true;
            }
            else if (graphType.Equals("PieGraph"))
            {
                result = true;
            }

            return result;
        }

        private String GetGraphType(String gphFilename)
        {
            String result = null;

            try
            {
                using (XmlTextReader reader = new XmlTextReader(gphFilename))
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (IsSupportedGraphType(reader.Name))
                                {
                                    result = reader.Name;
                                    break;
                                }
                                break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid Graph File:" + gphFilename, "Cannot Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private void ProcessFile(String excelFilename, String gphFilename, String pdfFilename)
        {
            Debug.WriteLine("------------------------------------------------------");
            Debug.WriteLine("Processing:");
            Debug.WriteLine(excelFilename);
            Debug.WriteLine(gphFilename);
            Debug.WriteLine(pdfFilename);

            String graphType = GetGraphType(gphFilename);

            if(graphType != null)
            {
                GraphForm graph = CreateGraphForm(graphType);

                if(graph != null)
                {

                    graph.Show();

                    graph.LoadExcelFile(excelFilename);
                    graph.LoadGphFile(gphFilename);

                    FileStream fos = new FileStream(pdfFilename, FileMode.Create, FileAccess.ReadWrite, FileShare.None);

                    graph.CreatePdfStream(fos);

                    fos.Close();

                    graph.Close();
                    
                }
                else
                {
                    Debug.WriteLine("CreateGraphForm Failed!!");
                }
            }
            else
            {
                Debug.WriteLine("Unsupported!!");
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach(String filename in openFileDialog.FileNames)
                {
                    String outPath = System.IO.Path.GetDirectoryName(filename) + "\\output\\";
                    String fileBaseName = System.IO.Path.GetFileNameWithoutExtension(filename);

                    ProcessFile(filename, outPath + fileBaseName + ".gph", outPath + fileBaseName + ".pdf");
                }
            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            LineForm form = new LineForm();
            form.ShowDialog();
        }
    }
}
