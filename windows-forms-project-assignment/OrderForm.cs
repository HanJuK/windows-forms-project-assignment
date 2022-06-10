using System.Collections.Generic;
using System.Windows.Forms;

namespace windows_forms_project_assignment
{
    internal class OrderForm : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Order Screen";
        const string STRING_PRODUCT_NAME_DEFAULT = "Select a Product";

        /** member variables */
        private int? selectedProductId = null;
        private List<CartItem> cart = new List<CartItem>();
        private int? selectedCartItemIndex = null;
        private int grandTotal;

        /** variables for child forms */
        private DataGridView dataGridViewProduct;
        private Label labelProductName;
        private Label labelQuantity;
        private NumericUpDown numericUpDownQuantity;
        private Button buttonAddToCart;
        private Button buttonRemoveFromCart;
        private Label labelGrandTotal;
        private Button buttonPay;
        private Label labelProductListTitle;
        private Label labelCartTitle;
        private Label labelGrandTotalTitle;
        private DataGridView dataGridViewCart;

        /** OrderForm class constructor (initialize) */
        public OrderForm()
        {
            /** set the title of the Form */
            this.Text = STRING_FORM_TITLE;

            this.InitializeComponent();

            this.refreshProductList();
            this.refreshCartList();

            this.hideShowProductDetailForms(true);
            this.hideShowCartDetailForms(true);
            this.hideShowPayButton(true);
            this.calculateAndUpdateGrandTotal();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.buttonAddToCart = new System.Windows.Forms.Button();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.buttonRemoveFromCart = new System.Windows.Forms.Button();
            this.labelGrandTotal = new System.Windows.Forms.Label();
            this.buttonPay = new System.Windows.Forms.Button();
            this.labelProductListTitle = new System.Windows.Forms.Label();
            this.labelCartTitle = new System.Windows.Forms.Label();
            this.labelGrandTotalTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProduct
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(12, 49);
            this.dataGridViewProduct.MultiSelect = false;
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.ReadOnly = true;
            this.dataGridViewProduct.RowTemplate.Height = 25;
            this.dataGridViewProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProduct.Size = new System.Drawing.Size(381, 254);
            this.dataGridViewProduct.TabIndex = 0;
            this.dataGridViewProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProduct_CellClick);
            // 
            // labelProductName
            // 
            this.labelProductName.AutoEllipsis = true;
            this.labelProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelProductName.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelProductName.Location = new System.Drawing.Point(399, 49);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(179, 123);
            this.labelProductName.TabIndex = 1;
            this.labelProductName.Text = "Select a Product";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(421, 193);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(60, 15);
            this.labelQuantity.TabIndex = 2;
            this.labelQuantity.Text = "Quantity: ";
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(421, 221);
            this.numericUpDownQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(143, 23);
            this.numericUpDownQuantity.TabIndex = 3;
            this.numericUpDownQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonAddToCart
            // 
            this.buttonAddToCart.Location = new System.Drawing.Point(421, 262);
            this.buttonAddToCart.Name = "buttonAddToCart";
            this.buttonAddToCart.Size = new System.Drawing.Size(143, 23);
            this.buttonAddToCart.TabIndex = 4;
            this.buttonAddToCart.Text = "Add to Cart";
            this.buttonAddToCart.UseVisualStyleBackColor = true;
            this.buttonAddToCart.Click += new System.EventHandler(this.buttonAddToCart_Click);
            // 
            // dataGridViewCart
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(12, 360);
            this.dataGridViewCart.MultiSelect = false;
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.ReadOnly = true;
            this.dataGridViewCart.RowTemplate.Height = 25;
            this.dataGridViewCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCart.Size = new System.Drawing.Size(566, 215);
            this.dataGridViewCart.TabIndex = 5;
            this.dataGridViewCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCart_CellClick);
            // 
            // buttonRemoveFromCart
            // 
            this.buttonRemoveFromCart.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonRemoveFromCart.ForeColor = System.Drawing.Color.Red;
            this.buttonRemoveFromCart.Location = new System.Drawing.Point(447, 331);
            this.buttonRemoveFromCart.Name = "buttonRemoveFromCart";
            this.buttonRemoveFromCart.Size = new System.Drawing.Size(131, 23);
            this.buttonRemoveFromCart.TabIndex = 6;
            this.buttonRemoveFromCart.Text = "Remove from Cart";
            this.buttonRemoveFromCart.UseVisualStyleBackColor = true;
            this.buttonRemoveFromCart.Click += new System.EventHandler(this.buttonRemoveFromCart_Click);
            // 
            // labelGrandTotal
            // 
            this.labelGrandTotal.AutoSize = true;
            this.labelGrandTotal.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGrandTotal.Location = new System.Drawing.Point(148, 578);
            this.labelGrandTotal.Name = "labelGrandTotal";
            this.labelGrandTotal.Size = new System.Drawing.Size(136, 30);
            this.labelGrandTotal.TabIndex = 7;
            this.labelGrandTotal.Text = "Lorem ipsum";
            // 
            // buttonPay
            // 
            this.buttonPay.BackColor = System.Drawing.Color.LightGreen;
            this.buttonPay.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonPay.Location = new System.Drawing.Point(526, 581);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(52, 27);
            this.buttonPay.TabIndex = 8;
            this.buttonPay.Text = "Pay";
            this.buttonPay.UseVisualStyleBackColor = false;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // labelProductListTitle
            // 
            this.labelProductListTitle.AutoSize = true;
            this.labelProductListTitle.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelProductListTitle.Location = new System.Drawing.Point(12, 9);
            this.labelProductListTitle.Name = "labelProductListTitle";
            this.labelProductListTitle.Size = new System.Drawing.Size(101, 30);
            this.labelProductListTitle.TabIndex = 9;
            this.labelProductListTitle.Text = "Products:";
            // 
            // labelCartTitle
            // 
            this.labelCartTitle.AutoSize = true;
            this.labelCartTitle.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCartTitle.Location = new System.Drawing.Point(12, 320);
            this.labelCartTitle.Name = "labelCartTitle";
            this.labelCartTitle.Size = new System.Drawing.Size(56, 30);
            this.labelCartTitle.TabIndex = 10;
            this.labelCartTitle.Text = "Cart:";
            // 
            // labelGrandTotalTitle
            // 
            this.labelGrandTotalTitle.AutoSize = true;
            this.labelGrandTotalTitle.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGrandTotalTitle.Location = new System.Drawing.Point(12, 578);
            this.labelGrandTotalTitle.Name = "labelGrandTotalTitle";
            this.labelGrandTotalTitle.Size = new System.Drawing.Size(130, 30);
            this.labelGrandTotalTitle.TabIndex = 11;
            this.labelGrandTotalTitle.Text = "Grand Total:";
            // 
            // OrderForm
            // 
            this.ClientSize = new System.Drawing.Size(590, 617);
            this.Controls.Add(this.labelGrandTotalTitle);
            this.Controls.Add(this.labelCartTitle);
            this.Controls.Add(this.labelProductListTitle);
            this.Controls.Add(this.buttonPay);
            this.Controls.Add(this.labelGrandTotal);
            this.Controls.Add(this.buttonRemoveFromCart);
            this.Controls.Add(this.dataGridViewCart);
            this.Controls.Add(this.buttonAddToCart);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.dataGridViewProduct);
            this.Name = "OrderForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        void refreshCartList()
        {
            List<CartItem> cartCopy = new List<CartItem>();

            foreach (CartItem cartItem in this.cart)
            {
                cartCopy.Add(cartItem);
            }

            dataGridViewCart.DataSource = null;
            dataGridViewCart.DataSource = cartCopy;

            return;
        }

        void hideShowProductDetailForms(bool isHide)
        {
            if (isHide)
            {
                this.labelProductName.Text = STRING_PRODUCT_NAME_DEFAULT;
                this.labelQuantity.Visible = false;
                this.numericUpDownQuantity.Visible = false;
                this.buttonAddToCart.Visible = false;
            }
            else
            {
                this.labelQuantity.Visible = true;
                this.numericUpDownQuantity.Visible = true;
                this.buttonAddToCart.Visible = true;
            }

            return;
        }

        void hideShowCartDetailForms(bool isHide)
        {
            this.buttonRemoveFromCart.Visible = !isHide;

            return;
        }

        void hideShowPayButton(bool isHide)
        {
            this.buttonPay.Visible = !isHide;

            return;
        }

        void calculateAndUpdateGrandTotal()
        {
            this.grandTotal = 0;

            foreach (CartItem cartItem in this.cart)
            {
                this.grandTotal += cartItem.totalPrice;
            }

            this.labelGrandTotal.Text = grandTotal.ToString();

            return;
        }

        /** define EventHandlers */
        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /** handle exception for when clicked topmost row */
            if (e.RowIndex == -1)
            {
                return;
            }

            /** show related forms */
            this.hideShowProductDetailForms(false);

            /** set values for forms */
            this.selectedProductId = (int)dataGridViewProduct.Rows[e.RowIndex].Cells[0].Value;
            this.labelProductName.Text = (string)dataGridViewProduct.Rows[e.RowIndex].Cells[1].Value;
            this.numericUpDownQuantity.Value = 1;

            /** enable quantity numericUpDown */
            this.numericUpDownQuantity.Enabled = true;

            return;
        }

        private void buttonAddToCart_Click(object sender, System.EventArgs e)
        {
            bool isProductAlreadyInCart = false;

            /** check if the product already exists in cart */
            foreach (CartItem cartItem in this.cart)
            {
                if (cartItem.id == selectedProductId)
                {
                    cartItem.quantity += (int)this.numericUpDownQuantity.Value;
                    cartItem.totalPrice = cartItem.price * cartItem.quantity;

                    isProductAlreadyInCart = true;

                    break;
                }
            }

            if (!isProductAlreadyInCart)
            {
                this.cart.Add(new CartItem()
                {
                    id = (int)this.selectedProductId,
                    name = DataManager.products[(int)this.selectedProductId].name,
                    price = DataManager.products[(int)this.selectedProductId].price,
                    quantity = (int)this.numericUpDownQuantity.Value,
                    totalPrice = DataManager.products[(int)this.selectedProductId].price
                                * (int)this.numericUpDownQuantity.Value
                });
            }

            this.selectedProductId = null;
            this.hideShowProductDetailForms(true);
            this.hideShowPayButton(false);

            this.refreshCartList();
            this.calculateAndUpdateGrandTotal();

            return;
        }

        private void dataGridViewCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /** handle exception for when clicked topmost row */
            if (e.RowIndex == -1)
            {
                return;
            }

            /** save selected index */
            this.selectedCartItemIndex = e.RowIndex;

            this.hideShowCartDetailForms(false);

            return;
        }

        private void buttonRemoveFromCart_Click(object sender, System.EventArgs e)
        {
            /** remove selected item from cart */
            this.cart.RemoveAt((int)selectedCartItemIndex);

            this.selectedCartItemIndex = null;
            this.hideShowCartDetailForms(true);

            this.refreshCartList();
            this.calculateAndUpdateGrandTotal();

            /** if no item left -> hide pay buutton */
            if (this.cart.Count == 0)
            {
                this.hideShowPayButton(true);
            }

            return;
        }

        private void buttonPay_Click(object sender, System.EventArgs e)
        {
            /** open mileage form */
            Form mileageForm = new MileageForm(this.cart, this.grandTotal);
            mileageForm.FormClosed += new FormClosedEventHandler(mileageFormClosed);

            void mileageFormClosed(object sender, FormClosedEventArgs e)
            {
                this.Close();
            }

            mileageForm.ShowDialog();

            return;
        }
    }
}
