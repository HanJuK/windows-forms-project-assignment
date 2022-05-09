using System;
using System.Windows.Forms;

namespace windows_forms_project_assignment
{
    internal class MainForm : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Main Screen";
        const string STRING_ADMIN_FORM = "Admin Form";
        const string STRING_ORDER_FORM = "Order Form";

        /** variables for child forms */
        private Button buttonAdminForm;
        private Button buttonOrderForm;

        /** MainForm class constructor */
        public MainForm()
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE;

            this.InitializeChildForms();
        }

        /** the Main method (code starts executing here) */
        static void Main(string[] args)
        {
            MainForm mainForm = new MainForm();

            Application.Run(mainForm);
        }

        /** initialize child forms (under MainForm) */
        private void InitializeChildForms()
        {
            /** create child forms */
            this.buttonAdminForm = new Button();
            this.buttonOrderForm = new Button();

            /** define admin form button */
            this.buttonAdminForm.Text = STRING_ADMIN_FORM;
            this.buttonAdminForm.Location = new System.Drawing.Point(12, 12);
            this.buttonAdminForm.Click += new EventHandler((object sender, EventArgs e) =>
            {
                (new AdminForm()).ShowDialog();
            });

            /** define order form button */
            this.buttonOrderForm.Text = STRING_ORDER_FORM;
            this.buttonOrderForm.Location = new System.Drawing.Point(197, 12);
            this.buttonOrderForm.Click += new EventHandler((object sender, EventArgs e) =>
            {
                (new OrderForm()).ShowDialog();
            });

            /** add child forms to MainForm */
            this.Controls.Add(buttonAdminForm);
            this.Controls.Add(buttonOrderForm);
        }
    }
}
