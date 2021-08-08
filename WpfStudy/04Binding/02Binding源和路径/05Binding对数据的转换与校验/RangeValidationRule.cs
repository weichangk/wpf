using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfStudy._04Binding._02Binding源和路径._05Binding对数据的转换与校验
{
    public class RangeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (double.TryParse(value.ToString(), out double d))
            {
                if (d >= 0 && d<= 100)
                {
                    return new ValidationResult(true, null);
                }
            }
            return new ValidationResult(false, "数据校验失败");
        }
    }
}
