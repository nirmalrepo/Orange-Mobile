﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OrangeMobileSelfhost;

namespace OrangeMobileWinForm
{
    public sealed partial class FrmOldPhone : OrangeMobileWinForm.FrmPhone
    {
        private static readonly FrmOldPhone Instance = new FrmOldPhone();
        public FrmOldPhone()
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

            comboBoxCondition.Text = _Phone.Condition;
        }
        protected override void pushData()
        {
            base.pushData();
            _Phone.Condition = comboBoxCondition.Text;
        }
        protected override bool IsValidForm()
        {
            if (!base.IsValidForm())
            {
                return false;
            }
            if (comboBoxCondition.Text == "")
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
