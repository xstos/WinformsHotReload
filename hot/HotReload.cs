using System;
using System.Threading;
using System.Windows.Forms;
using WinFormsHotReload;
using Button = System.Windows.Forms.Button;

namespace RENAME_ME;

public static class Hot
{
    public static void Run()
    {
        void MyThread()
        {
            Console.WriteLine("Enter " + Program.CompilationNumber);
            Form frm = new Form();
            var foo = new SomeOtherClass();
            frm.Shown += (sender, args) =>
            {
                var w2 = Screen.PrimaryScreen.Bounds.Width / 2;
                var h2 = Screen.PrimaryScreen.Bounds.Height / 2;
                frm.Top = 0;
                frm.Left = w2;
                frm.Text = "hi"; //edit me and hit save and watch the magic
                frm.Controls.Add(new Button() {Text = "foo"});
            };

            void ShutDown() => frm.Invoke(frm.Close);

            Program.ShutDown = ShutDown;
            System.Windows.Forms.Application.Run(frm);
            Console.WriteLine("Exit " + Program.CompilationNumber);
        }

        var thread = new Thread(MyThread);
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
    }
}