using System.Collections.Generic;

namespace windows_forms_project_assignment
{
    internal class Order
    {
        public List<CartItem> cart { get; set; }
        public int grandTotal { get; set; }
        public string datetime { get; set; }
        public string phone { get; set; }
        public bool isMileageUsed { get; set; }
    }
}
