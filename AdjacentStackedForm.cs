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
    public partial class AdjacentStackedForm : Graph.GraphForm
    {


        public AdjacentStackedForm()
        {
            InitializeComponent();

            SetLayout();

            _originX = 75.0f;
            _originY = 100.0f;

            SetDimensions();

        }

        protected override void SetDimensions()
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
            int barCount = _data.Legends.Count;

            float x = _originX + _barMargin;
            float y = _originY;

            if (_svgRender)
            {
                foreach (Column column in _data.Columns)
                {
                    foreach (Value value in column.Values)
                    {
                        if (_barDrawBorder)
                        {
                            _svgWriter.Rectangle(x, y, _barWidth, value.Data * _yScale, GetColorFromiTextColour(value.Legend.Colour), GetColorFromiTextColour(_barBorderColour), _barBorderWidth);
                        }
                        else
                        {
                            System.Drawing.Color temp = new System.Drawing.Color();
                            _svgWriter.Rectangle(x, y, _barWidth, value.Data * _yScale, GetColorFromiTextColour(value.Legend.Colour), temp, 0.0f);
                        }

                        x += _barWidth;
                    }
                    x += _barMargin;
                }
            }
            else
            {

                foreach (Column column in _data.Columns)
                {
                    foreach (Value value in column.Values)
                    {
                        iText.Kernel.Geom.Rectangle rectangle = new iText.Kernel.Geom.Rectangle(x, y, _barWidth, value.Data * _yScale);
                        canvas.SetFillColor(value.Legend.Colour);
                        canvas.Rectangle(rectangle);
                        canvas.Fill();

                        if (_barDrawBorder)
                        {
                            rectangle = new iText.Kernel.Geom.Rectangle(x, y + _barBorderWidth / 2, _barWidth, value.Data * _yScale - _barBorderWidth / 2);
                            canvas.SetStrokeColor(_barBorderColour);
                            canvas.SetLineWidth(_barBorderWidth);
                            canvas.Rectangle(rectangle);
                            canvas.Stroke();
                        }

                        x += _barWidth;
                    }
                    x += _barMargin;
                }
            }
        }

        protected override String GetGraphType()
        {
            return ("AdjacentStackedGraph");
        }

        protected override void WriteSubTypeSettings(XmlTextWriter xml)
        {

        }

        protected override void ReadSubTypeSettings(XmlTextReader xml)
        {

        }
    }
}
