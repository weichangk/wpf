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

namespace WpfStudy._04Binding._02Binding源和路径._03Binding的路径Path
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            //在 c# 中使用 SetBinding 为控件绑定 Binding 源的基本写法
            Binding binding = new Binding()
            {
                Path = new PropertyPath("Value"),//Path 的实际类型是 PropertyPath。
                Source = this.Slider,
            };
            this.TxbSliderValue.SetBinding(TextBox.TextProperty, binding);

            //简写
            //this.TxbSliderValue.SetBinding(TextBox.TextProperty, new Binding("Value") { Source = this.Slider });


            this.Txb3.SetBinding(TextBox.TextProperty, new Binding("Text.[3]") { Source = this.Txb1, Mode= BindingMode.OneWay});

            //使用斜线语法将集合默认元素作为 Path
            List<string> strList = new() { "foo", "bar", "baz", "qux"};
            this.Txb4.SetBinding(TextBox.TextProperty, new Binding("/") { Source = strList, Mode = BindingMode.OneWay });
            this.Txb5.SetBinding(TextBox.TextProperty, new Binding("/Length") { Source = strList, Mode = BindingMode.OneWay });
            this.Txb6.SetBinding(TextBox.TextProperty, new Binding("/[2]") { Source = strList, Mode = BindingMode.OneWay });

            //使用斜线语法将多层集合对象作为 Path
            List<Country> countryList = new List<Country>()
            {
                new Country()
                {
                    Name = "中国",
                    ProvinceList = new List<Province>()
                    { 
                        new Province()
                        {
                            Name = "广东",
                            CityList = new List<City>()
                            { 
                                new City()
                                {
                                    Name = "深圳"
                                }
                            }
                        }
                    }
                },
                new Country()
                {
                    Name = "foo",
                    ProvinceList = new List<Province>()
                    {
                        new Province()
                        {
                            Name = "bar",
                            CityList = new List<City>()
                            {
                                new City()
                                {
                                    Name = "baz"
                                }
                            }
                        }
                    }
                },
            };
            Console.WriteLine(countryList);

            this.Txb7.SetBinding(TextBox.TextProperty, new Binding("/Name") { Source = countryList, Mode = BindingMode.OneWay });
            this.Txb8.SetBinding(TextBox.TextProperty, new Binding("/ProvinceList/Name") { Source = countryList, Mode = BindingMode.OneWay });
            this.Txb9.SetBinding(TextBox.TextProperty, new Binding("/ProvinceList/CityList/Name.Length") { Source = countryList, Mode = BindingMode.OneWay });

            string TextBlockStr = "没有 Path 的 Binding";
            this.Tbk2.SetBinding(TextBlock.TextProperty, new Binding(".") { Source = TextBlockStr });
        }

        class City
        {
            public string Name { get; set; }
        }
        class Province
        {
            public string Name { get; set; }
            public List<City> CityList { get; set; }
        }
        class Country
        {
            public string Name { get; set; }
            public List<Province> ProvinceList { get; set; }
        }
    }
}
