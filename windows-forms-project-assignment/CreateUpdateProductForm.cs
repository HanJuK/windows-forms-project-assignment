using System;
using System.Windows.Forms;

namespace windows_forms_project_assignment
{
    internal class CreateUpdateProductForm : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Admin Screen - Create/Update Product";

        /** variables for child forms */
        private Label labelProductName;
        private TextBox textBoxProductName;
        private Label labelProductPrice;
        private NumericUpDown numericUpDownProductPrice;
        private Button buttonCreateUpdateProduct;

        /** CreateUpdateProductForm class constructor (initialize) */
        public CreateUpdateProductForm()
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE;

            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.labelProductName = new System.Windows.Forms.Label();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.labelProductPrice = new System.Windows.Forms.Label();
            this.buttonCreateUpdateProduct = new System.Windows.Forms.Button();
            this.numericUpDownProductPrice = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProductPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(12, 9);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(115, 20);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "Product Name: ";
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(12, 27);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(100, 27);
            this.textBoxProductName.TabIndex = 2;
            // 
            // labelProductPrice
            // 
            this.labelProductPrice.AutoSize = true;
            this.labelProductPrice.Location = new System.Drawing.Point(233, 9);
            this.labelProductPrice.Name = "labelProductPrice";
            this.labelProductPrice.Size = new System.Drawing.Size(108, 20);
            this.labelProductPrice.TabIndex = 1;
            this.labelProductPrice.Text = "Product Price: ";
            // 
            // buttonCreateUpdateProduct
            // 
            this.buttonCreateUpdateProduct.Location = new System.Drawing.Point(197, 56);
            this.buttonCreateUpdateProduct.Name = "buttonCreateUpdateProduct";
            this.buttonCreateUpdateProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateUpdateProduct.TabIndex = 4;
            this.buttonCreateUpdateProduct.Text = "Create/Update Product";
            this.buttonCreateUpdateProduct.UseVisualStyleBackColor = true;
            this.buttonCreateUpdateProduct.Click += new System.EventHandler(this.buttonCreateUpdateProduct_Click);
            // 
            // numericUpDownProductPrice
            // 
            this.numericUpDownProductPrice.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownProductPrice.Location = new System.Drawing.Point(122, 27);
            this.numericUpDownProductPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownProductPrice.Name = "numericUpDownProductPrice";
            this.numericUpDownProductPrice.Size = new System.Drawing.Size(150, 27);
            this.numericUpDownProductPrice.TabIndex = 5;
            // 
            // CreateUpdateProductForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.numericUpDownProductPrice);
            this.Controls.Add(this.buttonCreateUpdateProduct);
            this.Controls.Add(this.textBoxProductName);
            this.Controls.Add(this.labelProductPrice);
            this.Controls.Add(this.labelProductName);
            this.Name = "CreateUpdateProductForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProductPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /** define EventHandlers */
        private void buttonCreateUpdateProduct_Click(object sender, EventArgs e)
        {
            DataManager.products.Add(new Product()
            {
                id = DataManager.products.Count,
                name = textBoxProductName.Text,
                price = (int)numericUpDownProductPrice.Value,
                isDeleted = false
            });

            DataManager.saveData();

            // TODO: send data to parent (that a new item has been added)
        }
    }
}
