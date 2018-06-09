﻿using System;
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

        protected async virtual void GetCategories()
        {

            //clsPhoneCategories item = new clsPhoneCategories();
            //item.Text = "Apple";
            //item.Value = 1;

            //comboBoxCategory.Items.Add(item);

            //item.Text = "Samsung";
            //item.Value = 2;
            //comboBoxCategory.Items.Add(item);

            comboBoxCategory.DataSource = null;
            comboBoxCategory.DataSource = await ServiceClient.GetPhoneCategoriesAsync();


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
            textBoxID.Text = Convert.ToString(_Phone.ID);
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
            _Phone.CategoryID = (comboBoxCategory.SelectedItem as clsPhoneCategories).Value;
            _Phone.Availability = comboBoxAvailabilty.Text;
        }

        public delegate void LoadProductFormDelegate(clsPhone prPhone);
        public static Dictionary<char, Delegate> _PhoneForm = new Dictionary<char, Delegate>
        {
            { 'N', new LoadProductFormDelegate(FrmNewPhone.Run) },
            { 'O', new LoadProductFormDelegate(FrmOldPhone.Run) }
        };
        public static void DispatchPhoneForm(clsPhone prPhone) {
            _PhoneForm[Convert.ToChar(prPhone.Type)].DynamicInvoke(prPhone);
        }

        private async void  button1_ClickAsync(object sender, EventArgs e)
        {
           
            try {
                pushData();
                if (textBoxID.Text == "" || textBoxID.Text == "0")

                    MessageBox.Show(await ServiceClient.InsertProductAsync(_Phone));

                else

                    MessageBox.Show(await ServiceClient.UpdateProductAsync(_Phone));
                Hide();
                FrmMain.Instance.UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
