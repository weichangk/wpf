using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfStudy._05属性
{
    class School: DependencyObject
    {
        //propa

        //CLR属性包装器
        public static int GetGrade(DependencyObject obj)
        {
            return (int)obj.GetValue(GradeProperty);
        }
        //CLR属性包装器
        public static void SetGrade(DependencyObject obj, int value)
        {   
            obj.SetValue(GradeProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //附加属性
        public static readonly DependencyProperty GradeProperty =
            DependencyProperty.RegisterAttached("Grade", typeof(int), typeof(School), new PropertyMetadata(0));


    }
}
