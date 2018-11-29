using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Value
    {
        public Legend Legend { get; set; }
        public float Data { get; set; }

        public Value()
        {
            Legend = new Legend();
            Data = 0.0f;
        }

        public Value(Legend legend, float value)
        {
            Legend = legend;
            Data = value;
        }
    }
}
