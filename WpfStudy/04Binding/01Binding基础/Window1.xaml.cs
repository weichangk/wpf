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

namespace WpfStudy._04Binding._01Binding基础
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        Student stu;
        public Window1()
        {
            InitializeComponent();

            //1. 准备数据源
            stu = new Student();

            //2. 准备Binding
            Binding binding = new Binding();

            //3. Binding 的源(Source)指向逻辑对象
            binding.Source = stu;

            //4. Binding 的路径(Path)指向要监听的对象属性
            binding.Path = new PropertyPath(nameof(stu.Name));

            //5. 使用连接 Binding 的源(Source)和目标(Target)
            BindingOperations.SetBinding(this.TxbName, TextBox.TextProperty, binding);//三参数：目标，目标依赖属性，binding对象
        }

        private void BtnAddName_Click(object sender, RoutedEventArgs e)
        {
            stu.Name += "Hello Binding! ";
        }

        private void BtnGetName_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(stu.Name);
        }
    }
}
