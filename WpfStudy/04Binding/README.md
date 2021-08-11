## Binding
https://docs.microsoft.com/zh-cn/dotnet/desktop/wpf/data/data-binding-overview?view=netframeworkdesktop-4.8

WPF作为一种专门的展示层技术，华丽的外观和动画只是它的表层现象，更重要的是它在深层次上帮助程序员把思维的重心固定在了逻辑层、让展示层永远处于逻辑层的从属地位。
WPF具有这种能力的关键是它引入了 Data Binding 概念以及与之配套的 Dependency Property 系统和 DataTemplate。

展示层使用WPF类库来实现，而展示层与逻辑层的沟通使用 Data Binding 来实现。Data Binding 在 WPF 系统中起到的是数据高速公路的作用。
有了这条高速公路，加工好的数据会自动送达用户界面加以显示，被用户修改过的数据也会自动传回逻辑层，一旦数据被加工好又会被送达用户界。
程序的逻辑层就像一个强有力的引擎不停运转，用加工好的数据驱动程序的用户界面以文字、图形、动画等形式把数据显示出来，这就是“数据驱动UI”。
Binding 比作数据桥梁，它的两端分别是 Binding 的源(Source)和目标(Target)。Binding 源是逻辑层的对象, Binding 目标是 U1 层的控件对象。


### Binding 基础
数据源是一个对象，一个对象身上可能有很多数据，这些数据又通过属性暴露给外界。其中哪个数据是想通过 Binding 送达 UI 元素的呢？换句话说, UI上的元素关心的是哪个属性值的变化呢？
这个属性就称为Binding的路径(Path)，但光有属性还不行，Binding是一种自动机制，当值变化后属性要有能力通知 Binding，让Binding把变化传递给UI元素。
怎样才能让一个属性具备这种通知 Binding 值已经变化的能力呢?
方法是在属性的 set 语句中激发一个 PropertyChanged 事件。让作为数据源的类实现 System.ComponentModel 名称空间中的 INotifyPropertyChanged 接口。
当为Binding设置了数据源后，Binding 就会自动侦听来自这个接口的 PropertyChanged 事件。


### Binding 源(Source)和路径(Path)
Binding 的源也就是数据的源头。Binding对源的要求并不苛刻，只要它是一个对象，并且通过属性(Property)公开自己的数据，它就能作为Binding的源。
想让作为Binding源的对象具有自动通知Binding自己的属性值已经变化的能力，需要让类实现 INotifyPropertyChanged 接口，并在属性的 set 语句中激发 PropertyChanged 事件。
除了使用这种对象作为数据源外，还有更多的选择，比如控件把自己或自己的容器或子级元素当源、用一个控件作为另一个控件的数据源、把集合作为 ItemsControl 的数据源、使用 XML 作为 TreeView 或 Menu 的数据源、把多个控件关联到一个“数据制高点”上，甚至干脆不给Binding指定数据源、让它自己去找。


#### 把控件作为 Binding 源与 Binding 标志扩展
在xaml中使用Binding标志扩展将控件作为其它控件的Binding源
大多数 UIElement 属性都是依赖属性，而大多数依赖属性（只读属性除外）默认支持数据绑定。（仅派生自 DependencyObject 的类型才能定义依赖属性；所有 UIElement 类型都派生自 DependencyObject。）

#### 控制 Binding 的方向及数据更新
控制 Binding 数据流向的属性是 Mode，它的类型是 BindingMode 枚举。BindingMode 可取值为 TwoWay, OneWay, OnTime，OneWayToSource和Default。
Default 值是指 Binding 的模式会根据目标的实际情况来确定，比如若是可编辑的(如TextBox.Text属性), Default 就采用双向模式；若是只读的(如TextBlock.Text)则采用单向模式。

- OneWay 对源属性的更改会自动更新目标属性，但对目标属性的更改不会传播回源属性。 如果绑定的控件为隐式只读，则此类型的绑定适用。
- TwoWay 更改源属性或目标属性时会自动更新另一方。 此类型的绑定适用于可编辑窗体或其他完全交互式 UI 方案。大多数属性默认为 OneWay 绑定，但某些依赖属性（通常为用户可编辑控件的属性，例如 TextBox.Text 和 CheckBox.IsChecked）默认为 TwoWay 绑定。 用于确定依赖属性绑定在默认情况下是单向还是双向的编程方法是：使用 DependencyProperty.GetMetadata 获取属性元数据，然后检查 FrameworkPropertyMetadata.BindsTwoWayByDefault 属性的布尔值。
- OneWayToSource 与 OneWay 绑定相反；当目标属性更改时，它会更新源属性。 示例方案是只需要从 UI 重新计算源值的情况。
- OneTime 会使源属性初始化目标属性，但不传播后续更改。 如果数据上下文发生更改，或者数据上下文中的对象发生更改，则更改不会在目标属性中反映。 如果适合使用当前状态的快照或数据实际为静态数据，则此类型的绑定适合。 如果你想使用源属性中的某个值来初始化目标属性，且提前不知道数据上下文，则此类型的绑定也有用。 此模式实质上是 OneWay 绑定的一种简化形式，它在源值不更改的情况下提供更好的性能。

触发源更新的因素：
TwoWay 或 OneWayToSource 绑定侦听目标属性中的更改，并将更改传播回源（称为更新源）。例如，可以编辑文本框的文本以更改基础源值。
Binding.UpdateSourceTrigger 属性确定触发源更新的因素。
不同的依赖属性具有不同的默认 UpdateSourceTrigger 值。 大多数依赖属性的默认值为 PropertyChanged，而 TextBox.Text 属性的默认值为 LostFocus。 PropertyChanged 表示源更新通常在每次目标属性更改时发生。 即时更改适用于 CheckBox 和其他简单控件。 但对于文本字段，每次击键后都进行更新会降低性能，用户也没有机会在提交新值之前使用 Backspace 键修改键入错误。

- LostFocus（TextBox.Text 的默认值）。控件失去焦点时触发。
- PropertyChanged 每次目标属性更改时触发。
- Explicit 仅在应用程序调用UpdateSource方法时才会触发。

Binding 还具有 NotifyOnSourceUpdated 和 NotifyOnTargetUpdated 两个 bool 类型的属性。如果设为true，则当源或目标被更新后 Binding 会激发相应的 SourceUpdated 事件和 TargetUpdated 事件，可以通过监听这两个事件来找出有哪些数据或控件被更新了。


#### Binding 的路径 Path
在 XAML 代码中或者 Binding 类的构造器参数列表中以一个字符串来表示 Path，但 Path 的实际类型是 PropertyPath。
Binding 的路径 Path 还支持多级路径(就是一路 . 下去)，可以点属性，如果数据类型有所引器则可以点索引 .[index]。
如果 Binding 的路径 Path 是集合类型，可以使用斜线语法，如果集合的属性还是集合可以使用多级斜线语法，一路 / 下去。

没有 Path 的 Binding
Binding 源本身就是数据可以不需要 Path 来指明。典型的, string、 int等基本类型就是这样，他们的实例本身就是数据，无法指出通过它的哪个属性来访问这个数据，这时只需将 Path 的值设置为“." 就可以了。在XAML代码里这个 "." 可以省略不写，但在C#代码里却不能省略。


#### 为 Binding 指定源(Source)的几种方法
Binding 的源是数据的来源，所以只要一个对象包含数据并能通过属性把数据暴露出来，它就能当作Binding的源来使用。必须为 Binding 的 Source 指定合适的对象，Binding 才能正确工作，常见的办法有：

- 把普通CLR类型单个对象指定为Source：包括.NET Framework自带类型的对象和用户自定义类型的对象。如果类型实现了INotifyPropertyChanged接口，则可通过在属性的set语句里激发PropertyChanged事件来通知Binding数据已被更新。
- 把普通CLR集合类型对象指定为Source：包括数组、List<T>、 ObservableCollection<T>等集合类型。一般是把控件的ItemsSource属性使用Binding关联到一个集合对象上。
- 把ADO.NET数据对象指定为Source：包括DataTable和DataView等对象。
- 使用XmlDataProvider把XML数据指定为Source：XML作为标准的数据存储和传输格式几乎无处不在，可以用它表示单个数据对象或者集合；一些WPF控件是级联式的(如TreeView和Menu)，可以把树状结构的XML数据作为源指定给与之关联的Binding。
- 把依赖对象(Dependency Object)指定为Source：依赖对象不仅可以作为Binding的目标，同时也可以作为Binding的源。这样就有可能形成Binding链。依赖对象中的依赖属性可以作为Binding的Path。
- 把容器的DataContext指定为Source (WPF Data Binding的默认行为)：有时候会遇到这样的情况，已经明确知道将从哪个属性获取数据，但具体把哪个对象作为Binding源还不能确定。这时候，只能先建立一个Binding、只给它设置Path而不设置Source,让这个Binding自己去寻找Source，Binding会自动把控件的DataContext当作自己的Source(它会沿着控件树一层一层向外找，直到找到带有Path指定属性的对象为止)。
- 通过ElementName指定Source：在C#代码里可以直接把对象作为Source赋值给Binding，但XAML无法访问对象，所以只能使用对象的Name属性来找到对象。
- 通过Binding的RelativeSource属性相对地指定Source：当控件需要关注自己的、自己容器的或者自己内部元素的某个值就需要使用这种办法。
- 把ObjectDataProvider对象指定为Source：当数据源的数据不是通过属性而是通过方法暴露给外界的时候,可以使用这两种对象来包装数据源再把它们指定为Source。
- 把使用LINQ检索得到的数据对象作为Binding的源。

##### 使用DataContext作为Binding的源
- 当UI上的多个控件都使用Binding关注同一个对象时,可以使用DataContext。
- 当作为Source的对象不能被直接访问的时候。比如B窗体内的控件想把A窗体内的控件当作自己的Binding源时，但A窗体内的控件是private访问级别，这时候就可以把这个控件(或者控件的值)作为窗体A的DataContext (这个属性是public访问级别的)从而暴露数据。
- 外层或同层级容器的DataContext就相当于一个数据的“制高点”，只要把数据放上去，别的元素就都能看见。DataContext本身也是一个依赖属性，我们可以使用Binding把它关联到一个数据源上。

##### 使用集合对象作为列表控件的ItemsSource
WPF中的列表式控件们派生自ItemsControl类，自然也就继承了ItemsSource这个属性。ItemsSource属性可以接收一个IEnumerable接口派生类的实例作为自己的值(所有可被迭代遍历的集合都实现了这个接口，包括数组、List<T>等)，每个ItemsControl的派生类都具有自己对应的条目容器(Item Container)，例如, ListBox的条目容器是ListBoxltem、ComboBox的条目容器是ComhoBoxltem，ItemsSource里存放的是一条一条的数据。
依靠Binding，只要为一个ItemsControl对象设置了itemsSource属性值，Itemslontrol对象就会自动迭代其中的数据元素、为每个数据元素准备一个条目容器，并使用Binding在条目容器与数据元素之间建立起关联。
在xaml中可以使用DataTemplate实现对集合对象的数据绑定。
使用集合类型作为列表控件的ItemsSource时一般会考虑使用ObservableCollection<T>代替List<T>因为ObservableCollection<T>类实现了INotifyCollectionChanged和INotifyPropertyChanged接口，能把集合的变化立刻通知显示它的列表控件。实例中发现List<T>也可以更新变化。。。

##### 使用ADO.NET对象作为Binding的源
DataTable不能直接拿来为ItemsSource赋值，需要DataTable.DefaultView。但是把DataTable对象放在一个对象的DataContext属性里，并把ItemsSource与一个既没有指定Source又没有指定Path的Binding关联起来时, Binding却能自动找到它的DefaultView并当作自己的Source来使用。


##### 使用XML数据作为Binding的源
当使用XML数据作为Binding的Source时将使用XPath属性而不是Path属性来指定数据的来源。
在xaml中Binding XPath使用@符号加字符串表示的是XML元素的Attribute，不加@符号的字符串表示的是子级元素。


#### Binding对数据的转换与校验
Binding用于数据有效性校验的关卡是它的ValidationRules属性，用于数据类型转换的关卡是它的Converter属性。

##### Binding的数据校验
Binding的ValidationRules属性类型是Collection<ValidationRule>，从它的名称和数据类型可以得知可以为每个Binding设置多个数据校验条件，每个条件是一个ValidationRule类型对象。
ValidationRule类是个抽象类，在使用的时候我们需要创建它的派生类并实现它的Validate方法。
Validate方法的返回值是ValidationResult类型对象，如果校验通过，就把ValidationResult对象的IsValid属性设为true，反之，需要把IsValid属性设为false并为其ErrorContent属性设置一个合适的消息内容(一般是个字符串)。

Binding进行校验时的默认行为是认为来自Source的数据总是正确的，只有来自Target的数据才有可能有问题。当要校验来自Source的数据也有可能出问题时，需要将校验条件的ValidatesOnTargetUpdated属性设为true.

在创建Binding时要把Binding对象的NotifyOnValidationError属性设为true，这样当数据校验失败的时候Binding会像报警器一样发出一个信号，这个信号会以Binding对象的Target为起点在UI元素树上传播。
信号每到达一个结点，如果这个结点上设置有对这种信号的侦听器(事件处理器)，那么这个侦听器就会被触发用以处理这个信号。信号处理完后还可以选择是让信号继续向下传播还是就此终止--这就是路由事件，信号在UI元素树上的传递过程就称为路由(Route)。


##### Binding的数据转换
创建一个类并让这个类实现IValueConverter接口。IValueConverter接口定义如下:
object Convert(object value, Type targetType, object parameter, CultureInfo culture);
object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

#### MultiBinding
有的时候UI要需要显示的信息由不止一个数据来源决定，这时候就需要使用MultiBinding，即多路Binding。
MultiBinding与Binding一样均以BindingBase为基类，也就是说，凡是能使用Binding对象的场合都能使用MultiBinding，
MultiBinding具有一个名为Bindings的属性，其类型是Collection<BindingBase>，
通过这个属性MultiBinding把一组Binding对象聚合起来，处在这个集合中的Binding对象可以拥有自己的数据校验与转换机制，
它们汇集起来的数据将共同决定传往MultiBinding目标的数据。








