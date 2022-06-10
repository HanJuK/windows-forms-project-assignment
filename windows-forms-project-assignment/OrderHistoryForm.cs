using System;
using System.Windows.Forms;

namespace windows_forms_project_assignment
{
    internal class OrderHistoryForm : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Admin Screen - Order History";

        /** variables for child forms */
        private DataGridView dataGridViewOrder;

        /** OrderHistoryForm class constructor (initialize) */
        public OrderHistoryForm()
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE;

            InitializeComponent();

            initializeDataGridViewOrder();
        }

        /** initialize the DataGridView for orders and hide/reorder columns */
        private void initializeDataGridViewOrder()
        {
            dataGridViewOrder.DataSource = null;
            dataGridViewOrder.DataSource = DataManager.orders;

            dataGridViewOrder.Columns["cartDataInString"].Visible = false;

            dataGridViewOrder.Columns["datetime"].DisplayIndex = 1;
            dataGridViewOrder.Columns["phone"].DisplayIndex = 2;
            dataGridViewOrder.Columns["grandTotal"].DisplayIndex = 3;
            dataGridViewOrder.Columns["isMileageUsed"].DisplayIndex = 4;

            return;
        }

        private void InitializeComponent()
        {
            this.dataGridViewOrder = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOrder
            // 
            this.dataGridViewOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrder.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewOrder.Name = "dataGridViewOrder";
            this.dataGridViewOrder.ReadOnly = true;
            this.dataGridViewOrder.RowTemplate.Height = 25;
            this.dataGridViewOrder.Size = new System.Drawing.Size(520, 337);
            this.dataGridViewOrder.TabIndex = 0;
            this.dataGridViewOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrder_CellDoubleClick);
            // 
            // OrderHistoryForm
            // 
            this.ClientSize = new System.Drawing.Size(753, 560);
            this.Controls.Add(this.dataGridViewOrder);
            this.Name = "OrderHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).EndInit();
            this.ResumeLayout(false);

        }

        /** define EventHandlers */
        private void dataGridViewOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /** handle exception for when clicked topmost row */
            if (e.RowIndex == -1)
            {
                return;
            }

            /** open order history cart screen */
            (new OrderHistoryCart(e.RowIndex)).ShowDialog();

            return;
        }
    }
}
