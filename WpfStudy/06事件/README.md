### WPF事件

#### 树形结构
<p>
路由(Route)：起点与终点间有若干个中转站，从起点出发后经过每中转站时要做出选择，最终以正确的路径到达终点。WPF事件的路由环境是UI组件树。WPF有两种树，一种叫逻辑树(Logical Tree)；一种叫可视元素树(Visual Tree)。Logical Tree最显著的特点就是它完全由布局组件和控件构成，它的每个结点不是布局组件就是控件。可视元素树基本上是逻辑树的一种扩展。逻辑树的每个结点都被分解为它们的核心可视化组件。逻辑树的结点对我们而言基本是一个黑盒。而可视元素树不同，它暴露了可视元素的实现细节。实际上WPF的事件处理是基于可视元素树(Visual Tree)的，而非逻辑树(Logical Tree)，而属性继承(Property Inheritance)以及资源查找(Resource Lookup)则是基于逻辑树的。WPF中还提供了遍历逻辑树和可视元素树的辅助类：System.Windows.LogicalTreeHelper和System.Windows.Media.VisualTreeHelper。
</p>

#### 事件的来龙去脉
事件模型
- 事件的拥有者：即消息的发送者。事件的宿主可以在某些条件下激发它拥有的事件，即事件被触发。事件被触发则消息被发送。
- 事件的响应者：即消息的接收者、处理者。事件接收者使用其事件处理器(Event Handler)对事件做出响应。
- 事件的订阅关系：事件的拥有者可以随时激发事件，但事件发生后会不会得到响应要看有没有事件的响应者，或者说要看这个事件是否被关注。如果对象A关注对象B的某个事件是否发生，则称A订阅了B的事件。更进一步讲，事件实际上是一个使用event关键字修饰的委托(Delegate)类型成员变量，事件处理器则是一个函数，说A订阅了B的事件，本质上就是让B.Event与A.EventHandler关联起来。所谓事件激发就是B.Event被调用，这时与其关联的A.EventHandler就会被调用。

CLR事件本质上是一个用event关键字修饰的委托实例。每对消息是“发送一响应”关系，必须建立显式的点对点订阅关系。事件的宿主必须能够直接访问事件的响应者，不然无法建立订阅关系。


#### WPF路由事件
<p>
路由事件的事件拥有者和事件响应者之间则没有直接显式的订阅关系，事件的拥有者只负责激发事件，事件将由谁响应它并不知道，事件的响应者则安装有事件侦听器，针对某类事件进行侦听，当有此类事件传递至此时事件响应者就使用事件处理器来响应事件并决定事件是否可以继续传递。

功能定义：路由事件是一种可以针对元素树中的多个侦听器（而不是仅针对引发该事件的对象）调用处理程序的事件。

实现定义：路由事件是由类的实例支持的 CLR 事件， RoutedEvent 由事件 Windows Presentation Foundation (WPF) 系统处理。
</p>

#### 路由事件的实现方式
路由事件是由类的实例支持并注册到事件系统的 CLR RoutedEvent WPF 事件。 从注册获取的实例通常保留为注册的类的字段成员，因此 RoutedEvent public static readonly "拥有"路由事件。 与同名 CLR 事件 (有时称为"包装器"事件) 通过重写 CLR 事件的 和 实现 add remove 完成。 通常，add 和 remove 保留为隐式默认值，该默认值使用特定于语言的相应事件语法来添加和删除该事件的处理程序。 路由事件支持机制和连接机制在概念上类似于依赖属性是类支持并注册到属性系统的 CLR DependencyProperty WPF 属性。

#### 路由策略
- 冒泡(Bubble)：调用事件源上的事件处理程序。 路由事件随后会路由到后续的父级元素，直到到达元素树的根。 大多数路由事件都使用冒泡路由策略。 浮升路由事件通常用于报告来自不同控件或其他 UI 元素的输入或状态变化。
- 直接(Direct)：只有源元素本身才有机会调用处理程序以进行响应。 这类似于窗体用于事件的Windows路由。 但是与标准 CLR 事件不同，直接路由事件支持类处理，并且可以使用 EventSetter EventTrigger 。
- 隧道(Tunnel)：最初将调用元素树的根处的事件处理程序。 随后，路由事件将朝着路由事件的源节点元素（即引发路由事件的元素）方向，沿路由线路传播到后续的子元素。 合成控件的过程中通常会使用或处理隧道路由事件，通过这种方式，可以有意地禁止复合部件中的事件，或者将其替换为特定于整个控件的事件。 在 WPF 中提供的输入事件通常是以隧道/浮升成对实现的。 隧道事件有时又称作预览事件，这是由该对所使用的命名约定决定的。

##### RoutedEventArgs的Source与OriginalSource
路由事件是沿着 VisualTree 传递的。VisualTree 和 LogicalTree 的区别在于 LogicalTree 的叶子节点是构成用户界面的控件，VisualTree 连控件的细微细节结构也算上。路由事件的消息包含在 RoutedEventArgs 实例中，包含两个属性 Source 和 OriginalSource，这两属性都表示路由事件传递的起点（事件消息的源头），Source 表示 LogicalTree 上的消息源头，OriginalSource 表示 VisualTree上 的消息源头。

##### 附加事件
路由事件的宿主都是拥有可视化实体的界面元素，而附加事件则不具备显示在用户界面上的能力。一样可以使用附加事件与其它对象进行沟通。附加属性是某对象在特定环境中才具备的属性，附加事件，是非UIElement想具备事件路由功能，所以是定义在非UIElemnt中，通过借用附加的UIElement的方法，实现路由事件的注册，注销，触发，附加事件的引发必须在由Ulement所派生的类，具体而言就是Ulement的RaiseEvent方法引发。附加属性如果不和事务处理在一起，或者不是由Ulement所派生的 ，附属事件的意义很小。附加事件不同附加属性。附加事件属于路由事件的一种。

- 附加事件由EventManager.RegisterRoutedEvent注册。此方法有四个参数：
    - 附加事件的唯一名称
    - 附加事件的路由策略
    - 附加事件的委托类型
    - 附加事件的所属

- 事件的注册标准分别为AddHandle和RemoveHandle的方法，两个方法的参数数量一致都是两个第一个是DependencyObject 类型，第二个则是和注册时第三个参数相同的类型。

- 像Button.Click这些路由事件，因为事件的宿主是界面元素、本身就是UI树上是一个结点，所以路由事件路由时的第一站就是事件的激发者。附加事件宿主不是UIElement的派生类，所以不能出现在UI树上的结点，而且附加事件的激发是借助UI元素实现的，因此，附加事件路由的第一站是激发它的元素。

- 实际上很少会把附加事件定义在Student这种与业务逻辑相关的类中，一般都是定义在像Binding、Mouse、Keyboard这种全局的Helper类中。如果需要业务逻辑类的对象能发送出路由事件来怎么办？我们不是有Binding吗！如果程序架构设计的好（使用数据驱动UI），那么业务逻辑一定会使用Binding对象与UI元素关联，一旦与业务逻辑相关的对象实现了INotifyPropertyChanged接口并且Binding对象的NotifyOnSourceUpdated属性设为true，则Binding就会激发其SourceUpdated附加事件，此事件会在UI元素树上路由并被侦听者捕获。

##### 自定义路由事件
创建自定义路由事件三步骤
- 声明并注册路由事件
- 为路由事件添加CLR事件包装
- 创建可以激发路由事件额方法

很多类的事件都是路由事件，如TextBox类的TextChanged事件、 Binding类的SourceUpdated事件等，所以在用到这些类型的时候不要墨守传统NET编程带来的习惯，要发挥自己的想象力让程序结构更加合理、代码更加简洁。路由事件虽好，但也不要滥用，举个例子，如果让所有Button (包括组件里的Button)的Click事件都传递到最外层窗体，让窗体捕捉并处理它，那么程序架构就变得毫无意义了。正确的办法是事件该由谁来捕捉处理，传到这个地方时就应该处理掉。

