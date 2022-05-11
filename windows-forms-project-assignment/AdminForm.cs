using System;
using System.Windows.Forms;

namespace windows_forms_project_assignment
{
    internal class AdminForm : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Admin Screen";

        /** variables for child forms */
        private Button buttonCreateProduct;

        /** AdminForm class constructor (initialize) */
        public AdminForm()
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE;

            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.buttonCreateProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreateProduct
            // 
            this.buttonCreateProduct.Location = new System.Drawing.Point(197, 12);
            this.buttonCreateProduct.Name = "buttonCreateProduct";
            this.buttonCreateProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateProduct.TabIndex = 0;
            this.buttonCreateProduct.Text = "Create Product";
            this.buttonCreateProduct.Click += new System.EventHandler(this.buttonCreateProduct_Click);
            // 
            // AdminForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonCreateProduct);
            this.Name = "AdminForm";
            this.ResumeLayout(false);

        }

        /** define EventHandlers */
        private void buttonCreateProduct_Click(object sender, EventArgs e)
        {
            /** open create update product screen */
            (new CreateUpdateProductForm()).ShowDialog();
        }
    }
}
