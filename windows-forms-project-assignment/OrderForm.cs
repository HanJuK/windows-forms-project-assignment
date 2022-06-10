using System.Collections.Generic;
using System.Windows.Forms;

namespace windows_forms_project_assignment
{
    internal class OrderForm : Form
    {
        /** define constants */
        const string STRING_FORM_TITLE = "Self Ordering System - Order Screen";
        const string STRING_LABEL_PRODUCT_NAME_PREFIX = "Product: ";
        const string STRING_LABEL_GRAND_TOTAL_PREFIX = "Grand Total: ";

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
            this.calculateAndUpdateGrandTotal();
        }

        private void InitializeComponent()
        {
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.buttonAddToCart = new System.Windows.Forms.Button();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.buttonRemoveFromCart = new System.Windows.Forms.Button();
            this.labelGrandTotal = new System.Windows.Forms.Label();
            this.buttonPay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.ReadOnly = true;
            this.dataGridViewProduct.RowTemplate.Height = 25;
            this.dataGridViewProduct.Size = new System.Drawing.Size(381, 254);
            this.dataGridViewProduct.TabIndex = 0;
            this.dataGridViewProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProduct_CellClick);
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(412, 31);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(56, 15);
            this.labelProductName.TabIndex = 1;
            this.labelProductName.Text = "Product: ";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(412, 69);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(60, 15);
            this.labelQuantity.TabIndex = 2;
            this.labelQuantity.Text = "Quantity: ";
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(482, 67);
            this.numericUpDownQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownQuantity.TabIndex = 3;
            this.numericUpDownQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonAddToCart
            // 
            this.buttonAddToCart.Location = new System.Drawing.Point(482, 111);
            this.buttonAddToCart.Name = "buttonAddToCart";
            this.buttonAddToCart.Size = new System.Drawing.Size(120, 23);
            this.buttonAddToCart.TabIndex = 4;
            this.buttonAddToCart.Text = "Add to Cart";
            this.buttonAddToCart.UseVisualStyleBackColor = true;
            this.buttonAddToCart.Click += new System.EventHandler(this.buttonAddToCart_Click);
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(12, 312);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.ReadOnly = true;
            this.dataGridViewCart.RowTemplate.Height = 25;
            this.dataGridViewCart.Size = new System.Drawing.Size(494, 215);
            this.dataGridViewCart.TabIndex = 5;
            this.dataGridViewCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCart_CellClick);
            // 
            // buttonRemoveFromCart
            // 
            this.buttonRemoveFromCart.Location = new System.Drawing.Point(512, 312);
            this.buttonRemoveFromCart.Name = "buttonRemoveFromCart";
            this.buttonRemoveFromCart.Size = new System.Drawing.Size(132, 23);
            this.buttonRemoveFromCart.TabIndex = 6;
            this.buttonRemoveFromCart.Text = "Remove from Cart";
            this.buttonRemoveFromCart.UseVisualStyleBackColor = true;
            this.buttonRemoveFromCart.Click += new System.EventHandler(this.buttonRemoveFromCart_Click);
            // 
            // labelGrandTotal
            // 
            this.labelGrandTotal.AutoSize = true;
            this.labelGrandTotal.Location = new System.Drawing.Point(512, 370);
            this.labelGrandTotal.Name = "labelGrandTotal";
            this.labelGrandTotal.Size = new System.Drawing.Size(76, 15);
            this.labelGrandTotal.TabIndex = 7;
            this.labelGrandTotal.Text = "Grand Total: ";
            // 
            // buttonPay
            // 
            this.buttonPay.Location = new System.Drawing.Point(569, 504);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(75, 23);
            this.buttonPay.TabIndex = 8;
            this.buttonPay.Text = "Pay";
            this.buttonPay.UseVisualStyleBackColor = true;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // OrderForm
            // 
            this.ClientSize = new System.Drawing.Size(656, 539);
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
                this.labelProductName.Visible = false;
                this.labelQuantity.Visible = false;
                this.numericUpDownQuantity.Visible = false;
                this.buttonAddToCart.Visible = false;
            }
            else
            {
                this.labelProductName.Visible = true;
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

        void calculateAndUpdateGrandTotal()
        {
            this.grandTotal = 0;

            foreach (CartItem cartItem in this.cart)
            {
                this.grandTotal += cartItem.totalPrice;
            }

            this.labelGrandTotal.Text = STRING_LABEL_GRAND_TOTAL_PREFIX + grandTotal.ToString();

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
            this.labelProductName.Text = STRING_LABEL_PRODUCT_NAME_PREFIX +
                (string)dataGridViewProduct.Rows[e.RowIndex].Cells[1].Value;
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

            return;
        }

        private void buttonPay_Click(object sender, System.EventArgs e)
        {
            /** open mileage form */
            Form mileageForm = new MileageForm(this.cart, this.grandTotal);
            mileageForm.FormClosed += new FormClosedEventHandler(mileageFormClosed);

            void mileageFormClosed(object sender, FormClosedEventArgs e)
            {
                DataManager.loadData(); // TODO: delete this
                // TODO: close Form
            }

            mileageForm.ShowDialog();

            return;
        }
    }
}
