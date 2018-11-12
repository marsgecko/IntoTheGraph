using iText.Kernel.Colors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            mColours.Add(new DeviceCmyk(0.0f, 0.99f, 0.65f, 0.45f));
            mColours.Add(new DeviceCmyk(0.0f, 0.62f, 0.63f, 0.14f));
            mColours.Add(new DeviceCmyk(0.0f, 0.20f, 0.74f, 0.06f));
            mColours.Add(new DeviceCmyk(0.0f, 0.61f, 0.18f, 0.45f));
            mColours.Add(new DeviceCmyk(0.0f, 0.63f, 0.77f, 0.08f));
            mColours.Add(new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.1f));
            mColours.Add(new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.2f));
            mColours.Add(new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.3f));
            mColours.Add(new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.4f));
            mColours.Add(new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.5f));
            mColours.Add(new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.6f));
            mColours.Add(new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.7f));
            mColours.Add(new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.8f));
            mColours.Add(new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.9f));
            mColours.Add(new DeviceCmyk(0.0f, 0.0f, 0.0f, 1.0f));
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

            AddLegend("Age 0 - 5", iText.Kernel.Colors.ColorConstants.PINK);
            AddLegend("Age 6 - 15", iText.Kernel.Colors.ColorConstants.GREEN);
            AddLegend("Age 16 - 30", iText.Kernel.Colors.ColorConstants.BLUE);
            AddLegend("Age 31 - 50", iText.Kernel.Colors.ColorConstants.ORANGE);
            AddLegend("Age 51 - 100", iText.Kernel.Colors.ColorConstants.YELLOW);

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
            int i;
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
            int j;


            for (i = 2; i <= iTotalColumns; i++)
            {
                AddColumn(sheet.Cells[1, i].Value);
            }

            for (i = 2; i <= iTotalRows; i++)
            {
                AddLegend(sheet.Cells[i, 1].Value, mColours[i-2]);
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
                        value = sheet.Cells[j, i].Value * 100.0f;
                        mFormatPercent = true;
                    }
                    else
                    {
                        value = sheet.Cells[j, i].Value;
                    }
                    
                    column.AddValue(legend, Convert.ToSingle(value));
                }
            }
            excelWorkbook.Close(0);
            excelApp.Quit();
        }
    }
}
