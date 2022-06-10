using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System;

namespace windows_forms_project_assignment
{
    internal class DataManager
    {
        public static List<Product> products = new List<Product>();
        public static List<Order> orders = new List<Order>();

        /** load data when the DataManager is constructed */
        static DataManager()
        {
            loadData();
        }

        /** method for loading database to memory */
        public static void loadData()
        {
            /** load product data */
            try
            {
                string productsOutput = File.ReadAllText(@"./products.xml");
                XElement productsXElement = XElement.Parse(productsOutput);
                products = (from product in productsXElement.Descendants("product")
                         select new Product()
                         {
                             id = int.Parse(product.Element("id").Value),
                             name = product.Element("name").Value,
                             price = int.Parse(product.Element("price").Value),
                             isDeleted = (product.Element("isDeleted").Value).Equals("1") ? true : false
                         }).ToList<Product>();
            }
            catch (Exception e) when (e is FileLoadException || e is FileNotFoundException)
            {
                /** if no such file, create a new one */
                saveData();
            }

            /** load order data */
            try
            {
                string ordersOutput = File.ReadAllText(@"./orders.xml");
                XElement ordersXElement = XElement.Parse(ordersOutput);
                orders = (from order in ordersXElement.Descendants("order")
                            select new Order()
                            {
                                cart = new List<CartItem>(),
                                cartDataInString = order.Element("cartDataInString").Value,
                                grandTotal = int.Parse(order.Element("grandTotal").Value),
                                datetime = order.Element("datetime").Value,
                                phone = order.Element("phone").Value,
                                isMileageUsed = (order.Element("isMileageUsed").Value).Equals("1") ? true : false
                            }).ToList<Order>();

                /** convert cartDataInString into CartItem list */
                foreach (Order order in orders)
                {
                    string[] cartItems = order.cartDataInString.Split("|");

                    foreach (string cartItem in cartItems)
                    {
                        if (cartItem.Equals(""))
                        {
                            break;
                        }

                        string[] cartItemMembers = cartItem.Split(",");

                        order.cart.Add(new CartItem()
                        {
                            id = int.Parse(cartItemMembers[0]),
                            name = cartItemMembers[1],
                            price = int.Parse(cartItemMembers[2]),
                            quantity = int.Parse(cartItemMembers[3]),
                            totalPrice = int.Parse(cartItemMembers[4])
                        });
                    }
                }
            }
            catch (Exception e) when (e is FileLoadException || e is FileNotFoundException)
            {
                /** if no such file, create a new one */
                saveData();
            }

            return;
        }

        /** method for saving database to disk */
        public static void saveData()
        {
            /** save product data */
            string productsOutput = "";
            productsOutput += "<products>\n";
            foreach (var product in products)
            {
                productsOutput += "<product>\n";
                productsOutput += "  <id>" + product.id + "</id>\n";
                productsOutput += "  <name>" + product.name + "</name>\n";
                productsOutput += "  <price>" + product.price + "</price>\n";
                productsOutput += "  <isDeleted>" + (product.isDeleted ? 1 : 0) + "</isDeleted>\n";
                productsOutput += "</product>\n";
            }
            productsOutput += "</products>";

            File.WriteAllText(@"./products.xml", productsOutput);

            /** save order data */
            string ordersOutput = "";
            ordersOutput += "<orders>\n";
            foreach (var order in orders)
            {
                ordersOutput += "<order>\n";

                /** convert CartItem into cartDataInString */
                string cartDataInString = "";
                foreach (CartItem cartItem in order.cart)
                {
                    cartDataInString += cartItem.id.ToString() + ",";
                    cartDataInString += cartItem.name + ",";
                    cartDataInString += cartItem.price.ToString() + ",";
                    cartDataInString += cartItem.quantity.ToString() + ",";
                    cartDataInString += cartItem.totalPrice.ToString() + ",|";
                }

                ordersOutput += "  <cartDataInString>" + cartDataInString + "</cartDataInString>\n";
                ordersOutput += "  <grandTotal>" + order.grandTotal + "</grandTotal>\n";
                ordersOutput += "  <datetime>" + order.datetime + "</datetime>\n";
                ordersOutput += "  <phone>" + order.phone + "</phone>\n";
                ordersOutput += "  <isMileageUsed>" + (order.isMileageUsed ? 1 : 0) + "</isMileageUsed>\n";
                ordersOutput += "</order>\n";
            }
            ordersOutput += "</orders>";

            File.WriteAllText(@"./orders.xml", ordersOutput);

            return;
        }
    }
}
