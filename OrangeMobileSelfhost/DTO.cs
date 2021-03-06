﻿using System;


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
        public string Image { get; set; }



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

    public class clsOrders
    {
       
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ProductId { get; set; }
        public override string ToString()
        {
            return ProductName + "\t" + Email + "\t" + Date + "\t" +  Amount + "\t" ;
        }
    }

    
}
