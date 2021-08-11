### 属性

#### 依赖属性
依赖属性就是一种可以自己没有值，并能通过使用Binding从数据源获得值(依赖在别人身上)的属性。拥有依赖属性的对象被称为“依赖对象”。与传统的CLR属性和面向对象思想相比依赖属性有很多新颖之处，其中包括:
- 节省实例对内存的开销。
- 属性值可以通过Binding依赖在其他对象上。

##### 依赖属性对内存的使用方式	
传统的 .NET开发中，一个对象所占用的内存空间在调用new操作符进行实例化的时候就已经决定了，
而WPF允许对象在被创建的时候并不包含用于存储数据的空间(即字段所占用的空间)、只保留在需要用到数据时能够获得默认值、借用其他对象数据或实时分配空间的能力--这种对象就称为依赖对象(Dependency Object)
而它这种实时获取数据的能力则依靠依赖属性(Dependency Property)来实现。WPF开发中，必须使用依赖对象作为依赖属性的宿主，使二者结合起来，才能形成完整的Binding目标被数据所驱动。
在WPF系统中，依赖对象的概念被DependencyObject类所实现，依赖属性的概念则由DependencyProperty类所实现。DependencyObject继承DispatcherObject 具有GetValue和SetValue两个方法。
WPF的所有UI控件都是依赖对象。WPF的类库在设计时充分利用了依赖属性的优势, UI控件的绝大多数属性都已经依赖化了。

- 依赖属性的包装器( Wrapper )是一个CLR属性，实际上依赖属性就是那个由public static readonly修饰的DependencyProperty实例，有没有包装器这个依赖属性都存在。
- 既然有没有包装器依赖属性都存在，那么包装器是干什么用的呢？包装器的作用是以“实例属性”的形式向外界暴露依赖属性，这样一个依赖属性才能成为數据源的一个Path。
- 注册依赖属性时使用的第二个参數是一个数据类型，这个数据类型也是包装器的數据类型，它的全称应该是“依赖属性的注册类型”，但一般情况下也会把这个类型类型称为“依赖属性的类型” (严格地说，依赖属性的类型永远都是DependencyProperty)。
- DependencyProperty.Register参数
    - 第1个参数为string类型，用这个参数来指明以哪个CLR属性作为这个依赖属性的包装器，或者说此依赖属性支持(back)的是哪个CLR属性。
    -第2个参数用来指明此依赖属性用来存储什么类型的值
    - 第3个参数用来指明此依赖属性的宿主是什么类型，或者说DependencyProperty.Register方法将把这个依赖属性注册关联到哪个类型上。
    - 第4个参数的类型是PropertyMetadata类。DefaultMetadata的作用是向依赖属性的调用者提供一些基本信。
         - CoerceValueCallback：依赖属性值被强制改变时此委托会被调用，此委托可关联一个影响函数。
         - DefaultValue：依赖属性未被显式赋值时，若读取之则获得此默认值，不设此值会抛出异常。
         - IsSealed：控制PropertyMetadata的属性值是否可以更改，默认值为true。
         - PropertyChangedCallback：依赖属性的值被改变之后此委托会被调用，此委托可关联一个影响函数。

##### 依赖属性值存取的秘密
DependencyProperty对象的创建与注册，创建一个DependencyProperty实例并用它的CLR属性名和宿主类型名生成hash code，把hash code和DependencyProperty实例作为Key-Value对存入全局的、名为PropertyFromName的Hashtable中。通过CLR属性名和宿主类型名就可以从这个全局的Hashtable中检索出对应的DependencyProperty实例。

#### 附加属性
附加属性是说一个属性本来不属于某个对象，但由于某种需求而被后来附加上。也就是把对象放入一个特定环境后对象才具有的属性(表现出来就是被环境赋予的属性)就称为附加属性(Attached Properties)。
附加属性的本质就是依赖属性，二者仅在注册和包装器上有一点区别。附加属性也可以使用Binding依赖在其他对象的数据上。


