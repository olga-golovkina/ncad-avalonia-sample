using HostMgd.ApplicationServices;

using NCadAvaloniaSample.Avalonia;

using Teigha.Runtime;

namespace NCadAvaloniaSample.Startup;

public class MyNCadAddin
{
    [STAThread]
    [CommandMethod("OpenAvaloniaWindow")]
    public void OpenAvaloniaWindow()
    {
        /* 
         * Настраивать Avalonia необходимо только 1 раз за всю сессию nanoCAD.
         * В качестве альтернативы можно синглтоном реализовать, 
         * но это не пример для упражнения с паттернами.  
         */
        if (AvaloniaBuilder.WasntBuilt)
        {
            AvaloniaBuilder.BuildApp();
        }

        MainWindow win = new();

        //См. реализацию метода
        win.ShowModeless(Application.MainWindow.Handle);
    }
}
