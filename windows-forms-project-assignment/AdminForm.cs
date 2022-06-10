using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace windows_forms_project_assignment
{
    internal class AdminForm : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Admin Screen";
        private DataGridView dataGridViewProduct;
        private Label labelProductListTitle;
        private Label labelUpdateDeleteHint;
        private Label labelOrderListTitle;
        private DataGridView dataGridViewOrder;
        private Label labelItemDetailHint;
        private Label labelTotalSalesTitle;
        private Label labelTotalSales;

        /** variables for child forms */
        private Button buttonCreateProduct;

        /** AdminForm class constructor (initialize) */
        public AdminForm()
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE;

            this.InitializeComponent();

            this.refreshProductList();
            this.initializeDataGridViewOrder();

            /** set total sales */
            int totalSales = 0;
            foreach (Order order in DataManager.orders)
            {
                totalSales += order.grandTotal;
            }
            this.labelTotalSales.Text = totalSales.ToString();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonCreateProduct = new System.Windows.Forms.Button();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.labelProductListTitle = new System.Windows.Forms.Label();
            this.labelUpdateDeleteHint = new System.Windows.Forms.Label();
            this.labelOrderListTitle = new System.Windows.Forms.Label();
            this.dataGridViewOrder = new System.Windows.Forms.DataGridView();
            this.labelItemDetailHint = new System.Windows.Forms.Label();
            this.labelTotalSalesTitle = new System.Windows.Forms.Label();
            this.labelTotalSales = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateProduct
            // 
            this.buttonCreateProduct.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCreateProduct.Location = new System.Drawing.Point(368, 19);
            this.buttonCreateProduct.Name = "buttonCreateProduct";
            this.buttonCreateProduct.Size = new System.Drawing.Size(30, 27);
            this.buttonCreateProduct.TabIndex = 0;
            this.buttonCreateProduct.Text = "+";
            this.buttonCreateProduct.Click += new System.EventHandler(this.buttonCreateProduct_Click);
            // 
            // dataGridViewProduct
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(12, 52);
            this.dataGridViewProduct.MultiSelect = false;
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.ReadOnly = true;
            this.dataGridViewProduct.RowHeadersWidth = 51;
            this.dataGridViewProduct.RowTemplate.Height = 29;
            this.dataGridViewProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProduct.Size = new System.Drawing.Size(386, 436);
            this.dataGridViewProduct.TabIndex = 1;
            this.dataGridViewProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProduct_CellDoubleClick);
            // 
            // labelProductListTitle
            // 
            this.labelProductListTitle.AutoSize = true;
            this.labelProductListTitle.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelProductListTitle.Location = new System.Drawing.Point(12, 12);
            this.labelProductListTitle.Name = "labelProductListTitle";
            this.labelProductListTitle.Size = new System.Drawing.Size(101, 30);
            this.labelProductListTitle.TabIndex = 3;
            this.labelProductListTitle.Text = "Products:";
            // 
            // labelUpdateDeleteHint
            // 
            this.labelUpdateDeleteHint.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelUpdateDeleteHint.Location = new System.Drawing.Point(12, 491);
            this.labelUpdateDeleteHint.Name = "labelUpdateDeleteHint";
            this.labelUpdateDeleteHint.Size = new System.Drawing.Size(386, 20);
            this.labelUpdateDeleteHint.TabIndex = 4;
            this.labelUpdateDeleteHint.Text = "Double-click an item to update/delete it.";
            this.labelUpdateDeleteHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOrderListTitle
            // 
            this.labelOrderListTitle.AutoSize = true;
            this.labelOrderListTitle.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelOrderListTitle.Location = new System.Drawing.Point(417, 12);
            this.labelOrderListTitle.Name = "labelOrderListTitle";
            this.labelOrderListTitle.Size = new System.Drawing.Size(81, 30);
            this.labelOrderListTitle.TabIndex = 5;
            this.labelOrderListTitle.Text = "Orders:";
            // 
            // dataGridViewOrder
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrder.Location = new System.Drawing.Point(417, 52);
            this.dataGridViewOrder.MultiSelect = false;
            this.dataGridViewOrder.Name = "dataGridViewOrder";
            this.dataGridViewOrder.ReadOnly = true;
            this.dataGridViewOrder.RowTemplate.Height = 25;
            this.dataGridViewOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrder.Size = new System.Drawing.Size(457, 395);
            this.dataGridViewOrder.TabIndex = 6;
            this.dataGridViewOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrder_CellDoubleClick);
            // 
            // labelItemDetailHint
            // 
            this.labelItemDetailHint.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelItemDetailHint.Location = new System.Drawing.Point(417, 450);
            this.labelItemDetailHint.Name = "labelItemDetailHint";
            this.labelItemDetailHint.Size = new System.Drawing.Size(457, 20);
            this.labelItemDetailHint.TabIndex = 7;
            this.labelItemDetailHint.Text = "Double-click an item to view it\'s details.";
            this.labelItemDetailHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalSalesTitle
            // 
            this.labelTotalSalesTitle.AutoSize = true;
            this.labelTotalSalesTitle.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTotalSalesTitle.Location = new System.Drawing.Point(417, 481);
            this.labelTotalSalesTitle.Name = "labelTotalSalesTitle";
            this.labelTotalSalesTitle.Size = new System.Drawing.Size(119, 30);
            this.labelTotalSalesTitle.TabIndex = 8;
            this.labelTotalSalesTitle.Text = "Total Sales:";
            // 
            // labelTotalSales
            // 
            this.labelTotalSales.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTotalSales.Location = new System.Drawing.Point(537, 481);
            this.labelTotalSales.Name = "labelTotalSales";
            this.labelTotalSales.Size = new System.Drawing.Size(337, 30);
            this.labelTotalSales.TabIndex = 9;
            this.labelTotalSales.Text = "Lorem ipsum";
            this.labelTotalSales.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AdminForm
            // 
            this.ClientSize = new System.Drawing.Size(886, 520);
            this.Controls.Add(this.labelTotalSales);
            this.Controls.Add(this.labelTotalSalesTitle);
            this.Controls.Add(this.labelItemDetailHint);
            this.Controls.Add(this.dataGridViewOrder);
            this.Controls.Add(this.labelOrderListTitle);
            this.Controls.Add(this.labelUpdateDeleteHint);
            this.Controls.Add(this.labelProductListTitle);
            this.Controls.Add(this.dataGridViewProduct);
            this.Controls.Add(this.buttonCreateProduct);
            this.Name = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void refreshProductList()
        {
            List<Product> productsListWithoutDeleted = new List<Product>();

            foreach (Product product in DataManager.products)
            {
                if (!product.isDeleted)
                {
                    productsListWithoutDeleted.Add(product);
                }
            }

            dataGridViewProduct.DataSource = null;
            dataGridViewProduct.DataSource = productsListWithoutDeleted;

            dataGridViewProduct.Columns["isDeleted"].Visible = false;

            return;
        }

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

        /** define EventHandlers */
        private void buttonCreateProduct_Click(object sender, EventArgs e)
        {
            /** open create update product screen in create mode */
            Form createUpdateProductForm = new CreateUpdateProductForm();
            createUpdateProductForm.FormClosed += new FormClosedEventHandler(createUpdateProductFormClosed);

            void createUpdateProductFormClosed(object sender, FormClosedEventArgs e)
            {
                this.refreshProductList();
            }

            createUpdateProductForm.ShowDialog();

            return;
        }

        private void dataGridViewProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /** handle exception for when clicked topmost row */
            if (e.RowIndex == -1)
            {
                return;
            }

            /** open create update product screen in update mode */
            Form createUpdateProductForm = new CreateUpdateProductForm(
                (int)dataGridViewProduct.Rows[e.RowIndex].Cells[0].Value);
            createUpdateProductForm.FormClosed += new FormClosedEventHandler(createUpdateProductFormClosed);

            void createUpdateProductFormClosed(object sender, FormClosedEventArgs e)
            {
                this.refreshProductList();
            }

            createUpdateProductForm.ShowDialog();

            return;
        }

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
