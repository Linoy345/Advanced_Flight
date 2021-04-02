using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Linq;
namespace Advanced_Flight_Simulator
{
    /*
     * Handle Flight information- support different queries to extract data from specific attribute or specifiec row.
     * Require csv(for data) and xml(for headers) paths.
     */
    class Flight_Info
    {
        private List<Attribute> attributes;
        private List<Dictionary<string, string>> rows; // Keep rows in list- each row is a dictionary- key is attribute name.
        public Flight_Info()
        {
            rows = new List<Dictionary<string, string>>();
            attributes = new List<Attribute>();
        }
        /*
         * Extract data from csv and xml files using thier paths.
         */
        public void init_Flight_Info(string csv_path, string xml_path)
        {
            extract_headers(xml_path);
            extract_values(csv_path);
        }
        /*
        * Extract Headers from xml file. Headers are stored in "output"-name.
        */
        private void extract_headers(string xml_path)
        {
            XElement Xelement = XElement.Load(xml_path);
            XDocument xDoc = XDocument.Load(xml_path);
            IEnumerable<string> query = Xelement.Descendants("output").Descendants("name").Select(name => (string) name);
            foreach(var name in query.ToList())
            {
                    attributes.Add(new Attribute(name));
            }
        }
        /*
         * Extract values into attributes and rows from a path to a CSV file.
         */
        private void extract_values(string csv_path)
        {
            string[] lines = File.ReadAllLines(csv_path);
            int coulumn_index = 0;
            int row_index = 0;
            string current_value;
            string current_name;

            foreach (var line in lines)
            {
                rows.Add(new Dictionary<string, string>());
                string[] current_line = line.Split(',');
                foreach (var attribute in attributes)
                {
                    current_name = attribute.name;
                    if (rows[row_index].ContainsKey(attribute.name)) {
                        current_name += "2"; }; // Add 2 to name if two attributes have the same name
                    current_value = current_line[coulumn_index].ToString();
                    attribute.add_value(current_value);
                    rows[row_index].Add(current_name, current_value);
                    coulumn_index++;
                }
                coulumn_index = 0;
                row_index++;
            }
        }

        public List<string> get_attribute(string att_name)
        {
            foreach (var attribute in this.attributes)
            {
                if (attribute.name == att_name)
                {
                    return attribute.get_values();
                }
            }
            return new List<string>();
        }
        public Dictionary<string,string> get_row(int row)
        {
            return this.rows[row];
        }

        /*
         * Convert given row values into a single string wheres each value is seperated by ",".
         */
        public string get_row_string(int row)
        {
            return string.Join(",", rows[row].Select(x => x.Value).ToArray()) + "\r\n";
        }
        public int row_count()
        {
            return this.rows.Count();
        }
        public int attribute_count()
        {
            return this.attributes.Count();
        }

    }
   
 
}
