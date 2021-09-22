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

namespace WpfStudy._06事件
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            //BtnClear.Click += ClearClick;
            BtnClear.AddHandler(Button.ClickEvent, new RoutedEventHandler(ClearClick));

        }   

        private int eventCounter = 0;
        private void SomethingClicked(object sender, RoutedEventArgs e)
        {
            eventCounter++;
            string messages = @$"# {eventCounter}:
                                Sender: {sender}
                                Source: {e.Source}
                                Original Source: {e.OriginalSource}";
            lstMsesages.Items.Add(messages);
            e.Handled = (bool)chkHandle.IsChecked;
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            eventCounter = 0;
            lstMsesages.Items.Clear();
        }

    }
}
