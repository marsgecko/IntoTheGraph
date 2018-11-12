﻿using System;
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
    public partial class GraphForm : Form
    {
        protected PdfDocument _pdf;
        protected PdfFont _font;
        protected GraphData _data;

        protected float _canvasWidth = 600;
        protected float _canvasHeight = 400;

        protected float _yScale = 1.0f;

        protected float _originX;
        protected float _originY;

        protected float _axisLineWidth = 1.0f;
        protected iText.Kernel.Colors.Color _axisColour = new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.575f);
        protected float _axisWidth;
        protected float _axisHeight;
        protected bool _drawXAxis = true;
        protected bool _drawYAxis = true;

        protected float _valueAxisMax = 250;
        protected float _valueAxisInterval = 5;
        protected float _valueLabelMargin = 30;
        protected float _valueFontSize = 12.0f;
        protected iText.Kernel.Colors.Color _valueFontColour = new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.875f);

        protected float _tickLineWidth = 0.5f;
        protected iText.Kernel.Colors.Color _tickColour = new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.275f);
        protected float _tickFontSize = 8.0f;
        protected iText.Kernel.Colors.Color _tickFontColour = new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.575f);
        protected float _tickLabelMargin = 8.0f;

        protected float _barWidth = 10;
        protected float _barMargin = 10;

        protected float _columnLabelMargin = 5.0f;
        protected float _columnFontSize = 12.0f;
        protected iText.Kernel.Colors.Color _columnFontColour = new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.875f);

        protected bool _legendIsHorizontal = true;
        protected float _legendMargin = 15.0f;
        protected float _legendTextMargin = 10.0f;
        protected float _legendVerticalSize = 25.0f;
        protected float _legendKeySize = 5.0f;
        protected float _legendFontSize = 10.0f;
        protected iText.Kernel.Colors.Color _legendFontColour = new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.875f);

        protected List<Button> mLegendButtons;
        protected List<Label> mLegendLabels;

        public GraphForm()
        {
            InitializeComponent();

            mLegendButtons = new List<Button>();
            mLegendLabels = new List<Label>();

            _data = new GraphData();

            _data.GenerateData();

            _originX = 75.0f;
            _originY = 120.0f;

            SetDimensions();
            ShowLegend();

            SetFont();
        }

        protected System.Drawing.Color GetColorFromiTextColour(iText.Kernel.Colors.Color iTextColour)
        {
            System.Drawing.Color result;

            if (iTextColour.GetColorSpace().ToString() == "iText.Kernel.Pdf.Colorspace.PdfDeviceCs+Cmyk")
            {
                float[] cmyk = iTextColour.GetColorValue();
                result = ConvertCmykToRgb(cmyk[0], cmyk[1], cmyk[2], cmyk[3]);
            }
            else
            {
                float[] rgb = iTextColour.GetColorValue();
                result = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0] * 255), Convert.ToInt32(rgb[1] * 255), Convert.ToInt32(rgb[2] * 255));
            }

            return result;
        }

        protected virtual void UpdateOnScreenSettings()
        {
            udOriginX.Value = new decimal(_originX);
            udOriginY.Value = new decimal(_originY);

            cbDrawXAxis.Checked = _drawXAxis;
            cbDrawYAxis.Checked = _drawYAxis;

            udAxisLineWidth.Value =  new decimal(_axisLineWidth);

            udXAxisWidth.Value = new decimal(_axisWidth);
            udYAxisHeight.Value = new decimal(_axisHeight);

            udMaxValue.Value = new decimal(_valueAxisMax);
            udInterval.Value = new decimal(_valueAxisInterval);

            udBarWidth.Value = new decimal(_barWidth);
            udBarMargin.Value = new decimal(_barMargin);

            udTickLineWidth.Value = new decimal(_tickLineWidth);
            udTickLabelMargin.Value = new decimal(_tickLabelMargin);
            udTickFontSize.Value = new decimal(_tickFontSize);

            btnTickLineColour.BackColor = GetColorFromiTextColour(_tickColour);
            btnTickFontColour.BackColor = GetColorFromiTextColour(_tickFontColour);

            udXAxisLabelMargin.Value = new decimal(_valueLabelMargin);
            udXAxisLableFontSize.Value= new decimal(_valueFontSize);
            btnXAxisLabelFontColour.BackColor = GetColorFromiTextColour(_valueFontColour);

            udColumnLabelMargin.Value = new decimal(_columnLabelMargin);
            udColumnLabelFontSize.Value = new decimal(_columnFontSize);
            btnColumnLableFontColour.BackColor = GetColorFromiTextColour(_columnFontColour);
        }

        protected static System.Drawing.Color ConvertCmykToRgb(float c, float m, float y, float k)
        {
            int r;
            int g;
            int b;

            r = Convert.ToInt32(255 * (1 - c) * (1 - k));
            g = Convert.ToInt32(255 * (1 - m) * (1 - k));
            b = Convert.ToInt32(255 * (1 - y) * (1 - k));

            return System.Drawing.Color.FromArgb(r, g, b);
        }

        protected virtual void ShowLegend()
        {
            int x = lblLegend.Location.X;
            int y = lblLegend.Location.Y + 30;

            foreach( Button button in mLegendButtons )
            {
                button.Click -= btnLegend_Click;
                this.Controls.Remove(button);
            }
            foreach (Label label in mLegendLabels)
            {
                this.Controls.Remove(label);
            }
            mLegendButtons.Clear();
            mLegendLabels.Clear();

            foreach (Legend legend in _data.Legends)
            {
                Button newButton = new Button();
                newButton.Width = 20;
                newButton.Height = 20;
                newButton.Tag = legend;

                //float[] cmyk = legend.Colour.GetColorValue();
                //newButton.BackColor = ConvertCmykToRgb(cmyk[0], cmyk[1], cmyk[2], cmyk[3]);

                if (legend.Colour.GetColorSpace().ToString() == "iText.Kernel.Pdf.Colorspace.PdfDeviceCs+Cmyk")
                {
                    float[] cmyk = legend.Colour.GetColorValue();
                    newButton.BackColor = ConvertCmykToRgb(cmyk[0], cmyk[1], cmyk[2], cmyk[3]);
                }
                else
                {
                    float[] rgb = legend.Colour.GetColorValue();
                    newButton.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0] * 255), Convert.ToInt32(rgb[1] * 255), Convert.ToInt32(rgb[2] * 255));
                }

                newButton.Click += btnLegend_Click;

                this.Controls.Add(newButton);
                mLegendButtons.Add(newButton);
                newButton.Location = new System.Drawing.Point(x,y);

                Label label = new Label();
                label.Text = legend.Label;
                this.Controls.Add(label);
                mLegendLabels.Add(label);
                label.Location = new System.Drawing.Point(x + 25, y + 3);

                y += 30;
            }
        }

        public static string GetSystemFontFileName(Font font)
        {
            RegistryKey fonts = null;
            try
            {
                fonts = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Fonts", false);
                if (fonts == null)
                {
                    fonts = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Fonts", false);
                    if (fonts == null)
                    {
                        throw new Exception("Can't find font registry database.");
                    }
                }

                string suffix = "";
                if (font.Bold)
                    suffix += "(?: Bold)?";
                if (font.Italic)
                    suffix += "(?: Italic)?";

                var regex = new Regex(@"^(?:.+ & )?" + Regex.Escape(font.Name) + @"(?: & .+)?(?<suffix>" + suffix + @") \(TrueType\)$", RegexOptions.Compiled);

                string[] names = fonts.GetValueNames();

                string name = names.Select(n => regex.Match(n)).Where(m => m.Success).OrderByDescending(m => m.Groups["suffix"].Length).Select(m => m.Value).FirstOrDefault();

                if (name != null)
                {
                    return "C:\\Windows\\Fonts\\" + fonts.GetValue(name).ToString();
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                if (fonts != null)
                {
                    fonts.Dispose();
                }
            }
        }

        protected virtual void SetFont()
        {
            lblFont.Font = new Font(fontDialog.Font.FontFamily, 12);
            lblFont.Text = "The chosen font is " + fontDialog.Font.Name;
        }

        protected virtual void SetDimensions()
        {
            float maxValue = _data.GetMaxValue();

            for (_valueAxisMax = 0; _valueAxisMax < maxValue; _valueAxisMax += _valueAxisInterval)
            {

            }

            _axisWidth = _barWidth * _data.Legends.Count * _data.Columns.Count + _barMargin * (_data.Columns.Count + 1);
            _axisHeight = _valueAxisMax;

            _yScale = 1.0f;
            if( _axisHeight < _axisWidth * 0.25f)
            {
                float newHeight = _axisWidth * 0.25f;
                _yScale = newHeight/_axisHeight;
            }

            _canvasHeight = _originY + _axisHeight * _yScale + 300;
            _canvasWidth = _originX + _axisWidth + 75;

            UpdateOnScreenSettings();
        }

        protected virtual void UpdateYAxisHeight()
        {
            float maxValue = _data.GetMaxValue();

            for (_valueAxisMax = 0; _valueAxisMax < maxValue; _valueAxisMax += _valueAxisInterval)
            {

            }
            _axisHeight = _valueAxisMax;

            _yScale = 1.0f;
            if (_axisHeight < _axisWidth * 0.25f)
            {
                float newHeight = _axisWidth * 0.25f;
                _yScale = newHeight / _axisHeight;
            }
            _canvasHeight = _originY + _axisHeight + 300;
        }

        protected virtual void DrawTicks(PdfCanvas canvas, PdfPage page)
        {
            float i;
            String text;
            float textWidth;
            float textHeight;

            canvas.SetLineWidth(_tickLineWidth).SetStrokeColor(_tickColour);
            // DrawTicks
            for (i = _valueAxisInterval; i <= _valueAxisMax; i += _valueAxisInterval)
            {
                text = i.ToString();
                textWidth = _font.GetWidth(text, _tickFontSize) + _tickLabelMargin;
                textHeight = _font.GetAscent(text, _tickFontSize) - _font.GetDescent(text, _tickFontSize);

                canvas.MoveTo(_originX, _originY + i * _yScale);
                canvas.LineTo(_originX + _axisWidth, _originY + i * _yScale);

                canvas.BeginText()
                  .SetFontAndSize(_font, _tickFontSize)
                  .MoveText(_originX - textWidth, _originY + i * _yScale - textHeight / 2)
                  .SetColor(_tickFontColour, true)
                  .ShowText(text)
                  .EndText();
            }

            // Top tick has a label but no line
            /*ext = i.ToString();
            textWidth = _font.GetWidth(text, _tickFontSize) + _tickLabelMargin;
            textHeight = _font.GetAscent(text, _tickFontSize) - _font.GetDescent(text, _tickFontSize);

            canvas.BeginText()
              .SetFontAndSize(_font, _tickFontSize)
              .MoveText(_originX - textWidth, _originY + i - textHeight / 2)
              .SetColor(_tickFontColour, true)
              .ShowText(text)
              .EndText();
            */
            canvas.Stroke();
        }

        protected virtual void DrawAxes(PdfCanvas canvas, PdfPage page)
        {
            canvas.SetLineWidth(_axisLineWidth).SetStrokeColor(_axisColour);

            if (_drawXAxis)
            {
                // Draw X Axis
                canvas.MoveTo(_originX, _originY);
                canvas.LineTo(_originX + _axisWidth, _originY);
            }

            if (_drawYAxis)
            {
                // Draw Y Axis
                canvas.MoveTo(_originX, _originY);
                canvas.LineTo(_originX, _originY + _axisHeight * _yScale);
            }

            canvas.Stroke();
        }

        protected virtual void DrawBars(PdfCanvas canvas, PdfPage page)
        {
/*            int columnCount = _data.Columns.Count;
            int barCount = _data.Legends.Count;

            float x = _originX + _barMargin;
            float y = _originY;

            foreach (Column column in _data.Columns)
            {
                foreach (Value value in column.Values)
                {
                    iText.Kernel.Geom.Rectangle rectangle = new iText.Kernel.Geom.Rectangle(x, y, _barWidth, value.Data * _yScale);
                    canvas.SetFillColor(value.Legend.Colour);
                    canvas.Rectangle(rectangle);
                    canvas.Fill();
                    x += _barWidth;
                }
                x += _barMargin;
            }*/

        }

        protected virtual void DrawLabels(PdfCanvas canvas, PdfPage page)
        {

            //canvas.BeginText();
            //canvas.SetFontAndSize(_font, _valueFontSize);
            //canvas.SetFillColor(_valueFontColour);
            //canvas.EndText();

            iText.Layout.Canvas layoutCanvas = new iText.Layout.Canvas(canvas, _pdf, new iText.Kernel.Geom.Rectangle(_canvasWidth, _canvasHeight));
            layoutCanvas.SetFont(_font);
            layoutCanvas.SetFontSize(_valueFontSize);
            layoutCanvas.SetFontColor(_valueFontColour);

            float x = _originX - _valueLabelMargin;
            layoutCanvas.ShowTextAligned(_data.ValueLabel, x, _originY + _axisHeight * _yScale / 2, TextAlignment.CENTER, VerticalAlignment.MIDDLE, 0.5f * (float)Math.PI);
            

            int columnCount = _data.Columns.Count;
            float totalColumnWidth = (_axisWidth / columnCount);
            float barMargin = (totalColumnWidth - _barWidth) / 2;
            x = _originX + barMargin + _barWidth/2;
            float y = _originY - _columnLabelMargin;

            layoutCanvas.SetFontSize(_columnFontSize);
            layoutCanvas.SetFontColor(_columnFontColour);

            foreach (Column column in _data.Columns)
            {
                Debug.WriteLine(column.Label);
                layoutCanvas.ShowTextAligned(column.Label, x, y, TextAlignment.RIGHT, VerticalAlignment.TOP, 0.25f * (float)Math.PI);
                x += totalColumnWidth;
            }

            layoutCanvas.Close();
        }

        protected virtual void DrawLegend(PdfCanvas canvas, PdfPage page)
        {
            if (_legendIsHorizontal)
            {
                float x = 0.0f;
                float legendWidth = 0.0f;
                float y = _originY + _axisHeight * _yScale + _legendMargin;

                foreach (Legend legend in _data.Legends)
                {
                    float width = _font.GetWidth(legend.Label, _legendFontSize) + _legendTextMargin + _legendKeySize * 2 + _legendMargin;
                    legendWidth += width;
                }
                legendWidth -= _legendMargin;

                x = _originX + _axisWidth / 2 - legendWidth / 2;

                foreach (Legend legend in _data.Legends)
                {
                    canvas.SetFillColor(legend.Colour);
                    canvas.Circle(x, y, _legendKeySize);
                    canvas.Fill();

                    float textHeight = _font.GetAscent(legend.Label, _legendFontSize);

                    canvas.BeginText()
                          .SetFontAndSize(_font, _legendFontSize)
                          .MoveText(x + _legendTextMargin, y - textHeight / 2)
                          .SetColor(_legendFontColour, true)
                          .ShowText(legend.Label)
                          .EndText();

                    x += _font.GetWidth(legend.Label, _legendFontSize) + _legendTextMargin + _legendKeySize * 2 + _legendMargin;
                }
            }
            else
            {
                float x = _originX + _axisWidth + _legendMargin;
                float legendHeight = _data.Legends.Count * _legendVerticalSize;
                float y = _originY + _axisHeight / 2 - legendHeight / 2;

                foreach (Legend legend in _data.Legends)
                {

                    canvas.SetFillColor(legend.Colour);
                    canvas.Circle(x, y, _legendKeySize);
                    canvas.Fill();
                    //float textHeight = _font.GetAscent(legend.Label, _legendFontSize) - _font.GetDescent(legend.Label, _legendFontSize);
                    float textHeight = _font.GetAscent(legend.Label, _legendFontSize);

                    canvas.BeginText()
                          .SetFontAndSize(_font, _legendFontSize)
                          .MoveText(x + _legendTextMargin, y - textHeight / 2)
                          .SetColor(_legendFontColour, true)
                          .ShowText(legend.Label)
                          .EndText();

                    y += _legendVerticalSize;
                }
            }
        }

        protected virtual void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "graph.pdf";
            DialogResult result = saveFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {

                FileStream fos = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                PdfWriter writer = new PdfWriter(fos);

                _pdf = new PdfDocument(writer);

                String fontFileName = GetSystemFontFileName(fontDialog.Font);
                _font = PdfFontFactory.CreateFont(fontFileName, iText.IO.Font.PdfEncodings.IDENTITY_H); 

                iText.Kernel.Geom.Rectangle pageRect = new iText.Kernel.Geom.Rectangle(_canvasWidth, _canvasHeight);

                PdfPage page = _pdf.AddNewPage(new PageSize(pageRect));
                PdfCanvas canvas = new PdfCanvas(page);

                Debug.WriteLine("Page Size: " + page.GetPageSize().ToString());


                SetFont();

                DrawTicks(canvas, page);
                DrawBars(canvas, page);
                DrawAxes(canvas, page);
                DrawLabels(canvas, page);
                DrawLegend(canvas, page);

                _pdf.Close();
                writer.Close();
                fos.Close();
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                SetFont();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _data.LoadExcelFile(openFileDialog.FileName, cbNoAuto.Checked);

                if (!cbNoAuto.Checked)
                {
                    SetDimensions();
                }

                ShowLegend();
            }
        }

        private void udOriginX_ValueChanged(object sender, EventArgs e)
        {
            _originX = (float)udOriginX.Value;
            SetDimensions();
        }

        private void udOriginY_ValueChanged(object sender, EventArgs e)
        {
            _originY = (float)udOriginY.Value;
            SetDimensions();
        }

        private void cbDrawXAxis_CheckedChanged(object sender, EventArgs e)
        {
            _drawXAxis = cbDrawXAxis.Checked;
            udXAxisWidth.Enabled = cbDrawXAxis.Checked;
        }

        private void cbDrawYAxis_CheckedChanged(object sender, EventArgs e)
        {
            _drawYAxis = cbDrawYAxis.Checked;
            udYAxisHeight.Enabled = cbDrawYAxis.Checked;
        }

        private void udAxisLineWidth_ValueChanged(object sender, EventArgs e)
        {
            _axisLineWidth = (float)udAxisLineWidth.Value;
        }

        private void udXAxisWidth_ValueChanged(object sender, EventArgs e)
        {
            _axisWidth = (float)udXAxisWidth.Value;
        }

        private void udYAxisHeight_ValueChanged(object sender, EventArgs e)
        {
            _axisHeight = (float)udYAxisHeight.Value;
        }

        private void udMaxValue_ValueChanged(object sender, EventArgs e)
        {
            _valueAxisMax = (float)udMaxValue.Value;
        }

        private void udInterval_ValueChanged(object sender, EventArgs e)
        {
            _valueAxisInterval = (float)udInterval.Value;

            SetDimensions();
        }

        private void udBarWidth_ValueChanged(object sender, EventArgs e)
        {
            _barWidth = (float)udBarWidth.Value;

            SetDimensions();
        }

        private void udBarMargin_ValueChanged(object sender, EventArgs e)
        {
            _barMargin = (float)udBarMargin.Value;

            SetDimensions();
        }

        private void btnLegend_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Legend legend = (Legend)button.Tag;
            System.Drawing.Color currentColor;

            if (legend.Colour.GetColorSpace().ToString() == "iText.Kernel.Pdf.Colorspace.PdfDeviceCs+Cmyk")
            {
                float[] cmyk = legend.Colour.GetColorValue();
                currentColor = ConvertCmykToRgb(cmyk[0], cmyk[1], cmyk[2], cmyk[3]);
            }
            else
            {
                float[] rgb = legend.Colour.GetColorValue();
                currentColor = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0] * 255), Convert.ToInt32(rgb[1] * 255), Convert.ToInt32(rgb[2] * 255));
            }

            colorDialog.CustomColors = new int[] { ColorTranslator.ToOle(currentColor) };
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                legend.Colour = new DeviceRgb(colorDialog.Color);
                ShowLegend();
            }
        }

        private void udTickLineWidth_ValueChanged(object sender, EventArgs e)
        {
            _tickLineWidth = (float)udTickLineWidth.Value;
        }

        private void udTickLabelMargin_ValueChanged(object sender, EventArgs e)
        {
            _tickLabelMargin = (float)udTickLabelMargin.Value;
        }

        private void udTickFontSize_ValueChanged(object sender, EventArgs e)
        {
            _tickFontSize = (float)udTickFontSize.Value;
        }

        private void SetButtonColour(ref iText.Kernel.Colors.Color iTextColour, Button button)
        {
            System.Drawing.Color currentColor;

            if (iTextColour.GetColorSpace().ToString() == "iText.Kernel.Pdf.Colorspace.PdfDeviceCs+Cmyk")
            {
                float[] cmyk = iTextColour.GetColorValue();
                currentColor = ConvertCmykToRgb(cmyk[0], cmyk[1], cmyk[2], cmyk[3]);
            }
            else
            {
                float[] rgb = iTextColour.GetColorValue();
                currentColor = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0] * 255), Convert.ToInt32(rgb[1] * 255), Convert.ToInt32(rgb[2] * 255));
            }

            colorDialog.CustomColors = new int[] { ColorTranslator.ToOle(currentColor) };
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                iTextColour = new DeviceRgb(colorDialog.Color);
                button.BackColor = colorDialog.Color;
            }
        }

        private void btnTickFontColour_Click(object sender, EventArgs e)
        {
            SetButtonColour(ref _tickFontColour, btnTickFontColour);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetButtonColour(ref _tickColour, btnTickLineColour);
        }

        private void udXAxisLabelMargin_ValueChanged(object sender, EventArgs e)
        {
            _valueLabelMargin = (float)udXAxisLabelMargin.Value;
        }

        private void udXAxisLableFontSize_ValueChanged(object sender, EventArgs e)
        {
            _valueFontSize = (float)udXAxisLableFontSize.Value;
        }

        private void btnXAxisLabelFontColour_Click(object sender, EventArgs e)
        {
            SetButtonColour(ref _valueFontColour, btnXAxisLabelFontColour);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _columnLabelMargin = (float)udColumnLabelMargin.Value;
        }

        private void udColumnLabelFontSize_ValueChanged(object sender, EventArgs e)
        {
            _columnFontSize = (float)udColumnLabelFontSize.Value;
        }

        private void btnColumnLableFontColour_Click(object sender, EventArgs e)
        {
            SetButtonColour(ref _columnFontColour, btnColumnLableFontColour);
        }

        protected virtual String GetGraphType()
        {
            return("Invalid");
        }

        protected void WriteColourSetting(XmlTextWriter xml, iText.Kernel.Colors.Color iTextColour, String name)
        {
            System.Drawing.Color currentColor;

            if (iTextColour.GetColorSpace().ToString() == "iText.Kernel.Pdf.Colorspace.PdfDeviceCs+Cmyk")
            {
                float[] cmyk = iTextColour.GetColorValue();
                currentColor = ConvertCmykToRgb(cmyk[0], cmyk[1], cmyk[2], cmyk[3]);
            }
            else
            {
                float[] rgb = iTextColour.GetColorValue();
                currentColor = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0] * 255), Convert.ToInt32(rgb[1] * 255), Convert.ToInt32(rgb[2] * 255));
            }

            xml.WriteAttributeString(name, currentColor.ToArgb().ToString());

        }

        protected virtual void WriteSettings(XmlTextWriter xml)
        {
            xml.WriteStartElement(GetGraphType());

            xml.WriteAttributeString("canvasWidth", _canvasWidth.ToString("0.0"));

            xml.WriteAttributeString("canvasHeight", _canvasHeight.ToString("0.0"));

            xml.WriteAttributeString("yScale", _yScale.ToString("0.0"));

            xml.WriteAttributeString("originX", _originX.ToString("0.0"));
            xml.WriteAttributeString("originY", _originY.ToString("0.0"));

            xml.WriteAttributeString("axisLineWidth", _axisLineWidth.ToString("0.0"));
            WriteColourSetting(xml, _axisColour, "axisColour");
            xml.WriteAttributeString("axisWidth", _axisWidth.ToString("0.0"));
            xml.WriteAttributeString("axisHeight", _axisHeight.ToString("0.0"));
            xml.WriteAttributeString("drawXAxis", _drawXAxis.ToString());
            xml.WriteAttributeString("drawYAxis", _drawYAxis.ToString());

            xml.WriteAttributeString("valueAxisMax", _valueAxisMax.ToString("0.0"));
            xml.WriteAttributeString("valueAxisInterval", _valueAxisInterval.ToString("0.0"));
            xml.WriteAttributeString("valueLabelMargin", _valueLabelMargin.ToString("0.0"));
            xml.WriteAttributeString("valueFontSize", _valueFontSize.ToString("0.0"));
            WriteColourSetting(xml, _valueFontColour, "valueFontColour");

            xml.WriteAttributeString("tickLineWidth", _tickLineWidth.ToString("0.0"));
            WriteColourSetting(xml, _tickColour, "tickColour");
            xml.WriteAttributeString("tickFontSize", _tickFontSize.ToString("0.0"));
            WriteColourSetting(xml, _tickFontColour, "tickFontColour");
            xml.WriteAttributeString("tickLabelMargin", _tickLabelMargin.ToString("0.0"));

            xml.WriteAttributeString("barWidth", _barWidth.ToString("0.0"));
            xml.WriteAttributeString("barMargin", _barMargin.ToString("0.0"));

            xml.WriteAttributeString("columnLabelMargin", _columnLabelMargin.ToString("0.0"));
            xml.WriteAttributeString("columnFontSize", _columnFontSize.ToString("0.0"));
            WriteColourSetting(xml, _columnFontColour, "columnFontColour");

            xml.WriteAttributeString("legendIsHorizontal", _legendIsHorizontal.ToString());
            xml.WriteAttributeString("legendMargin", _legendMargin.ToString("0.0"));
            xml.WriteAttributeString("legendTextMargin", _legendTextMargin.ToString("0.0"));
            xml.WriteAttributeString("legendVerticalSize", _legendVerticalSize.ToString("0.0"));
            xml.WriteAttributeString("legendKeySize", _legendKeySize.ToString("0.0"));
            xml.WriteAttributeString("legendFontSize", _legendFontSize.ToString("0.0"));
            WriteColourSetting(xml, _legendFontColour, "legendFontColour");

            xml.WriteEndElement();   
        }

        protected virtual void WriteLegends(XmlTextWriter xml)
        {
            int i = 0;
            foreach (Legend legend in _data.Legends)
            {
                xml.WriteStartElement("legend");

                xml.WriteAttributeString("index", i.ToString());
                WriteColourSetting(xml, legend.Colour, "colour");

                xml.WriteEndElement();
                i++;
            }
        }

        protected virtual void ReadSettings(XmlTextReader xml)
        {
            _canvasWidth = float.Parse(xml.GetAttribute("canvasWidth") );
            _canvasHeight = float.Parse(xml.GetAttribute("canvasHeight") );
            _yScale = float.Parse(xml.GetAttribute("yScale") );
            _originX = float.Parse(xml.GetAttribute("originX") );
            _originY = float.Parse(xml.GetAttribute("originY") );
            _axisLineWidth = float.Parse(xml.GetAttribute("axisLineWidth") );
            _axisColour = new DeviceRgb(System.Drawing.Color.FromArgb(Convert.ToInt32(xml.GetAttribute("axisColour"))));
            _axisWidth = float.Parse(xml.GetAttribute("axisWidth"));
            _axisHeight = float.Parse(xml.GetAttribute("axisHeight"));
            _drawXAxis = Convert.ToBoolean(xml.GetAttribute("drawXAxis"));
            _drawYAxis = Convert.ToBoolean(xml.GetAttribute("drawYAxis"));
            _valueAxisMax = float.Parse(xml.GetAttribute("valueAxisMax"));
            _valueAxisInterval = float.Parse(xml.GetAttribute("valueAxisInterval"));
            _valueLabelMargin = float.Parse(xml.GetAttribute("valueLabelMargin"));
            _valueFontSize = float.Parse(xml.GetAttribute("valueFontSize"));
            _valueFontColour = new DeviceRgb(System.Drawing.Color.FromArgb(Convert.ToInt32(xml.GetAttribute("valueFontColour"))));
            _tickLineWidth = float.Parse(xml.GetAttribute("tickLineWidth"));
            _tickColour = new DeviceRgb(System.Drawing.Color.FromArgb(Convert.ToInt32(xml.GetAttribute("tickColour"))));
            _tickFontSize = float.Parse(xml.GetAttribute("tickFontSize"));
            _tickFontColour = new DeviceRgb(System.Drawing.Color.FromArgb(Convert.ToInt32(xml.GetAttribute("tickFontColour"))));
            _tickLabelMargin = float.Parse(xml.GetAttribute("tickLabelMargin"));
            _barWidth = float.Parse(xml.GetAttribute("barWidth"));
            _barMargin = float.Parse(xml.GetAttribute("barMargin"));
            _columnLabelMargin = float.Parse(xml.GetAttribute("columnLabelMargin"));
            _columnFontSize = float.Parse(xml.GetAttribute("columnFontSize"));
            _columnFontColour = new DeviceRgb(System.Drawing.Color.FromArgb(Convert.ToInt32(xml.GetAttribute("columnFontColour"))));
            _legendIsHorizontal = Convert.ToBoolean(xml.GetAttribute("legendIsHorizontal"));
            _legendMargin = float.Parse(xml.GetAttribute("legendMargin"));
            _legendTextMargin = float.Parse(xml.GetAttribute("legendTextMargin"));
            _legendVerticalSize = float.Parse(xml.GetAttribute("legendVerticalSize"));
            _legendKeySize = float.Parse(xml.GetAttribute("legendKeySize"));
            _legendFontSize = float.Parse(xml.GetAttribute("legendFontSize"));
            _legendFontColour = new DeviceRgb(System.Drawing.Color.FromArgb(Convert.ToInt32(xml.GetAttribute("legendFontColour"))));
        }

        protected virtual void ReadLegend(XmlTextReader xml)
        {
            Int32 index = Convert.ToInt32(xml.GetAttribute("index"));
            String colourString = xml.GetAttribute("colour");
            if(index < _data.Legends.Count)
            {
                _data.Legends[index].Colour = new DeviceRgb(System.Drawing.Color.FromArgb(Convert.ToInt32(colourString)));
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = GetGraphType() + ".gph";
            DialogResult result = saveFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                using (XmlTextWriter xml = new XmlTextWriter(saveFileDialog.FileName, null))
                {
                    // Root.
                    xml.WriteStartDocument();

                    xml.Formatting = Formatting.Indented;

                    xml.WriteStartElement("graph");

                    WriteSettings(xml);
                    WriteLegends(xml);

                    xml.WriteEndElement();

                    xml.WriteEndDocument();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Graph files (*.gph)|*.gph|All files (*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (XmlTextReader reader = new XmlTextReader(openFileDialog.FileName))
                    {
                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element:
                                    if (reader.Name == GetGraphType())
                                    {
                                        ReadSettings(reader);
                                    }
                                    else if (reader.Name == "legend")
                                    {
                                        ReadLegend(reader);
                                    }
                                    else if (reader.Name == "graph")
                                    {
                                        ReadLegend(reader);
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
                    UpdateYAxisHeight();
                    UpdateOnScreenSettings();
                    ShowLegend();
                }
                catch
                {
                    MessageBox.Show("Invalid Graph File", "Cannot Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
