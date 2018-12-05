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
        bool _lineCurved = true;
        float _lineWidth = 2.0f;
        protected iText.Kernel.Colors.DeviceRgb _lineColour = new DeviceRgb(46, 121, 144);
        float _linePointSpace = 4.0f;
        float _lineXTicksInterval = 6.0f;
        bool _lineXTicks = true;

        float _yAxisMax;
        float _yAxisMin;
        int _pointCount;
        bool _skipDuplicates = false;

        public LineForm()
        {
            InitializeComponent();

            SetLayout();

            // Override defaults
            _originX = 75.0f;
            _originY = 75.0f;
            _valueAxisInterval = 10.0f;
            _barWidth = 40.0f;

            gbBars.Enabled = false;
            gbLegend.Enabled = false;

            SetDimensions();

        }

        protected override void SetLayout()
        {
            base.SetLayout();
            Int32 y = gbLegend.Location.Y + gbLegend.Size.Height + 10;
            Int32 x = 260;

            gbLine.Location = new System.Drawing.Point(x, y);
            y += gbLine.Size.Height;

            //preview.Size = new System.Drawing.Size(640, y - gbOrigin.Location.Y);

            this.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height + gbLine.Size.Height);
            this.MinimumSize = this.Size;
        }

        protected override void UpdateOnScreenSettings()
        {
            base.UpdateOnScreenSettings();

            if (udLineWidth != null)
            {
                udLineWidth.Value = new decimal(_lineWidth);
                udLinePointSpacing.Value = new decimal(_linePointSpace);
                cbLineCurve.Checked = _lineCurved;
                udXTicksInterval.Value = new decimal(_lineXTicksInterval);
                cbLineXTicks.Checked = _lineXTicks;
            }
        }

        protected override void SetDimensions()
        {
            SetAxisDimensions();

            for (_valueAxisMax = _yAxisMin; _valueAxisMax < _yAxisMax; _valueAxisMax += _valueAxisInterval)
            {

            }

            _axisHeight = Math.Abs(_valueAxisMax) + Math.Abs(_yAxisMin);

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

            _canvasHeight = _originY + _axisHeight * _yScale + _originY;
            _canvasWidth = _originX + _axisWidth + _originX;

            UpdateOnScreenSettings();
        }

        protected void SetAxisDimensions()
        {
            float x = 0;
            int i = 0;

            _pointCount = 0;
            _yAxisMax = float.MinValue;
            _yAxisMin = float.MaxValue;

            if (_lineCurved)
            {
                int j = 0;

                for (j = 0; j < _data.Legends.Count; j++)
                {
                    x = 0;

                    for (i = 0; i < _data.Columns.Count; i++)
                    {
                        Column column = _data.Columns[i];

                        Value value = column.Values[j];

                        double y = value.Data;
                        x += _linePointSpace;
                        _pointCount++;
                        if (y > _yAxisMax)
                        {
                            _yAxisMax = (float)y;
                        }
                        if (y < _yAxisMin)
                        {
                            _yAxisMin = (float)y;
                        }
                    }
                }
                _axisWidth = x;
            }
           

            Debug.WriteLine("Axis Width:" + _axisWidth.ToString("0.00"));
            Debug.WriteLine("Y Axis Max:" + _yAxisMax.ToString("0.00"));
            Debug.WriteLine("Y Axis Min:" + _yAxisMin.ToString("0.00"));

        }

        protected override void DrawBars(PdfCanvas canvas, PdfPage page)
        {
            //int columnCount = _data.Columns.Count;
            //float totalColumnWidth = (_axisWidth / columnCount);
            //float barMargin = (totalColumnWidth - _barWidth) / 2;

            if (_svgRender)
            {
                float x = _originX;
                foreach (Column column in _data.Columns)
                {
                    float y = _originY;
                    Value value = column.Values[0];


                    x += _linePointSpace;
                }
            }
            else
            {
                float x = _originX;
                int i = 0;
                int k = 0;
                double yOffset = 0;
                if (_yAxisMin < 0)
                {
                    yOffset = _yAxisMin * -1.0 * _yScale;
                }
                
                
                if (_lineCurved)
                {
                    int j = 0;
                    double lastX = 0.0;
                    double lastY = 0.0;
                    bool lastValueDuplicate = false;

                    for (j = 0; j < _data.Legends.Count; j++)
                    {
                        Legend legend = _data.Legends[j];
                        // Make a list of control points
                        List<iText.Kernel.Geom.Point> control1 = new List<iText.Kernel.Geom.Point>();
                        List<iText.Kernel.Geom.Point> control2 = new List<iText.Kernel.Geom.Point>();
                        List<iText.Kernel.Geom.Point> points = new List<iText.Kernel.Geom.Point>();

                        x = _originX;
                        // -----------------------

                        for (i = 0; i < _data.Columns.Count; i++)
                        {
                            Column column = _data.Columns[i];

                            Value value = column.Values[j];

                            double y = _originY + value.Data * _yScale + yOffset;
                            lastX = x;
                            if (_skipDuplicates)
                            {
                                if (lastY != y)
                                {
                                    lastY = y;
                                    points.Add(new iText.Kernel.Geom.Point(x, y));
                                    lastValueDuplicate = false;
                                }
                                else
                                {
                                    lastValueDuplicate = true;
                                }
                            }
                            else
                            {
                                lastY = y;
                                points.Add(new iText.Kernel.Geom.Point(x, y));
                            }
                            //Debug.WriteLine("X:" + x.ToString() + " Y:" + y.ToString());
                            x += _linePointSpace;
                           
                        }

                        if (lastValueDuplicate)
                        {
                            if (j < _data.Legends.Count - 1)
                            {
                                double nextY = _originY + _data.Columns[0].Values[j + 1].Data * _yScale + yOffset;
                                // Make sure the last value is added as a point if it was a duplicate
                                points.Add(new iText.Kernel.Geom.Point(lastX, nextY));
                                lastY = nextY;
                            }
                            lastValueDuplicate = false;
                            Debug.WriteLine("Add last Duplicate X:" + lastX.ToString() + " Y:" + lastY.ToString());
                        }

                        // Add a fake first control point so that the indexes are the same
                        control1.Add(new iText.Kernel.Geom.Point(0, 0));
                        control2.Add(new iText.Kernel.Geom.Point(0, 0));
                        for (i = 1; i < points.Count - 1; i++) // from the second point to the second to last point
                        {
                            iText.Kernel.Geom.Point point = points[i];

                            double x0 = points[i - 1].x;
                            double x2 = points[i + 1].x;
                            double y0 = points[i - 1].y;
                            double y2 = points[i + 1].y;
                            double dirx = x2 - x0;
                            double diry = y2 - y0;

                            double distance = Math.Sqrt(Math.Pow(dirx, 2) + Math.Pow(diry, 2));

                            double unitx = dirx / distance;
                            double unity = diry / distance;

                            double angle1 = Math.Atan2(unitx, -unity) + Math.PI / 2;
                            double angle2 = Math.Atan2(-unitx, unity) + Math.PI / 2;

                            double control1x = points[i].x + Math.Cos(angle1) * (distance / 5);
                            double control1y = points[i].y + Math.Sin(angle1) * (distance / 5);
                            double control2x = points[i].x + Math.Cos(angle2) * (distance / 5);
                            double control2y = points[i].y + Math.Sin(angle2) * (distance / 5);

                            control1.Add(new iText.Kernel.Geom.Point(control1x, control1y));
                            control2.Add(new iText.Kernel.Geom.Point(control2x, control2y));
                        }
                        // Add the last control point so that the indexes are the same
                        control1.Add(new iText.Kernel.Geom.Point(control2[control2.Count - 1].x, control2[control2.Count - 1].y));
                        control2.Add(new iText.Kernel.Geom.Point(0, 0));


                        canvas.SetLineWidth(_lineWidth);
                        canvas.SetStrokeColor(legend.Colour);

                        double startX = points[0].x;
                        double startY = _originY + yOffset; ;

                        for (i = 0; i < points.Count; i++)
                        {
                            if (i == 0)
                            {
                                canvas.MoveTo(points[i].x, points[i].y);
                                canvas.CurveTo(control1[i + 1].x, control1[i + 1].y, points[i + 1].x, points[i + 1].y);
                            }
                            else if (i == (points.Count - 1))
                            {

                            }
                            else
                            {
                                canvas.CurveTo(control2[i].x, control2[i].y, control1[i + 1].x, control1[i + 1].y, points[i + 1].x, points[i + 1].y);
                            }
                        }
                        canvas.Stroke();
                    }
                }
            } // SVG Render
        }

        protected override void DrawTicks(PdfCanvas canvas, PdfPage page)
        {
            base.DrawTicks(canvas, page);

            try
            {
                float lastTickValue = float.Parse(_data.Columns[0].Label);

                iText.Layout.Canvas layoutCanvas = new iText.Layout.Canvas(canvas, _pdf, new iText.Kernel.Geom.Rectangle(_canvasWidth, _canvasHeight));
                layoutCanvas.SetFont(_font);
                layoutCanvas.SetFontSize(_valueFontSize);
                layoutCanvas.SetFontColor(_valueFontColour);

                canvas.SetLineWidth(_tickLineWidth).SetStrokeColor(_tickColour);

                float x = _originX;
                foreach (Column column in _data.Columns)
                {
                    float y = _originY;
                    float columnValue = float.Parse(column.Label);

                    if (columnValue >= (lastTickValue + _lineXTicksInterval))
                    {
                        lastTickValue = columnValue;

                        canvas.MoveTo(x, _originY);
                        canvas.LineTo(x, _originY + _axisHeight * _yScale);

                        if (_columnLabelAngle == 0.0f)
                        {
                            layoutCanvas.ShowTextAligned(column.Label, x, _originY - _columnLabelMargin, TextAlignment.CENTER, VerticalAlignment.TOP, (float)Math.PI / 180.0f * _columnLabelAngle);
                        }
                        else if (_columnLabelAngle == 90.0f)
                        {
                            layoutCanvas.ShowTextAligned(column.Label, x, _originY - _columnLabelMargin, TextAlignment.RIGHT, VerticalAlignment.MIDDLE, (float)Math.PI / 180.0f * _columnLabelAngle);
                        }
                        else
                        {
                            layoutCanvas.ShowTextAligned(column.Label, x, _originY - _columnLabelMargin, TextAlignment.RIGHT, VerticalAlignment.TOP, (float)Math.PI / 180.0f * _columnLabelAngle);
                        }
                    }


                    x += _linePointSpace;
                }
                canvas.Stroke();
            }
            catch
            {
                // not numeric column values, bail
                return;
            }
        }

        protected override void DrawLegend(PdfCanvas canvas, PdfPage page)
        {
            if (_data.Legends.Count > 1)
            {
                base.DrawLegend(canvas, page);
            }
        }

        protected override void DrawLabels(PdfCanvas canvas, PdfPage page)
        {
            iText.Layout.Canvas layoutCanvas = new iText.Layout.Canvas(canvas, _pdf, new iText.Kernel.Geom.Rectangle(_canvasWidth, _canvasHeight));
            layoutCanvas.SetFont(_font);
            layoutCanvas.SetFontSize(_valueFontSize);
            layoutCanvas.SetFontColor(_valueFontColour);
            float x;

            if (_data.ValueLabel != null)
            {
                x = _originX - _valueLabelMargin;
                layoutCanvas.ShowTextAligned(_data.ValueLabel, x, _originY + _axisHeight * _yScale / 2, TextAlignment.CENTER, VerticalAlignment.MIDDLE, 0.5f * (float)Math.PI);
            }

            if (_data.Legends.Count == 1)
            {
                layoutCanvas.ShowTextAligned(_data.Legends[0].Label, _originX + _axisWidth / 2, _originY - _valueLabelMargin, TextAlignment.CENTER, VerticalAlignment.MIDDLE, 0);
            }
        }

        protected override String GetGraphType()
        {
            return ("LineGraph");
        }


        protected override void WriteSubTypeSettings(XmlTextWriter xml)
        {
            xml.WriteAttributeString("lineCurved", _lineCurved.ToString());
            xml.WriteAttributeString("lineWidth", _lineWidth.ToString("0.0"));
            xml.WriteAttributeString("linePointSpace", _linePointSpace.ToString("0.0"));
            WriteColourSetting(xml, _lineColour, "lineColour");
            xml.WriteAttributeString("lineXTicks", _lineXTicks.ToString());
            xml.WriteAttributeString("lineXTicksInterval", _lineXTicksInterval.ToString("0.0"));
        }

        protected override void ReadSubTypeSettings(XmlTextReader xml)
        {
            _lineCurved = Convert.ToBoolean(xml.GetAttribute("lineCurved"));
            _lineWidth = float.Parse(xml.GetAttribute("lineWidth"));
            _linePointSpace = float.Parse(xml.GetAttribute("linePointSpace"));
            ReadColour(xml, ref _lineColour, "lineColour");
            _lineXTicks = Convert.ToBoolean(xml.GetAttribute("lineXTicks"));
            _lineXTicksInterval = float.Parse(xml.GetAttribute("lineXTicksInterval"));
        }

        private void udLineWidth_ValueChanged(object sender, EventArgs e)
        {
            _lineWidth = (float)udLineWidth.Value;
        }

        private void btnLineColour_Click(object sender, EventArgs e)
        {
            SetButtonColour(ref _lineColour, btnLineColour);
        }

        private void cbLineCurve_CheckedChanged(object sender, EventArgs e)
        {
            _lineCurved = cbLineCurve.Checked;
        }

        private void udLinePointSpacing_ValueChanged(object sender, EventArgs e)
        {
            _linePointSpace = (float)udLinePointSpacing.Value;
        }

        private void udXTicksInterval_ValueChanged(object sender, EventArgs e)
        {
            _lineXTicksInterval = (float)udXTicksInterval.Value;
        }

        private void cbLineXTicks_CheckedChanged(object sender, EventArgs e)
        {
            _lineXTicks = cbLineXTicks.Checked;
        }
    }
}
