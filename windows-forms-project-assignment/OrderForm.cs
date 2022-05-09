using System;
using System.Windows.Forms;

namespace windows_forms_project_assignment
{
    internal class OrderForm : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Order Screen";

        /** AdminForm class constructor */
        public OrderForm()
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE;
        }
    }
}
