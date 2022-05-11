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
        private TextBox textBoxProductPrice;
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
            this.textBoxProductPrice = new System.Windows.Forms.TextBox();
            this.buttonCreateUpdateProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(12, 9);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(92, 15);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "Product Name: ";
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(12, 27);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(100, 23);
            this.textBoxProductName.TabIndex = 2;
            // 
            // labelProductPrice
            // 
            this.labelProductPrice.AutoSize = true;
            this.labelProductPrice.Location = new System.Drawing.Point(233, 9);
            this.labelProductPrice.Name = "labelProductPrice";
            this.labelProductPrice.Size = new System.Drawing.Size(86, 15);
            this.labelProductPrice.TabIndex = 1;
            this.labelProductPrice.Text = "Product Price: ";
            // 
            // textBoxProductPrice
            // 
            this.textBoxProductPrice.Location = new System.Drawing.Point(172, 27);
            this.textBoxProductPrice.Name = "textBoxProductPrice";
            this.textBoxProductPrice.Size = new System.Drawing.Size(100, 23);
            this.textBoxProductPrice.TabIndex = 3;
            // 
            // buttonCreateUpdateProduct
            // 
            this.buttonCreateUpdateProduct.Location = new System.Drawing.Point(197, 56);
            this.buttonCreateUpdateProduct.Name = "buttonCreateUpdateProduct";
            this.buttonCreateUpdateProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateUpdateProduct.TabIndex = 4;
            this.buttonCreateUpdateProduct.Text = "Create/Update Product";
            this.buttonCreateUpdateProduct.UseVisualStyleBackColor = true;
            // 
            // CreateUpdateProductForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonCreateUpdateProduct);
            this.Controls.Add(this.textBoxProductPrice);
            this.Controls.Add(this.textBoxProductName);
            this.Controls.Add(this.labelProductPrice);
            this.Controls.Add(this.labelProductName);
            this.Name = "CreateUpdateProductForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
