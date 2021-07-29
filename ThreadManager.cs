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
    class ThreadManager
    {
        public static void PosistionSavedText()
        {
            Thread.Sleep(1000);
            Keyboard.TpPositionToggle = $"Y = {Movements.YAxisLocation}, Z = {Movements.ZAxisLocation}, X = {Movements.XAxisLocation}";
            Keyboard.TpPositionLoaded = "Ready to TP";
        }

        public static void PositionLoadedText()
        {
            Thread.Sleep(1000);
            Keyboard.TpPositionLoaded = "Press 'F5' to TP";
        }
    }
}
