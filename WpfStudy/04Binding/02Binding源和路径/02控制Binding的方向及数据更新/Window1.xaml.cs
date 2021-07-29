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

namespace WpfStudy._04Binding._02Binding源和路径._02控制Binding的方向及数据更新
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

        private void BtnExplicit_Click(object sender, RoutedEventArgs e)
        {
            //调用UpdateSource方法时才会触发目标更新
            BindingExpression be = Txt5.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }

        private void Txt7_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            MessageBox.Show("SourceUpdated: " + e.Source.ToString());
        }

        private void Txt7_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            MessageBox.Show("TargetUpdated: " + e.Source.ToString());
        }
    }
}
