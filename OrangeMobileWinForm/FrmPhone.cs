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

        protected virtual void GetCategories()
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("1", "Apple");
            comboSource.Add("1", "Samsung");

            comboBoxCategory.DataSource = new BindingSource(comboSource, null);
            comboBoxCategory.DisplayMember = "Value";
            comboBoxCategory.ValueMember = "Key";

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
                 
        }

        protected virtual void pushData()
        {
            _Phone.IMEI = textBoxIMEI.Text;
            _Phone.Name = textBoxName.Text;
            _Phone.Description = textBoxDescription.Text;
            _Phone.Color = textBoxColor.Text;
            _Phone.ItemPrice = numericUpDownPrice.Value;
        }

        public delegate void LoadProductFormDelegate(clsPhone prPhone);
        public static Dictionary<char, Delegate> _PhoneForm = new Dictionary<char, Delegate>
        {
            { 'N', new LoadProductFormDelegate(FrmNewPhone.Run) },
            { 'O', null }
        };
        public static void DispatchPhoneForm(clsPhone prPhone) {
            _PhoneForm[Convert.ToChar(prPhone.Type)].DynamicInvoke(prPhone);
        }
    }
}
