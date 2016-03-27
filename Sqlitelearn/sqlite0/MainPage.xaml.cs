using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using Windows.Storage;
using sqlite0.Models;
using System.Text;
using Windows.UI.Popups;
using SQLite;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace sqlite0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static String DB_NAME = "linq.db";


        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, DB_NAME);
            using (var conn = new SQLiteConnection(new SQLitePlatformWinRT(), path))
            {
                conn.CreateTable<User>();
                User uu1 = new User { Age = 22, Address = "Beijing", UserName = "Lin", SomeProperty = "single" };
                User uu2 = new User { Age = 22, Address = "Beijing", UserName = "A", SomeProperty = "single" };
                User uu3 = new User { Age = 22, Address = "Beijing", UserName = "B", SomeProperty = "single" };
                User uu4 = new User { Age = 22, Address = "Beijing", UserName = "D", SomeProperty = "single" };
                User uu5 = new User { Age = 22, Address = "Beijing", UserName = "G", SomeProperty = "single" };
                User uu6 = new User { Age = 22, Address = "Beijing", UserName = "G", SomeProperty = "single" };
                List<User> listd = new List<User> { uu1, uu2, uu3, uu4, uu5, uu6 };
                conn.InsertAll(listd);
            }
        }

        private async void Button_Click1(object sender, RoutedEventArgs e)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, DB_NAME);
            using (var conn = new SQLiteConnection(new SQLitePlatformWinRT(), path))
            {
                conn.CreateTable<User>();
                StringBuilder sb = new StringBuilder();
                var list = conn.Table<User>();
                foreach (var item in list)
                {
                    sb.AppendLine($"{item.Id} {item.UserName} {item.Age} {item.Address}");
                }
                await new MessageDialog(sb.ToString()).ShowAsync();
            }
        }

        private async void Button_Click2(object sender, RoutedEventArgs e)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, DB_NAME);
            using (var conn = new SQLiteConnection(new SQLitePlatformWinRT(), path))
            {
                conn.CreateTable<User>();
                conn.Update(new User { Id = 1, UserName = "Michael Jackson" });//垃圾
                var q1 = conn.Table<User>().Count(x=>x.UserName=="HHHH");
                await new MessageDialog(q1.ToString()).ShowAsync();
                //foreach (var VARIABLE in q1)
                //{
                //    VARIABLE.UserName = "HHHH";
                //    conn.Update(VARIABLE);
                //}
               // conn.UpdateAll(q1);
                //var q = conn.Table<User>().FirstOrDefault(x => x.UserName == "Lin");
                //if (q != null)
                //{
                //    q.UserName = "Michael";
                //    conn.Update(q);
                //}
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, DB_NAME);
            using (var conn = new SQLiteConnection(new SQLitePlatformWinRT(), path))
            {
                conn.CreateTable<User>();
                //conn.Update(new User { Id = 1, UserName = "Michael Jackson" });//垃圾

                var q = conn.Table<User>().FirstOrDefault(x => x.UserName == "D");
                if (q != null)
                {
                    conn.Delete(q);
                }
            }

            //public static SQLiteConnection GetDbConnection()
            //{
            //public readonly static string DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "test.db");
            //// 连接数据库，如果数据库文件不存在则创建一个空数据库。
            //var conn = new SQLiteConnection(new SQLitePlatformWinRT(), DbPath);
            //// 创建 Person 模型对应的表，如果已存在，则忽略该操作。
            //conn.CreateTable<Person>();
            //    return conn;
            //}
        }
    }
}
