using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OrangeMobileSelfhost
{
    public class PhoneController: ApiController
    {
        public List<string> GetPhoneList() {
            DataTable lcResult = ClsDBConnection.GetDataTable("SELECT name FROM tbl_all_products", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]); return lcNames;
        }
    }
}
