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
        public iText.Kernel.Colors.Color Colour { get; set; }

        public Legend(String label, iText.Kernel.Colors.Color colour)
        {
            Label = label;
            Colour = colour;
        }
    }
}
