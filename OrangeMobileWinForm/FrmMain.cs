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
            //lstArtists.DataSource = null;
            //string[] lcDisplayList = new string[_ArtistList.Count];
            //_ArtistList.Keys.CopyTo(lcDisplayList, 0);
            //lstArtists.DataSource = lcDisplayList;
            //lblValue.Text = Convert.ToString(_ArtistList.GetTotalValue());
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
            Console.WriteLine("Reply {0}", lcReply);
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
    }
}
