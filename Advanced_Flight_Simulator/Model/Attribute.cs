using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Flight_Simulator
{
    /*
     * Hold flight info of one plane part.
     */
    class Attribute
    {
        public string name;
        private List<string> value_list;

        public Attribute(string name)
        {
            this.name = name;
            value_list = new List<string>();
        }
        public Attribute()
        {
            this.name = String.Empty;
            value_list = new List<string>();
        }

        public string get_value(int index)
        {
            return this.value_list[index];
        }
        public List<string> get_values()
        {
            return this.value_list;
        }
        public void add_value(string new_value)
        {
            value_list.Add(new_value);
        }
        public void add_values(List<string> values)
        {
            foreach(string value in values)
            {
                this.add_value(value);
            }
        }
        public int get_size()
        {
            return this.value_list.Count();
        }
    }
}
