using System;
using System.Windows.Forms;
using OrangeMobileSelfhost;

namespace OrangeMobileWinForm
{
    public sealed partial class FrmMain : Form

    {
        private static readonly FrmMain _Instance = new FrmMain();



        private FrmMain()
        {
            InitializeComponent();
        }

        public static FrmMain Instance
        {
            get { return FrmMain._Instance; }
        }
        public async void UpdateDisplay()
        {
            phoneList.DataSource = null;
            phoneList.DataSource = await ServiceClient.GetPhoneListAsync();
            lblTotalItems.Text = phoneList.Items.Count.ToString();

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void phoneList_DoubleClick(object sender, EventArgs e)
        {
            FrmPhone.DispatchPhoneForm(phoneList.SelectedValue as clsPhone);
        }

        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            string lcReply = new InputBox(clsPhone.FACTORY_PROMPT).Answer;

            if (!string.IsNullOrEmpty(lcReply)) // not cancelled?

            {

                clsPhone lcPhone = clsPhone.NewPhone(lcReply[0]);
                FrmPhone.DispatchPhoneForm(lcPhone);
                if (lcPhone != null) // valid artwork created?

                {
                    FrmMain.Instance.UpdateDisplay();
                }

            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            FrmOrders frmOrders = new FrmOrders();
            frmOrders.Run();
        }

    }
}
