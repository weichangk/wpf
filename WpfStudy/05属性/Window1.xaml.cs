using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace WpfStudy._05属性
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
            stu = new Student();
            //将依赖对象stu的依赖属性NameProperty绑定到TxbName的Text上
            stu.SetBinding(Student.NameProperty, new Binding("Text") { Source = this.TxbName });
            //将TxbName1的依赖属性TextProperty绑定到stu的Name上
            this.TxbName1.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = stu });
            stu.SetBinding(Student.AgeProperty, new Binding("Text") { Source = this.TxbAge });
            this.TxbAge1.SetBinding(TextBox.TextProperty, new Binding("Age") { Source = stu });
        }

        private void BtnAttached_Click(object sender, RoutedEventArgs e)
        {
            Human human = new Human();
            School.SetGrade(human, 1);
            int grade = School.GetGrade(human);
            MessageBox.Show(grade.ToString());
            //foreach (System.Reflection.PropertyInfo p in human.GetType().GetProperties())
            //{
            //    Console.WriteLine("Name:{0} Value:{1}", p.Name, p.GetValue(human));
            //}

            Type t = human.GetType();
            PropertyInfo[] PropertyList = t.GetProperties();
            foreach (PropertyInfo item in PropertyList)
            {
                string name = item.Name;
                object value = item.GetValue(human, null);
                MessageBox.Show($"Name:{name} Value:{value}");
            }
        }
    }

    class Human : DependencyObject
    { 

    }
}
