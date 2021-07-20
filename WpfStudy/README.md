### wpf

在Windows上实现图形化的界面却有多种方法，每种方法又拥有自己的一套开发理念和工具。每种GUI开发方法与它的理念和工具共同组成一种方法论，常见的有：
- Windows API (Win API)：调用Windows底层绘图函数，使用C语言，最原始也最基础。
- Microsoft Foundation Class(MFC)：使用 C++ 语法将原始的 Win32 API 函数封装成控件类。
- Visual Component Library (VCL): Delphi 和 C++ Builder 使用的与 MFC 相近的控件类库。
- Visual Basic + Activex 控件(VB6)：使用组件化的思想把 Win API 封装成UI控件，多语言共用。
- Java Swing/AWT: Java SDK 中用于跨平台开发 GUI 程序的控件类库。
- Windows Form: .NET平台上进行 GUI 开发的老牌劲旅，事件驱动，完全组件化但需要NET运行时支持。
- Windows Presentation Foundation (WPF)：后起之秀，使用全新的数据驱动U1的理念。

Windows GUI开发历史，可以把上述这些方法论分为四代:
- Win APT时代：函数调用 + Windows 消息处理。
- 封装时代：使用面向对象理念把 Win API 封装成类，由来自UI的消息驱动程序处理数据。
- 组件化时代：使用面向组件理念在类的基础上封装成组件，消息被封装成事件，变成事件驱动。
- WPF时代：在组件化的基础上，使用专门的 UI 设计语言并引入由数据驱动 UI 的理念。WPF 之所以能够称得上是新的一代关键在于两点：第一，之前几代 GU1 方法论只能使用编程语言进行 U1 设计，而 WPF 具有专门用于 UI 设计的 XAML；第二，前几代在 U1 与数据的交互方面是由 Windows 消息到控件事件一脉相承，始终是把 UI 控件放在主导地位而把数据放在被动地位，用 UI 来驱动数据的改变，WPF 在事件驱动的基础上引入了数据驱动界面的理念，让数据重归核心地位而让 U1 回归数据表达者的位置。WPF 中是数据驱动 UI，数据是核心是主动的；U1 从属于数据并表达数据是被动的。
