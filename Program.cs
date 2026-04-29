using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WinFormsHotReload;


public static partial class Program
{
    public static int CompilationNumber = 0;
    public static Action ShutDown = () => { };
    static string GetSrcPath()
    {
        var location = Directory.GetCurrentDirectory();
        var dir = location + "../../../../hot";
        return Path.GetFullPath(dir);
    }
    
    [STAThread]
    static void Main(string[] args)
    {
        var frm = new Form();
        
        frm.FormClosing += (sender, eventArgs) =>
        {
            ShutDown();
        };
        frm.Shown += (sender, eventArgs) =>
        {
            var screen = Screen.PrimaryScreen.Bounds;
            var w2 = screen.Width / 2;
            var h2 = screen.Height / 2;
            frm.Height = 0;
            frm.Top = h2;
            frm.Left = w2;
            frm.Text = "Hot Reloader";
            Watch(run =>
            {
                ShutDown();
                run();
                CompilationNumber++;
            }, GetSrcPath());
        };
        Application.Run(frm);
    }
}
