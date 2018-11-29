using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Legend
    {
        public String Label { get; set; }
        public iText.Kernel.Colors.DeviceRgb Colour { get; set; }

        public Legend()
        {
            Label = "";
            Colour = new iText.Kernel.Colors.DeviceRgb();
        }

        public Legend(String label, iText.Kernel.Colors.DeviceRgb colour)
        {
            Label = label;
            Colour = colour;
        }
    }
}
