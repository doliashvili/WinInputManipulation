using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using WindowsInput;

namespace Win32InputManipulations
{
    public static class WriteTextWithClick
    {
        private static IntPtr CurrentMainWindowHandle { get; set; }

        [DllImport("user32.dll")]
        private static extern bool GetAsyncKeyState(Int32 i);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(short i);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point point);

        public static void Run(string text)
        {
            var point = new Point(0, 0);

            while (true)
            {
                //1 catch mouse click
                if (GetAsyncKeyState(1))
                {
                    //2 get cursor coordinate
                    GetCursorPos(out point);
                    Console.WriteLine($"X - {point.X} Y - {point.Y}");

                    //3 get point from windows
                    CurrentMainWindowHandle = WindowFromPoint(point);
                    Console.WriteLine(CurrentMainWindowHandle);

                    //4 Set foreground window with current point
                    SetForegroundWindow(CurrentMainWindowHandle);

                    //5 activate keyboard keys with some text F.e "hello"
                    var inputSimulator = new InputSimulator();
                    inputSimulator.Keyboard.TextEntry(text);
                }
                Thread.Sleep(130);
            }
            //var processes = Process.GetProcesses().Where(p => p.ProcessName.StartsWith("note"));
            //foreach (Process proc in processes)
            //{
            //    if (proc.MainWindowTitle.Contains("txtdoc"))
            //    {
            //        SetForegroundWindow(proc.MainWindowHandle);
            //        var inputSimulator = new InputSimulator();

            //        inputSimulator.Keyboard.TextEntry("hello ");
            //        Thread.Sleep(2000);
            //    }
            //}
            //Console.WriteLine($"{Process.GetCurrentProcess().ProcessName}");
            //Thread.Sleep(2000);
        }
    }
}