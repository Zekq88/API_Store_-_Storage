using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Lab_4___Winform
{
    public partial class Webbutik : Form
    {
        private Product product;
        private MainForm mainForm;
        private List<string> cartList;
        private Logger logger;
        private List<string> loggerlist;
        private List<object> productList;
        List<string> gameList = new List<string>();
        List<string> bookList = new List<string>();
        List<string> movieList = new List<string>();
        



        public Webbutik(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            product = new Product();
            logger = new Logger();
            cartList = new List<string>();
            productList = product.GetProducts();
            readXML(logger.fileXMLPath);
            
            updateGUI();

            cartNr.Text = cartList.Count.ToString();
               
             
            


        }
        private void changeStockXML(string obj, int index)
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
                            MessageBox.Show(stockNode.InnerText);

                            if (stockNode != null)
                            {
                                int stockValue = int.Parse(stockNode.InnerText.Replace(">", string.Empty).Trim());
                                stockValue--;
                                stockNode.InnerText = stockValue.ToString();

                                found = true;
                                break;
                            }
                            
                        }
                    }

                    if (found)
                    {
                        xDoc.Save(logger.fileXMLPath);
                        
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
            catch (NullReferenceException e) { MessageBox.Show(e.Message,"det är NULL"); }
        }

        private void readXML(string filePath)
        {
            XmlDocument xDoc = null;
            try
            {
                xDoc = new XmlDocument();
                if (!string.IsNullOrEmpty(filePath))
                {
                    xDoc.Load(filePath);
                }
                else { xDoc.LoadXml(logger.fileXMLPath); }


                XmlNodeList gameNode = xDoc.GetElementsByTagName("game");
                XmlNodeList movieNode = xDoc.GetElementsByTagName("movie");
                XmlNodeList bookNode = xDoc.GetElementsByTagName("book");

                foreach (XmlNode node in bookNode)
                {


                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        bookList.Add($"{childNode.InnerText.Trim().Replace(">", string.Empty)}");
                    }

                    if (bookList.Count() == 8)
                    {
                        Book b1 = new Book(int.Parse(bookList[1]), bookList[2], int.Parse(bookList[3]), int.Parse(bookList[4]), bookList[5], bookList[6], bookList[7]);
                        product.AddProduct(b1);

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

                        movieList.Clear();
                    }
                    else if (movieList.Count() == 6)
                    {
                        Movie m1 = new Movie(int.Parse(movieList[1]), movieList[2], int.Parse(movieList[3]), int.Parse(movieList[4]), null, null);
                        product.AddProduct(m1);

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

            try
            {
                productList = product.GetProducts();

                gameUpdate();
                bookUpdate();
                movieUpdate();
                movieListView.Refresh();
                gameListView.Refresh();
                bookListView.Refresh();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void getBackBtn_Click(object sender, EventArgs e)
        {
            cartNr.Text = cartList.Count.ToString();
            mainForm.Show();
            this.Close();
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {

            if (bookListView.SelectedItems.Count > 0 && bookListView.SelectedItems[0].Focused)
            {
                ListViewItem bookItem = bookListView.SelectedItems[0];


                int stock = int.Parse(bookItem.SubItems[3].Text);
                if (stock > 0)
                {
                    cartList.Add($"{bookItem.SubItems[1].Text, -35} {bookItem.SubItems[2].Text, -10}   {bookItem.SubItems[4].Text, -10} {bookItem.SubItems[5].Text,-20} {bookItem.SubItems[6].Text,-10}");
                    cartNr.Text = cartList.Count.ToString();
                    bookItem.SubItems[3].Text = (stock - 1).ToString();
                    changeStockXML("book", int.Parse(bookListView.SelectedItems[0].Text));
                }
                else
                {
                    MessageBox.Show("Antalet av denna produkt är slut", "Finns inga fler i lager");
                }
                bookItem.Selected = false;
                bookListView.Refresh();
            }
            else if (movieListView.SelectedItems.Count > 0 && movieListView.SelectedItems[0].Focused)
            {
                ListViewItem movieItem = movieListView.SelectedItems[0];


                int stock = int.Parse(movieItem.SubItems[3].Text);
                if (stock > 0)
                {
                    cartList.Add($"{movieItem.SubItems[1].Text, -20} {movieItem.SubItems[2].Text,-10} {movieItem.SubItems[4].Text, -10} {movieItem.SubItems[5].Text,-10}");
                    cartNr.Text = cartList.Count.ToString();
                    movieItem.SubItems[3].Text = (stock - 1).ToString();
                    changeStockXML("movie", int.Parse(movieListView.SelectedItems[0].Text));
                }
                else
                {
                    MessageBox.Show("Antalet av denna produkt är slut", "Finns inga fler i lager");
                }
                movieItem.Selected = false;
                movieListView.Refresh();
            }
            else if (gameListView.SelectedItems.Count > 0 && gameListView.SelectedItems[0].Focused)
            {
                ListViewItem gameItem = gameListView.SelectedItems[0];


                int stock = int.Parse(gameItem.SubItems[3].Text);
                if (stock > 0)
                {
                    cartList.Add($"{gameItem.SubItems[1].Text, -20} {gameItem.SubItems[2].Text, -10} {gameItem.SubItems[4].Text, -10}");
                    cartNr.Text = cartList.Count.ToString();
                    gameItem.SubItems[3].Text = (stock - 1).ToString();
                    changeStockXML("game", int.Parse(gameListView.SelectedItems[0].Text));
                }
                else
                {
                    MessageBox.Show("Antalet av denna produkt är slut", "Finns inga fler i lager");
                }
                gameItem.Selected = false;
                gameListView.Refresh();
            }
        }

        public void setCartNr(int i)
        {
            cartNr.Text = i.ToString();
        }

        private void cartBtn_Click(object sender, EventArgs e)
        {
            PayForm pay = new PayForm(cartList);
            pay.Show();
            cartList.Clear();
            cartNr.Text = cartList.Count.ToString();
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
                            Game currentGame = (Game)obj;
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
    }
}
