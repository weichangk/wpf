using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudy._04Binding._04ObjectDataProvider的使用
{
    public class Calculator
    {
        public string Add(string a, string b)
        {
            if (double.TryParse(a, out double aa) && double.TryParse(b, out double bb))
            {
                return (aa + bb).ToString();
            }
            return "Input error";
        }
    }
}
