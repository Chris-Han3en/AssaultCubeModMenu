using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Linq;
using Microsoft.Win32.SafeHandles;
using Jupiter;
using System.Windows.Forms;

namespace AssaultCubeHacks
{
    class GameStatus
    {
        public static bool NotFound = false;

        public static void search()
        {
            while (true)
            {
                bool GameNotFound = false;
                Process game;
                try
                {
                    game = Process.GetProcessesByName("ac_client")[0];
                }
                catch
                {
                    GameNotFound = true;
                }
                if (GameNotFound)
                {
                    NotFound = true;
                }
                else if (!GameNotFound)
                {
                    NotFound = false;
                }
            }
        }
    }
}
