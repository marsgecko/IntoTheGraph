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
        protected bool _barDrawBorder = false;
        protected float _barBorderWidth = 1;
        protected iText.Kernel.Colors.Color _barBorderColour = new DeviceCmyk(0.0f, 0.0f, 0.0f, 0.0f);

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

        protected bool _svgRender = false;
        protected svgWriter _svgWriter;

        public GraphForm()
        {
            InitializeComponent();

            String fontFileName = GetSystemFontFileName(fontDialog.Font);
            _font = PdfFontFactory.CreateFont(fontFileName, iText.IO.Font.PdfEncodings.IDENTITY_H);

            mLegendButtons = new List<Button>();
            mLegendLabels = new List<Label>();

            _data = new GraphData();

            _data.GenerateData();

            _originX = 75.0f;
            _originY = 120.0f;

            SetFont();
            SetDimensions();
            ShowLegend();

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
            udXAxisWidth.Enabled = cbDrawXAxis.Checked;
            udYAxisHeight.Enabled = cbDrawYAxis.Checked;

            udMaxValue.Value = new decimal(_valueAxisMax);
            udInterval.Value = new decimal(_valueAxisInterval);

            udBarWidth.Value = new decimal(_barWidth);
            udBarMargin.Value = new decimal(_barMargin);
            cbDrawBorder.Checked = _barDrawBorder;
            udBorderWidth.Value = new decimal(_barBorderWidth);
            btnBorderColour.BackColor = GetColorFromiTextColour(_barBorderColour);
            btnBorderColour.Enabled = cbDrawBorder.Checked;
            udBorderWidth.Enabled = cbDrawBorder.Checked;

            udTickLineWidth.Value = new decimal(_tickLineWidth);
            udTickLabelMargin.Value = new decimal(_tickLabelMargin);
            udTickFontSize.Value = new decimal(_tickFontSize);

            btnTickLineColour.BackColor = GetColorFromiTextColour(_tickColour);
            btnTickFontColour.BackColor = GetColorFromiTextColour(_tickFontColour);

            udYAxisLabelMargin.Value = new decimal(_valueLabelMargin);
            udYAxisLableFontSize.Value= new decimal(_valueFontSize);
            btnYAxisLabelFontColour.BackColor = GetColorFromiTextColour(_valueFontColour);

            udColumnLabelMargin.Value = new decimal(_columnLabelMargin);
            udColumnLabelFontSize.Value = new decimal(_columnFontSize);
            btnColumnLableFontColour.BackColor = GetColorFromiTextColour(_columnFontColour);

            cbLegendHorizontal.Checked = _legendIsHorizontal;
            udLegendMargin.Value = new decimal(_legendMargin);
            udLegendTextMargin.Value = new decimal(_legendTextMargin);
            udLegendVerticalSize.Value = new decimal(_legendVerticalSize);
            udLegendKeySize.Value = new decimal(_legendKeySize);
            udLegendFontSize.Value = new decimal(_legendFontSize);
            btnLegendFontColour.BackColor = GetColorFromiTextColour(_legendFontColour);

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

            if(_legendIsHorizontal)
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

        protected virtual void DrawTicks(PdfCanvas canvas, PdfPage page)
        {
            float i;
            String text;
            float textWidth;
            float textHeight;

            if (_svgRender)
            {
                for (i = _valueAxisInterval; i <= _valueAxisMax; i += _valueAxisInterval)
                {
                    //Line(float x1, float y1, float x2, float y2, System.Drawing.Color colour, float lineWidth)
                    _svgWriter.Line(_originX,
                                    _originY + i * _yScale,
                                    _originX + _axisWidth,
                                    _originY + i * _yScale,
                                    GetColorFromiTextColour(_tickColour),
                                    _tickLineWidth);

                    // Text(float x, float y, String text, System.Drawing.Color fillColour, String anchor, float rotation)
                    _svgWriter.Text(_originX - _tickLabelMargin,
                                    _originY + i * _yScale,
                                    i.ToString(),
                                    GetColorFromiTextColour(_tickFontColour),
                                    "end",
                                    0.0f,
                                    _tickFontSize);
                }
            }
            else
            {
                canvas.SetLineWidth(_tickLineWidth).SetStrokeColor(_tickColour);
                // DrawTicks
                for (i = _valueAxisInterval; i <= _valueAxisMax; i += _valueAxisInterval)
                {
                    text = i.ToString();
                    textWidth = _font.GetWidth(text, _tickFontSize) + _tickLabelMargin;
                    textHeight = _font.GetAscent(text, _tickFontSize) + _font.GetDescent(text, _tickFontSize);

                    canvas.MoveTo(_originX, _originY + i * _yScale);
                    canvas.LineTo(_originX + _axisWidth, _originY + i * _yScale);

                    canvas.BeginText()
                      .SetFontAndSize(_font, _tickFontSize)
                      .MoveText(_originX - textWidth, _originY + i * _yScale - textHeight / 2)
                      .SetColor(_tickFontColour, true)
                      .ShowText(text)
                      .EndText();
                }
                canvas.Stroke();
            }
        }

        protected virtual void DrawAxes(PdfCanvas canvas, PdfPage page)
        {
            if (_svgRender)
            {
                //Line(float x1, float y1, float x2, float y2, System.Drawing.Color colour, float lineWidth)
                if (_drawXAxis)
                {
                    _svgWriter.Line(_originX,
                                    _originY,
                                    _originX + _axisWidth,
                                    _originY,
                                    GetColorFromiTextColour(_axisColour),
                                    _axisLineWidth);
                }
                if (_drawYAxis)
                {
                    _svgWriter.Line(_originX,
                                    _originY,
                                    _originX,
                                    _originY + _axisHeight * _yScale,
                                    GetColorFromiTextColour(_axisColour),
                                    _axisLineWidth);
                }
            }
            else
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
        }

        protected virtual void DrawBars(PdfCanvas canvas, PdfPage page)
        {

        }

        protected virtual void DrawLabels(PdfCanvas canvas, PdfPage page)
        {
            if (_svgRender)
            {
                float x = _originX - _valueLabelMargin;
                //Text(float x, float y, String text, System.Drawing.Color fillColour, String anchor, float rotation)
                _svgWriter.Text(x,
                                _originY + _axisHeight * _yScale / 2,
                                _data.ValueLabel,
                                GetColorFromiTextColour(_valueFontColour),
                                "middle",
                                -90.0f,
                                _valueFontSize);
                //layoutCanvas.ShowTextAligned(_data.ValueLabel, x, _originY + _axisHeight * _yScale / 2, TextAlignment.CENTER, VerticalAlignment.MIDDLE, 0.5f * (float)Math.PI);


                int columnCount = _data.Columns.Count;
                float totalColumnWidth = (_axisWidth / columnCount);
                float barMargin = (totalColumnWidth - _barWidth) / 2;
                x = _originX + barMargin + _barWidth / 2;
                float y = _originY - _columnLabelMargin;
                foreach (Column column in _data.Columns)
                {
                    //layoutCanvas.ShowTextAligned(column.Label, x, y, TextAlignment.RIGHT, VerticalAlignment.TOP, 0.25f * (float)Math.PI);
                    _svgWriter.Text(x,
                                y,
                                column.Label,
                                GetColorFromiTextColour(_columnFontColour),
                                "end",
                                -45.0f,
                                _columnFontSize);
                    x += totalColumnWidth;
                }
            }
            else
            {
                iText.Layout.Canvas layoutCanvas = new iText.Layout.Canvas(canvas, _pdf, new iText.Kernel.Geom.Rectangle(_canvasWidth, _canvasHeight));
                layoutCanvas.SetFont(_font);
                layoutCanvas.SetFontSize(_valueFontSize);
                layoutCanvas.SetFontColor(_valueFontColour);

                float x = _originX - _valueLabelMargin;
                layoutCanvas.ShowTextAligned(_data.ValueLabel, x, _originY + _axisHeight * _yScale / 2, TextAlignment.CENTER, VerticalAlignment.MIDDLE, 0.5f * (float)Math.PI);


                int columnCount = _data.Columns.Count;
                float totalColumnWidth = (_axisWidth / columnCount);
                float barMargin = (totalColumnWidth - _barWidth) / 2;
                x = _originX + barMargin + _barWidth / 2;
                float y = _originY - _columnLabelMargin;

                layoutCanvas.SetFontSize(_columnFontSize);
                layoutCanvas.SetFontColor(_columnFontColour);

                IRenderer renderer = layoutCanvas.GetRenderer();

                foreach (Column column in _data.Columns)
                {
                    layoutCanvas.ShowTextAligned(column.Label, x, y, TextAlignment.RIGHT, VerticalAlignment.TOP, 0.25f * (float)Math.PI);
                    x += totalColumnWidth;
                }

                layoutCanvas.Close();
            }
        }

        protected virtual float GetLegendWidth()
        {
            float result = 0.0f;
            if (_font == null)
            {
                return result;
            }
            if (_legendIsHorizontal)
            {
                float legendWidth = 0.0f;

                foreach (Legend legend in _data.Legends)
                {
                    float width = _font.GetWidth(legend.Label, _legendFontSize) + _legendTextMargin + _legendKeySize * 2 + _legendMargin;
                    legendWidth += width;
                }
                legendWidth -= _legendMargin;

                result = legendWidth;
            }
            else
            {
                float x = _originX + _axisWidth + _legendMargin;
                float legendWidth = 0.0f;

                foreach (Legend legend in _data.Legends)
                {
                    float width = _font.GetWidth(legend.Label, _legendFontSize) + _legendTextMargin + _legendKeySize * 2 + _legendMargin;
                    if( width > legendWidth )
                    {
                        legendWidth = width;
                    }
                }
                result = legendWidth;
            }

            Debug.WriteLine("Legend Width:" + result.ToString());
            return result;
        }

        protected virtual void DrawLegend(PdfCanvas canvas, PdfPage page)
        {
            if (_svgRender)
            {
                if (_legendIsHorizontal)
                {
                    float x = 0.0f;
                    float legendWidth = 0.0f;
                    float y = _originY * 0.25f;

                    foreach (Legend legend in _data.Legends)
                    {
                        float width = _font.GetWidth(legend.Label, _legendFontSize) + _legendTextMargin + _legendKeySize * 2 + _legendMargin;
                        legendWidth += width;
                    }
                    legendWidth -= _legendMargin;

                    x = _originX + _axisWidth / 2 - legendWidth / 2;

                    foreach (Legend legend in _data.Legends)
                    {
                        _svgWriter.Circle(x, y, _legendKeySize, GetColorFromiTextColour(legend.Colour), GetColorFromiTextColour(legend.Colour), 0.0f);

                        float textHeight = _font.GetAscent(legend.Label, _legendFontSize);

                        _svgWriter.Text(x + _legendTextMargin,
                                y - textHeight / 2,
                                legend.Label,
                                GetColorFromiTextColour(_legendFontColour),
                                "start",
                                -0.0f,
                                _legendFontSize);

                        x += _font.GetWidth(legend.Label, _legendFontSize) + _legendTextMargin + _legendKeySize * 2 + _legendMargin;
                    }
                }
                else
                {
                    float x = _originX + _axisWidth + _legendMargin;
                    float legendHeight = _data.Legends.Count * _legendVerticalSize;
                    float y = _originY + (_axisHeight * _yScale / 2) + (legendHeight / 2);

                    Debug.WriteLine("originY:" + _originY.ToString() + " axisHeight:" + _axisHeight.ToString() + " legendHeight:" + legendHeight.ToString() + " y:" + y.ToString());

                    foreach (Legend legend in _data.Legends)
                    {
                        _svgWriter.Circle(x, y, _legendKeySize, GetColorFromiTextColour(legend.Colour), GetColorFromiTextColour(legend.Colour), 0.0f);

                        float textHeight = _font.GetAscent(legend.Label, _legendFontSize);

                        _svgWriter.Text(x + _legendTextMargin,
                                y - textHeight / 2,
                                legend.Label,
                                GetColorFromiTextColour(_legendFontColour),
                                "start",
                                -0.0f,
                                _legendFontSize);

                        y -= _legendVerticalSize;
                    }
                }
            }
            else
            {
                if (_legendIsHorizontal)
                {
                    float x = 0.0f;
                    float legendWidth = 0.0f;
                    float y = _originY * 0.25f;

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
                    float y = _originY + (_axisHeight * _yScale / 2) + (legendHeight / 2);

                    Debug.WriteLine("originY:" + _originY.ToString() + " axisHeight:" + _axisHeight.ToString() + " legendHeight:" + legendHeight.ToString() + " y:" + y.ToString());

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

                        y -= _legendVerticalSize;
                    }
                }
            } // render svg
        }

        protected virtual void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "graph.pdf";
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            DialogResult result = saveFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {

                FileStream fos = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                PdfWriter writer = new PdfWriter(fos);

                _pdf = new PdfDocument(writer);

                String fontFileName = GetSystemFontFileName(fontDialog.Font);
                _font = PdfFontFactory.CreateFont(fontFileName, iText.IO.Font.PdfEncodings.IDENTITY_H);

                SetDimensions();

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
                _data.LoadExcelFile(openFileDialog.FileName, true);

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

            OpenPainter.ColorPicker.frmColorPicker colorDialog = new OpenPainter.ColorPicker.frmColorPicker(currentColor);

            System.Windows.Forms.DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                legend.Colour = RGBToCMYK(colorDialog.PrimaryColor);
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

        public static DeviceCmyk RGBToCMYK(System.Drawing.Color rgb)
        {
            double dr = (double)rgb.R / 255;
            double dg = (double)rgb.G / 255;
            double db = (double)rgb.B / 255;
            float k = (float)(1 - Math.Max(Math.Max(dr, dg), db));
            float c = (float)((1 - dr - k) / (1 - k));
            float m = (float)((1 - dg - k) / (1 - k));
            float y = (float)((1 - db - k) / (1 - k));

            return new DeviceCmyk(c, m, y, k);
        }

        protected void SetButtonColour(ref iText.Kernel.Colors.Color iTextColour, Button button)
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

            OpenPainter.ColorPicker.frmColorPicker colourDialog = new OpenPainter.ColorPicker.frmColorPicker(currentColor);

            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                //iTextColour = RGBToCMYK(colourDialog.PrimaryColor);

                Debug.WriteLine("c:" + colourDialog.CMYK.C.ToString() +
                    " m:" + colourDialog.CMYK.M.ToString() +
                    " y:" + colourDialog.CMYK.Y.ToString() +
                    " k:" + colourDialog.CMYK.K.ToString());

                iTextColour = new DeviceCmyk((float)colourDialog.CMYK.C,
                    (float)colourDialog.CMYK.M,
                    (float)colourDialog.CMYK.Y,
                (float)colourDialog.CMYK.K);

                button.BackColor = colourDialog.PrimaryColor;
            }

            /*
            colorDialog.CustomColors = new int[] { ColorTranslator.ToOle(currentColor) };
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                iTextColour = RGBToCMYK(colorDialog.Color);
                button.BackColor = colorDialog.Color;
            }*/
        }

        private void btnTickFontColour_Click(object sender, EventArgs e)
        {
            SetButtonColour(ref _tickFontColour, btnTickFontColour);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetButtonColour(ref _tickColour, btnTickLineColour);
        }

        private void udYAxisLabelMargin_ValueChanged(object sender, EventArgs e)
        {
            _valueLabelMargin = (float)udYAxisLabelMargin.Value;
        }

        private void udYAxisLableFontSize_ValueChanged(object sender, EventArgs e)
        {
            _valueFontSize = (float)udYAxisLableFontSize.Value;
        }

        private void btnYAxisLabelFontColour_Click(object sender, EventArgs e)
        {
            SetButtonColour(ref _valueFontColour, btnYAxisLabelFontColour);
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
            //System.Drawing.Color currentColor;

            if (iTextColour.GetColorSpace().ToString() == "iText.Kernel.Pdf.Colorspace.PdfDeviceCs+Cmyk")
            {
                float[] cmyk = iTextColour.GetColorValue();
                String attribute = cmyk[0].ToString() + "," +  cmyk[1].ToString() + "," + cmyk[2].ToString() + "," + cmyk[3].ToString();
                //currentColor = ConvertCmykToRgb(cmyk[0], cmyk[1], cmyk[2], cmyk[3]);

                xml.WriteAttributeString(name, attribute);
            }
            else
            {
                //float[] rgb = iTextColour.GetColorValue();
                //currentColor = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0] * 255), Convert.ToInt32(rgb[1] * 255), Convert.ToInt32(rgb[2] * 255));
                MessageBox.Show("Wrong Colour Space", "Not SUpported", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        protected virtual void WriteSubTypeSettings(XmlTextWriter xml)
        {

        }

        protected virtual void ReadSubTypeSettings(XmlTextReader xml)
        {

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
            xml.WriteAttributeString("barDrawBorder", _barDrawBorder.ToString());
            xml.WriteAttributeString("barBorderWidth", _barBorderWidth.ToString("0.0"));
            WriteColourSetting(xml, _barBorderColour, "barBorderColour");

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

            WriteSubTypeSettings(xml);

            xml.WriteEndElement();   
        }

        protected virtual void WriteLegends(XmlTextWriter xml)
        {
            int i = 0;
            foreach (Legend legend in _data.Legends)
            {
                xml.WriteStartElement("legend");

                xml.WriteAttributeString("index", i.ToString());

                Debug.WriteLine("Write " + _data.Legends.Count.ToString() + " Legends");
                Debug.WriteLine("Write legend:" + legend.Label + " colour space:" + legend.Colour.GetColorSpace().ToString());
                float[] colour = legend.Colour.GetColorValue();
                Debug.WriteLine(colour.Length.ToString() + " colours");
                foreach (float channel in colour)
                {
                    Debug.WriteLine(channel.ToString("0.0000"));
                }

                //Debug.WriteLine("Write legend:" + legend.Label + " " + legend.Colour.GetColorValue().ToString());

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
            ReadColour(xml, ref _axisColour, "axisColour");

            _axisWidth = float.Parse(xml.GetAttribute("axisWidth"));
            _axisHeight = float.Parse(xml.GetAttribute("axisHeight"));
            _drawXAxis = Convert.ToBoolean(xml.GetAttribute("drawXAxis"));
            _drawYAxis = Convert.ToBoolean(xml.GetAttribute("drawYAxis"));
            _valueAxisMax = float.Parse(xml.GetAttribute("valueAxisMax"));
            _valueAxisInterval = float.Parse(xml.GetAttribute("valueAxisInterval"));
            _valueLabelMargin = float.Parse(xml.GetAttribute("valueLabelMargin"));
            _valueFontSize = float.Parse(xml.GetAttribute("valueFontSize"));
            ReadColour(xml, ref _valueFontColour, "valueFontColour");

            _tickLineWidth = float.Parse(xml.GetAttribute("tickLineWidth"));
            ReadColour(xml, ref _tickColour, "tickColour");

            _tickFontSize = float.Parse(xml.GetAttribute("tickFontSize"));
            ReadColour(xml, ref _tickFontColour, "tickFontColour");

            _tickLabelMargin = float.Parse(xml.GetAttribute("tickLabelMargin"));
            _barWidth = float.Parse(xml.GetAttribute("barWidth"));
            _barMargin = float.Parse(xml.GetAttribute("barMargin"));
            _barDrawBorder = Convert.ToBoolean(xml.GetAttribute("barDrawBorder"));
            _barBorderWidth = float.Parse(xml.GetAttribute("barBorderWidth"));
            ReadColour(xml, ref _barBorderColour, "barBorderColour");

            _columnLabelMargin = float.Parse(xml.GetAttribute("columnLabelMargin"));
            _columnFontSize = float.Parse(xml.GetAttribute("columnFontSize"));
            ReadColour(xml, ref _columnFontColour, "columnFontColour");

            _legendIsHorizontal = Convert.ToBoolean(xml.GetAttribute("legendIsHorizontal"));
            _legendMargin = float.Parse(xml.GetAttribute("legendMargin"));
            _legendTextMargin = float.Parse(xml.GetAttribute("legendTextMargin"));
            _legendVerticalSize = float.Parse(xml.GetAttribute("legendVerticalSize"));
            _legendKeySize = float.Parse(xml.GetAttribute("legendKeySize"));
            _legendFontSize = float.Parse(xml.GetAttribute("legendFontSize"));
            ReadColour(xml, ref _legendFontColour, "legendFontColour");

            ReadSubTypeSettings(xml);
        }

        protected virtual void ReadColour(XmlTextReader xml, ref iText.Kernel.Colors.Color iTextColour, String attributeName)
        {
            String colourString = xml.GetAttribute(attributeName);
            String[] values = colourString.Split(',');
            if (values.Length == 4)
            {
                float c = float.Parse(values[0]);
                float m = float.Parse(values[1]);
                float y = float.Parse(values[2]);
                float k = float.Parse(values[3]);
                iTextColour = new DeviceCmyk(c, m, y, k);
            }
        }

        protected virtual void ReadLegend(XmlTextReader xml)
        {
            Int32 index = Convert.ToInt32(xml.GetAttribute("index"));
/*
            Debug.WriteLine("[" + index.ToString() + "] " + "Read legend:" + _data.Legends[index].Label + " colour space:" + _data.Legends[index].Colour.GetColorSpace().ToString());
            float[] colour = _data.Legends[index].Colour.GetColorValue();
            Debug.WriteLine(colour.Length.ToString() + " colours");
            foreach (float channel in colour)
            {
                Debug.WriteLine(channel.ToString("0.0000"));
            }
            */
            iText.Kernel.Colors.Color iTextColour = new DeviceCmyk();
            ReadColour(xml, ref iTextColour, "colour");
            _data.Legends[index].Colour = iTextColour;
            /*
            Debug.WriteLine("[" + index.ToString() + "] " + "After Read legend:" + _data.Legends[index].Label + " colour space:" + _data.Legends[index].Colour.GetColorSpace().ToString());
            colour = _data.Legends[index].Colour.GetColorValue();
            Debug.WriteLine(colour.Length.ToString() + " colours");
            foreach (float channel in colour)
            {
                Debug.WriteLine(channel.ToString("0.0000"));
            }*/
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
                    SetDimensions();
                    UpdateOnScreenSettings();
                    ShowLegend();
                }
                catch
                {
                    MessageBox.Show("Invalid Graph File", "Cannot Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbLegendHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            _legendIsHorizontal = cbLegendHorizontal.Checked;

        }

        private void udLegendMargin_ValueChanged(object sender, EventArgs e)
        {
            _legendMargin = (float)udLegendMargin.Value;
        }

        private void udLegendTextMargin_ValueChanged(object sender, EventArgs e)
        {
            _legendTextMargin = (float)udLegendTextMargin.Value;
        }

        private void udLegendVerticalSize_ValueChanged(object sender, EventArgs e)
        {
            _legendVerticalSize = (float)udLegendVerticalSize.Value;
        }

        private void udKeySize_ValueChanged(object sender, EventArgs e)
        {
            _legendKeySize = (float)udLegendKeySize.Value;
        }

        private void udLegendFontSize_ValueChanged(object sender, EventArgs e)
        {
            _legendFontSize = (float)udLegendFontSize.Value;
        }

        private void btnLegendFontColour_Click(object sender, EventArgs e)
        {
            SetButtonColour(ref _legendFontColour, btnLegendFontColour);
        }

        private void cbDrawBorder_CheckedChanged(object sender, EventArgs e)
        {
            _barDrawBorder = cbDrawBorder.Checked;
            btnBorderColour.Enabled = cbDrawBorder.Checked;
            udBorderWidth.Enabled = cbDrawBorder.Checked;
        }

        private void btnBorderColour_Click(object sender, EventArgs e)
        {
            SetButtonColour(ref _barBorderColour, btnBorderColour);
        }

        private void udBorderWidth_ValueChanged(object sender, EventArgs e)
        {
            _barBorderWidth = (float)udBorderWidth.Value;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "graph.svg";
            saveFileDialog.Filter = "SVG files (*.svg)|*.svg|All files (*.*)|*.*";
            DialogResult result = saveFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {

                FileStream fos = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                _svgRender = true;
                _svgWriter = new svgWriter(fos);
                String fontFileName = GetSystemFontFileName(fontDialog.Font);
                _font = PdfFontFactory.CreateFont(fontFileName, iText.IO.Font.PdfEncodings.IDENTITY_H);

                SetDimensions();
                _svgWriter.StartRootElement(_canvasWidth, _canvasHeight);

                SetFont();

                DrawTicks(null, null);
                DrawBars(null, null);
                DrawAxes(null, null);
                DrawLabels(null, null);
                DrawLegend(null, null);

                _svgRender = false;

                _svgWriter.EndRootElement();
                fos.Close();
            }
        }

    }
}
