using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace windows_forms_project_assignment
{
    internal class MileageForm : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Order Screen - Mileage System";

        /** member variables */
        private List<CartItem> cart = new List<CartItem>();
        private int grandTotal;
        private Button buttonEarnMileage;
        private TextBox textBoxPhone;
        private Label labelTitle;
        private Label labelDescription1;
        private Label labelDescription2;
        private Label labelPhone;
        private LinkLabel linkNoThanks;

        /** MileageForm class constructor (initialize) */
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
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDescription1 = new System.Windows.Forms.Label();
            this.labelDescription2 = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.linkNoThanks = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // buttonEarnMileage
            // 
            this.buttonEarnMileage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonEarnMileage.Location = new System.Drawing.Point(244, 210);
            this.buttonEarnMileage.Name = "buttonEarnMileage";
            this.buttonEarnMileage.Size = new System.Drawing.Size(105, 23);
            this.buttonEarnMileage.TabIndex = 1;
            this.buttonEarnMileage.Text = "Earn Mileage!";
            this.buttonEarnMileage.UseVisualStyleBackColor = false;
            this.buttonEarnMileage.Click += new System.EventHandler(this.buttonEarnMileage_Click);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(107, 210);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(131, 23);
            this.textBoxPhone.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new System.Drawing.Point(14, 19);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(374, 30);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "Mileage System";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDescription1
            // 
            this.labelDescription1.Location = new System.Drawing.Point(14, 78);
            this.labelDescription1.Name = "labelDescription1";
            this.labelDescription1.Size = new System.Drawing.Size(374, 45);
            this.labelDescription1.TabIndex = 9;
            this.labelDescription1.Text = "You can earn mileage points* by entering your phone number.\n\nGet a 10% discount f" +
    "or every 10 orders!";
            this.labelDescription1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDescription2
            // 
            this.labelDescription2.Font = new System.Drawing.Font("Malgun Gothic Semilight", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelDescription2.Location = new System.Drawing.Point(14, 154);
            this.labelDescription2.Name = "labelDescription2";
            this.labelDescription2.Size = new System.Drawing.Size(374, 15);
            this.labelDescription2.TabIndex = 10;
            this.labelDescription2.Text = "* 1 point per order";
            this.labelDescription2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(57, 214);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(44, 15);
            this.labelPhone.TabIndex = 11;
            this.labelPhone.Text = "Phone:";
            // 
            // linkNoThanks
            // 
            this.linkNoThanks.Location = new System.Drawing.Point(14, 271);
            this.linkNoThanks.Name = "linkNoThanks";
            this.linkNoThanks.Size = new System.Drawing.Size(374, 15);
            this.linkNoThanks.TabIndex = 12;
            this.linkNoThanks.TabStop = true;
            this.linkNoThanks.Text = "No thanks I\'ll just pay.";
            this.linkNoThanks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkNoThanks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNoThanks_LinkClicked);
            // 
            // MileageForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 311);
            this.Controls.Add(this.linkNoThanks);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelDescription2);
            this.Controls.Add(this.labelDescription1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonEarnMileage);
            this.Controls.Add(this.textBoxPhone);
            this.Name = "MileageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /** define EventHandlers */
        private void buttonEarnMileage_Click(object sender, System.EventArgs e)
        {
            /** handle exception where phone value is invalid */
            try
            {
                if (int.Parse(this.textBoxPhone.Text) < 0)
                {
                    // TODO: clean this
                    MessageBox.Show("invalid");

                    return;
                }
            }
            catch (Exception _)
            {
                // TODO: clean this
                MessageBox.Show("invalid");

                return;
            }

            int mileageCount = 0;

            /** calculate mileage count */
            foreach (Order order in DataManager.orders)
            {
                if (order.phone.Equals(this.textBoxPhone.Text))
                {
                    if (order.isMileageUsed)
                    {
                        mileageCount = 0;

                        continue;
                    }

                    ++mileageCount;
                }
            }

            /** save phone value to Order (and if the new mileage is 10 -> apply a 10% discount) */
            if (mileageCount + 1 == 10)
            {
                DataManager.orders.Add(new Order()
                {
                    cart = this.cart,
                    grandTotal = (int)(this.grandTotal * (0.9)),
                    datetime = DateTime.Now.ToString(),
                    phone = this.textBoxPhone.Text,
                    isMileageUsed = true
                });

                DataManager.saveData();

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

                DataManager.saveData();

                // TODO: clean this
                MessageBox.Show($"current mileage: {mileageCount + 1}");
            }

            return;
        }

        private void linkNoThanks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataManager.orders.Add(new Order()
            {
                cart = this.cart,
                grandTotal = this.grandTotal,
                datetime = DateTime.Now.ToString(),
                phone = "-1",
                isMileageUsed = false
            });

            DataManager.saveData();

            // TODO: clean this
            MessageBox.Show("purchase success");

            return;
        }
    }
}
