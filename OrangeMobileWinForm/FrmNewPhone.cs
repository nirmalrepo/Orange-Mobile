using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OrangeMobileSelfhost;

namespace OrangeMobileWinForm
{
    public sealed partial class FrmNewPhone : OrangeMobileWinForm.FrmPhone
    {
        private static readonly FrmNewPhone Instance = new FrmNewPhone();
        public FrmNewPhone()
        {
            InitializeComponent();
            GetCategories();
        }
        public static void Run(clsPhone prPhone)
        {
            Instance.SetDetails(prPhone);
        }

        protected override void GetCategories()
        {
            base.GetCategories();
        }

        protected override void updateForm()
        {
            base.updateForm();

            textBoxWarrenty.Text = _Phone.Warrenty;
        }
        protected override void pushData()
        {
            base.pushData();
            _Phone.Warrenty = textBoxWarrenty.Text;
        }
        protected override bool IsValidForm()
        {
            if (!base.IsValidForm())
            {
                return false;
            }
            if (textBoxWarrenty.Text == "")
            {
                ShowErrorMessage("Please provide all the required fields.", "Required Fields");
                return false;
            }
            else
            {
                return true;
            }
        }

        protected override void ShowErrorMessage(string detail, string title)
        {
            base.ShowErrorMessage(detail, title);
        }
    }
}
