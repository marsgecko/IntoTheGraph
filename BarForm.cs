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
        bool _barDrawValueAbove = false;
        bool _barDrawValueOn = true;
        float _barValueMargin = 1;


        public BarForm()
        {
            InitializeComponent();

            // Override defaults
            _originX = 75.0f;
            _originY = 120.0f;
            _valueAxisInterval = 10.0f;
            _barWidth = 40.0f;

            SetDimensions();

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
                float textWidth = _font.GetWidth(text, _valueFontSize);

                float textX = x + _barWidth / 2 - textWidth / 2;
                    
                if( _barDrawValueAbove )
                {
                    float textY = _originY + value.Data * _yScale + _barValueMargin;

                    canvas.BeginText()
                        .SetFontAndSize(_font, _valueFontSize)
                        .MoveText(textX, textY)
                        .SetColor(_valueFontColour, true)
                        .ShowText(text)
                        .EndText();

                }
                if( _barDrawValueOn )
                {
                    float textY = _originY + (value.Data * _yScale)/2;

                    canvas.BeginText()
                        .SetFontAndSize(_font, _valueFontSize)
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

        protected override void WriteSettings(XmlTextWriter xml)
        {
            base.WriteSettings(xml);

        }

        protected override void ReadSettings(XmlTextReader xml)
        {
            base.ReadSettings(xml);

        }
    }
}
