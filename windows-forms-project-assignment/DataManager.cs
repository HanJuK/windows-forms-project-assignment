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

        /** DataManager constructor. */
        static DataManager()
        {
            loadData();
        }

        /** Function for loading database to memory. */
        public static void loadData()
        {
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
                /** If no such file, create a new one. */
                saveData();
            }
        }

        /** Function for saving database to disk. */
        public static void saveData()
        {
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
        }
    }
}
