using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

            #region 使用集合对象作为列表控件的ItemsSource：
            List<Student> stuList = new List<Student>()
            {
                new Student(){ Id = 0, Name = "Foo", Age = 0},
                new Student(){ Id = 1, Name = "Bar", Age = 1},
                new Student(){ Id = 2, Name = "Baz", Age = 2},
                new Student(){ Id = 3, Name = "Qux", Age = 3},
            };
            //为LsbStuList设置Binding
            this.LsbStuList.ItemsSource = stuList;
            this.LsbStuList.DisplayMemberPath = "Name";//显示对象成员路径
            //为TxtStuId设置Binding
            this.TxtStuId.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.Id") { Source = this.LsbStuList });//this.LsbStuList.SelectedItem 选中的成员
            #endregion

            #region 使用DataTemplate
            List<Student> stuList1 = new List<Student>()
            {
                new Student(){ Id = 4, Name = "Foo", Age = 4},
                new Student(){ Id = 5, Name = "Bar", Age = 5},
                new Student(){ Id = 6, Name = "Baz", Age = 6},
                new Student(){ Id = 7, Name = "Qux", Age = 7},
            };
            //为LsbStuList1设置Binding
            this.LsbStuList1.ItemsSource = stuList1;

            //为TxtStuId1设置Binding
            this.TxtStuId1.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.Id") { Source = this.LsbStuList1 });
            #endregion


            #region ObservableCollection<T>代替List<T>
            ObservableCollection<Student> stuObs = new ObservableCollection<Student>()
            {
                new Student(){ Id = 8, Name = "Foo", Age = 8},
                new Student(){ Id = 9, Name = "Bar", Age = 9},
                new Student(){ Id = 10, Name = "Baz", Age = 10},
                new Student(){ Id = 11, Name = "Qux", Age = 12},
            };
            this.LsbStuObs.ItemsSource = stuObs;
            this.TxtStuAge.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.Age") { Source = this.LsbStuObs });
            #endregion

            #region 使用ADO.NET对象作为Binding的源

            #endregion
        }

        #region 使用DataContext作为Binding的源
        private void BtnShowDataContext_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.BtnShowDataContext.DataContext.ToString());//如果控件有多层DataContext只会使用最近的DataContext。
            MessageBox.Show(this.BtnHelloDatacontext.DataContext.ToString());
        }
        #endregion

        #region 使用ADO.NET对象作为Binding的源
        private void BtnLoadDataTable_Click(object sender, RoutedEventArgs e)
        {
            List<Student> stuList = new List<Student>()
            {
                new Student(){ Id = 12, Name = "Foo", Age = 12},
                new Student(){ Id = 13, Name = "Bar", Age = 13},
                new Student(){ Id = 14, Name = "Baz", Age = 14},
                new Student(){ Id = 15, Name = "Qux", Age = 15},
            };
            DataTable dt = stuList.ListToDt();
            this.LsvStudents.ItemsSource = dt.DefaultView;
        }
        #endregion

    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    static class Extensions
    {
        public static DataTable ListToDt<T>(this IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new
            DataColumn(p.Name, p.PropertyType)).ToArray());
            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }
    }
}
