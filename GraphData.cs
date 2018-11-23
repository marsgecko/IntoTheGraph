using iText.Kernel.Colors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private List<iText.Kernel.Colors.Color> mColours;
        public List<iText.Kernel.Colors.Color> LegendColours { get { return mColours; } }

        private Boolean mFormatPercent;
        public Boolean FormatPercent { get { return mFormatPercent; } }

        public GraphData()
        {
            mFormatPercent = false;

            mLegends = new List<Legend>();
            mColumns = new List<Column>();

            mColours = new List<iText.Kernel.Colors.Color>();


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

        public Legend AddLegend(String label, iText.Kernel.Colors.Color colour)
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
            float result = 0;

            foreach (Column column in mColumns)
            {
                float stack = 0;
                foreach (Value value in column.Values)
                {
                    stack += value.Data;
                }
                if (stack > result)
                {
                    result = stack;
                }
            }

            return result;
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
                        value = sheet.Cells[1, i].Value;
                    }
                    catch
                    {
                        Double number = sheet.Cells[1, i].Value;
                        value = number.ToString("0");
                    }
                    AddColumn(value);
                }

                for (i = 2; i <= iTotalRows; i++)
                {
                    String value;
                    try
                    {
                        value = sheet.Cells[i, 1].Value;
                    }
                    catch
                    {
                        Double number = sheet.Cells[i, 1].Value;
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

                        String temp = sheet.Cells[j, i].NumberFormat;

                        Debug.WriteLine(temp);

                        if (temp.Contains("%"))
                        {
                            // Round to truncate small data scraps
                            value = Math.Round(sheet.Cells[j, i].Value - .0005, 3) * 100.0f;
                            mFormatPercent = true;
                        }
                        else
                        {
                            value = Math.Round(sheet.Cells[j, i].Value - .0005, 3);
                        }

                        column.AddValue(legend, Convert.ToSingle(value));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error Row:" + i.ToString() + " Column:" + j.ToString(), "Cannot Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            excelWorkbook.Close(0);
            excelApp.Quit();
        }
    }
}
