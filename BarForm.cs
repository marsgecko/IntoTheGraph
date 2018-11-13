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
    public partial class BarForm : Graph.GraphForm
    {
        bool _barDrawValueAboveTop = false;
        bool _barDrawValueBelowTop = true;
        bool _barDrawValueCenter = false;
        float _barValueMargin = 2.0f;
        float _barValueFontSize = 8.0f;


        public BarForm()
        {
            InitializeComponent();

            // Override defaults
            _originX = 75.0f;
            _originY = 75.0f;
            _valueAxisInterval = 10.0f;
            _barWidth = 40.0f;

            SetDimensions();

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
            if (_axisHeight < _axisWidth * 0.25f)
            {
                float newHeight = _axisWidth * 0.25f;
                _yScale = newHeight / _axisHeight;
            }

            _canvasHeight = _originY + _axisHeight * _yScale + 75;
            _canvasWidth = _originX + _axisWidth + 75;

            UpdateOnScreenSettings();
        }

        protected override void DrawBars(PdfCanvas canvas, PdfPage page)
        {
            int columnCount = _data.Columns.Count;
            float totalColumnWidth = (_axisWidth / columnCount);
            float barMargin = (totalColumnWidth - _barWidth) / 2;

            float x = _originX + barMargin;
            foreach(Column column in _data.Columns)
            {
                float y = _originY;
                Value value = column.Values[0];

                iText.Kernel.Geom.Rectangle rectangle = new iText.Kernel.Geom.Rectangle(x, y, _barWidth, value.Data * _yScale);
                canvas.SetFillColor(value.Legend.Colour);
                canvas.Rectangle(rectangle);
                canvas.Fill();

                String text = value.Data.ToString("0.0");
                if (_data.FormatPercent)
                {
                    text = text + "%";
                }
                float textWidth = _font.GetWidth(text, _barValueFontSize);
                float textHeight = _font.GetAscent(text, _barValueFontSize) + _font.GetDescent(text, _barValueFontSize);

                float textX = x + (_barWidth / 2) - (textWidth / 2);
                    
                if( _barDrawValueAboveTop )
                {
                    float textY = _originY + value.Data * _yScale + _barValueMargin;

                    canvas.BeginText()
                        .SetFontAndSize(_font, _barValueFontSize)
                        .MoveText(textX, textY)
                        .SetColor(_valueFontColour, true)
                        .ShowText(text)
                        .EndText();

                }
                if (_barDrawValueBelowTop)
                {
                    float textY = _originY + value.Data * _yScale - _barValueMargin - textHeight;

                    canvas.BeginText()
                        .SetFontAndSize(_font, _barValueFontSize)
                        .MoveText(textX, textY)
                        .SetColor(_valueFontColour, true)
                        .ShowText(text)
                        .EndText();

                }
                if (_barDrawValueCenter)
                {
                    float textY = _originY + (value.Data * _yScale) / 2 - textHeight/2;

                    canvas.BeginText()
                        .SetFontAndSize(_font, _barValueFontSize)
                        .MoveText(textX, textY)
                        .SetColor(_valueFontColour, true)
                        .ShowText(text)
                        .EndText();
                }
                
                x += totalColumnWidth;
            }

        }



        protected override void DrawLegend(PdfCanvas canvas, PdfPage page)
        {

        }

        protected override String GetGraphType()
        {
            return ("BarGraph");
        }


        protected override void WriteSubTypeSettings(XmlTextWriter xml)
        {
            xml.WriteAttributeString("barValueAboveTop", _barDrawValueAboveTop.ToString());
            xml.WriteAttributeString("barValueBelowTop", _barDrawValueBelowTop.ToString());
            xml.WriteAttributeString("barValueCenter", _barDrawValueCenter.ToString());
            
            xml.WriteAttributeString("barValueMargin", _barValueMargin.ToString("0.0"));
            xml.WriteAttributeString("barValueFontSize", _barValueFontSize.ToString("0.0"));
        }

        protected override void ReadSubTypeSettings(XmlTextReader xml)
        {
            _barDrawValueAboveTop = Convert.ToBoolean(xml.GetAttribute("barValueAboveTop"));
            _barDrawValueBelowTop = Convert.ToBoolean(xml.GetAttribute("barValueBelowTop"));
            _barDrawValueCenter = Convert.ToBoolean(xml.GetAttribute("barValueCenter"));
            _barValueMargin = float.Parse(xml.GetAttribute("barValueMargin"));
            _barValueFontSize = float.Parse(xml.GetAttribute("barValueFontSize"));
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
    }
}
