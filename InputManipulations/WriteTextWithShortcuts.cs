using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace Win32InputManipulations
{
    public static class WriteTextWithShortcuts
    {
        private static IntPtr CurrentMainWindowHandle { get; set; }
        private static InputSimulator InputSimulator { get; } = new();

        [DllImport("user32.dll")]
        private static extern bool GetAsyncKeyState(byte i);

        [DllImport("user32.dll")]
        private static extern Int16 GetAsyncKeyState(Int32 vKey);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point point);

        public static void Run(string text)
        {
            var point = new Point(0, 0);
            var isClicked = false;

            while (true)
            {
                //1 catch mouse click
                if (GetAsyncKeyState((byte)1))
                {
                    //2 get cursor coordinate
                    GetCursorPos(out point);
                    Console.WriteLine($"X - {point.X} Y - {point.Y}");

                    //3 get point from windows
                    CurrentMainWindowHandle = WindowFromPoint(point);
                    Console.WriteLine(CurrentMainWindowHandle);

                    //4 Set foreground window with current point
                    SetForegroundWindow(CurrentMainWindowHandle);

                    isClicked = true;
                }

                if (isClicked)
                {
                    Thread.Sleep(1500);
                    isClicked = false;

                    const short alt1 = 164;

                    var resultAlt1 = GetAsyncKeyState(alt1);
                    var isAlt1 = resultAlt1 == 1;

                    if (GetAsyncKeyState((int)VirtualKeyCode.VK_P) == 1 && isAlt1)
                    {
                        InputSimulator.Keyboard.TextEntry("password"); // example ALT + P press keyboard keys 'p''a''s''s''w'....
                    }

                    if (GetAsyncKeyState((int)VirtualKeyCode.VK_N) == 1 && isAlt1) // example ALT + N press keyboard keys 'u''s''e''r''n' ....
                    {
                        InputSimulator.Keyboard.TextEntry("username");
                    }

                    if (GetAsyncKeyState((int)VirtualKeyCode.VK_E) == 1 && isAlt1) // example ALT + E press keyboard keys 'e''m''a''i''l'
                    {
                        InputSimulator.Keyboard.TextEntry("email");
                    }

                    if (GetAsyncKeyState((int)VirtualKeyCode.VK_R) == 1 && isAlt1) // example ALT + R press F5 (refresh page)
                    {
                        InputSimulator.Keyboard.KeyDown(VirtualKeyCode.F5);
                    }
                }
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