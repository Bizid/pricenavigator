
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.IO;
using ExcelLibrary.SpreadSheet;
using OfficeOpenXml;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace priceComparer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        int _c = 0;
        string _themeName = "";
        public MainWindow()
        {
            InitializeComponent();
            TestDatabaseExists(@".", "PriceComparer");
   
            DownloadPrice();
            WriteToExcelTask();
            ShowPartner();
            ChangeTheme();
            ResetVisibilityCheck();
            UpdateFavoriteDatagrid();
            addToFavorite.Visibility = Visibility.Hidden;
        }

        private void ResetVisibilityCheck()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            var conProduct = new SqlConnection(connectionString);
            conProduct.Open();
            using (var cmd3 = new SqlCommand("SELECT * FROM [favorite]", conProduct))
            {
                var reader = Convert.ToInt32(cmd3.ExecuteScalar());
                ResetFavorite.Visibility = reader > 0 ? Visibility.Visible : Visibility.Hidden;
            }
            conProduct.Close();
        }

        private void WriteToExcelTask()
        {
            WriteToExcelSheet("yadro", @"c:\priceDb\price_yadro.xls");
            WriteToExcelSheet("serverkh", @"c:\priceDb\serverkh.xls");
            //WriteToExcelSheet("technokit", @"c:\priceDb\technokit.xls");
            // WriteToExcelSheet("pricekomtek", @"c:\priceDb\pricekomtek.xls");
            WriteToExcelSheet("pricektc", @"c:\priceDb\pricektc.xls");
        }

        private void ChangeTheme()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            var conProduct = new SqlConnection(connectionString);
            conProduct.Open();
            using (var cmd3 = new SqlCommand("SELECT [selectedtheme] FROM [applicationtheme] where ID = 1", conProduct))
            {
                var reader = cmd3.ExecuteReader();
                while (reader.Read())
                {
                    _themeName = reader.GetValue(0).ToString();
                    if (_themeName == "blueTheme")
                    {
                        blueTheme.IsChecked = true;
                    }
                    if (_themeName == "lightBlueTheme")
                    {
                        lightBlueTheme.IsChecked = true;
                    }
                    if (_themeName == "darkBlueTheme")
                    {
                        darkBlueTheme.IsChecked = true;
                    }
                }
                reader.Close();
            }
            conProduct.Close();
        }

        private void DownloadPrice()
        {
            var webClient1 = new WebClient();
            webClient1.DownloadFileAsync(new Uri("http://yadro.in.ua/price/price_yadro.xls"), @"c:\priceDb\price_yadro.xls");

            var webClient2 = new WebClient();
            webClient2.DownloadFileAsync(new Uri("http://server.kh.ua/price.xls"), @"c:\priceDb\serverkh.xls");

            /*var webClient7 = new WebClient();
            webClient7.DownloadFile("http://technokit.com.ua/pricexls.php", @"c:\priceDb\technokit.xls");

            var webClient8 = new WebClient();
            webClient8.DownloadFile("http://komtek.net.ua/price_komtek.xls", @"c:\priceDb\pricekomtek.xls");*/

            var webClient9 = new WebClient();
            webClient9.DownloadFile("http://www.ktc.com.ua/storage/price/price.xls", @"c:\priceDb\pricektc.xls");
        }

       private DataTable WorksheetToDataTable(ExcelWorksheet oSheet)
        {
	        var totalRows = oSheet.Dimension.End.Row;
	        var totalCols = oSheet.Dimension.End.Column;
	        var dt = new DataTable(oSheet.Name);
	        DataRow dr = null;
	        for (var i = 1; i <= totalRows; i++)
	        {
		        if (i > 1) dr = dt.Rows.Add();
		        for (var j = 1; j <= totalCols; j++)
		        {
			        if (i == 1)
				        dt.Columns.Add(oSheet.Cells[i, j].Value.ToString());
			        else
				        dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
		        }
	        }
	        return dt;
        }
		
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Advirstment.Visibility = Visibility.Collapsed;
                var connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
                var con = new SqlConnection(connectionString);
                con.Open();
                using (var cmd2 = new SqlCommand("EXEC SP_SearchInTables @Tablenames = '%',@SearchStr = '%" + searchVal.Text + "%'", con))
                {
                    var sda = new SqlDataAdapter(cmd2);
                    var dt = new DataTable("Price");
                    sda.Fill(dt);
                    datagrid1.ItemsSource = dt.DefaultView;
                    datagrid1.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                    var namecol = new DataGridTextColumn();
                    var productName = new Binding("Name");
                    namecol.Binding = productName;
                    namecol.Header = "Name";
                    namecol.Width = 270;
                    datagrid1.Columns.Add(namecol);
                    var pricecol = new DataGridTextColumn();
                    var productPrice = new Binding("Price");
                    pricecol.Binding = productPrice;
                    pricecol.Header = "Price";
                    pricecol.Width = 60;
                    datagrid1.Columns.Add(pricecol);
                    var storenamecol = new DataGridTextColumn();
                    var productStoreName = new Binding("storename");
                    storenamecol.Binding = productStoreName;
                    storenamecol.Header = "Store Name";
                    storenamecol.Width = 100;
                    datagrid1.Columns.Add(storenamecol);
                    var storecity = new DataGridTextColumn();
                    var productStoreCity = new Binding("storecity");
                    storecity.Binding = productStoreCity;
                    storecity.Header = "Store City";
                    storecity.Width = 100;
                    datagrid1.Columns.Add(storecity);
                    var style = new Style(typeof(TextBlock));
                    style.Setters.Add(new EventSetter(Hyperlink.ClickEvent, (RoutedEventHandler)OnHyperlinkClick));
                    datagrid1.Columns.Add(new DataGridHyperlinkColumn { Binding = new Binding("storeurl"), Header = "Store Url", Width = 80, ElementStyle = style });
                    
                }
                con.Close();
                var conProduct = new SqlConnection(connectionString);
                conProduct.Open();
                using (var cmd3 = new SqlCommand("Select * From productDetail where ProductName Like '%" + searchVal.Text + "%'", conProduct))
                {
                    var reader = cmd3.ExecuteReader();
                    while (reader.Read())
                    {
                        var fullFilePath = reader.GetValue(2).ToString();
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(fullFilePath, UriKind.Relative);
                        bitmap.EndInit();
                        ProductImage.Source = bitmap;
                        ProductDescription.Text = reader.GetValue(3).ToString();
                        Advirstment.Visibility = Visibility.Visible;
                    }
                    reader.Close();
                }
                conProduct.Close();
                addToFavorite.Visibility = Visibility.Visible;
            }
        }

        private void OnHyperlinkClick(object sender, RoutedEventArgs e)
        {
            var destination = ((Hyperlink)e.OriginalSource).NavigateUri;
            Trace.WriteLine("Browsing to " + destination);
            using (var browser = new Process())
            {
                browser.StartInfo = new ProcessStartInfo
                {
                    FileName = destination.ToString(),
                    UseShellExecute = true,
                    ErrorDialog = true
                };
                browser.Start();
            }
        }

        // changing app theme styles
        private void lightBlueTheme_Checked(object sender, RoutedEventArgs e)
        {
            mainGrid.Style = (Style)mainGrid.FindResource("lightBlueStyle");
            Home.Style = (Style)Home.FindResource("lightBlueStyle");
            Partners.Style = (Style)Partners.FindResource("lightBlueStyle");
            favourites.Style = (Style)favourites.FindResource("lightBlueStyle");
            searchP.Style = (Style)searchP.FindResource("lightBlueStyle");
            styles.Style = (Style)styles.FindResource("lightBlueStyle");
        }
        private void darkBlueTheme_Checked(object sender, RoutedEventArgs e)
        {
            mainGrid.Style = (Style)mainGrid.FindResource("darkBlueStyle");
            Home.Style = (Style)Home.FindResource("darkBlueStyle");
            Partners.Style = (Style)Partners.FindResource("darkBlueStyle");
            favourites.Style = (Style)favourites.FindResource("darkBlueStyle");
            searchP.Style = (Style)searchP.FindResource("darkBlueStyle");
            styles.Style = (Style)styles.FindResource("darkBlueStyle");
        }
        private void blueTheme_Checked(object sender, RoutedEventArgs e)
        {
            mainGrid.Style = (Style)mainGrid.FindResource("blueStyle");
            Home.Style = (Style)Home.FindResource("blueStyle");
            Partners.Style = (Style)Partners.FindResource("blueStyle");
            favourites.Style = (Style)favourites.FindResource("blueStyle");
            searchP.Style = (Style)searchP.FindResource("blueStyle");
            styles.Style = (Style)styles.FindResource("blueStyle");
        }

        private void ResetFavorite_Click(object sender, RoutedEventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            var conProduct = new SqlConnection(connectionString);
            conProduct.Open();
            using (var cmd3 = new SqlCommand("DELETE  FROM favorite ", conProduct))
            {
                var reader = cmd3.ExecuteReader();
                reader.Close();
            }
            conProduct.Close();
            UpdateFavoriteDatagrid();
            ResetFavorite.Visibility = Visibility.Hidden;
        }

        private void addToFavorite_Click(object sender, RoutedEventArgs e)
        {
            AddFavorite();
        }

        private void UpdateFavoriteDatagrid()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            var con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd5 = new SqlCommand("Select * From favorite", con))
            {
                var sdab = new SqlDataAdapter(cmd5);
                var dtd = new DataTable("Price");
                sdab.Fill(dtd);
                datagrid2.ItemsSource = dtd.DefaultView;
                datagrid2.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                var namecol = new DataGridTextColumn();
                var productName = new Binding("productName");
                namecol.Binding = productName;
                namecol.Header = "Name";
                namecol.Width = 270;
                datagrid2.Columns.Add(namecol);
                var pricecol = new DataGridTextColumn();
                var productPrice = new Binding("productPrice");
                pricecol.Binding = productPrice;
                pricecol.Header = "Price";
                pricecol.Width = 60;
                datagrid2.Columns.Add(pricecol);
                var storenamecol = new DataGridTextColumn();
                var productStoreName = new Binding("storeName");
                storenamecol.Binding = productStoreName;
                storenamecol.Header = "Store Name";
                storenamecol.Width = 100;
                datagrid2.Columns.Add(storenamecol);
                var storecity = new DataGridTextColumn();
                var productStoreCity = new Binding("storeCity");
                storecity.Binding = productStoreCity;
                storecity.Header = "Store City";
                storecity.Width = 100;
                datagrid2.Columns.Add(storecity);
            }
            con.Close();
            ResetFavorite.Visibility = Visibility.Visible;
        }

        private void AddFavorite()
        {
            var item = datagrid1.SelectedItem;
            _c++;
            int id = _c;
            var textBlock = datagrid1.SelectedCells[0].Column.GetCellContent(item) as TextBlock;
            if (textBlock != null)
            {
                string productName = textBlock.Text;
                var block = datagrid1.SelectedCells[1].Column.GetCellContent(item) as TextBlock;
                if (block != null)
                {
                    string productPrice = block.Text;
                    var textBlock1 = datagrid1.SelectedCells[2].Column.GetCellContent(item) as TextBlock;
                    if (textBlock1 != null)
                    {
                        var storeName = textBlock1.Text;
                        var block1 = datagrid1.SelectedCells[4].Column.GetCellContent(item) as TextBlock;
                        if (block1 != null)
                        {
                            var storeCity = block1.Text;
                            var connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
                            var conProduct = new SqlConnection(connectionString);
                            conProduct.Open();
                            using (var cmd3 = new SqlCommand("INSERT INTO favorite VALUES ('" + id + "', '" + productName + "', '" + productPrice + "', '" + storeName + "', '" + storeCity + "'); ", conProduct))
                            {
                                var reader = cmd3.ExecuteReader();
                                reader.Close();
                            }
                            conProduct.Close();
                        }
                    }
                }
            }
            UpdateFavoriteDatagrid();
        }
        public Boolean TestDatabaseExists(string server, string database)
        {
            var connString = ("Data Source=" + (server + ";Initial Catalog=master;Integrated Security=True;"));
            var cmdText = ("select * from master.dbo.sysdatabases where name=\'" + (database + "\'"));
            Boolean bRet;
            var sqlConnection = new SqlConnection(connString);
            var sqlCmd = new SqlCommand(cmdText, sqlConnection);
            try
            {
            sqlConnection.Open();
            var reader = sqlCmd.ExecuteReader();
            bRet = reader.HasRows;
            sqlConnection.Close();
            }
            catch (Exception e) 
            {
            bRet = false;
            sqlConnection.Close();
            MessageBox.Show(e.Message);
            return false;
            } //End Try Catch Block
            if (bRet == true)
            {
                //MessageBox.Show("DATABASE EXISTS");
                return true;
            }
            else
            {
                MessageBox.Show("DATABASE DOES NOT EXIST");
                if (!Directory.Exists("c:/priceDb"))
                {
                    Directory.CreateDirectory("c:/priceDb");
                }
           
                BuildDb();
                return false;
            } //END OF IF
        } //END FUNCTION

        private void BuildDb()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["createDbConnection"].ConnectionString;
            var script1 = File.ReadAllText(@"sql/priceComparer.txt");
            var con2 = new SqlConnection(connectionString);
            var server1 = new Server(new ServerConnection(con2));
            server1.ConnectionContext.ExecuteNonQuery(script1);
        }
      
        private void ShowPartner()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            var con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd3 = new SqlCommand("SELECT * FROM store ", con))
            {
                var sdab = new SqlDataAdapter(cmd3);
                var dtd = new DataTable("Price");
                sdab.Fill(dtd);
                datagrid3.ItemsSource = dtd.DefaultView;
                datagrid3.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                var namecol = new DataGridTextColumn();
                var storeName = new Binding("storename");
                namecol.Binding = storeName;
                namecol.Header = "Store Name";
                namecol.Width = 110;
                datagrid3.Columns.Add(namecol);
                var storeAdress = new DataGridTextColumn();
                var storeadress = new Binding("storeadress");
                storeAdress.Binding = storeadress;
                storeAdress.Header = "store Adress";
                storeAdress.Width = 150;
                datagrid3.Columns.Add(storeAdress);
                var style = new Style(typeof(TextBlock));
                style.Setters.Add(new EventSetter(Hyperlink.ClickEvent, (RoutedEventHandler)OnHyperlinkClick));
                datagrid3.Columns.Add(new DataGridHyperlinkColumn { Binding = new Binding("storeurl"), Header = "Store Url", Width = 150, ElementStyle = style });
                var storecity = new DataGridTextColumn();
                var productStoreCity = new Binding("storecity");
                storecity.Binding = productStoreCity;
                storecity.Header = "Store City";
                storecity.Width = 110;
                datagrid3.Columns.Add(storecity);
            }
            con.Close();
        }

        private void BtnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            var smtpClient = new SmtpClient();
            var basicCredential = new NetworkCredential("pricecompua@gmail.com", "myapp2014");
            var message = new MailMessage();
            var fromAddress = new MailAddress("pricecompua@gmail.com"); //send from (app e-mail adress)
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            smtpClient.EnableSsl = true;
            message.From = fromAddress;
            message.Subject = newname.Text;
            message.IsBodyHtml = true; // true means you can send HTML email.
            message.Body = "Письмо: \n" + newtextarea.Text + " \n с адреса: " + newemail.Text;
            message.To.Add("bizid-kh@yandex.ru"); //send to (developer e-mail adress)
            try
            {
                smtpClient.Send(message);
                MessageBox.Show("Ваше письмо отправлено");
            }
            catch (Exception ex) //Error
            {
                MessageBox.Show(ex.ToString());
            }
        }


              private void savetheme_Click(object sender, RoutedEventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            var con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd3 = new SqlCommand("UPDATE [applicationtheme] SET ID = 1, selectedtheme = '" + _themeName + "' ;", con))
            {
                var reader = cmd3.ExecuteReader();
                reader.Close();
            }
            con.Close();
        }
   
        public void WriteToExcelSheet(string tableName, string pricePath)
        {
            var book = Workbook.Load(pricePath);
            var sheet = book.Worksheets[0];
            var namePriceHeaderCol = 0;
            var namePriceHeaderStartRow = 0;
            var nameProductHeaderCol = 0;
            for (var rowIndex = sheet.Cells.FirstRowIndex;
                           rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            {
                var row = sheet.Cells.GetRow(rowIndex);
                for (var colIndex = row.FirstColIndex;
                        colIndex <= row.LastColIndex; colIndex++)
                {
                    var cell = row.GetCell(colIndex);
                    if (cell.ToString().ToLower() == "название товара" || cell.ToString().ToLower() == "полное описание")
                    {
                        nameProductHeaderCol = colIndex;
                    }
                    if (cell.ToString().ToLower() == "наименование")
                    {
                        nameProductHeaderCol = colIndex +1;
                    }
                    if (cell.ToString().ToLower() == "цена" || cell.ToString().ToLower() == "цена, грн" || cell.ToString() == "Опт$ ")
                    {
                        namePriceHeaderCol = colIndex;
                        namePriceHeaderStartRow = rowIndex;
                    }
                }
            }
    
      var connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
      for (var rowIndex = namePriceHeaderStartRow + 1;
             rowIndex <= sheet.Cells.LastRowIndex;
             rowIndex++)
             {
                 var row = sheet.Cells.GetRow(rowIndex);
                 using (var conProduct = new SqlConnection(connectionString))
                 {
                     var cmd3 = new SqlCommand("INSERT INTO " + tableName + "(Name, Price)  VALUES (@nameProduct, @namePrice)")
                     {
                         CommandType = CommandType.Text,
                         Connection = conProduct
                     };
                        cmd3.Parameters.AddWithValue("@nameProduct", row.GetCell(nameProductHeaderCol).ToString());
                        cmd3.Parameters.AddWithValue("@namePrice", row.GetCell(namePriceHeaderCol).ToString());
                        conProduct.Open();
                        cmd3.ExecuteNonQuery();
                        conProduct.Close();
                   }
             }
               
        }
    }
}

