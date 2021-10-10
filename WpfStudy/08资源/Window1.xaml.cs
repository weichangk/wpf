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

namespace WpfStudy._08资源
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            double txt = (double)this.FindResource("t1_db");
            t1_txt2.Text = txt.ToString();


            //t3_image1.Source = new BitmapImage(new Uri("pack://SiteOfOrigin:,,,/08资源/Resources/yawning-face.png"));

            t3_image4.Source = new BitmapImage(new Uri("pack://application:,,,/08资源/Resources/grinning-face-emoji.png"));
        }

        private void T2_Btn1(object sender, RoutedEventArgs e)
        {
            this.Resources["t2_res1"] = new TextBlock() { Text = "天涯共此时" };
            this.Resources["t2_res2"] = new TextBlock() { Text = "天涯共此时" };
        }
    }
}
