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
大多数 UIElement 属性都是依赖属性，而大多数依赖属性（只读属性除外）默认支持数据绑定。（仅派生自 DependencyObject 的类型才能定义依赖属性；所有 UIElement 类型都派生自 DependencyObject。）

###### 控制Binding的方向及数据更新
控制 Binding 数据流向的属性是 Mode，它的类型是 BindingMode 枚举。BindingMode 可取值为 TwoWay, OneWay, OnTime，OneWayToSource和Default。
Default 值是指 Binding 的模式会根据目标的实际情况来确定，比如若是可编辑的(如TextBox.Text属性), Default 就采用双向模式；若是只读的(如TextBlock.Text)则采用单向模式。

- OneWay 对源属性的更改会自动更新目标属性，但对目标属性的更改不会传播回源属性。 如果绑定的控件为隐式只读，则此类型的绑定适用。
- TwoWay 更改源属性或目标属性时会自动更新另一方。 此类型的绑定适用于可编辑窗体或其他完全交互式 UI 方案。大多数属性默认为 OneWay 绑定，但某些依赖属性（通常为用户可编辑控件的属性，例如 TextBox.Text 和 CheckBox.IsChecked）默认为 TwoWay 绑定。 用于确定依赖属性绑定在默认情况下是单向还是双向的编程方法是：使用 DependencyProperty.GetMetadata 获取属性元数据，然后检查 FrameworkPropertyMetadata.BindsTwoWayByDefault 属性的布尔值。
- OneWayToSource 与 OneWay 绑定相反；当目标属性更改时，它会更新源属性。 示例方案是只需要从 UI 重新计算源值的情况。
- OneTime 会使源属性初始化目标属性，但不传播后续更改。 如果数据上下文发生更改，或者数据上下文中的对象发生更改，则更改不会在目标属性中反映。 如果适合使用当前状态的快照或数据实际为静态数据，则此类型的绑定适合。 如果你想使用源属性中的某个值来初始化目标属性，且提前不知道数据上下文，则此类型的绑定也有用。 此模式实质上是 OneWay 绑定的一种简化形式，它在源值不更改的情况下提供更好的性能。

触发源更新的因素
TwoWay 或 OneWayToSource 绑定侦听目标属性中的更改，并将更改传播回源（称为更新源）。例如，可以编辑文本框的文本以更改基础源值。
Binding.UpdateSourceTrigger 属性确定触发源更新的因素。
不同的依赖属性具有不同的默认 UpdateSourceTrigger 值。 大多数依赖属性的默认值为 PropertyChanged，而 TextBox.Text 属性的默认值为 LostFocus。 PropertyChanged 表示源更新通常在每次目标属性更改时发生。 即时更改适用于 CheckBox 和其他简单控件。 但对于文本字段，每次击键后都进行更新会降低性能，用户也没有机会在提交新值之前使用 Backspace 键修改键入错误。

- LostFocus（TextBox.Text 的默认值）。控件失去焦点时触发。
- PropertyChanged 每次目标属性更改时触发。
- Explicit 仅在应用程序调用UpdateSource方法时才会触发。

Binding 还具有 NotifyOnSourceUpdated 和 NotifyOnTargetUpdated 两个 bool 类型的属性。如果设为true，则当源或目标被更新后 Binding 会激发相应的 SourceUpdated 事件和 TargetUpdated 事件，可以通过监听这两个事件来找出有哪些数据或控件被更新了。



















