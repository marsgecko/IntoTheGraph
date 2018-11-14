using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private bool _initialised = false;

        bool _doughnut = false;
        float _doughnutSize = 50.0f;

        public PieForm()
        {
            InitializeComponent();

            _drawXAxis = false;
            _drawYAxis = false;
            _legendIsHorizontal = false;

            // Origin is the center of the Circle
            // BarWidth is the radius
            _barWidth = 100.0f;
            _originX = 150.0f;
            _originY = 150.0f;

            groupAxes.Enabled = false;
            groupTicks.Enabled = false;
            udBarMargin.Enabled = false;

            _initialised = true;
            SetDimensions();
        }

        protected override void UpdateOnScreenSettings()
        {
            base.UpdateOnScreenSettings();

            if (cbDoughnut != null)
            {
                cbDoughnut.Checked = _doughnut;

                udDoughnutSize.Value = new decimal(_doughnutSize);
                udDoughnutSize.Enabled = _doughnut;
            }
        }


        protected override void SetDimensions()
        {
            if (_initialised)
            {
                // Set axis values so the legend will draw
                _valueAxisMax = _barWidth;
                _axisHeight = _valueAxisMax/2;
                _axisWidth = _barWidth;
                _yScale = 1.0f;

                _canvasHeight = _originY + _barWidth + 75;
                _canvasWidth = _originX + _barWidth + 150;

                UpdateOnScreenSettings();
            }
        }

        protected override void DrawTicks(PdfCanvas canvas, PdfPage page)
        {

        }

        protected override void DrawAxes(PdfCanvas canvas, PdfPage page)
        {

        }

        protected override void DrawBars(PdfCanvas canvas, PdfPage page)
        {
            if (_data.Columns.Count > 0)
            {
                // Convert to Percentages
                float totalValue = 0.0f;
                float startAngle = 0.0f;
                List<float> percentages = new List<float>();
                List<float> angles = new List<float>();
                Column column = _data.Columns[0];
                foreach (Value value in column.Values)
                {
                    totalValue += value.Data;
                }

                foreach (Value value in column.Values)
                {
                    percentages.Add(value.Data / totalValue);
                }

                foreach (float percentage in percentages)
                {
                    angles.Add(360.0f * percentage);
                }

                // Start at Angle 0, Todo add Start Angle
                int i;

                for (i = 0; i < angles.Count; i++ )
                {
                    float segmentAngle = angles[i];
                    float cosX = (float)Math.Cos(startAngle * (Math.PI / 180));
                    float sinY = (float)Math.Sin(startAngle * (Math.PI / 180));
                    float cosX1 = (float)Math.Cos((startAngle + segmentAngle) * (Math.PI / 180));
                    float sinY1 = (float)Math.Sin((startAngle + segmentAngle) * (Math.PI / 180));

                    float X = _barWidth * cosX;
                    float Y = _barWidth * sinY;
                    float X1 = _barWidth * cosX1;
                    float Y1 = _barWidth * sinY1;

                    //Debug.WriteLine("Angle: " + startAngle.ToString("0.00") + " X:" + X.ToString() + " Y:" + Y.ToString() + " cos:" + cosX.ToString("0.0000") + " sin:" + sinY.ToString("0.0000"));
                    Debug.WriteLine("Angle: " + segmentAngle.ToString("0.00") + " X:" + X1.ToString() + " Y:" + Y1.ToString() + " cos:" + cosX1.ToString("0.0000") + " sin:" + sinY1.ToString("0.0000"));

                    canvas.NewPath();
                    canvas.MoveTo(_originX, _originY);
                    canvas.LineTo(_originX + X, _originY + Y);
                    
                    //canvas.LineTo(_originX + X1, _originY + Y1);
                    canvas.Arc(_originX - _barWidth, _originY - _barWidth, _originX + _barWidth, _originY + _barWidth, startAngle, segmentAngle);

                    canvas.LineTo(_originX, _originY);
                    canvas.SetFillColor(column.Values[i].Legend.Colour);
                    

                    if (_barDrawBorder)
                    {
                        canvas.SetStrokeColor(_barBorderColour);
                        canvas.SetLineWidth(_barBorderWidth);
                        canvas.FillStroke();
                    }
                    else
                    {
                        canvas.Fill();
                    }
                    startAngle += angles[i];
                }

                if(_doughnut)
                {
                    canvas.NewPath();
                    canvas.SetFillColor(_barBorderColour);
                    canvas.Circle(_originX, _originY, _doughnutSize);
                    canvas.Fill();
                }
            }
        }

        protected override void DrawLabels(PdfCanvas canvas, PdfPage page)
        {
            String text = _data.Columns[0].Label;
            float x = _originX - _font.GetWidth(text, _tickFontSize)/2;
            float y = _originY + _barWidth + _legendTextMargin;

            canvas.BeginText()
                  .SetFontAndSize(_font, _legendFontSize)
                  .MoveText(x, y)
                  .SetColor(_legendFontColour, true)
                  .ShowText(text)
                  .EndText();
        }

        protected override String GetGraphType()
        {
            return ("PieGraph");
        }

        protected override void WriteSubTypeSettings(XmlTextWriter xml)
        {
            xml.WriteAttributeString("doughnut", _doughnut.ToString());
            xml.WriteAttributeString("doughnutSize", _doughnutSize.ToString("0.0"));
        }

        protected override void ReadSubTypeSettings(XmlTextReader xml)
        {
            _doughnut = Convert.ToBoolean(xml.GetAttribute("doughnut"));
            _doughnutSize = float.Parse(xml.GetAttribute("doughnutSize"));
        }

        private void cbDoughnut_CheckedChanged(object sender, EventArgs e)
        {
            _doughnut = cbDoughnut.Checked;
            udDoughnutSize.Enabled = _doughnut;
        }

        private void udDoughnutSize_ValueChanged(object sender, EventArgs e)
        {
            _doughnutSize = (float)udDoughnutSize.Value;
        }
    }
}
