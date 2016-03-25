using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SQLitetry
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtAddName.Text;
            using (var conn = AppDatabase.GetDbConnection())
            {
                // 需要添加的 Person 对象。
                var addPerson = new Person() { Name = name };

                // 受影响行数。
                var count = conn.Insert(addPerson);

                string msg = $"新增的 Person 对象的 Id 为 {addPerson.Id}，Name 为 {addPerson.Name}";
                await new MessageDialog(msg).ShowAsync();
            }
        }

        private async void BtnGetAll_Click(object sender, RoutedEventArgs e)
        {
            using (var conn = AppDatabase.GetDbConnection())
            {
                StringBuilder msg = new StringBuilder();
                var dbPerson = conn.Table<Person>();
                msg.AppendLine($"数据库中总共 {dbPerson.Count()} 个 Person 对象。");
                foreach (var person in dbPerson)
                {
                    msg.AppendLine($"Id：{person.Id}；Name：{person.Name}");
                }

                await new MessageDialog(msg.ToString()).ShowAsync();
            }
        }

    }
}
