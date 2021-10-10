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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfStudy._09模板
{
    /// <summary>
    /// CarDetailView.xaml 的交互逻辑
    /// </summary>
    public partial class CarDetailView : UserControl
    {
        public CarDetailView()
        {
            InitializeComponent();
        }
        private Car _car;

        public Car Car
        {
            get { return _car; }
            set
            {
                _car = value;
                this.txtBlockName.Text = _car.Name;
                this.txtBlockAutoMark.Text = _car.AutoMark;
                this.txtBlockYear.Text = _car.Year;
                this.txtTopSpeed.Text = _car.TopSpeed;
                this.imgPhoto.Source = new BitmapImage(new Uri(@"pack://SiteOfOrigin:,,,/09模板/Image/" + _car.Name + ".jpg"));
            }
        }
    }
}
