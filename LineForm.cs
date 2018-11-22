using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Layout.Renderer;
using iText.Layout.Layout;
using iText.Layout;
using iText.Layout.Borders;
using iText.Kernel.Pdf.Extgstate;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Font;
using System.IO;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;
using System.Diagnostics;
using iText.Layout.Properties;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using iText.Kernel.Pdf.Colorspace;
using System.Xml;

namespace Graph
{
    public partial class LineForm : Graph.GraphForm
    {
        bool _barDrawValueAboveTop = false;
        bool _barDrawValueBelowTop = true;
        bool _barDrawValueCenter = false;
        float _barValueMargin = 2.0f;
        float _barValueFontSize = 8.0f;
        protected iText.Kernel.Colors.Color _barValueFontColour = new DeviceRgb(255,255,255);

        bool _lineCurved = true;
        float _lineWidth = 1.0f;
        protected iText.Kernel.Colors.Color _lineColour = new DeviceRgb(127, 127, 127);


        public LineForm()
        {
            InitializeComponent();

            SetLayout();

            // Override defaults
            _originX = 75.0f;
            _originY = 75.0f;
            _valueAxisInterval = 10.0f;
            _barWidth = 40.0f;

            SetDimensions();

        }

        protected override void SetLayout()
        {
            base.SetLayout();
            Int32 y = gbLegend.Location.Y + gbLegend.Size.Height + 10;
            Int32 x = 260;

            gbBarValue.Location = new System.Drawing.Point(x, y);
            y += gbBarValue.Size.Height;

            //preview.Size = new System.Drawing.Size(640, y - gbOrigin.Location.Y);

            this.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height + gbBarValue.Size.Height);
            this.MinimumSize = this.Size;
        }

        protected override void UpdateOnScreenSettings()
        {
            base.UpdateOnScreenSettings();

            if (cbValueAboveTop != null)
            {
                cbValueAboveTop.Checked = _barDrawValueAboveTop;
                cbValueBelowTop.Checked = _barDrawValueBelowTop;
                cbValueCentered.Checked = _barDrawValueCenter;

                udValueMargin.Value = new decimal(_barValueMargin);
                udValueFontSize.Value = new decimal(_barValueFontSize);
                btnBarValueFontColour.BackColor = GetColorFromiTextColour(_barValueFontColour);
            }
        }

        protected override void SetDimensions()
        {
            float maxValue = _data.GetMaxValue();

            for (_valueAxisMax = 0; _valueAxisMax < maxValue; _valueAxisMax += _valueAxisInterval)
            {

            }


            _axisWidth = _barWidth * _data.Columns.Count + _barMargin * (_data.Columns.Count + 1);
            _axisHeight = _valueAxisMax;

            _yScale = 1.0f;
            if (_userYScale != 1.0f)
            {
                _yScale = _userYScale;
            }
            else
            {
                if (_axisHeight < _axisWidth * 0.25f)
                {
                    float newHeight = _axisWidth * 0.25f;
                    _yScale = newHeight / _axisHeight;
                }
            }

            if (_legendIsHorizontal)
            {
                float legendWidth = GetLegendWidth();
                _canvasHeight = _originY + _axisHeight * _yScale + _originY;
                if (_axisWidth < legendWidth)
                {
                    _canvasWidth = _originX + _axisWidth / 2 + legendWidth / 2 + _originX;
                }
                else
                {
                    _canvasWidth = _originX + _axisWidth + _originX;
                }
            }
            else
            {
                _canvasHeight = _originY + _axisHeight * _yScale + _originY;
                _canvasWidth = _originX + _axisWidth + GetLegendWidth() + 10;
            }

            UpdateOnScreenSettings();
        }

        protected override void DrawBars(PdfCanvas canvas, PdfPage page)
        {
            int columnCount = _data.Columns.Count;
            float totalColumnWidth = (_axisWidth / columnCount);
            float barMargin = (totalColumnWidth - _barWidth) / 2;

            if (_svgRender)
            {
                float x = _originX + barMargin;
                foreach (Column column in _data.Columns)
                {
                    float y = _originY;
                    Value value = column.Values[0];


                    x += totalColumnWidth;
                }
            }
            else
            {
                float x = _originX + barMargin;
                int i = 0;

                canvas.SetLineWidth(_lineWidth);
                canvas.SetStrokeColor(_lineColour);

                if (_lineCurved)
                {
                    // Make a list of control points
                    List<iText.Kernel.Geom.Point> control1 = new List<iText.Kernel.Geom.Point>();
                    List<iText.Kernel.Geom.Point> control2 = new List<iText.Kernel.Geom.Point>();
                    List<iText.Kernel.Geom.Point> points = new List<iText.Kernel.Geom.Point>();

                    control1.Add(new iText.Kernel.Geom.Point(0, 0));
                    control2.Add(new iText.Kernel.Geom.Point(0, 0));

                    for (i = 0; i < _data.Columns.Count; i++)
                    {
                        double y = _originY + _data.Columns[i].Values[0].Data * _yScale;
                        if ( (i > 0) && (i < (_data.Columns.Count - 1)))
                        {
                            double x0 = (double)(x - totalColumnWidth);
                            double x2 = (double)(x + totalColumnWidth);
                            double y0 = (double)(_originY + _data.Columns[i - 1].Values[0].Data * _yScale);
                            double y2 = (double)(_originY + _data.Columns[i + 1].Values[0].Data * _yScale);
                            double dirx = x2 - x0;
                            double diry = y2 - y0;

                            double distance = Math.Sqrt(Math.Pow(dirx, 2) + Math.Pow(diry, 2));

                            double unitx = dirx / distance;
                            double unity = diry / distance;

                            double angle1 = Math.Atan2(unitx, -unity) + Math.PI / 2;
                            double angle2 = Math.Atan2(-unitx, unity) + Math.PI / 2;

                            double control1x = x + Math.Cos(angle1) * (distance / 5);
                            double control1y = y + Math.Sin(angle1) * (distance / 5);
                            double control2x = x + Math.Cos(angle2) * (distance / 5);
                            double control2y = y + Math.Sin(angle2) * (distance / 5);

                            control1.Add(new iText.Kernel.Geom.Point(control1x, control1y));
                            control2.Add(new iText.Kernel.Geom.Point(control2x, control2y));
                        }
                        points.Add(new iText.Kernel.Geom.Point(x, y));
                        x += totalColumnWidth;
                    }

                    // replace the first control point
                    control1[0].x = control1[1].x;
                    control1[0].y = control1[1].y;
                    control2[0].x = control2[1].x;
                    control2[0].y = control2[1].y;
                    // add the last control point
                    control1.Add(new iText.Kernel.Geom.Point(control2[control2.Count - 1].x, control2[control2.Count - 1].y));
                    control2.Add(new iText.Kernel.Geom.Point(0, 0));
// Draw Control point and normals
                    x = _originX + barMargin;

                    for (i = 0; i < _data.Columns.Count; i++)
                    {
                        Column column = _data.Columns[i];
                        Value value = column.Values[0];
                        float y = _originY + value.Data * _yScale;

                        if (i == 0)
                        {
                            //canvas.MoveTo(x, y);
                            canvas.SetFillColor(iText.Kernel.Colors.ColorConstants.BLUE);
                            canvas.Circle(x, y, 2.0f);
                            canvas.Fill();
                        }
                        else if (i == (_data.Columns.Count - 1))
                        {
                            //canvas.CurveTo(control1[i].x, control1[i].y, (double)x, (double)y);
                            canvas.SetFillColor(iText.Kernel.Colors.ColorConstants.BLUE);
                            canvas.Circle(x, y, 2.0f);
                            canvas.Fill();

                            canvas.SetFillColor(iText.Kernel.Colors.ColorConstants.RED);
                            canvas.Circle(control1[i].x, control1[i].y, 2.0f);
                            canvas.Fill();
                        }
                        else
                        {
                            //canvas.CurveTo(control1[i].x, control1[i].y, control2[i].x, control2[i].y, (double)x, (double)y);

                            canvas.SetFillColor(iText.Kernel.Colors.ColorConstants.BLUE);
                            canvas.Circle(x, y, 2.0f);
                            canvas.Fill();

                            canvas.SetFillColor(iText.Kernel.Colors.ColorConstants.RED);
                            canvas.Circle(control1[i].x, control1[i].y, 2.0f);
                            canvas.Circle(control2[i].x, control2[i].y, 2.0f);
                            canvas.Fill();

                            canvas.MoveTo(control1[i].x, control1[i].y);
                            canvas.LineTo(control2[i].x, control2[i].y);
                            canvas.Stroke();
                        }
                        x += totalColumnWidth;
                    }


                    x = _originX + barMargin;
                    for (i = 0; i < _data.Columns.Count; i++)
                    {
                        Column column = _data.Columns[i];
                        Value value = column.Values[0];
                        float y = _originY + value.Data * _yScale;

                        if(i == 0)
                         {
                             canvas.MoveTo(x, y);
                             canvas.CurveTo(control1[i + 1].x, control1[i + 1].y, points[i + 1].x, points[i + 1].y);
                         }
                        else if (i == (_data.Columns.Count - 1))
                        {
                            //canvas.CurveTo(control1[i].x, control1[i].y, (double)x, (double)y);
                        }
                        else
                        {
                            canvas.CurveTo(control2[i].x, control2[i].y, control1[i + 1].x, control1[i + 1].y, points[i + 1].x, points[i + 1].y);
                        }
                        x += totalColumnWidth;
                    }
                    canvas.Stroke();
                }
                else
                {

                    for (i = 0; i < _data.Columns.Count; i++)
                    {
                        Column column = _data.Columns[i];
                        Value value = column.Values[0];
                        float y = _originY + value.Data * _yScale;


                        if (i == 0)
                        {
                            canvas.MoveTo(x, y);
                        }
                        else
                        {
                            canvas.LineTo(x, y);
                        }

                        x += totalColumnWidth;
                    }
                    canvas.Stroke();
                }
            } // SVG Render
        }



        protected override void DrawLegend(PdfCanvas canvas, PdfPage page)
        {

        }

        protected override void DrawLabels(PdfCanvas canvas, PdfPage page)
        {

        }

        protected override String GetGraphType()
        {
            return ("LineGraph");
        }


        protected override void WriteSubTypeSettings(XmlTextWriter xml)
        {
            xml.WriteAttributeString("barValueAboveTop", _barDrawValueAboveTop.ToString());
            xml.WriteAttributeString("barValueBelowTop", _barDrawValueBelowTop.ToString());
            xml.WriteAttributeString("barValueCenter", _barDrawValueCenter.ToString());
            
            xml.WriteAttributeString("barValueMargin", _barValueMargin.ToString("0.0"));
            xml.WriteAttributeString("barValueFontSize", _barValueFontSize.ToString("0.0"));
            WriteColourSetting(xml, _barValueFontColour, "barValueFontColour");
        }

        protected override void ReadSubTypeSettings(XmlTextReader xml)
        {
            _barDrawValueAboveTop = Convert.ToBoolean(xml.GetAttribute("barValueAboveTop"));
            _barDrawValueBelowTop = Convert.ToBoolean(xml.GetAttribute("barValueBelowTop"));
            _barDrawValueCenter = Convert.ToBoolean(xml.GetAttribute("barValueCenter"));
            _barValueMargin = float.Parse(xml.GetAttribute("barValueMargin"));
            _barValueFontSize = float.Parse(xml.GetAttribute("barValueFontSize"));
            ReadColour(xml, ref _barValueFontColour, "barValueFontColour");
        }

        private void cbValueAboveTop_CheckedChanged(object sender, EventArgs e)
        {
            _barDrawValueAboveTop = cbValueAboveTop.Checked;
        }

        private void cbValueCentered_CheckedChanged(object sender, EventArgs e)
        {

            _barDrawValueCenter = cbValueCentered.Checked;
        }

        private void cbValueBelowTop_CheckedChanged(object sender, EventArgs e)
        {
            _barDrawValueBelowTop = cbValueBelowTop.Checked;
        }

        private void udValueMargin_ValueChanged(object sender, EventArgs e)
        {
            _barValueMargin = (float)udValueMargin.Value;
        }

        private void udValueFontSize_ValueChanged(object sender, EventArgs e)
        {
            _barValueFontSize = (float)udValueFontSize.Value;
        }

        private void btnBarValueFontColour_Click(object sender, EventArgs e)
        {
            SetButtonColour(ref _barValueFontColour, btnBarValueFontColour);
        }
    }
}
