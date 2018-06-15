using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OrangeMobileSelfhost;

namespace OrangeMobileWinForm
{
    public partial class FrmPhone : Form
    {
        protected clsPhone _Phone;
        public FrmPhone()
        {
            InitializeComponent();
        }

        protected virtual void FrmPhone_Load(object sender, EventArgs e)
        {
            GetCategories();
        }

        protected async virtual void GetCategories()
        {
            comboBoxCategory.DataSource = null;
            comboBoxCategory.DataSource = await ServiceClient.GetPhoneCategoriesAsync();
            if (_Phone.ID != 0)
            {

                List<clsPhoneCategories> lcCategories = (List<clsPhoneCategories>)comboBoxCategory.DataSource;
                clsPhoneCategories lcCategory = lcCategories.FirstOrDefault(lcCat => lcCat.Value == _Phone.CategoryID);
                comboBoxCategory.Text = lcCategory.Text;
            }


        }
        public void SetDetails(clsPhone prPhone)
        {
            _Phone = prPhone;
            updateForm();
            ShowDialog();
        }



        protected virtual bool isValid()
        {
            return true;
        }

        protected virtual void updateForm()
        {
            textBoxIMEI.Text = _Phone.IMEI;
            textBoxName.Text = _Phone.Name;
            textBoxDescription.Text = _Phone.Description;
            textBoxColor.Text = _Phone.Color;
            numericUpDownPrice.Value = Convert.ToDecimal(_Phone.ItemPrice);
            comboBoxAvailabilty.Text = _Phone.Availability;



        }

        protected virtual void pushData()
        {
            _Phone.IMEI = textBoxIMEI.Text;
            _Phone.Name = textBoxName.Text;
            _Phone.Description = textBoxDescription.Text;
            _Phone.Color = textBoxColor.Text;
            _Phone.ItemPrice = numericUpDownPrice.Value;
            _Phone.CategoryID = (comboBoxCategory.SelectedItem as clsPhoneCategories).Value;
            _Phone.Availability = comboBoxAvailabilty.Text;
        }

        public delegate void LoadProductFormDelegate(clsPhone prPhone);
        public static Dictionary<char, Delegate> _PhoneForm = new Dictionary<char, Delegate>
        {
            { 'N', new LoadProductFormDelegate(FrmNewPhone.Run) },
            { 'O', new LoadProductFormDelegate(FrmOldPhone.Run) }
        };
        public static void DispatchPhoneForm(clsPhone prPhone)
        {
            _PhoneForm[Convert.ToChar(prPhone.Type)].DynamicInvoke(prPhone);
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            string Response;
            if (IsValidForm())
            {
                try
                {
                    pushData();
                    if (_Phone.ID == 0)
                        Response = await ServiceClient.InsertProductAsync(_Phone);

                    else
                        Response = await ServiceClient.UpdateProductAsync(_Phone);

                    MessageBox.Show(Response);
                    if (!Response.Contains("Error"))
                        Hide();
                    FrmMain.Instance.UpdateDisplay();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual bool IsValidForm()
        {
            if (textBoxColor.Text == "" & textBoxDescription.Text == "" && textBoxIMEI.Text == "" && textBoxName.Text == "")
            {
                ShowErrorMessage("Please provide all the required fields.", "Required Fields");
                return false;
            }
            else
            {
                return true;
            }
        }

        protected virtual void ShowErrorMessage(string detail, string title)
        {
            MessageBox.Show(detail, title,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
