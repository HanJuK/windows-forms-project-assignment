using System;
using System.Windows.Forms;

namespace windows_forms_project_assignment
{
    internal class MainForm : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Main Screen";

        /** variables for child forms */
        private Button buttonAdminForm;
        private Button buttonOrderForm;

        /** MainForm class constructor (initialize) */
        public MainForm()
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE;

            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.buttonAdminForm = new System.Windows.Forms.Button();
            this.buttonOrderForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAdminForm
            // 
            this.buttonAdminForm.Location = new System.Drawing.Point(12, 12);
            this.buttonAdminForm.Name = "buttonAdminForm";
            this.buttonAdminForm.Size = new System.Drawing.Size(75, 23);
            this.buttonAdminForm.TabIndex = 0;
            this.buttonAdminForm.Text = "Admin Form";
            this.buttonAdminForm.Click += new System.EventHandler(this.buttonAdminForm_Click);
            // 
            // buttonOrderForm
            // 
            this.buttonOrderForm.Location = new System.Drawing.Point(197, 12);
            this.buttonOrderForm.Name = "buttonOrderForm";
            this.buttonOrderForm.Size = new System.Drawing.Size(75, 23);
            this.buttonOrderForm.TabIndex = 1;
            this.buttonOrderForm.Text = "Order Form";
            this.buttonOrderForm.Click += new System.EventHandler(this.buttonOrderForm_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonAdminForm);
            this.Controls.Add(this.buttonOrderForm);
            this.Name = "MainForm";
            this.ResumeLayout(false);

        }

        /** define EventHandlers */
        private void buttonAdminForm_Click(object sender, EventArgs e)
        {
            /** open the Admin Screen */
            (new AdminForm()).ShowDialog();

            return;
        }
        private void buttonOrderForm_Click(object sender, EventArgs e)
        {
            /** open the Order Screen */
            (new OrderForm()).ShowDialog();

            return;
        }

        /** the Main method (code starts executing here) */
        static void Main(string[] args)
        {
            MainForm mainForm = new MainForm();

            Application.Run(mainForm);
        }
    }
}
