using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace Lab_4___Winform
{
    public partial class Lager : Form
    {
        private MainForm mainForm;
        private Product product;
        private List<object> productList;

        private List<int> lagerIdList;
        private Logger logger;
        List<string> APIlist = new List<string>();
        List<string> gameList = new List<string>();
        List<string> bookList = new List<string>();
        List<string> movieList = new List<string>();

        private int productId = 0;
        public int ProductId { get; set; }
        public Lager(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            product = new Product();
            logger = new Logger();
            lagerIdList = new List<int>();
            readXML(logger.fileXMLPath);


            updateGUI();


        }

        private void getBackBtn_Click(object sender, EventArgs e)
        {
            logger.Write(productList);
            mainForm.Show();
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct(this, lagerIdList);
            addProduct.Show();
        }

        private void changeStockXML(string obj, int index, int i)
        {
            XmlDocument xDoc = null;
            try
            {
                xDoc = new XmlDocument();
                xDoc.Load(logger.fileXMLPath);

                XmlNodeList nodes = null;

                if (obj.Equals("game"))
                {
                    nodes = xDoc.GetElementsByTagName("game");
                }
                else if (obj.Equals("movie"))
                {
                    nodes = xDoc.GetElementsByTagName("movie");
                }
                else if (obj.Equals("book"))
                {
                    nodes = xDoc.GetElementsByTagName("book");
                }

                if (nodes != null)
                {
                    bool found = false;
                    foreach (XmlNode node in nodes)
                    {


                        XmlNode idNode = node.SelectSingleNode("id");


                        if (idNode != null && idNode.FirstChild.Value.Replace(">", string.Empty).Trim().Equals(index.ToString()))
                        {
                            XmlNode stockNode = node.SelectSingleNode("stock");
                            

                            if (stockNode != null)
                            {
                                
                                stockNode.InnerText = i.ToString();

                                found = true;
                                break;
                            }

                        }
                    }

                    if (found)
                    {
                        xDoc.Save(logger.fileXMLPath);
                        MessageBox.Show($"{obj} objekt med {index} är ändrad");
                    }
                    else
                    {
                        MessageBox.Show($"{obj} objekt med id: {index} hittades inte");
                    }
                }

            }
            catch (XmlException ex)
            {
                MessageBox.Show(ex.ToString(), "Error : " + ex.Message);
            }
            catch (NullReferenceException e) { MessageBox.Show(e.Message, "det är NULL"); }
        }

        private void removeFromXML(string obj, int index)
        {
            XmlDocument xDoc = null;
            try
            {
                xDoc = new XmlDocument();
                xDoc.Load(logger.fileXMLPath);

                XmlNodeList nodes = null;

                if (obj.Equals("game"))
                {
                    nodes = xDoc.GetElementsByTagName("game");
                }
                else if (obj.Equals("movie"))
                {
                    nodes = xDoc.GetElementsByTagName("movie");
                }
                else if (obj.Equals("book"))
                {
                    nodes = xDoc.GetElementsByTagName("book");
                }

                if (nodes != null)
                {
                    bool found = false;
                    foreach (XmlNode node in nodes)
                    {
                        
                        
                        XmlNode idNode = node.SelectSingleNode("id");
                       

                        if (idNode != null && idNode.FirstChild.Value.Replace(">", string.Empty).Trim().Equals(index.ToString()))
                        {
                            
                            node.ParentNode.RemoveChild(node);
                            found = true;
                            break;
                        }
                    }

                    if (found)
                    {
                        xDoc.Save(logger.fileXMLPath);
                        MessageBox.Show($"{obj} objekt med {index} är borttagen");
                    }
                    else
                    {
                        MessageBox.Show($"{obj} objekt med id: {index} hittades inte");
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error : " + ex.Message);
            }
        }

        private void updateXML(object obj)
        {
            XmlDocument xDoc = null;
            string slut = ">";
            try
            {
                xDoc = new XmlDocument();
                xDoc.Load(logger.fileXMLPath);

                XmlNode productsNode = xDoc.SelectSingleNode("//response/products");
                if (productsNode != null)
                {
                    XmlElement productElement = null;

                    if (obj is Game)
                    {
                        Game game = (Game)obj;

                        productElement = xDoc.CreateElement("game");
                        productElement.InnerText = slut;
                    }
                    else if (obj is Movie)
                    {
                        Movie movie = (Movie)obj;

                        productElement = xDoc.CreateElement("movie");
                        productElement.InnerText = slut;
                    }
                    else if (obj is Book)
                    {
                        Book book = (Book)obj;

                        productElement = xDoc.CreateElement("book");
                        productElement.InnerText = slut;
                    }

                    if (productElement != null)
                    {
                        Product product = (Product) obj;
                        XmlElement idElement = xDoc.CreateElement("id");
                        idElement.InnerText = slut + product.Id.ToString();
                        lagerIdList.Add(product.Id);
                        productElement.AppendChild(idElement);

                        XmlElement nameElement = xDoc.CreateElement("name");
                        nameElement.InnerText = slut + product.Name; 
                        productElement.AppendChild(nameElement);

                        XmlElement priceElement = xDoc.CreateElement("price");
                        priceElement.InnerText = slut + product.Price.ToString(); 
                        productElement.AppendChild(priceElement);

                        XmlElement stockElement = xDoc.CreateElement("stock");
                        stockElement.InnerText = slut + product.Stock.ToString(); 
                        productElement.AppendChild(stockElement);

                        if (obj is Game)
                        {
                            Game game = (Game)obj;

                            XmlElement platformElement = xDoc.CreateElement("platform");
                            platformElement.InnerText = slut + game.Platform; 
                            productElement.AppendChild(platformElement);
                        }
                        else if (obj is Movie)
                        {
                            Movie movie = (Movie)obj;

                            XmlElement formatElement = xDoc.CreateElement("format");
                            formatElement.InnerText = slut + movie.Format; 
                            productElement.AppendChild(formatElement);

                            XmlElement playtimeElement = xDoc.CreateElement("playtime");
                            playtimeElement.InnerText = slut + movie.PlayTime.ToString(); 
                            productElement.AppendChild(playtimeElement);
                        }
                        else if (obj is Book)
                        {
                            Book book = (Book)obj;

                            XmlElement genreElement = xDoc.CreateElement("genre");
                            genreElement.InnerText = slut + book.Genre; 
                            productElement.AppendChild(genreElement);

                            XmlElement formatElement = xDoc.CreateElement("format");
                            formatElement.InnerText = slut + book.Format; 
                            productElement.AppendChild(formatElement);

                            XmlElement languageElement = xDoc.CreateElement("language");
                            languageElement.InnerText = slut + book.Language; 
                            productElement.AppendChild(languageElement);
                        }

                        productsNode.AppendChild(productElement);

                        xDoc.Save(logger.fileXMLPath);
                    }
                }
                else
                {
                    MessageBox.Show("Products node hittades inte.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        
        private void readXML(string filePath)
        {
            XmlDocument xDoc = null;
            try { 
            xDoc = new XmlDocument();
                if (!string.IsNullOrEmpty(filePath))
                {
                    xDoc.Load(filePath);
                }
                 else { xDoc.LoadXml(logger.fileXMLPath); }
            

            XmlNodeList gameNode = xDoc.GetElementsByTagName("game");
            XmlNodeList movieNode = xDoc.GetElementsByTagName("movie");
            XmlNodeList bookNode = xDoc.GetElementsByTagName("book");

           // restartList.Add($"{' ',-5}, {' ',-5}, {"Böcker",80}");
           // restartList.Add($"{"Id",-5}, {"Namn*",-40}, {"Pris*",-20}, {"Antal",-5}, {"Genre",-20}, {"Format",-20}, {"Språk",-15},");
            foreach (XmlNode node in bookNode)
            {
                   // productId++;
                //     Console.WriteLine(($"{node.InnerText},").Replace(">", string.Empty));

                foreach (XmlNode childNode in node.ChildNodes)
                {
                    bookList.Add($"{childNode.InnerText.Trim().Replace(">", string.Empty)}");
                }

                if (bookList.Count() == 8)
                {
                    Book b1 = new Book(int.Parse(bookList[1]), bookList[2], int.Parse(bookList[3]), int.Parse(bookList[4]), bookList[5], bookList[6], bookList[7]);
                    product.AddProduct(b1);
                        //   productList.Add(b1);
                        //      restartList.Add(b1.ToString());
                        //lagerIdList.Add(int.Parse(bookList[1]));
                        bookList.Clear();
                }
                else if (bookList.Count() == 7)
                {
                    Book b1 = new Book(int.Parse(bookList[1]), bookList[2], int.Parse(bookList[3]), int.Parse(bookList[4]), bookList[5], bookList[6], null);
                    product.AddProduct(b1);
                        bookList.Clear();
                }
                else if (bookList.Count() == 6)
                {
                    Book b1 = new Book(int.Parse(bookList[1]), bookList[2], int.Parse(bookList[3]), int.Parse(bookList[4]), bookList[5], null, null);
                    product.AddProduct(b1);
                        bookList.Clear();
                }
            }

            foreach (XmlNode node in gameNode)
            {

                    foreach (XmlNode childNode in node.ChildNodes)
                {
                    gameList.Add($"{childNode.InnerText.Trim().Replace(">", string.Empty)}");
                }

                Game g1 = new Game(int.Parse(gameList[1]), gameList[2], int.Parse(gameList[3]), int.Parse(gameList[4]), gameList[5]);
                product.AddProduct(g1);

                    lagerIdList.Add(int.Parse(gameList[1]));
                    gameList.Clear();
            }

            foreach (XmlNode node in movieNode)
            {

                    foreach (XmlNode childNode in node.ChildNodes)
                {
                    movieList.Add($"{childNode.InnerText.Trim().Replace(">", string.Empty)}");
                }

                if (movieList.Count() == 7)
                {
                    Movie m1 = new Movie(int.Parse(movieList[1]), movieList[2], int.Parse(movieList[3]), int.Parse(movieList[4]), movieList[5], movieList[6]);
                    product.AddProduct(m1);

                        lagerIdList.Add(int.Parse(movieList[1]));
                        movieList.Clear();
                }
                else if (movieList.Count() == 6)
                {
                    Movie m1 = new Movie(int.Parse(movieList[1]), movieList[2], int.Parse(movieList[3]), int.Parse(movieList[4]), null, null);
                    product.AddProduct(m1);

                        lagerIdList.Add(int.Parse(movieList[1]));
                        movieList.Clear();
                }
            }


        }
                catch (HttpRequestException evo)
                {

                    MessageBox.Show("Error baby: " + evo.Message);

                }
                catch (ArgumentException ex)
                {

                    MessageBox.Show("Error baby: " + ex.Message);
                }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void updateGUI()
        {
            ProductId = 0;
            try
            {
                productList = product.GetProducts();
               
                movieListView.Items.Clear();
                gameListView.Items.Clear();
                bookListView.Items.Clear();

                gameUpdate();
                bookUpdate();
                movieUpdate();
                movieListView.Refresh();
                gameListView.Refresh();
                bookListView.Refresh();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        

        

        private void removeBtn_Click(object sender, EventArgs e)
        {
            

            if(bookListView.SelectedItems.Count > 0 && bookListView.SelectedItems[0].Focused)
            {
                ListViewItem bookItem = bookListView.SelectedItems[0];
                if (int.Parse(bookItem.SubItems[3].Text) > 0)
                {
                    
                    DialogResult result = MessageBox.Show("Vill du verkligen ta bort varan?", "Varan är inte slut.", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        
                        removeFromXML("book", int.Parse(bookListView.SelectedItems[0].Text));
                        bookListView.Items.Remove(bookListView.SelectedItems[0]);
                        
                        
                    }
                    else
                    {
                        return;
                    }
                    
                }
                else
                {
                    
                    removeFromXML("book", int.Parse(bookListView.SelectedItems[0].Text));
                    bookListView.Items.Remove(bookListView.SelectedItems[0]);
                    
                }

            } 
            else if(movieListView.SelectedItems.Count > 0 && movieListView.SelectedItems[0].Focused)
            {
                ListViewItem movieItem = movieListView.SelectedItems[0];
                if (int.Parse(movieItem.SubItems[3].Text) > 0)
                {
                    DialogResult result = MessageBox.Show("Vill du verkligen ta bort varan?", "Varan är inte slut.", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        
                        removeFromXML("movie", int.Parse(movieListView.SelectedItems[0].Text));
                        movieListView.Items.Remove(movieListView.SelectedItems[0]);
                        
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    removeFromXML("movie", int.Parse(movieListView.SelectedItems[0].Text));
                    movieListView.Items.Remove(movieListView.SelectedItems[0]);
                    
                }
            }
            else if (gameListView.SelectedItems.Count > 0 && gameListView.SelectedItems[0].Focused)
            {
                ListViewItem gameItem = gameListView.SelectedItems[0];
                if (int.Parse(gameItem.SubItems[3].Text) > 0)
                {
                    DialogResult result = MessageBox.Show("Vill du verkligen ta bort varan?", "Varan är inte slut.", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        
                        removeFromXML("game", int.Parse(gameListView.SelectedItems[0].Text));
                        gameListView.Items.Remove(gameListView.SelectedItems[0]);
                        
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    removeFromXML("game", int.Parse(gameListView.SelectedItems[0].Text));
                    gameListView.Items.Remove(gameItem);
                    
                }
                
            }
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            ChangeForm changeForm = new ChangeForm(this);
            changeForm.Show();
        }

        public void changingProduct(int j)
        {

            if(bookListView.SelectedItems.Count > 0 && bookListView.SelectedItems[0].Focused)
            {
                ListViewItem bookItem = bookListView.SelectedItems[0];

                
                changeStockXML("book", int.Parse(bookListView.SelectedItems[0].Text), j);
                bookItem.SubItems[3].Text = j.ToString();
                bookItem.Selected = false;
                bookListView.Refresh();
            }
            else if (movieListView.SelectedItems.Count > 0 && movieListView.SelectedItems[0].Focused)
            {
                ListViewItem movieItem = movieListView.SelectedItems[0];

                changeStockXML("movie", int.Parse(movieListView.SelectedItems[0].Text), j);
                movieItem.SubItems[3].Text = j.ToString();
                movieItem.Selected = false;

                movieListView.Refresh();
            }
            else if (gameListView.SelectedItems.Count > 0 && gameListView.SelectedItems[0].Focused)
            {
                ListViewItem gameItem = gameListView.SelectedItems[0];

                changeStockXML("game", int.Parse(gameListView.SelectedItems[0].Text), j);
                gameItem.SubItems[3].Text = j.ToString();
                gameItem.Selected = false;
                
                gameListView.Refresh();
            }

            
        }

        private void rebootBtn_Click(object sender, EventArgs e)
        {
            XmlTextReader reader = null;
            
            try
            {
                ProductId = 0;
                productList.Clear();

                // Nyhämtad Data
                

                string url = "https://hex.cse.kau.se/~jonavest/csharp-api/";
                reader = new XmlTextReader(url);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: 
                            APIlist.Add("<" + reader.Name);

                            while (reader.MoveToNextAttribute()) 
                                APIlist.Add(" " + reader.Name + "='" + reader.Value + "'");
                            APIlist.Add(">");
                            APIlist.Add(">");
                            break;
                        case XmlNodeType.Text: 
                            APIlist.Add(reader.Value);
                            break;
                        case XmlNodeType.EndElement: 
                            APIlist.Add("</" + reader.Name);
                            APIlist.Add(">");
                            break;
                    }
                    logger.WriteXML(APIlist);
                }
                
            
                 
                }
                catch (HttpRequestException evo)
                {

                    MessageBox.Show("Error baby: " + evo.Message);

                }
                catch (ArgumentException ex)
                {

                    MessageBox.Show("Error baby: " + ex.Message);
                }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally 
            {
                reader.Close();
                APIlist.Clear();
            }
            
            this.Close();
        }

        private void gameUpdate()
        {
            try
            {
                gameListView.Items.Clear();
                gameListView.Columns.Clear();
                gameListView.View = View.Details;
                gameListView.FullRowSelect = true;

                gameListView.Columns.Add("Id", 30);
                gameListView.Columns.Add("Name", 200);
                gameListView.Columns.Add("Price", 50);
                gameListView.Columns.Add("Stock", 50);
                gameListView.Columns.Add("Plattform", 100);

                if (gameList.Count >= 0)
                {


                    foreach (object obj in productList)
                    {
                        
                        if (obj is Game)
                        {
                            productId++;
                            Game currentGame = (Game)obj;
                            string[] arry2 = new string[]
                            {
                                    currentGame.Id.ToString(),
                                    currentGame.Name,
                                    currentGame.Price.ToString(),
                                    currentGame.Stock.ToString(),
                                    currentGame.Platform


                            };
                            lagerIdList.Add(currentGame.Id);
                            ListViewItem item2 = new ListViewItem(arry2);
                            for (int i = 0; i < arry2.Length; i++)
                            {

                                if (string.IsNullOrEmpty(arry2[i]))
                                {
                                    item2.SubItems.Add(arry2[i]).BackColor = Color.DimGray;
                                    return;
                                }
                                else if (arry2[i].Contains(" x "))
                                {

                                    arry2[i].Trim().Replace(" x ", "     ");

                                    item2.SubItems[i].BackColor = Color.LightGray;
                                    item2.SubItems[i].Text = string.Empty;


                                }
                                else if (arry2[i].EndsWith("x"))
                                {
                                    Console.WriteLine("Game: slutade med ett 'x'");
                                    item2.SubItems[i].BackColor = Color.LightGray;
                                    item2.SubItems[i].Text = string.Empty;
                                }
                                else if (arry2[i].Equals("x"))
                                {
                                    Console.WriteLine("Game: är lika med 'x'");
                                    item2.SubItems[i].BackColor = Color.LightGray;
                                    item2.SubItems[i].Text = string.Empty;
                                }
                                else
                                {

                                    item2.SubItems.Add(arry2[i]);
                                }

                            }

                            gameListView.Items.Add(item2);
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        private void movieUpdate()
        {
            try
            {
                movieListView.Items.Clear();
                movieListView.Columns.Clear();
                movieListView.View = View.Details;
                movieListView.FullRowSelect = true;

                movieListView.Columns.Add("Id", 30);
                movieListView.Columns.Add("Name", 200);
                movieListView.Columns.Add("Price", 50);
                movieListView.Columns.Add("Stock", 50);
                movieListView.Columns.Add("Format", 100);
                movieListView.Columns.Add("Playtime", 80);
                foreach (object obj in productList)
                {
                    
                    if (obj is Movie)
                    {
                        productId++;
                        Movie currentMovie = (Movie)obj;
                        string[] arry3 = new string[]
                        {
                                    currentMovie.Id.ToString(),
                                    currentMovie.Name,
                                    currentMovie.Price.ToString(),
                                    currentMovie.Stock.ToString(),
                                    currentMovie.Format,
                                    currentMovie.PlayTime
                        };
                        lagerIdList.Add(currentMovie.Id);
                        ListViewItem item3 = new ListViewItem(arry3);
                        for (int i = 0; i < arry3.Length; i++)
                        {


                            if (string.IsNullOrEmpty(arry3[i]))
                            {
                                Console.WriteLine("Movie: Var null eller empty");
                                item3.SubItems.Add(arry3[i]).BackColor = Color.DimGray;
                                return;
                            }
                            else if (arry3[i].Contains(" x "))
                            {
                                arry3[i].Trim().Replace(" x ", "     ");

                                item3.SubItems[i].BackColor = Color.LightGray;
                                item3.SubItems[i].Text = string.Empty;

                            }

                            else if (arry3[i].Equals("x"))
                            {
                                Console.WriteLine("Movie: är lika med 'x'");
                                arry3[i].Trim().Replace(" x ", "     ");

                            }
                            else
                            {
                                item3.SubItems.Add(arry3[i]);

                            }

                        }
                        movieListView.Items.Add(item3);
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        private void bookUpdate()
        {
            try
            {
                
                if (productList != null)
                {
                    bookListView.Items.Clear();
                    bookListView.Columns.Clear();
                    bookListView.View = View.Details;
                    bookListView.FullRowSelect = true;

                    bookListView.Columns.Add("Id", 30);
                    bookListView.Columns.Add("Name", 200);
                    bookListView.Columns.Add("Price", 50);
                    bookListView.Columns.Add("Stock", 50);
                    bookListView.Columns.Add("Format", 100);
                    
                    bookListView.Columns.Add("Genre", 100);
                    bookListView.Columns.Add("Language", 80);
                    

                    foreach (object obj in productList)
                    {
                        if (bookList.Count >= 0)
                        {
                            if (obj is Book)
                            {
                                productId++;

                                Book currentBook = (Book)obj;
                                string[] arry = new string[]
                                {
                                    currentBook.Id.ToString(),
                                    currentBook.Name,
                                    currentBook.Price.ToString(),
                                    currentBook.Stock.ToString(),
                                    currentBook.Format,
                                    
                                    currentBook.Genre,
                                    currentBook.Language
                                    

                                };
                                lagerIdList.Add(currentBook.Id);
                                ListViewItem item = new ListViewItem(arry);
                                for (int i = 0; i < arry.Length; i++)
                                {

                                    if (arry[i].Contains(" x "))
                                    {

                                        item.SubItems[i].BackColor = Color.LightGray;
                                        item.SubItems[i].Text = string.Empty;
                                    }
                                    else if (string.IsNullOrEmpty(arry[i]))
                                    {
                                        Console.WriteLine("Book: Var null eller empty");
                                        item.SubItems.Add(arry[i]).BackColor = Color.DimGray;
                                        return;
                                    }

                                    else if (arry[i].EndsWith("x"))
                                    {

                                        arry[i].Trim().Replace(" x ", "     ");

                                        item.SubItems.Add(arry[i]).BackColor = Color.DimGray;
                                    }
                                    else if (arry[i].Equals("x"))
                                    {

                                        arry[i].Trim().Replace("x", "     ");

                                        item.SubItems.Add(arry[i]).BackColor = Color.DimGray;
                                    }
                                    else
                                    {
                                        item.SubItems.Add(arry[i]);

                                    }

                                }
                                bookListView.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void addObj(object obj)
        {
            try
            {
                productId++;
                if (obj is Game)
                {
                    Game currentGame = (Game)obj;
                    updateXML(currentGame);
                    string[] arry2 = new string[]
                    {
                                    currentGame.Id.ToString(),
                                    currentGame.Name,
                                    currentGame.Price.ToString(),
                                    currentGame.Stock.ToString(),
                                    currentGame.Platform


                    };

                    ListViewItem item2 = new ListViewItem(arry2);
                    for (int i = 0; i < arry2.Length; i++)
                    {

                        if (string.IsNullOrEmpty(arry2[i]))
                        {
                            item2.SubItems.Add(arry2[i]).BackColor = Color.DimGray;
                            return;
                        }
                        else if (arry2[i].Contains(" x "))
                        {

                            arry2[i].Trim().Replace(" x ", "     ");


                            item2.SubItems[i].BackColor = Color.LightGray;
                            item2.SubItems[i].Text = string.Empty;


                        }
                        else if (arry2[i].EndsWith("x"))
                        {
                            Console.WriteLine("Game: slutade med ett 'x'");
                            item2.SubItems[i].BackColor = Color.LightGray;
                            item2.SubItems[i].Text = string.Empty;
                        }
                        else if (arry2[i].Equals("x"))
                        {
                            Console.WriteLine("Game: är lika med 'x'");
                            item2.SubItems[i].BackColor = Color.LightGray;
                            item2.SubItems[i].Text = string.Empty;
                        }
                        else
                        {

                            item2.SubItems.Add(arry2[i]);
                        }

                    }

                    gameListView.Items.Add(item2);
                }
                else if(obj is Book)
                            {

                    Book currentBook = (Book)obj;
                    updateXML(currentBook);
                    string[] arry = new string[]
                    {
                                    currentBook.Id.ToString(),
                                    currentBook.Name,
                                    currentBook.Price.ToString(),
                                    currentBook.Stock.ToString(),
                                    currentBook.Format,

                                    currentBook.Genre,
                                    currentBook.Language


                    };

                    ListViewItem item = new ListViewItem(arry);
                    for (int i = 0; i < arry.Length; i++)
                    {

                        if (arry[i].Contains(" x "))
                        {

                            item.SubItems[i].BackColor = Color.LightGray;
                            item.SubItems[i].Text = string.Empty;
                        }
                        else if (string.IsNullOrEmpty(arry[i]))
                        {
                            Console.WriteLine("Book: Var null eller empty");
                            item.SubItems.Add(arry[i]).BackColor = Color.DimGray;
                            return;
                        }

                        else if (arry[i].EndsWith("x"))
                        {

                            arry[i].Trim().Replace(" x ", "     ");

                            item.SubItems.Add(arry[i]).BackColor = Color.DimGray;
                        }
                        else if (arry[i].Equals("x"))
                        {

                            arry[i].Trim().Replace("x", "     ");

                            item.SubItems.Add(arry[i]).BackColor = Color.DimGray;
                        }
                        else
                        {
                            item.SubItems.Add(arry[i]);

                        }

                    }
                    bookListView.Items.Add(item);
                }
                else if (obj is Movie)
                {
                    Movie currentMovie = (Movie)obj;
                    updateXML(currentMovie);
                    string[] arry3 = new string[]
                    {
                                    currentMovie.Id.ToString(),
                                    currentMovie.Name,
                                    currentMovie.Price.ToString(),
                                    currentMovie.Stock.ToString(),
                                    currentMovie.Format,
                                    currentMovie.PlayTime
                    };

                    ListViewItem item3 = new ListViewItem(arry3);
                    for (int i = 0; i < arry3.Length; i++)
                    {


                        if (string.IsNullOrEmpty(arry3[i]))
                        {
                            Console.WriteLine("Movie: Var null eller empty");
                            item3.SubItems.Add(arry3[i]).BackColor = Color.DimGray;
                            return;
                        }
                        else if (arry3[i].Contains(" x "))
                        {

                            arry3[i].Trim().Replace(" x ", "     ");

                            item3.SubItems[i].BackColor = Color.LightGray;
                            item3.SubItems[i].Text = string.Empty;

                        }

                        else if (arry3[i].Equals("x"))
                        {
                            Console.WriteLine("Movie: är lika med 'x'");
                            arry3[i].Trim().Replace(" x ", "     ");
 
                        }
                        else
                        {
                            item3.SubItems.Add(arry3[i]);

                        }

                    }
                    movieListView.Items.Add(item3);
                }
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
