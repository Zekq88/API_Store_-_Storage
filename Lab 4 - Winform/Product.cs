using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab_4___Winform
{
    internal class Product
    {
        private List<object> productsObjList;

 
        public string Name { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }
        public int Stock { get; set; }
        private int id;
        public List<int> idList;
        
        public Product()
        {
            idList = new List<int>();
            productsObjList = new List<object>();
            
            
        }
        public Product(int id ,string name, int price, int stock)
        {
            if (idList == null)
            {
                idList = new List<int>();
            }

                idList.Add(id);
                if (stock < 0)
                {
                    Stock = 1;
                }
                else { Stock = stock; }

                if (!string.IsNullOrEmpty(name) && price > 0)
                {

                    this.Id = id;
                    this.Name = name;
                    this.Price = price;

                }
                else { MessageBox.Show("Name och pris är obligatoriskt", "Error"); }

        }



        public void AddProduct(object obj)
        {

            productsObjList.Add(obj);
        }


        public List<object> GetProducts()
        {

            return productsObjList;
        }

        public override string ToString()
        {
            return $"{Id,-5},{Name,-40},{Price,-20},{Stock, -5},";
        }
    }
}
