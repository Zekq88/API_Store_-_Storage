namespace Lab_4___Winform
{
    internal class Book : Product
    {

        public string Name { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }
        public int Stock { get; set; }
        public string Format { set; get; }
        public string Language { set; get; }
        public string Genre { set; get; }
        public string Auther { set; get; }


        public Book() { }

        public Book(int id, string name, int price, int stock, string genre, string format, string language) :
            base(id, name, price, stock)
        {
            if (string.IsNullOrEmpty(format) && string.IsNullOrEmpty(language))
            {
                Id = id;
                Stock = stock;
                Name = name;
                Price = price;

                Genre = genre;
                Format = " x ";
                Language = " x ";

            }
            else if (string.IsNullOrEmpty(language))
            {
                Id = id;
                Stock = stock;
                Name = name;
                Price = price;

                Genre = genre;
                Language = " x ";
                Format = format;

            }
            else if (string.IsNullOrEmpty(format))
            {
                Id = id;
                Stock = stock;
                Name = name;
                Price = price;

                Genre = genre;
                Format = " x ";
                Language = language;

            }
            else
            {
                Id = id;
                Stock = stock;
                Name = name;
                Price = price;

                Genre = genre;
                Format = format;
                Language = language;
            }

        }
        public Book(int id, string name, int price, int stock, string auther, string genre, string format, string language) :
            base(id, name, price, stock)
        {
            if (string.IsNullOrEmpty(format) && string.IsNullOrEmpty(language))
            {
                Id = id;
                Stock = stock;
                Name = name;
                Price = price;
                Auther = auther;
                Genre = genre;
                Format = "x";
                Language = "x";

            }
            else if (string.IsNullOrEmpty(language))
            {
                Id = id;
                Stock = stock;
                Name = name;
                Price = price;
                Auther = auther;
                Genre = genre;
                Language = "x";
                Format = format;

            }
            else if (string.IsNullOrEmpty(format))
            {
                Id = id;
                Stock = stock;
                Name = name;
                Price = price;
                Auther = auther;
                Genre = genre;
                Format = "x";
                Language = language;

            }
            else
            {
                Id = id;
                Stock = stock;
                Name = name;
                Price = price;
                Auther = auther;
                Genre = genre;
                Format = format;
                Language = language;
            }

        }

        public override string ToString()
        {
            return base.ToString() + $"{Genre,-20},{Format,-20},{Language,-15},";
        }

    }
}
