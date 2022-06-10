using System;
using System.Windows.Forms;

namespace windows_forms_project_assignment
{
    internal class CreateUpdateProductForm : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE_CREATE_MODE = "Self Ordering System - Admin Screen - Create Product";
        const string STRING_FORM_TITLE_UPDATE_MODE = "Self Ordering System - Admin Screen - Update Product";
        const string STRING_BUTTON_CREATE = "Create";
        const string STRING_BUTTON_UPDATE = "Update";
        const int INT_CREATE_MODE = 0;
        const int INT_UPDATE_MODE = 1;

        /** variable for setting the mode */
        private int mode;

        /** member variables (used when updating) */
        private int id;
        private string name;
        private int price;

        /** variables for child forms */
        private Label labelProductName;
        private TextBox textBoxProductName;
        private Label labelProductPrice;
        private NumericUpDown numericUpDownProductPrice;
        private Button buttonDeleteProduct;
        private Label labelTitle;
        private Button buttonCreateUpdateProduct;

        /** CreateUpdateProductForm class constructor (create mode) */
        public CreateUpdateProductForm()
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE_CREATE_MODE;

            /** set mode to create */
            this.mode = INT_CREATE_MODE;

            this.InitializeComponent();

            this.labelTitle.Text = "Create Product";

            this.buttonCreateUpdateProduct.Text = STRING_BUTTON_CREATE;

            this.buttonDeleteProduct.Enabled = false;
        }

        /** CreateUpdateProductForm class constructor (update mode) */
        public CreateUpdateProductForm(int id)
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE_UPDATE_MODE;

            /** set mode to update */
            this.mode = INT_UPDATE_MODE;

            /** set values of the product */
            this.id = id;
            this.name = DataManager.products[id].name;
            this.price = DataManager.products[id].price;

            this.InitializeComponent();

            this.labelTitle.Text = "Update Product";
            this.textBoxProductName.Text = name;
            this.numericUpDownProductPrice.Value = price;

            this.buttonCreateUpdateProduct.Text = STRING_BUTTON_UPDATE;
        }

        private void InitializeComponent()
        {
            this.labelProductName = new System.Windows.Forms.Label();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.labelProductPrice = new System.Windows.Forms.Label();
            this.buttonCreateUpdateProduct = new System.Windows.Forms.Button();
            this.numericUpDownProductPrice = new System.Windows.Forms.NumericUpDown();
            this.buttonDeleteProduct = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProductPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(27, 64);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(92, 15);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "Product Name: ";
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(125, 61);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(112, 23);
            this.textBoxProductName.TabIndex = 2;
            // 
            // labelProductPrice
            // 
            this.labelProductPrice.AutoSize = true;
            this.labelProductPrice.Location = new System.Drawing.Point(27, 114);
            this.labelProductPrice.Name = "labelProductPrice";
            this.labelProductPrice.Size = new System.Drawing.Size(86, 15);
            this.labelProductPrice.TabIndex = 1;
            this.labelProductPrice.Text = "Product Price: ";
            // 
            // buttonCreateUpdateProduct
            // 
            this.buttonCreateUpdateProduct.Location = new System.Drawing.Point(141, 157);
            this.buttonCreateUpdateProduct.Name = "buttonCreateUpdateProduct";
            this.buttonCreateUpdateProduct.Size = new System.Drawing.Size(96, 33);
            this.buttonCreateUpdateProduct.TabIndex = 4;
            this.buttonCreateUpdateProduct.Text = "Lorem ipsum";
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
            this.numericUpDownProductPrice.Location = new System.Drawing.Point(125, 112);
            this.numericUpDownProductPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownProductPrice.Name = "numericUpDownProductPrice";
            this.numericUpDownProductPrice.Size = new System.Drawing.Size(112, 23);
            this.numericUpDownProductPrice.TabIndex = 5;
            // 
            // buttonDeleteProduct
            // 
            this.buttonDeleteProduct.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDeleteProduct.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDeleteProduct.ForeColor = System.Drawing.Color.Red;
            this.buttonDeleteProduct.Location = new System.Drawing.Point(27, 157);
            this.buttonDeleteProduct.Name = "buttonDeleteProduct";
            this.buttonDeleteProduct.Size = new System.Drawing.Size(96, 34);
            this.buttonDeleteProduct.TabIndex = 6;
            this.buttonDeleteProduct.Text = "Delete";
            this.buttonDeleteProduct.UseVisualStyleBackColor = false;
            this.buttonDeleteProduct.Click += new System.EventHandler(this.buttonDeleteProduct_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new System.Drawing.Point(27, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(210, 30);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.Text = "Lorem ipsum";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreateUpdateProductForm
            // 
            this.ClientSize = new System.Drawing.Size(266, 214);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonDeleteProduct);
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
            /** handle exception where the name invalid */
            if (textBoxProductName.Text.Equals("") || textBoxProductName.Text.Contains("|")
                || textBoxProductName.Text.Contains(","))
            {
                MessageBox.Show("The product name can't be blank or contain the characters ['|' , ','].",
                    "Product name invalid!");
                
                return;
            }

            if (this.mode == INT_CREATE_MODE)
            {
                DataManager.products.Add(new Product()
                {
                    id = DataManager.products.Count,
                    name = textBoxProductName.Text,
                    price = (int)numericUpDownProductPrice.Value,
                    isDeleted = false
                });
            }
            else // this.mode == INT_UPDATE_MODE
            {
                DataManager.products[id].name = textBoxProductName.Text;
                DataManager.products[id].price = (int)numericUpDownProductPrice.Value;
            }

            DataManager.saveData();

            this.Close();

            return;
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            DataManager.products[id].isDeleted = true;

            DataManager.saveData();

            this.Close();

            return;
        }
    }
}
