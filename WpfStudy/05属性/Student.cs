using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfStudy._05属性
{
    //依赖对象
    class Student: DependencyObject
    {
        //依赖属性
        //第1个参数为string类型，用这个参数来指明以哪个CLR属性作为这个依赖属性的包装器，或者说此依赖属性支持(back)的是哪个CLR属性。
        //第2个参数用来指明此依赖属性用来存储什么类型的值
        //第3个参数用来指明此依赖属性的宿主是什么类型，或者说DependencyProperty.Register方法将把这个依赖属性注册关联到哪个类型上。
        //第4个参数的类型是PropertyMetadata类。DefaultMetadata的作用是向依赖属性的调用者提供一些基本信息
        public static readonly DependencyProperty NameProperty = 
            DependencyProperty.Register("Name", typeof(string), typeof(Student));

        //CLR属性包装器
        public string Name 
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        //SetBinding包装
        public BindingExpressionBase SetBinding(DependencyProperty dp, Binding binding)
        {
            return BindingOperations.SetBinding(this, dp, binding);
        }



        //propdp  tab tab

        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AgeProperty =
            DependencyProperty.Register("Age", typeof(int), typeof(Student), new PropertyMetadata(0));



    }
}
