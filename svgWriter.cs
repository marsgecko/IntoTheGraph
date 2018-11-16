using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class svgWriter
    {
        private FileStream _file;
        private float _width;
        private float _height;

        public svgWriter(FileStream file)
        {
            _file = file;
        }

        public void StartRootElement(float width, float height)
        {
            _width = width;
            _height = height;
            String line = "<svg width=\"" + width.ToString() + "\" height=\"" + height.ToString() + "\">" + "\r\n";
            byte[] data = new UTF8Encoding(true).GetBytes(line);
            _file.Write(data, 0, data.Length);
        }

        public void EndRootElement()
        {
            String line = "</svg>\r\n";
            byte[] data = new UTF8Encoding(true).GetBytes(line);
            _file.Write(data, 0, data.Length);
        }

        public void Line(float x1, float y1, float x2, float y2, System.Drawing.Color colour, float lineWidth)
        {
            float _y1 = _height - y1;
            float _y2 = _height - y2;
            String line = "  <line x1=\"" + x1.ToString() + "\" y1=\"" + _y1.ToString() + "\"";
            line += "  x2=\"" + x2.ToString() + "\" y2=\"" + _y2.ToString() + "\"";
            line += "  style=\"stroke:rgb(" + colour.R.ToString() + "," + colour.G.ToString() + "," + colour.B.ToString() + ");stroke-width:" + lineWidth.ToString() + "\"";
            line += "/>\r\n";
            byte[] data = new UTF8Encoding(true).GetBytes(line);
            _file.Write(data, 0, data.Length);
        }

        public void Rectangle( float x, float y, float width, float height, System.Drawing.Color fillColour, System.Drawing.Color strokeColour, float lineWidth)
        {
            float _y = _height - y - height;
            String line = "  <rect x=\"" + x.ToString() + "\" y=\"" + _y.ToString() + "\"";
            line += "  width=\"" + width.ToString() + "\" height=\"" + height.ToString() + "\"";
            line += "  style=\"";
            if (fillColour != null)
            {
                line += "fill:rgb(" + fillColour.R.ToString() + "," + fillColour.G.ToString() + "," + fillColour.B.ToString() + ");";
            }
            if (lineWidth != 0.0f)
            {
                line += "stroke:rgb(" + strokeColour.R.ToString() + "," + strokeColour.G.ToString() + "," + strokeColour.B.ToString() + ");stroke-width:" + lineWidth.ToString() + ";";
            }
            line += "\"";
            line += "/>\r\n";
            byte[] data = new UTF8Encoding(true).GetBytes(line);
            _file.Write(data, 0, data.Length);
        }

        public void Circle(float x, float y, float radius, System.Drawing.Color fillColour, System.Drawing.Color strokeColour, float lineWidth)
        {
            float _y = _height - y;
            String line = "  <circle cx=\"" + x.ToString() + "\" cy=\"" + _y.ToString() + "\"";
            line += "  r=\"" + radius.ToString() + "\"";
            if (fillColour != null)
            {
                line += " fill=\"rgb(" + fillColour.R.ToString() + "," + fillColour.G.ToString() + "," + fillColour.B.ToString() + ");\"";
            }
            if (strokeColour != null)
            {
                line += " stroke=\"rgb(" + strokeColour.R.ToString() + "," + strokeColour.G.ToString() + "," + strokeColour.B.ToString() + "); stroke-width=\"" + lineWidth.ToString() + "\";";
            }
            line += "/>\r\n";
            byte[] data = new UTF8Encoding(true).GetBytes(line);
            _file.Write(data, 0, data.Length);
        }

        public void Text(float x, float y, String text, System.Drawing.Color fillColour, String anchor, float rotation, float fontSize)
        {
            float _y = _height - y;
            String line = "  <text x=\"" + x.ToString() + "\" y=\"" + _y.ToString() + "\"";
            line += "  text-anchor=\"" + anchor + "\"";
            line += "  alignment-baseline=\"hanging\"";
            if (rotation != 0.0f)
            {
                line += "  transform=\"rotate(" + rotation.ToString() + "," + x.ToString() + "," + _y.ToString() + ")\"";
            }
            if (fillColour != null)
            {
                line += "  fill=\"rgb(" + fillColour.R.ToString() + "," + fillColour.G.ToString() + "," + fillColour.B.ToString() + ")\"";
            }
            line += "  font-size=\"" + fontSize.ToString() + "px\"";
            line += ">" + text + "</text>\r\n";
            byte[] data = new UTF8Encoding(true).GetBytes(line);
            _file.Write(data, 0, data.Length);
        }

    }
}
