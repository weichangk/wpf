using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfStudy._06事件
{
    public class Person
    {
        //1.声明并定义路由事件
        //附加事件由EventManager.RegisterRoutedEvent注册
        //此方法有四个参数：
        //附加事件的唯一名称
        //附加事件的路由策略
        //附加事件的委托类型
        //附加事件的所属
        public static readonly RoutedEvent NameChangedEvent = EventManager.RegisterRoutedEvent("NameChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Person));

        //2.为界面元素添加路由事件侦听
        //事件的注册标准分别为AddHandle和RemoveHandle的方法，两个方法的参数数量一致都是两个第一个是DependencyObject 类型，第二个则是和注册时第三个参数相同的类型。
        public static void AddNameChangeHandle(DependencyObject o, RoutedEventHandler h)
        {
            if (o is UIElement e)
            {
                e.AddHandler(NameChangedEvent, h);
            }
        }
        //3.移除侦听
        public static void RemoveNameChangeHandle(DependencyObject o, RoutedEventHandler h)
        {
            if (o is UIElement e)
            {
                e.RemoveHandler(NameChangedEvent, h);
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
