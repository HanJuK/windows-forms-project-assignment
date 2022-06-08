using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace windows_forms_project_assignment
{
    internal class MileageForm : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Order Screen - Earn Mileage";

        /** member variables */
        private List<CartItem> cart = new List<CartItem>();
        private int grandTotal;
        private Button buttonEarnMileage;
        private TextBox textBoxPhone;
        private Button buttonNoThanks;

        public MileageForm(List<CartItem> cart, int grandTotal)
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE;

            /** set the cart and grandTotal value (from parent Form) */
            this.cart = cart;
            this.grandTotal = grandTotal;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.buttonEarnMileage = new System.Windows.Forms.Button();
            this.buttonNoThanks = new System.Windows.Forms.Button();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonEarnMileage
            // 
            this.buttonEarnMileage.Location = new System.Drawing.Point(118, 12);
            this.buttonEarnMileage.Name = "buttonEarnMileage";
            this.buttonEarnMileage.Size = new System.Drawing.Size(132, 23);
            this.buttonEarnMileage.TabIndex = 1;
            this.buttonEarnMileage.Text = "Earn Mileage";
            this.buttonEarnMileage.UseVisualStyleBackColor = true;
            this.buttonEarnMileage.Click += new System.EventHandler(this.buttonEarnMileage_Click);
            // 
            // buttonNoThanks
            // 
            this.buttonNoThanks.Location = new System.Drawing.Point(197, 226);
            this.buttonNoThanks.Name = "buttonNoThanks";
            this.buttonNoThanks.Size = new System.Drawing.Size(75, 23);
            this.buttonNoThanks.TabIndex = 2;
            this.buttonNoThanks.Text = "No Thanks";
            this.buttonNoThanks.UseVisualStyleBackColor = true;
            this.buttonNoThanks.Click += new System.EventHandler(this.buttonNoThanks_Click);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(12, 12);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(100, 23);
            this.textBoxPhone.TabIndex = 0;
            // 
            // MileageForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonNoThanks);
            this.Controls.Add(this.buttonEarnMileage);
            this.Controls.Add(this.textBoxPhone);
            this.Name = "MileageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /** define EventHandlers */
        private void buttonEarnMileage_Click(object sender, System.EventArgs e)
        {
            int mileageCount = 0;
            bool isMileageFull = false;

            /** handle exception where phone value is invalid */
            try
            {
                if (int.Parse(this.textBoxPhone.Text) < 0)
                {
                    // TODO: clean this
                    MessageBox.Show("invalid");
                }
            }
            catch (Exception _)
            {
                // TODO: clean this
                MessageBox.Show("invalid");
            }

            /** check if mileage is full (it's the 10th purchase) */
            foreach (Order order in DataManager.orders)
            {
                if (order.phone.Equals(this.textBoxPhone.Text))
                {
                    if (order.isMileageUsed)
                    {
                        mileageCount = 0;

                        continue;
                    }

                    if (++mileageCount == 9)
                    {
                        isMileageFull = true;

                        break;
                    }
                }
            }

            /** save phone value to Order (and if mileage is full -> apply a 10% discount) */
            if (isMileageFull)
            {
                DataManager.orders.Add(new Order()
                {
                    cart = this.cart,
                    grandTotal = (int)(this.grandTotal * (0.9)),
                    datetime = DateTime.Now.ToString(),
                    phone = this.textBoxPhone.Text,
                    isMileageUsed = true
                });

                // TODO: clean this
                MessageBox.Show("10% dc applied");
            }
            else
            {
                DataManager.orders.Add(new Order()
                {
                    cart = this.cart,
                    grandTotal = this.grandTotal,
                    datetime = DateTime.Now.ToString(),
                    phone = this.textBoxPhone.Text,
                    isMileageUsed = false
                });

                // TODO: clean this
                MessageBox.Show($"current mileage: {mileageCount + 1}");
            }

            return;
        }

        private void buttonNoThanks_Click(object sender, System.EventArgs e)
        {
            DataManager.orders.Add(new Order()
            {
                cart = this.cart,
                grandTotal = this.grandTotal,
                datetime = DateTime.Now.ToString(),
                phone = "-1",
                isMileageUsed = false
            });

            // TODO: clean this
            MessageBox.Show("purchase success");

            return;
        }
    }
}
