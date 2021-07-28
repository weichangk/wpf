### wpf
WPF作为一种专门的展示层技术，华丽的外观和动画只是它的表层现象，更重要的是它在深层次上帮助程序员把思维的重心固定在了逻辑层、让展示层永远处于逻辑层的从属地位。
WPF具有这种能力的关键是它引入了 Data Binding 概念以及与之配套的 Dependency Property 系统和 DataTemplate。

展示层使用WPF类库来实现，而展示层与逻辑层的沟通使用 Data Binding 来实现。Data Binding 在 WPF 系统中起到的是数据高速公路的作用。
有了这条高速公路，加工好的数据会自动送达用户界面加以显示，被用户修改过的数据也会自动传回逻辑层，一旦数据被加工好又会被送达用户界。
程序的逻辑层就像一个强有力的引擎不停运转，用加工好的数据驱动程序的用户界面以文字、图形、动画等形式把数据显示出来，这就是“数据驱动UI”。
Binding 比作数据桥梁，它的两端分别是 Binding 的源(Source)和目标(Target)。Binding 源是逻辑层的对象, Binding 目标是 U1 层的控件对象。


#### Binding基础
数据源是一个对象，一个对象身上可能有很多数据，这些数据又通过属性暴露给外界。其中哪个数据是想通过 Binding 送达 UI 元素的呢？换句话说, UI上的元素关心的是哪个属性值的变化呢？
这个属性就称为Binding的路径(Path)，但光有属性还不行，Binding是一种自动机制，当值变化后属性要有能力通知 Binding，让Binding把变化传递给UI元素。
怎样才能让一个属性具备这种通知 Binding 值已经变化的能力呢?
方法是在属性的 set 语句中激发一个 PropertyChanged 事件。让作为数据源的类实现 System.ComponentModel 名称空间中的 INotifyPropertyChanged 接口。
当为Binding设置了数据源后，Binding 就会自动侦听来自这个接口的 PropertyChanged 事件。


#### Binding源(Source)和路径(Path)
Binding 的源也就是数据的源头。Binding对源的要求并不苛刻，只要它是一个对象，并且通过属性(Property)公开自己的数据，它就能作为Binding的源。
想让作为Binding源的对象具有自动通知Binding自己的属性值已经变化的能力，需要让类实现 INotifyPropertyChanged 接口，并在属性的 set 语句中激发 PropertyChanged 事件。
除了使用这种对象作为数据源外，还有更多的选择，比如控件把自己或自己的容器或子级元素当源、用一个控件作为另一个控件的数据源、把集合作为 ItemsControl 的数据源、使用 XML 作为 TreeView 或 Menu 的数据源、把多个控件关联到一个“数据制高点”上，甚至干脆不给Binding指定数据源、让它自己去找。


###### 把控件作为Binding源与Binding标志扩展
在xaml中使用Binding标志扩展将控件作为其它控件的Binding源

###### 控制Binding的方向及数据更新
	
