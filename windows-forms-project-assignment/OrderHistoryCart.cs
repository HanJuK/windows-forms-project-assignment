using System;
using System.Windows.Forms;

namespace windows_forms_project_assignment
{
    internal class OrderHistoryCart : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Admin Screen - Order History (Cart)";

        /** member variables */
        private int id;
        private Label labelCartListTitle;
        private Label labelDatetime;
        private Label labelDatetimeValue;
        private Label labelPhoneValue;
        private Label labelPhone;
        private Label labelGrandTotalValue;
        private Label labelGrandTotal;
        private Label labelMileageUsedValue;
        private Label labelMileageUsed;

        /** variables for child forms */
        private DataGridView dataGridViewCart;

        /** OrderHistoryCart class constructor (initialize) */
        public OrderHistoryCart(int id)
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE;

            /** set cart id */
            this.id = id;

            InitializeComponent();

            /** set form values */
            this.labelDatetimeValue.Text = DataManager.orders[id].datetime;
            this.labelPhoneValue.Text = DataManager.orders[id].phone;
            this.labelGrandTotalValue.Text = DataManager.orders[id].grandTotal.ToString();
            this.labelMileageUsedValue.Text = DataManager.orders[id].isMileageUsed ? "YES" : "NO";

            /** initialize the DataGridView for cart */
            this.dataGridViewCart.DataSource = null;
            this.dataGridViewCart.DataSource = DataManager.orders[id].cart;
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.labelCartListTitle = new System.Windows.Forms.Label();
            this.labelDatetime = new System.Windows.Forms.Label();
            this.labelDatetimeValue = new System.Windows.Forms.Label();
            this.labelPhoneValue = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelGrandTotalValue = new System.Windows.Forms.Label();
            this.labelGrandTotal = new System.Windows.Forms.Label();
            this.labelMileageUsedValue = new System.Windows.Forms.Label();
            this.labelMileageUsed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(12, 49);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.ReadOnly = true;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewCart.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCart.RowTemplate.Height = 25;
            this.dataGridViewCart.Size = new System.Drawing.Size(587, 387);
            this.dataGridViewCart.TabIndex = 0;
            // 
            // labelCartListTitle
            // 
            this.labelCartListTitle.AutoSize = true;
            this.labelCartListTitle.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCartListTitle.Location = new System.Drawing.Point(12, 9);
            this.labelCartListTitle.Name = "labelCartListTitle";
            this.labelCartListTitle.Size = new System.Drawing.Size(142, 30);
            this.labelCartListTitle.TabIndex = 4;
            this.labelCartListTitle.Text = "Order Details:";
            // 
            // labelDatetime
            // 
            this.labelDatetime.AutoSize = true;
            this.labelDatetime.Location = new System.Drawing.Point(695, 143);
            this.labelDatetime.Name = "labelDatetime";
            this.labelDatetime.Size = new System.Drawing.Size(59, 15);
            this.labelDatetime.TabIndex = 5;
            this.labelDatetime.Text = "Datetime:";
            // 
            // labelDatetimeValue
            // 
            this.labelDatetimeValue.AutoSize = true;
            this.labelDatetimeValue.Location = new System.Drawing.Point(807, 143);
            this.labelDatetimeValue.Name = "labelDatetimeValue";
            this.labelDatetimeValue.Size = new System.Drawing.Size(39, 15);
            this.labelDatetimeValue.TabIndex = 6;
            this.labelDatetimeValue.Text = "label1";
            // 
            // labelPhoneValue
            // 
            this.labelPhoneValue.AutoSize = true;
            this.labelPhoneValue.Location = new System.Drawing.Point(807, 200);
            this.labelPhoneValue.Name = "labelPhoneValue";
            this.labelPhoneValue.Size = new System.Drawing.Size(39, 15);
            this.labelPhoneValue.TabIndex = 8;
            this.labelPhoneValue.Text = "label2";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(695, 200);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(44, 15);
            this.labelPhone.TabIndex = 7;
            this.labelPhone.Text = "Phone:";
            // 
            // labelGrandTotalValue
            // 
            this.labelGrandTotalValue.AutoSize = true;
            this.labelGrandTotalValue.Location = new System.Drawing.Point(807, 258);
            this.labelGrandTotalValue.Name = "labelGrandTotalValue";
            this.labelGrandTotalValue.Size = new System.Drawing.Size(39, 15);
            this.labelGrandTotalValue.TabIndex = 10;
            this.labelGrandTotalValue.Text = "label3";
            // 
            // labelGrandTotal
            // 
            this.labelGrandTotal.AutoSize = true;
            this.labelGrandTotal.Location = new System.Drawing.Point(695, 258);
            this.labelGrandTotal.Name = "labelGrandTotal";
            this.labelGrandTotal.Size = new System.Drawing.Size(72, 15);
            this.labelGrandTotal.TabIndex = 9;
            this.labelGrandTotal.Text = "Grand Total:";
            // 
            // labelMileageUsedValue
            // 
            this.labelMileageUsedValue.AutoSize = true;
            this.labelMileageUsedValue.Location = new System.Drawing.Point(807, 314);
            this.labelMileageUsedValue.Name = "labelMileageUsedValue";
            this.labelMileageUsedValue.Size = new System.Drawing.Size(39, 15);
            this.labelMileageUsedValue.TabIndex = 12;
            this.labelMileageUsedValue.Text = "label4";
            // 
            // labelMileageUsed
            // 
            this.labelMileageUsed.AutoSize = true;
            this.labelMileageUsed.Location = new System.Drawing.Point(695, 314);
            this.labelMileageUsed.Name = "labelMileageUsed";
            this.labelMileageUsed.Size = new System.Drawing.Size(82, 15);
            this.labelMileageUsed.TabIndex = 11;
            this.labelMileageUsed.Text = "Mileage Used:";
            // 
            // OrderHistoryCart
            // 
            this.ClientSize = new System.Drawing.Size(1048, 451);
            this.Controls.Add(this.labelMileageUsedValue);
            this.Controls.Add(this.labelMileageUsed);
            this.Controls.Add(this.labelGrandTotalValue);
            this.Controls.Add(this.labelGrandTotal);
            this.Controls.Add(this.labelPhoneValue);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelDatetimeValue);
            this.Controls.Add(this.labelDatetime);
            this.Controls.Add(this.labelCartListTitle);
            this.Controls.Add(this.dataGridViewCart);
            this.Name = "OrderHistoryCart";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
