using System;
using System.Windows.Forms;

namespace windows_forms_project_assignment
{
    internal class OrderHistoryCart : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Admin Screen - Order History";

        /** member variables */
        private int id;

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

            /** initialize the DataGridView for cart */
            this.dataGridViewCart.DataSource = null;
            this.dataGridViewCart.DataSource = DataManager.orders[id].cart;
        }

        private void InitializeComponent()
        {
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.ReadOnly = true;
            this.dataGridViewCart.RowTemplate.Height = 25;
            this.dataGridViewCart.Size = new System.Drawing.Size(651, 387);
            this.dataGridViewCart.TabIndex = 0;
            // 
            // OrderHistoryCart
            // 
            this.ClientSize = new System.Drawing.Size(974, 506);
            this.Controls.Add(this.dataGridViewCart);
            this.Name = "OrderHistoryCart";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
