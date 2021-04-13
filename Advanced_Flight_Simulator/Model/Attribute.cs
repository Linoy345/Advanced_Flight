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
    public class Attribute
    {
        public string name;
        private List<string> value_list;
        /*
        * CONSTUCTOR - initalize attribute with given name and empty list of string.
        */
        public Attribute(string name)
        {
            this.name = name;
            value_list = new List<string>();
        }
        /*
        * CONSTUCTOR - initailize empty attribute.
        */
        public Attribute()
        {
            this.name = String.Empty;
            value_list = new List<string>();
        }
        /*
        * return the attribute in index place.
        */
        public string get_value(int index)
        {
            return this.value_list[index];
        }
        /*
        * return all attributes in a list
        */
        public List<string> get_values()
        {
            return this.value_list;
        }
        /*
        * adding attribute to the list
        */
        public void add_value(string new_value)
        {
            value_list.Add(new_value);
        }
        /*
        * adding attributes from given list to the class list.
        */
        public void add_values(List<string> values)
        {
            foreach (string value in values)
            {
                this.add_value(value);
            }
        }
        /*
        * getting size of list.
        */
        public int get_size()
        {
            return this.value_list.Count();
        }
    }
}
