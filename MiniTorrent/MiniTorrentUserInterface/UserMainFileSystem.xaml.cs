
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using MiniTorrent;
using MiniTorrent.Controllers;
using MiniTorrent.Models;
using MiniTorrent.Services;
using DataGridColumn = System.Windows.Controls.DataGridColumn;

namespace MiniTorrentUserInterface
{
    /// <summary>
    /// Interaction logic for UserMainFileSystem.xaml
    /// </summary>
    public partial class UserMainFileSystem : MetroWindow
    {
        private string username;
        private string password;

        public UserMainFileSystem(string username, string password)
        {
            this.username = username;
            this.password = password;
            InitializeComponent();
            tbName.Text = "";
            new UploadRequestHandler(); // Create New Task from request files
            
        }
       
        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            FileManagerService service = new FileManagerService();
            List<MyFile> mySearch = service.FindFile(tbName.Text.Trim());
            dtGrid.ItemsSource = mySearch;

        }

        private void BtDownload_Click_1(object sender, RoutedEventArgs e)
        {
            process.Value = 0;

            string downloadpath;
            if (dtGrid.SelectedCells.Count > 0)
            {
                try
                {

                    MyFile toDownload = (MyFile)dtGrid.SelectedItem;
                   

                    SaveFileDialog folderBrowser = new SaveFileDialog();
                    // Set validate names and check file exists to false otherwise windows will
                    // not let you select "Folder Selection."
                    folderBrowser.ValidateNames = false;
                    folderBrowser.CheckFileExists = false;
                    folderBrowser.CheckPathExists = true;
                    // Always default to Folder Selection.
                    folderBrowser.FileName = "";
                    if (folderBrowser.ShowDialog() == true)
                    {
                        downloadpath = folderBrowser.FileName;
                        using (AdminsController admincontroler  = new AdminsController() )
                        {

                            User UploadUser = admincontroler.GetUser(toDownload.IdUser);
                            if(UploadUser != null)
                            {
                                // continue

                                //download path =  downloadpath
                                // uploadUser
                                //toDownload.name == namefile
                                // TODO : open socket client ! 

                                GetFileFromUser(UploadUser, toDownload.name, downloadpath);

                                process.Value = 100;
                                MessageBox.Show("Downloaded successfully " + toDownload.name);

                            }


                        }



                    }
                }


                catch (Exception)
                {

                }

            }
        }

        private void GetFileFromUser(User uploadUser, string namefile,String DownloadPath)
        {
            DownloadRequest handlerDownload = new DownloadRequest(uploadUser,namefile, DownloadPath);
            
        }

        private void BtLogOut_Click(object sender, RoutedEventArgs e)
        {
            using (FilesController filescontroler = new FilesController())
            {
               
                filescontroler.SignOut(new User { username = this.username, password = password });
                
            }
            MainWindow LoginPage = new MainWindow();
            this.Close();
            LoginPage.Show();
        }

        
    }
}
