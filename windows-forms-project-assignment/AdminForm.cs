using System;
using System.Windows.Forms;

namespace windows_forms_project_assignment
{
    internal class AdminForm : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Admin Screen";

        /** AdminForm class constructor */
        public AdminForm()
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE;
        }
    }
}
