using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OrangeMobileSelfhost
{
    public class PhoneController : ApiController
    {
        //public List<string> GetPhoneList()
        //{
        //    DataTable lcResult = ClsDBConnection.GetDataTable("SELECT name FROM tbl_all_products", null);
        //    List<string> lcNames = new List<string>();
        //    foreach (DataRow dr in lcResult.Rows)
        //        lcNames.Add((string)dr[0]); return lcNames;
        //}
        public List<clsPhone> GetPhoneList()
        {
            DataTable lcResult = ClsDBConnection.GetDataTable("SELECT id, IMEI, name, item_price, description, color, type, availability, phone_condition, category_id, warrenty FROM tbl_all_products", null);
            List<clsPhone> lcPhones = new List<clsPhone>();
            foreach (DataRow dr in lcResult.Rows)
                lcPhones.Add(new clsPhone
                {
                    
                    ID = (int)dr[0],
                    IMEI = (string)dr[1],
                    Name = (string)dr[2],
                    ItemPrice = (decimal)dr[3],
                    Description = (string)dr[4],
                    Color = (string)dr[5],
                    Type = (string)dr[6],
                    Availability = (int)dr[7],
                    Condition = (string)dr[8],
                    CategoryID = (int)dr[9],
                    Warrenty = (string)dr[10]

                });

            return lcPhones;
        }

        public clsPhone GetPhoneDetailsById(string ID)

        {

            Dictionary<string, object> par = new Dictionary<string, object>(1);

            par.Add("ID", ID);

            DataTable lcResult =

            ClsDBConnection.GetDataTable("SELECT * FROM tbl_all_products WHERE id = @ID", par);

            if (lcResult.Rows.Count > 0)

                return new clsPhone()

                {

                    Name = (string)lcResult.Rows[0]["name"],
                    ID = (int)lcResult.Rows[0]["id"],
                    IMEI = (string)lcResult.Rows[0]["IMEI"],
                    ItemPrice = (decimal)lcResult.Rows[0]["item_price"],
                    Description = (string)lcResult.Rows[0]["description"],
                    Color = (string)lcResult.Rows[0]["color"],
                    Type = (string)lcResult.Rows[0]["type"],
                    Availability = (int)lcResult.Rows[0]["availability"],
                    Condition = lcResult.Rows[0]["phone_condition"] != null ? (string)lcResult.Rows[0]["condition"] : "",
                    CategoryID = (int)lcResult.Rows[0]["category_id"],
                    Warrenty = (string)lcResult.Rows[0]["warrenty"]

                };

            else

                return null;

        }
    }
}
