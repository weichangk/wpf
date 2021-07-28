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

namespace WpfStudy._04Binding._02Binding源和路径._01把控件作为Binding源与Binding标志扩展
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            //在c#代码中建立Binding
            //this.TxbSliderValue.SetBinding(TextBox.TextProperty, new Binding("Value") { ElementName = "Slider" });
            //因为在c#代码中可以直接访问控件对象,所以一般也不会使用 Binding 的 ElementName 属性，而是直接把对象赋值给 Binding 的 Source 属性
            //this.TxbSliderValue.SetBinding(TextBox.TextProperty, new Binding("Value") { Source = this.Slider });
        }
    }
}
