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

namespace WpfStudy._09模板
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            InitialCarList();


            //XmlDataProvider xdp = new XmlDataProvider
            //{
                
            //    Source = new Uri($"{System.AppDomain.CurrentDomain.BaseDirectory}04Binding\\02Binding源和路径\\04Binding指定Source的方法\\StudentList.xml"),
            //    XPath = @"/StudentList/Student"
            //};

            //this.LsvGradeDataXml.DataContext = xdp;
            //this.LsvGradeDataXml.SetBinding(ListView.ItemsSourceProperty, new Binding());
        }

        private void InitialCarList()
        {
            List<Car> infos = new List<Car>() {
            new Car(){ AutoMark="Aodi", Name="Aodi", TopSpeed="200", Year="1990"},
            new Car(){ AutoMark="Aodi", Name="Aodi", TopSpeed="250", Year="1998"},
            new Car(){ AutoMark="Aodi", Name="Aodi", TopSpeed="300", Year="2002"},
            new Car(){ AutoMark="Aodi", Name="Aodi", TopSpeed="350", Year="2011"},
            new Car(){ AutoMark="Aodi", Name="Aodi", TopSpeed="500", Year="2020"}
            };
            foreach (Car item in infos)
            {
                CarListViewItem viewItem = new CarListViewItem();
                viewItem.Car = item;
                this.listBoxCars.Items.Add(viewItem);
            }

            //
            this.t2_listBoxCars.ItemsSource = infos;
        }

        private void listBoxCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarListViewItem viewItem = e.AddedItems[0] as CarListViewItem;
            if (viewItem != null)
            {
                carDetailView1.Car = viewItem.Car;
            }
        }
    }
}
