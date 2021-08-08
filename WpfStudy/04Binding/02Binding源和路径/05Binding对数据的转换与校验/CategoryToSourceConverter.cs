using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfStudy._04Binding._02Binding源和路径._05Binding对数据的转换与校验
{
    public class CategoryToSourceConverter : IValueConverter
    {
        //将飞机类型转图片url
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Category category = (Category)value;
            switch (category)
            {
                case Category.Bomber:
                    return $"{System.AppDomain.CurrentDomain.BaseDirectory}img\\Bomber.png";
                case Category.Fighter:
                    return $"{System.AppDomain.CurrentDomain.BaseDirectory}img\\Fighter.png";   
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
