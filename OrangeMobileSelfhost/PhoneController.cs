using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OrangeMobileSelfhost
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PhoneController : ApiController
    {

        public List<clsPhone> GetPhoneList()
        {
            DataTable lcResult = ClsDBConnection.GetDataTable("SELECT id, IMEI, name, item_price, " +
                "description, color, type, availability, phone_condition, category_id, warrenty, image " +
                "FROM tbl_all_products", null);
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
                    Availability = (string)dr[7],
                    Condition = (dr[8] == DBNull.Value) ? string.Empty : (string)dr[8],
                    CategoryID = (int)dr[9],
                    Warrenty = (dr[10] == DBNull.Value) ? string.Empty : (string)dr[10],
                    Image = (string)dr[11]
                });

            return lcPhones;
        }

        public List<clsPhoneCategories> GetPhoneCategories()
        {
            DataTable lcResult = ClsDBConnection.GetDataTable("SELECT id, name FROM tbl_categories", null);
            List<clsPhoneCategories> lcPhoneCategories = new List<clsPhoneCategories>();
            foreach (DataRow dr in lcResult.Rows)
                lcPhoneCategories.Add(new clsPhoneCategories
                {
                    Text = (string)dr[1],
                    Value = (int)dr[0],
                });

            return lcPhoneCategories;
        }
        public List<clsPhone> GetPhoneListByCategory(string CategoryID)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("CategoryID", CategoryID);
            DataTable lcResult = ClsDBConnection.GetDataTable("SELECT id, IMEI, name, item_price, description, color, " +
                "type, availability, phone_condition, category_id, warrenty, image FROM tbl_all_products " +
                "where category_id = @CategoryID", par);
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
                    Availability = (string)dr[7],
                    Condition = (dr[8] == DBNull.Value) ? string.Empty : (string)dr[8],
                    CategoryID = (int)dr[9],
                    Warrenty = (dr[10] == DBNull.Value) ? string.Empty : (string)dr[10],
                    Image = (string)dr[11]
                });

            return lcPhones;
        }

        public List<clsPhone> GetPhoneListByType(string Type)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Type", Type);
            DataTable lcResult = ClsDBConnection.GetDataTable("SELECT id, IMEI, name, item_price, description, color, " +
                "type, availability, phone_condition, category_id, warrenty, image FROM tbl_all_products " +
                "where type = @Type", par);
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
                    Availability = (string)dr[7],
                    Condition = (dr[8] == DBNull.Value) ? string.Empty : (string)dr[8],
                    CategoryID = (int)dr[9],
                    Warrenty = (dr[10] == DBNull.Value) ? string.Empty : (string)dr[10],
                    Image = (string)dr[11]
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
                    Availability = (string)lcResult.Rows[0]["availability"],
                    Condition = lcResult.Rows[0]["phone_condition"] != DBNull.Value ? (string)lcResult.Rows[0]["phone_condition"] : "",
                    CategoryID = (int)lcResult.Rows[0]["category_id"],
                    Warrenty = lcResult.Rows[0]["warrenty"] != DBNull.Value ? (string)lcResult.Rows[0]["warrenty"] : "",
                    Image = (string)lcResult.Rows[0]["Image"]
                };
            else
                return null;
        }

        public string PostPhone(clsPhone prPhone)
        {
            try
            {
                int lcRecCount = ClsDBConnection.Execute("INSERT INTO tbl_all_products " +
                    "(IMEI, name, item_price, description, color, type, availability, phone_condition, category_id, warrenty) " +
                    "VALUES (@IMEI, @Name, @ItemPrice, @Description, @Color, @Type, @Availability, @Condition, @CategoryID, @Warrenty)", preparePhoneParameters(prPhone));
                if (lcRecCount == 1) return "One Product inserted";
                else return "Error Unexpected Product insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.GetBaseException().Message;
            }
        }

        public string PutPhone(clsPhone prPhone)
        {
            try
            {
                int lcRecCount = ClsDBConnection.Execute(
                "UPDATE tbl_all_products SET IMEI = @IMEI, name = @Name, item_price = @ItemPrice, description = @Description, color = @Color, type = @Type, availability = @Availability, " +
                "phone_condition = @Condition, category_id = @CategoryID, warrenty = @Warrenty WHERE id = @Id",
                preparePhoneParameters(prPhone));
                if (lcRecCount == 1)
                    return "One product updated";
                else
                    return "Error Unexpected product update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.GetBaseException().Message;
            }

        }

        public string DeletePhone(clsPhone prPhone)
        {
            
            try
            {
                int lcRecCount = ClsDBConnection.Execute(
                "DELETE FROM tbl_all_products WHERE id = @Id",
                preparePhoneParameters(prPhone));
                if (lcRecCount == 1)
                    return "One product deleted";
                else
                    return "Error Unexpected product update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.GetBaseException().Message;
            }

        }
        public List<clsOrders> GetPhonePendingOrders()
        {
            DataTable lcResult = ClsDBConnection.GetDataTable("SELECT tbl_orders.email, tbl_orders.amount, " +
                "tbl_orders.id, tbl_all_products.`name`, DATE_FORMAT(tbl_orders.created_at,'%m/%d/%Y') as date," +
                " tbl_orders.updated_at FROM tbl_orders INNER JOIN tbl_all_products ON tbl_orders.product_id = tbl_all_products.id WHERE" +
                " tbl_orders.`status` = 0", null);
            List<clsOrders> lcPhoneOrders = new List<clsOrders>();
            foreach (DataRow dr in lcResult.Rows)
                lcPhoneOrders.Add(new clsOrders
                {
                    Email = (string)dr[0],
                    Amount = (string)dr[1],
                    ID = (int)dr[2],
                    ProductName = (string)dr[3],
                    Date = (string)dr[4],
                    UpdatedAt = (DateTime)dr[5]
                });

            return lcPhoneOrders;
        }

        public List<clsOrders> GetPhoneCompletedOrders()
        {
            DataTable lcResult = ClsDBConnection.GetDataTable("SELECT tbl_orders.email, tbl_orders.amount, " +
                "tbl_orders.id, tbl_all_products.`name`, DATE_FORMAT(tbl_orders.created_at,'%m/%d/%Y') as date" +
                " FROM tbl_orders INNER JOIN tbl_all_products ON tbl_orders.product_id = tbl_all_products.id WHERE" +
                " tbl_orders.`status` = 1", null);
            List<clsOrders> lcPhoneOrders = new List<clsOrders>();
            foreach (DataRow dr in lcResult.Rows)
                lcPhoneOrders.Add(new clsOrders
                {
                    Email = (string)dr[0],
                    Amount = (string)dr[1],
                    ID = (int)dr[2],
                    ProductName = (string)dr[3],
                    Date = (string)dr[4]
                });

            return lcPhoneOrders;
        }

        public string PutConfirmOrder(clsOrders prOrder)
        {
            try
            {
                int lcRecCount = ClsDBConnection.Execute(
                "UPDATE tbl_orders SET status = 1 WHERE id = @Id and updated_at = @UpdatedAt",
                prepareOrderParameters(prOrder));
                if (lcRecCount == 1)
                    return "Order is confirmed";
                else
                    return "Error Unexpected order confirm count: " + lcRecCount;

            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteOrder(clsOrders prOrder)
        {
            try
            {
                int lcRecCount = ClsDBConnection.Execute(
                "DELETE FROM tbl_orders WHERE id = @Id",
                prepareOrderParameters(prOrder));
                if (lcRecCount == 1)
                    return "Order is deleted";
                else
                    return "Error Unexpected order confirm count: " + lcRecCount;

            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
        public string PostOrder(clsOrders prOrder)
        {
            var validString = ValidateNewOrder(prOrder);
            if (validString == "true")
            {
                try
                {

                    int lcRecCount = ClsDBConnection.Execute("INSERT INTO `tbl_orders` (`name`, `status`, `email`, " +
                        "`amount`, `product_id`) VALUES (@Name, 0, @Email, @Amount, @ProductId)", prepareOrderParameters(prOrder));
                    if (lcRecCount == 1)
                    {
                        int lcRecUpdateCount = ClsDBConnection.Execute(
                    "UPDATE tbl_all_products SET availability = 'Not Available' WHERE id = " + prOrder.ProductId + "",
                    null);
                        if (lcRecUpdateCount == 1)
                            return "Your order is completed.";
                        else
                            return "Error Unexpected order confirm count: " + lcRecCount;
                       
                    }
                    else
                    {
                        return "Error Unexpected Product insert count: " + lcRecCount;
                    }

                }
                catch (Exception ex)
                {
                    return "Error: " + ex.GetBaseException().Message;
                }

            }
            else
            {
                return validString;
            }
            
        }
        private string ValidateNewOrder(clsOrders prOrder)
        {
            if (prOrder.Name == "" || prOrder.Email == "")
            {
                return "Name or Email Required";
            }else if (IsPhoneBooked(prOrder.ProductId))
            {
                return "This product is out of stock";
            }
            else
            {
                return "true";
            }
        }

        private bool IsPhoneBooked(int productId)
        {
            DataTable lcResult = ClsDBConnection.GetDataTable("SELECT * FROM tbl_orders where product_id = " + productId + "", null);
            if (lcResult.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Dictionary<string, object> preparePhoneParameters(clsPhone prPhone)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(11);
            par.Add("Id", prPhone.ID);
            par.Add("IMEI", prPhone.IMEI);
            par.Add("Name", prPhone.Name);
            par.Add("ItemPrice", prPhone.ItemPrice);
            par.Add("Description", prPhone.Description);
            par.Add("Color", prPhone.Color);
            par.Add("Type", prPhone.Type);
            par.Add("Availability", prPhone.Availability);
            par.Add("Condition", prPhone.Condition);
            par.Add("CategoryId", prPhone.CategoryID);
            par.Add("Warrenty", prPhone.Warrenty);
            return par;
        }

        private Dictionary<string, object> prepareOrderParameters(clsOrders prOrder)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Id", prOrder.ID);
            par.Add("ProductId", prOrder.ProductId);
            par.Add("Name", prOrder.Name);
            par.Add("Email", prOrder.Email);
            par.Add("Amount", prOrder.Amount);
            par.Add("UpdatedAt", prOrder.UpdatedAt);

            return par;
        }

    }
}
