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
    public partial class VerticalStackedForm : Graph.GraphForm
    {

        public VerticalStackedForm()
        {
            InitializeComponent();

            // Different Bar width defaults
            _legendIsHorizontal = false;
            _originX = 120;
            _originY = 120;
            _barWidth = 30;
            _barMargin = 15;

            SetDimensions();
        }


        protected override void SetDimensions()
        {
            float maxValue = _data.GetMaxStackValue();

            for (_valueAxisMax = 0; _valueAxisMax < maxValue; _valueAxisMax += _valueAxisInterval)
            {

            }

            //_valueAxisInterval = _valueAxisMax * 0.1f;


            _axisWidth = _barWidth * _data.Columns.Count + _barMargin * (_data.Columns.Count + 1);
            _axisHeight = _valueAxisMax;
            _yScale = 1.0f;
            if (_axisHeight < _axisWidth * 0.25f)
            {
                float newHeight = _axisWidth * 0.25f;
                _yScale = newHeight / _axisHeight;
            }

            _canvasHeight = _originY + _axisHeight * _yScale + 100;
            _canvasWidth = _originX + _axisWidth + 150;

            UpdateOnScreenSettings();
        }

        protected override void UpdateYAxisHeight()
        {
            float maxValue = _data.GetMaxStackValue();

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
            _canvasHeight = _originY + _axisHeight + 100;
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

                    y += value.Data * _yScale;
                }
                x += totalColumnWidth;
            }

        }

        protected override String GetGraphType()
        {
            return ("VerticalStackedGraph");
        }

        protected override void WriteSubTypeSettings(XmlTextWriter xml)
        {

        }

        protected override void ReadSubTypeSettings(XmlTextReader xml)
        {

        }

    }
}
