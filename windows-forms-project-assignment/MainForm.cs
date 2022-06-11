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
        private Label labelTitle;
        private Label labelStudentInfo;
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelStudentInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAdminForm
            // 
            this.buttonAdminForm.Location = new System.Drawing.Point(32, 134);
            this.buttonAdminForm.Name = "buttonAdminForm";
            this.buttonAdminForm.Size = new System.Drawing.Size(90, 45);
            this.buttonAdminForm.TabIndex = 0;
            this.buttonAdminForm.Text = "Admin Mode";
            this.buttonAdminForm.Click += new System.EventHandler(this.buttonAdminForm_Click);
            // 
            // buttonOrderForm
            // 
            this.buttonOrderForm.Location = new System.Drawing.Point(162, 134);
            this.buttonOrderForm.Name = "buttonOrderForm";
            this.buttonOrderForm.Size = new System.Drawing.Size(90, 45);
            this.buttonOrderForm.TabIndex = 1;
            this.buttonOrderForm.Text = "Order Mode";
            this.buttonOrderForm.Click += new System.EventHandler(this.buttonOrderForm_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Noto Sans KR Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new System.Drawing.Point(12, 49);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(260, 47);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Self Ordering System";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStudentInfo
            // 
            this.labelStudentInfo.AutoSize = true;
            this.labelStudentInfo.Location = new System.Drawing.Point(169, 9);
            this.labelStudentInfo.Name = "labelStudentInfo";
            this.labelStudentInfo.Size = new System.Drawing.Size(103, 15);
            this.labelStudentInfo.TabIndex = 3;
            this.labelStudentInfo.Text = "18011567 김한주";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 213);
            this.Controls.Add(this.labelStudentInfo);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonAdminForm);
            this.Controls.Add(this.buttonOrderForm);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

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
            Application.Run(new MainForm());
        }
    }
}
