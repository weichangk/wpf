using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfStudy._06事件
{
    public class TimeButton : Button
    {
        //声明和注册路由事件
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent("ReportTime", RoutingStrategy.Bubble, typeof(EventHandler<ReportTimeRoutedEventArgs>), typeof(TimeButton));

        //为路由事件添加CLR事件包装
        public event RoutedEventHandler ReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }

        //创建可以激发路由事件额方法
        protected override void OnClick()
        {
            base.OnClick();//确保原有功能正常使用

            ReportTimeRoutedEventArgs args = new ReportTimeRoutedEventArgs(ReportTimeEvent, this) { ClickTime = DateTime.Now };

            this.RaiseEvent(args);
        }
    }
}
