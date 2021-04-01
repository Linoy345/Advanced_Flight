using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Advanced_Flight_Simulator
{
    class Flight_Info
    {
        //private List<Attribute> attributes;
        public DataTable data_t;
        public Flight_Info(string csv_path, string xml_path)
        {
            data_t = new DataTable();
            //attributes = new List<Attribute>();
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
                if (data_t.Columns.Contains(name))
                {
                    data_t.Columns.Add(new DataColumn(name + "first"));
                } else {
                    data_t.Columns.Add(new DataColumn(name));
                }
                //attributes.Add(new Attribute(name));
            }
        }
        /*
         * Extract values into attributes from a path to a CSV file.
         */
        private void extract_values(string csv_path)
        {
            string[] lines = File.ReadAllLines(csv_path);
            //int index = 0;
                foreach(var line in lines)
                {
                DataRow new_row = data_t.NewRow();
                //new_row.ItemArray(line.Split(','));
                //List<string> current_line = line.Split(',').ToList();
                data_t.Rows.Add((line.Split(',')));
                //foreach (var value in current_line)
                //{
                //    attributes[index].add_value(value);
                //    index++;
                //}
                //index = 0;
                }
        }
        public DataColumn get_attribute(string att_name)
        {
            foreach(DataColumn column in this.data_t.Columns)
            {
                if(column.ColumnName == att_name)
                {
                    return column;
                }
            }
            return this.data_t.Columns[att_name];
            //foreach(var att in attributes)
            //{
            //    if(att.name == att_name) { return att.name; }
            //}
            //return String.Empty;
        }
        public int get_row_size()
        {
            return this.data_t.Rows.Count;
            //return this.attributes[0].get_size();
        }
    }
   
 
}
