using System.Collections.Generic;

namespace Lab_4___Winform
{
    internal class Game : Product
    {

        public string Platform { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }
        public int Stock { get; set; }

        public Game() {}
       
        public Game(int id, string name, int price, int stock, string platform) :
            base(id, name, price, stock)
        {
            Id = id;
            Stock = stock;
            Name = name;
            Price = price;
            Platform = platform;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Platform,-20},";
        }
    }
}
