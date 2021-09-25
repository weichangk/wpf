using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfStudy._06事件
{
    /// <summary>
    /// 用于承载时间消息的事件参数
    /// </summary>
    public class ReportTimeRoutedEventArgs : RoutedEventArgs
    {
        public ReportTimeRoutedEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source) { }

        public DateTime ClickTime { get; set; }
    }
}
