using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrangeMobileSelfhost;

namespace OrangeMobileWinForm
{
    public partial class FrmOrders : Form
    {
        
        public FrmOrders()
        {
            InitializeComponent();
        }
        public void Run()
        {
            this.ShowDialog();
        }
        public async void UpdateDisplay()
        {
            listBoxPendingOrders.DataSource = null;
            listBoxPendingOrders.DataSource = await ServiceClient.GetPhoneOrdersAsync();
        }

        private async void FrmOrders_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
            listView1.Items.Clear();
            List<clsOrders> orderDetails = await ServiceClient.GetPhoneOrdersAsync();
            foreach (var clsOrders in orderDetails)
            {
                ListViewItem order = new ListViewItem();
                Console.WriteLine("TEs==== {0}", clsOrders.Email);
                order.Text = clsOrders.ProductName;
                order.SubItems.Add(clsOrders.Email);
                order.Tag = clsOrders;
                listView1.Items.Add(order);
                

            }
        }
    }
}
