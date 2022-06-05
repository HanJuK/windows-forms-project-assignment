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

        /** variables for child forms */
        private Button buttonCreateProduct;

        /** AdminForm class constructor (initialize) */
        public AdminForm()
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE;

            this.InitializeComponent();

            this.refreshProductList();
        }

        private void InitializeComponent()
        {
            this.buttonCreateProduct = new System.Windows.Forms.Button();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateProduct
            // 
            this.buttonCreateProduct.Location = new System.Drawing.Point(395, 418);
            this.buttonCreateProduct.Name = "buttonCreateProduct";
            this.buttonCreateProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateProduct.TabIndex = 0;
            this.buttonCreateProduct.Text = "Create Product";
            this.buttonCreateProduct.Click += new System.EventHandler(this.buttonCreateProduct_Click);
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.ReadOnly = true;
            this.dataGridViewProduct.RowHeadersWidth = 51;
            this.dataGridViewProduct.RowTemplate.Height = 29;
            this.dataGridViewProduct.Size = new System.Drawing.Size(458, 400);
            this.dataGridViewProduct.TabIndex = 1;
            this.dataGridViewProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProduct_CellDoubleClick);
            // 
            // AdminForm
            // 
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.dataGridViewProduct);
            this.Controls.Add(this.buttonCreateProduct);
            this.Name = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            this.ResumeLayout(false);

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
    }
}
