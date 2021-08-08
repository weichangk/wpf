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

namespace WpfStudy._04Binding._02Binding源和路径._05Binding对数据的转换与校验
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //Binding binding = new("Value")
            //{
            //    Source = this.Slider1,
            //    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            //    NotifyOnValidationError= true,
            //};
            //binding.ValidationRules.Add(new RangeValidationRule() { 
            //    ValidatesOnTargetUpdated = true,
            //});

            //this.Txb1.SetBinding(TextBox.TextProperty, binding);
            //this.Txb1.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(this.ValidationError));
        }

        //void ValidationError(object sender, RoutedEventArgs e)
        //{
        //    if (Validation.GetErrors(this.Txb1).Count > 0)
        //    {
        //        if (Validation.GetErrors(this.Txb1).Count > 0)
        //        {
        //            //ToolTip没有显示。。。。
        //            this.Txb1.ToolTip = Validation.GetErrors(this.Txb1)[0].ErrorContent.ToString();
        //        }
        //    }

        //    TextBox textBox = sender as TextBox;
        //    if (textBox != null)
        //    {
        //        if (Validation.GetErrors(textBox).Count > 0)
        //        {
        //            Txb1ErrorMsg.Text = Validation.GetErrors(textBox)[0].ErrorContent.ToString();
        //        }
        //    }

        //}


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            List<Plane> infos = new List<Plane>() {
            new Plane(){ Category= Category.Bomber,Name="B-1", State= State.Unknown},
            new Plane(){ Category= Category.Bomber,Name="B-2", State= State.Unknown},
            new Plane(){ Category= Category.Fighter,Name="F-22", State= State.Locked},
            new Plane(){ Category= Category.Fighter,Name="Su-47", State= State.Unknown},
            new Plane(){ Category= Category.Bomber,Name="B-52", State= State.Available},
            new Plane(){ Category= Category.Fighter,Name="J-10", State= State.Unknown},
            };
            this.listBox1.ItemsSource = infos;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Plane item in listBox1.Items)
            {
                sb.AppendLine(string.Format("Categroy={0},Name={1}State={2},", item.Category, item.Name, item.State));
            }
            textBlockSave.Text = sb.ToString();
            //File.WriteAllText(@"D:\PlaneList.text", sb.ToString());
        }
    }
}
