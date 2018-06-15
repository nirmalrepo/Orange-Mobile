using System;
using System.Collections.Generic;
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
        public void UpdateDisplay()
        {
            getPendingOrders();
            getCompletedOrders();
        }

        private async void getPendingOrders()
        {
            listViewPendingOrders.Items.Clear();
            List<clsOrders> orderDetails = await ServiceClient.GetPhonePendingOrdersAsync();
            foreach (var clsOrders in orderDetails)
            {
                ListViewItem order = new ListViewItem();
                order.Text = clsOrders.ProductName;
                order.SubItems.Add(clsOrders.Email);
                order.SubItems.Add(clsOrders.Date);
                order.SubItems.Add(clsOrders.Amount);
                order.Tag = clsOrders;
                listViewPendingOrders.Items.Add(order);
            }
        }

        private async void getCompletedOrders()
        {
            listViewCompletedOrders.Items.Clear();
            List<clsOrders> orderDetails = await ServiceClient.GetPhoneCompletedOrdersAsync();
            foreach (var clsOrders in orderDetails)
            {
                ListViewItem order = new ListViewItem();
                order.Text = clsOrders.ProductName;
                order.SubItems.Add(clsOrders.Email);
                order.SubItems.Add(clsOrders.Date);
                order.SubItems.Add(clsOrders.Amount);
                order.Tag = clsOrders;
                listViewCompletedOrders.Items.Add(order);
            }
        }

        private void FrmOrders_Load(object sender, EventArgs e)
        {
            UpdateDisplay();

        }

        private void btnConfirmOrders_Click(object sender, EventArgs e)
        {
            if (listViewPendingOrders.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select alteast one pending order.", "Selection Required!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Confirm Order ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    confirmOrder();
                }
             
            }
            
        }

        private async void confirmOrder()
        {
            clsOrders lcOrder = (clsOrders)listViewPendingOrders.FocusedItem.Tag;

            try
            {
                MessageBox.Show(await ServiceClient.ConfirmOrderAsync(lcOrder));
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
