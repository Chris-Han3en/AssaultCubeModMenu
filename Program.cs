using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using Jupiter;

namespace AssaultCubeHacks
{
    class Program
    {
        internal static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal static extern Boolean AllocConsole();
        }

        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();


        static void Main(string[] args)
        {
            NativeMethods.AllocConsole();
            Console.Title = "Assult Cube Cheats";
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);
            Console.SetWindowSize(70, 25);
            Console.BufferWidth = Console.WindowWidth = 70;
            Console.BufferHeight = Console.WindowHeight = 25;
            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }

            Thread gameStatus = new Thread(() => GameStatus.search());
            gameStatus.Start();//starts to check if the game is running
            Thread.Sleep(500);
            Thread menu = new Thread(() => Menu.start());
            menu.Start();//constantly updates the menu
            while (true)
            {
                if (!GameStatus.NotFound)
                {
                    Thread keyboard = new Thread(() => Keyboard.start());
                    keyboard.Start();//checks if the user presses key binds
                    break;
                }
            }
        }
    }
}
