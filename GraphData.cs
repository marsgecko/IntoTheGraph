using iText.Kernel.Colors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace Graph
{
    public class GraphData
    {
        public String ValueLabel { get; set; }

        private List<Legend> mLegends;
        public List<Legend> Legends { get { return mLegends; } }

        private List<Column> mColumns;
        public List<Column> Columns { get { return mColumns; } }

        private List<iText.Kernel.Colors.DeviceRgb> mColours;
        public List<iText.Kernel.Colors.DeviceRgb> LegendColours { get { return mColours; } }

        private Boolean mFormatPercent;
        public Boolean FormatPercent { get { return mFormatPercent; } }

        public GraphData()
        {
            mFormatPercent = false;

            mLegends = new List<Legend>();
            mColumns = new List<Column>();

            mColours = new List<iText.Kernel.Colors.DeviceRgb>();


            // Option 3
            mColours.Add(new DeviceRgb(79,79,125));
            mColours.Add(new DeviceRgb(110,152,124));
            mColours.Add(new DeviceRgb(121,166,189));
            mColours.Add(new DeviceRgb(227,211,68));
            mColours.Add(new DeviceRgb(46,121,144));
            mColours.Add(new DeviceRgb(87,101,112));
            mColours.Add(new DeviceRgb(188,147,46));
            mColours.Add(new DeviceRgb(191,191,191));
            mColours.Add(new DeviceRgb(106, 196, 206));
            mColours.Add(new DeviceRgb(33, 33, 33));
            mColours.Add(new DeviceRgb(128, 128, 128));
            mColours.Add(new DeviceRgb(220, 220, 220));
        }

        public Legend AddLegend(String label, iText.Kernel.Colors.DeviceRgb colour)
        {
            Legend result = new Legend(label, colour);
            mLegends.Add(result);
            return result;
        }

        public float GetMaxValue()
        {
            float result = 0;

            foreach (Column column in mColumns)
            {
                foreach (Value value in column.Values)
                {
                    if(value.Data > result )
                    {
                        result = value.Data;
                    }
                }
            }

            return result;
        }

        public float GetMaxStackValue()
        {
            double result = 0;

            foreach (Column column in mColumns)
            {
                double stack = 0;
                foreach (Value value in column.Values)
                {
                    stack += value.Data;
                }
                if (stack > result)
                {
                    result = (float)stack;
                }
                Debug.WriteLine("column:" + column.Label + " total:" + stack.ToString());
            }

            return (float)result;
        }

        public Column AddColumn(String label)
        {
            Column result = new Column(label);
            mColumns.Add(result);
            return result;
        }

        public void GenerateData()
        {
            ValueLabel = "Sales Distribution";

            mLegends.Clear();
            mColumns.Clear();

            AddLegend("Age 0 - 5", mColours[0]);
            AddLegend("Age 6 - 15", mColours[1]);
            AddLegend("Age 16 - 30", mColours[2]);
            AddLegend("Age 31 - 50", mColours[3]);
            AddLegend("Age 51 - 100", mColours[4]);

            AddColumn("Skirts");
            AddColumn("Trousers");
            AddColumn("Shorts");
            AddColumn("T-Shirts");
            AddColumn("Jumpers");

            Random random = new Random();

            foreach( Column column in mColumns)
            {
                foreach( Legend legend in mLegends)
                {
                    float value = random.Next(0, 100);
                    column.AddValue(legend, value);
                }
            }
        }

        protected void WriteColourSetting(XmlTextWriter xml, iText.Kernel.Colors.Color iTextColour, String name)
        {
            if (iTextColour.GetColorSpace().ToString() == "iText.Kernel.Pdf.Colorspace.PdfDeviceCs+Cmyk")
            {
                MessageBox.Show("Wrong Colour Space", "Not SUpported", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                float[] float_rgb = iTextColour.GetColorValue();
                int r = Convert.ToInt32(Math.Round(255 * float_rgb[0]));
                int g = Convert.ToInt32(Math.Round(255 * float_rgb[1]));
                int b = Convert.ToInt32(Math.Round(255 * float_rgb[2]));
                String attribute = r.ToString() + "," + g.ToString() + "," + b.ToString();
                xml.WriteAttributeString(name, attribute);
            }


        }

        protected virtual void WriteLegends(XmlTextWriter xml)
        {
            int i = 0;
            foreach (Legend legend in Legends)
            {
                xml.WriteStartElement("legend");

                xml.WriteAttributeString("index", i.ToString());

                xml.WriteAttributeString("label", legend.Label);

                WriteColourSetting(xml, legend.Colour, "colour");

                xml.WriteEndElement();
                i++;
            }
        }

        protected virtual void WriteColumns(XmlTextWriter xml)
        {
            int i = 0;
            foreach (Column column in Columns)
            {
                xml.WriteStartElement("column");

                xml.WriteAttributeString("index", i.ToString());

                xml.WriteAttributeString("label", column.Label);

                int j = 0;
                foreach(Value value in column.Values)
                {
                    xml.WriteStartElement("value");

                    xml.WriteAttributeString("legend", value.Legend.Label);
                    xml.WriteAttributeString("data", value.Data.ToString());
                    
                    xml.WriteEndElement();
                    j++;
                }

                xml.WriteEndElement();
                i++;
            }
        }

        public void SaveDataFile(String filename)
        {
            using (XmlTextWriter xml = new XmlTextWriter(filename, null))
            {
                // Root.
                xml.WriteStartDocument();

                xml.Formatting = Formatting.Indented;

                xml.WriteStartElement("graph");

                xml.WriteAttributeString("y_label", ValueLabel);
                xml.WriteAttributeString("format_percent", FormatPercent.ToString());

                WriteLegends(xml);
                WriteColumns(xml);

                xml.WriteEndElement();

                xml.WriteEndDocument();
            }
        }

        protected virtual void ReadColour(XmlTextReader xml, ref iText.Kernel.Colors.DeviceRgb iTextColour, String attributeName)
        {
            String colourString = xml.GetAttribute(attributeName);
            String[] values = colourString.Split(',');
            if (values.Length == 3)
            {
                int r = Convert.ToInt32(values[0]);
                int g = Convert.ToInt32(values[1]);
                int b = Convert.ToInt32(values[2]);
                iTextColour = new DeviceRgb(r, g, b);
            }
        }

        protected virtual void ReadLegend(XmlTextReader xml)
        {
            //Int32 index = Convert.ToInt32(xml.GetAttribute("index"));

            iText.Kernel.Colors.DeviceRgb iTextColour = new DeviceRgb();
            ReadColour(xml, ref iTextColour, "colour");

            String label = xml.GetAttribute("label");
            Legends.Add(new Legend(label, iTextColour));
            mColours.Add(iTextColour);
        }

        protected virtual Legend GetLegendFromName(String name)
        {
            Legend result = null;

            foreach(Legend legend in Legends)
            {
                if(legend.Label == name)
                {
                    result = legend;
                    break;
                }
            }

            return result;
        }

        protected virtual void ReadColumn(XmlTextReader xml)
        {

            String label = xml.GetAttribute("label");
            Column column = new Column(label);
            Columns.Add(column);

            while (xml.Read())
            {
                switch (xml.NodeType)
                {
                    case XmlNodeType.Element:
                        if (xml.Name == "value")
                        {
                            String legendName = xml.GetAttribute("legend");
                            float data = float.Parse(xml.GetAttribute("data"));
                            Legend legend = GetLegendFromName(legendName);
                            if (legend != null)
                            {
                                column.AddValue(legend, data);
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Invalid Column Element:" + xml.Name);
                            return;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (xml.Name == "column")
                        {
                            return;
                        }
                        break;
                }
            }
        }

        public void LoadDataFile(String filename)
        {
            try
            {
                Legends.Clear();
                Columns.Clear();
                mColours.Clear();
                using (XmlTextReader reader = new XmlTextReader(filename))
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (reader.Name == "column")
                                {
                                    ReadColumn(reader);
                                }
                                else if (reader.Name == "legend")
                                {
                                    ReadLegend(reader);
                                }
                                else if (reader.Name == "graph")
                                {
                                    mFormatPercent = Convert.ToBoolean(reader.GetAttribute("format_percent"));
                                    ValueLabel = reader.GetAttribute("y_label");
                                }
                                else
                                {
                                    MessageBox.Show("Wrong Graph Type", "Cannot Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid Graph File", "Cannot Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadExcelFile(String filename, bool saveColours)
        {
            int i = 0;
            Excel.Application excelApp = new Excel.Application();

            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filename,
                                                                   0, true, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                                                                   true, false, 0, true, false, false);
            Excel.Sheets excelSheets = excelWorkbook.Worksheets;

            Excel.Worksheet sheet = (Excel.Worksheet)excelSheets.get_Item("Sheet1");

            if (saveColours)
            {
                for (i = 0; i < mLegends.Count; i++)
                {
                    mColours[i] = mLegends[i].Colour;
                }
            }

            mLegends.Clear();
            mColumns.Clear();
            mFormatPercent = false;

            ValueLabel = sheet.Cells[1, 1].Value;

            int iTotalRows = sheet.UsedRange.Rows.Count;
            int iTotalColumns = sheet.UsedRange.Columns.Count;
            int j = 0;

            try
            {
                for (i = 2; i <= iTotalColumns; i++)
                {
                    String value;
                    try
                    {
                        value = sheet.Cells[1, i].Value2;
                    }
                    catch
                    {
                        Double number = sheet.Cells[1, i].Value2;
                        value = number.ToString("0");
                    }
                    AddColumn(value);
                }

                for (i = 2; i <= iTotalRows; i++)
                {
                    String value;
                    try
                    {
                        value = sheet.Cells[i, 1].Value2;
                    }
                    catch
                    {
                        Double number = sheet.Cells[i, 1].Value2;
                        value = number.ToString("0");
                    }
                    AddLegend(value, mColours[i - 2]);
                }

                for (i = 2; i <= iTotalColumns; i++)
                {
                    Column column = mColumns[i - 2];


                    for (j = 2; j <= iTotalRows; j++)
                    {
                        Legend legend = mLegends[j - 2];
                        Double value;

                        if (sheet.Cells[j, i] != null && sheet.Cells[j, i].Value2 != null)
                        {

                            String temp = sheet.Cells[j, i].NumberFormat;

                        
                            //Debug.WriteLine(temp);

                            if (temp.Contains("%"))
                            {
                                // Round to truncate small data scraps
                                value = Math.Round(sheet.Cells[j, i].Value2 - .0005, 3) * 100.0f;
                                mFormatPercent = true;
                            }
                            else
                            {
                                value = Math.Round(sheet.Cells[j, i].Value2 - .0005, 3);
                            }

                            column.AddValue(legend, Convert.ToSingle(value));
                        }
                    }
                }
            }
            catch
            {
                String text = "Error Column:" + i.ToString() + " Row:" + j.ToString();
                MessageBox.Show(text, "Cannot Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(text);
            }
            excelWorkbook.Close(0);
            excelApp.Quit();
        }
    }
}
