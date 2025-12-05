// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ExampleBlankApp;

using ExampleLibrary;
using Microsoft.UI.Xaml;
using System.Runtime.CompilerServices;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Content = Renderer.Render();
    }
}
