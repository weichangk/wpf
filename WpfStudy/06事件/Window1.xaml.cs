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
            BtnClear2.AddHandler(Button.ClickEvent, new RoutedEventHandler(ClearClick2));

            t3.AddHandler(Button.ClickEvent, new RoutedEventHandler(ButtonClick));

            //附加事件，是非UIElement想具备事件路由功能，所以是定义在非UIElemnt中，通过借用附加的UIElement的方法，实现路由事件的注册，注销，触发
            //非UIElement对象的附加事件注册到UIElement对象中  (为外层TabItem添加路由事件)
            Person.AddNameChangeHandle(t4, PersonNameChanged);
        }

        #region 冒泡，隧道事件
        private int eventCounter = 0;
        private int eventCounter2 = 0;

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

        private void SomeKeyPressed(object sender, RoutedEventArgs e)
        {
            eventCounter2++;
            string messages = @$"# {eventCounter2}:
                                Sender: {sender}
                                Source: {e.Source}
                                Original Source: {e.OriginalSource}";
            lstMsesages2.Items.Add(messages);
            e.Handled = (bool)chkHandle2.IsChecked;
        }

        private void ClearClick2(object sender, RoutedEventArgs e)
        {
            eventCounter2 = 0;
            lstMsesages2.Items.Clear();
        }
        #endregion

        #region Original Source 与 Source
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string originSource = string.Format("VisualTree StartPoint:{0},type is {1}", (e.OriginalSource as FrameworkElement).Name, e.OriginalSource.GetType().Name);

            string stringSource = string.Format("LogicTree startPoint:{0},Type is {1}", (e.Source as FrameworkElement).Name, e.Source.GetType().Name);
            MessageBox.Show(originSource + "\r\n" + stringSource);
        }
        #endregion

        #region 附加事件
        //
        private void PersonNameChanged(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as Person).Name);
        }

        private void attachEvent_Click(object sender, RoutedEventArgs e)
        {
            Person persion = new Person();
            persion.Id = 0;
            persion.Name = "Darren";
            //准备事件消息并发送路由事件
            RoutedEventArgs arg = new RoutedEventArgs(Person.NameChangedEvent, persion);
            //附加事件的引发必须在由Ulement所派生的类，具体而言就是Ulement的RaiseEvent方法引发
            this.attachEventBtn.RaiseEvent(arg);
        }
        #endregion

        #region 自定义路由事件
        private void ReportTimeHandle(object sender, ReportTimeRoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            string timeStr = e.ClickTime.ToLongTimeString();
            string content = string.Format("{0}到达{1}", timeStr, element.Name);
            this.t5_ListBox1.Items.Add(content);
            if (element == t5_gd2)
            {
                //e.Handled = true;
            }
        }
        #endregion
    }
}
