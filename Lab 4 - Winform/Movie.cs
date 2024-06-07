namespace Lab_4___Winform
{
    internal class Movie : Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }
        public int Stock { get; set; }
        public string Format { get; set; }
        public string PlayTime { get; set; }


        public Movie() { }
        public Movie(int id, string name, int price, int stock, string format, string playTime) :
            base(id, name, price, stock)
        {
            if (string.IsNullOrEmpty(playTime) && string.IsNullOrEmpty(format))
            {
                Id = id;
                Stock = stock;
                Name = name;
                Price = price;
                Format = " x ";
                PlayTime = " x ";
            }
            else if (string.IsNullOrEmpty(playTime))
            {
                Id = id;
                Stock = stock;
                Name = name;
                Price = price;
                PlayTime = " x ";
                Format = format;

            }
            else if (string.IsNullOrEmpty(format))
            {
                Id = id;
                Stock = stock;
                Name = name;
                Price = price;
                Format = " x ";
                PlayTime = playTime;

            }
            else
            {
                Id = id;
                Stock = stock;
                Name = name;
                Price = price;
                Format = format;
                PlayTime = playTime;
            }
        }


        public override string ToString()
        {
            return base.ToString() + $"{Format,-20},{PlayTime,-20},";
        }
    }
}
