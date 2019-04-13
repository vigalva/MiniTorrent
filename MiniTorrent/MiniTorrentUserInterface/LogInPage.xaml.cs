using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using MiniTorrent;
using MiniTorrent.Controllers;
using MiniTorrent.Models;

namespace MiniTorrentUserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        protected string pathString = @"c:\Share_Folder";

        public MainWindow()
        {
            InitializeComponent();
            tbUserName.Text = "";
            tbPassword.Text = "";
        }

        private void BtRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(pathString))
            {
                System.IO.Directory.CreateDirectory(pathString);

                MessageBoxResult result = MessageBox.Show("Opening Sharing Folder In C Drive",
                                           "Confirmation",
                                           MessageBoxButton.OK,
                                           MessageBoxImage.Exclamation);

            }
             Process.Start("http://localhost:31058/WebPortal/Register.aspx");

        }

        private void btLogIn_Click(object sender, RoutedEventArgs e)
        {
            FilesController fc = new FilesController();
            User loggedIn = new User
            {
                username = tbUserName.Text,
                password = tbPassword.Text
            };
            List<MyFile> filesInSharingFolder=new List<MyFile>();

            string[] fileEntries = Directory.GetFiles(pathString);
            foreach (var f in fileEntries)
            {
                FileInfo info = new FileInfo(f);
                filesInSharingFolder.Add(new MyFile
                {
                    name = info.Name,
                    size = info.Length,
                    description = info.CreationTime.ToShortTimeString()
                });
            }
            User_lst_Files userAndFiles = new User_lst_Files
            {
                User = loggedIn,
                lstFiles = filesInSharingFolder

            };
            HttpResponseMessage actionResult=fc.SignIn(userAndFiles);
            if (actionResult.IsSuccessStatusCode)
            {
                UserMainFileSystem MainUserPage = new UserMainFileSystem(tbUserName.Text,tbPassword.Text);
                MainUserPage.Show();
                this.Close();
            }
            else
            {
                 MessageBox.Show("unvalid username ",
                                           "Error",
                                           MessageBoxButton.OK,
                                           MessageBoxImage.Exclamation);
            }
        }
    }
}
