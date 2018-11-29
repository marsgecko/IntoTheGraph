using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Column
    {
        public String Label { get; set; }

        private List<Value> mValues;
        public List<Value> Values { get { return mValues; } }

        public Column()
        {
            Label = "";
            mValues = new List<Value>();
        }

        public Column(String label)
        {
            Label = label;
            mValues = new List<Value>();
        }

        public Value AddValue(Legend legend, float value)
        {
            Value result = new Value(legend, value);
            mValues.Add(result);
            return result;
        }
    }
}
