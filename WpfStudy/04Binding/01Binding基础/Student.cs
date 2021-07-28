using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudy._04Binding._01Binding基础
{
    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string Name 
        {
            set
            {
                this._name = value;
                //Name 属性值变化触发 PropertyChanged 事件
                //Binding 接收到这个事件后发现事件的消息告诉它是名为 Name 的属性发生了值的改变，于是就会通知 Binding 目标端的 UI 元素显示新的值。
                this.PropertyChanged ?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
            get
            {
                return this._name;
            }
        }
    }
}
