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
using SQLitePCL;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SQLboomlitepcl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static String DB_NAME = "SQLiteSample.db";
        private static String TABLE_NAME = "SampleTable";
        private static String SQL_CREATE_TABLE = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " (Key TEXT,Value TEXT);";
        private static String SQL_QUERY_VALUE = "SELECT * FROM " + TABLE_NAME;// + " WHERE Key = (?);";
        private static String SQL_INSERT = "INSERT INTO " + TABLE_NAME + " VALUES(?,?);";
        private static String SQL_UPDATE = "UPDATE " + TABLE_NAME + " SET Value = ? WHERE Key = ?";
        private static String SQL_DELETE = "DELETE FROM " + TABLE_NAME + " WHERE Key = ?";
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void create_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(DB_NAME);
            using (var statement = conn.Prepare(SQL_CREATE_TABLE))
            {
                statement.Step();
            }
        }
        private void insert_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(DB_NAME);
            using (var statement = conn.Prepare(SQL_INSERT))
            {
                statement.Bind(1, "hhhhh");
                statement.Bind(2, "fkfjfk");
                statement.Step();
            }
        }

        private void read_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(DB_NAME);
            using (var statement = conn.Prepare(SQL_QUERY_VALUE))
            {
               var a= statement.Step();
                if (SQLiteResult.ROW == a)
                {
                   var  value = statement[0] as String;
                }

            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void date_Click(object sender, RoutedEventArgs e)
        {

        }


        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
