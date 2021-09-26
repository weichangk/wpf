### 命令

#### 命令系统的基本元素
- 命令(Command)：WPF的命令实际上就是实现了ICommand接口的类，平时使用最多的就是RoutedCommand类。还可以使用自定义命令。
- 命令源(Command Source)：即命令的发送者，是实现了ICommandSource接口的类。很多界面元素都实现了这个接口，其中包括Button,ListBoxItem,MenuItem等。
- 命令目标(Command Target)：即命令发送给谁，或者说命令作用在谁的身上。命令目标必须是实现了IInputElement接口的类。
- 命令关联(Command Binding)：负责把一些外围逻辑和命令关联起来，比如执行之前对命令是否可以执行进行判断、命令执行之后还有哪些后续工作等。

#### 命令系统的基本元素之间的关系 
- 创建命令类：即获得一个实现ICommand接口的类，如果命令与具体的业务逻辑无关则使用WPF类库中的（RoutedCommand）类即可。如果想得到与业务逻辑相关的专有命令，则需要创建RoutedCommand（或者ICommand接口）的派生类。 
- 声明命名实例：使用命令时需要创建命令类的实例。这里有一个技巧，一般情况下程序中某种操作只需要一个命令实例与之对应即可。比如对应“保存”这个命令操作。因此程序中的命令多使用单件模式以减少代码的复杂度。 
- 指定命令的源：即指定由谁来发送命令。如果把命令看作炮弹，那么命令源就相当于火炮。同一个命令可以有多个源。比如保存命令，即可以由菜单中的保存项来发送，也可以由保存工具栏中的图标进行发送。需要注意的是，一旦把命令指派给了命令源，那么命令源就会受命令的影响，当命令不能被执行的时候命令源的控件处于不可用状态。看来命令这种炮弹还很智能，当不满足发送条件的时候还会给用来发射它的火炮上一道保险、避免走火。还需要注意，各种控件发送命令的方法不经相同，比如Button和MenuButton在单击时发送命令，而ListBoxItem单击时表示被选中，双击的时候才发送命令。 
- 指令命令目标：命令目标并不是命令的属性，而是命令源的属性。指定命令目标是告诉命令源向哪个组件发送命令。无论这个组件是否拥有焦点他都会收到这个命令。如果没有为源指定命令目标，则WPF系统认为当前拥有焦点的对象就是命令目标。这个步骤有点像为火炮指定目标。 
- 设置命令关联：炮兵是不能单独战斗的，就像炮兵在设计之前需要侦察兵观察敌情、判断发射时机，在射击后观测射击效果，帮助修正一样。WPF命令需要CommandBinding在执行之前来帮助判断是不是可以执行、在执行后做一些事来“打扫战场”。
在命令目标和命令关联之间还有一些微妙的关系。无论命令目标是由程序员指定还是由WPF系统根据焦点所在地判断出来的，一旦某个UI组件被命令源瞄上，命令源就会不断的向命令目标投石问路，命令目标就会不停的发送可路由的PreviewCanExecute和CanExecute附加事件。事件会沿UI元素树向上传递并被命令关联所捕获，命令关联会完成一些后续任务。别小看“后续任务”，对于那些业务逻辑无关的通用命令，这些后续任务才是最重要的。 

#### WPF中的命令库 
- ApplicationCommands
- ComponentCommands
- NavigationCommands
- MediaCommands
- EditingCommands 


#### 了解ICommand接口和RoutedCommand
WPF的命令是实现了ICommand接口的类。ICommand接口中包含有最重要的两个方法和一个事件：
- Execute方法：命令执行，或者说命令作用于命令目标之上。需要注意的是现实世界中的命令是不会自己“执行”的，它只能“被执行”，而在这里执行变成了命令的方法。
- CanExecute方法：在执行之前用来探知命令是否可被执行。
- CanExecuteChanged事件：当命令可执行状态发生改变时，可激发此事件来通知其他对象。RoutedCommand就是这样一个实现了ICommand接口的类。RoutedCommand在实现ICommand接口时，并未向Execute和CanExecute方法中添加任何逻辑，也就是它是通用的与具体业务逻辑无关的。而是外围的CommandBinding捕获到命令目标受命令激发而发送的路由事件后在其CanExecute和Executed事件处理器中完成。
- 带两个参数的Execute方法是对外公开的，可以使用第一个参数向命令传递一些数据，第二个参数是命令的目标，如果目标为null, Execute方法就把当前拥有焦点的控件作为命令的目标。该Execute方法会调用命令执行逻辑的核心-Executelmpl方法(Executelmpl是Execute Implement的缩写)，而这个方法内部就是“借用”命令目标的RaiseEvent把RoutedEvent发送出去。显然，这个事件会被外围的CommandBinding捕获到然后执行程序员预设的与业务相关的逻辑。
- RoutedCommand源码地址：https://github1s.com/dotnet/wpf/blob/HEAD/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/Input/Command/RoutedCommand.cs


#### 了解命令
- 使用命令可以避免自己写代码判断控件是否可用以及添加快捷键。
- 无论是探测命令是否执行还是命令送达目标，都会激发命令目标发送路由事件，这些路由事件会沿着U1元素树向上传递并最终被CommandBinding所捕捉。 当CommandBinding捕捉到CanExecute事件(判断命令执行的条件是否满足，并反馈给命令供其影响命令源的状态); 当捕捉到的是Executed事件(表示命令的Execute方法已经执行了，或说命令已经作用在了命令目标上, RoutedCommand的Execute方法不包含业务逻辑、只负责让命令目标激发Executed )。
- 因为CanExecute事件的激发频率比较高，为了避免降低性能，在处理完后建议把e.Handled设为true。
- CommandBinding一定要设置在命令目标的外围控件上，不然无法捕捉到CanExecute和Executed等路由事件。

#### 命令参数 
使用CommandParameter，命令源一定是实现了ICommandSource接口的对象，而ICommandSource有一个属性就是CommandParameter，如果把命令看作飞向目标的炮弹，那么CommandParameter就相当于装载在炮弹里面的“消息”。

#### 命令与Binding的结合 
控件那么多事件，可以让我们进行各种各样的不同操作，可控件只有一个Command属性、而命令库却有数10种命令，这样怎么可能使用这个唯一的Command属性来调用那么多种命令呢？答案是使用BIndding。前面已经说过，Binding作为一种间接的、不固定的赋值手段，可以让你有机会选择在某个条件下为目标赋特定的值（有时候需要借助Converter）。 例如一个Button所关联的命令有可能根据某些条件而改变，如：
```xml
<Button x:Name="cmdBtn" Command="{Binding Path=ppp, Source=sss}" Content="Command"></Button>
```

#### 自定义命令
自定义命令可以分两个层次来理解。第一个层次比较浅，指的是当WPF命令库中没有包含想要的命令时，我们就得声明定义自己的RoutedCommand实例。比如你想让命令目标在命令到达时发出笑声, WPF命令库里没有这个命令，那就可以定义一个名为Laugh的RoutedCommand实例。很难说这是真正意义上的“自定义命令”，这只是对RoutedCommand的使用。第二个层次是指从实现ICommand接口开始，定义自己的命令并且把某些业务逻辑也包含在命令之中，这才称得上是真正意义上的自定义命令。但是，WPF自带的命令源和CommandBinding就是专门为RoutedCommand而编写的，如果我们想使用自己的ICommand派生类就必须连命令源一起实现(即实现ICommandSource接口)。因此，为了简便地使用WPF这套成熟的体系，为了更高效率地“从零开始”打造自己的命令系统，需要我们根据项目的实际情况进行权衡。

#### 命令和事件的区别
事件的作用是发布、传播一些消息，消息传达到了接收者，事件的指令也就算完成了，至于如何响应事件送来的消息事件并不做任何限制，每个接收者可已用自己的行为来响应事件。也就是说，事件不具有约束力。命令和事件的区别就在于命令具有约束力。

#### 命令，自定义命令的用途，命令和事件的区别，后续再进一步研究。。。

