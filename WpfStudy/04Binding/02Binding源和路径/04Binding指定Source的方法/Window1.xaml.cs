using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfStudy._04Binding._02Binding源和路径._04Binding指定Source的方法
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void BtnShowDataContext_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.BtnShowDataContext.DataContext.ToString());//如果控件有多层DataContext只会使用最近的DataContext。
            MessageBox.Show(this.BtnHelloDatacontext.DataContext.ToString());
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
