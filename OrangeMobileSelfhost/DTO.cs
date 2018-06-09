using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeMobileSelfhost
{
    public class clsPhone
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string IMEI { get; set; }
        public decimal ItemPrice { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string Availability { get; set; }
        public string Warrenty { get; set; }
        public string Condition { get; set; }
        public int CategoryID { get; set; }
        



        public override string ToString()
        {
            return Name;
        }
        public static readonly string FACTORY_PROMPT = "Enter N for New and O for Old";

        public static clsPhone NewPhone(char prChoice)
        {
            return new clsPhone() { Type = Convert.ToString(Char.ToUpper(prChoice)) };
        }
    }

    public class clsPhoneCategories {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    
}
