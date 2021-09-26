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

namespace WpfStudy._07命令
{
    /// <summary>
    /// MniView.xaml 的交互逻辑
    /// </summary>
    public partial class MniView : UserControl, IView
    {
        public MniView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 用于清除内容的业务逻辑
        /// </summary>
        public void Clear()
        {
            this.txt1.Clear();
            this.txt2.Clear();
            this.txt3.Clear();
            this.txt4.Clear();
        }

    }
}
