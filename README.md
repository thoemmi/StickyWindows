# StickyWindows

This library helps creating window applications where the windows can both stick to
screen borders and to each other.

The code originates from the Codeproject article
[Sticky Windows - How to make your (top-level) forms to stick one to the other or to the screen](https://www.codeproject.com/Articles/6045/Sticky-Windows-How-to-make-your-top-level-forms-to)
by Corneliu Tusnea. He never published a NuGet package, so I asked for his permission
to both create a repository at GiutHub and publish it as a NuGet package.

## Build status and NuGet packages

|                   | Stable                                                         | Pre-release                                              |
|-------------------|----------------------------------------------------------------|----------------------------------------------------------|
| AppVeyor          | [![Build status][appveyor-master-badge]][appveyor-master-link] | [![Build status][appveyor-dev-badge]][appveyor-dev-link] |
| StickyWindows     | [![NuGet][nuget-master-badge]][nuget-master-link]              | [![NuGet][nuget-dev-badge]][nuget-dev-link]              |
| StickyWindows.Wpf | [![NuGet][nuget-master-wpf-badge]][nuget-master-wpf-link]      | [![NuGet][nuget-dev-wpf-badge]][nuget-dev-wpf-link]      |

[appveyor-master-badge]: https://ci.appveyor.com/api/projects/status/ynjy63xrlvrrmseg/branch/master?svg=true
[appveyor-master-link]:  https://ci.appveyor.com/project/thoemmi/stickywindows/branch/master
[appveyor-dev-badge]:    https://ci.appveyor.com/api/projects/status/ynjy63xrlvrrmseg/branch/develop?svg=true
[appveyor-dev-link]:     https://ci.appveyor.com/project/thoemmi/stickywindows/branch/develop
[nuget-master-badge]:    https://img.shields.io/nuget/v/StickyWindows.svg
[nuget-master-link]:     https://www.nuget.org/packages/StickyWindows
[nuget-dev-badge]:       https://img.shields.io/nuget/vpre/StickyWindows.svg
[nuget-dev-link]:        https://www.nuget.org/packages/StickyWindows
[nuget-master-wpf-badge]:  https://img.shields.io/nuget/v/StickyWindows.WPF.svg
[nuget-master-wpf-link]:   https://www.nuget.org/packages/StickyWindows.WPF
[nuget-dev-wpf-badge]:     https://img.shields.io/nuget/vpre/StickyWindows.WPF.svg
[nuget-dev-wpf-link]:      https://www.nuget.org/packages/StickyWindows.WPF

## Usage

Actually there are two libraries published: one is for WinForms applications,
and the other one for WPF applications. The latter bases on the WinForms package
though. but this shouldn't be an issue as that the WinForms library is part of the
.NET framework and as such is always available.

### WinForms

For WinForms application, use the
[**StickyWindow**](https://www.nuget.org/packages/StickyWindows)
package.

In the **constructor** of your form add this line:

```csharp
new StickyWindows.StickyWindow(this);
```

If you want to deviate from the default settings, `StickyWindow` provides following
boolean properties (which are all `true` by default:

* `StickOnMove`<br>Allows the form to try to stick when the form is moved.
* `StickOnResize`<br>Allows the form to try to stick when the form is resized.
* `StickToOther`<br>Allows the form to try to stick to other stick-able forms.
* `StickToScreen`<br>Allows the form to try to stick to the screen margins.

### WPF

For WinForms application, use the
[**StickyWindow.WPF**](https://www.nuget.org/packages/StickyWindows.WPF)
package.


You have two options to make your windows "sticky":

1. Subscribe to your window's `Loaded` event and call the extension method
   `CreateStickyWindow` in the handler:
   ```csharp
   _stickyWindow = this.CreateStickyWindow();
   ```

2. Use the `StickyWindowBehavior` in your XAML code (which I think is more elegant
   than option 1):
   ```xml
    <Window
      x:Class="WpfTest.Window2"
      xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
      xmlns:wpf="clr-namespace:StickyWindows.WPF;assembly=StickyWindows.WPF"
      ...>
      <i:Interaction.Behaviors>
        <wpf:StickyWindowBehavior />
      </i:Interaction.Behaviors>
      ...
    </Window>
   ```

Both options support the same properties as the WinForms implementation.

> Please note that **StickyWindows.WPF** requires **System.Windows.Interactivity**,
> which is neither part of the library nor a dependency of the NuGet package. The point
> is, there's no official NuGet package for **System.Windows.Interactivity** by Microsoft.
> I decided against delivering this library as part of **StickyWindows.WPF** as it may
> conflict with different versions in other libraries you may be using potentially.

## Known issues

* [#1](https://github.com/thoemmi/StickyWindows/issues/1) There's a strange margin
  when running on Windows 10
