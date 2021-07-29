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
    class Keyboard
    {
        //vars for the mod things
        public static bool AmmoStart = false;
        public static bool HealthStart = false;
        public static bool TpPositionSet = false;
        public static bool GrenadeStart = false;
        public static bool ArmourStart = false;
        public static bool GunTimerStart = false;
        public static bool SpeedHackStart = false;
        public static bool RapidFireStart = false;
        public static bool NoRecoilStart = false;
        public static string AmmoToggle = "off";
        public static string HealthToggle = "off";
        public static string GunTimerToggle = "off";
        public static string SpeedHackToggle = "off";
        public static string RapidFireToggle = "off";
        public static string NoRecoilToggle = "off";
        public static string ArmourToggle = "off";
        public static string TpPositionToggle = "No saved coords found";
        public static string TpPositionLoaded = "No coords found";
        public static string GrenadeToggle = "off";


        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;


        public static void start()
        {
            _hookID = SetHook(_proc);
            Application.Run();
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {

            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                //This is the bind for infinite ammo
                if ((Keys)vkCode == Keys.F1)
                {
                    if (!AmmoStart)
                    {
                        Thread ammo = new Thread(() => InfiniteAmmo.Ammo());
                        AmmoStart = true;
                        AmmoToggle = "on";
                        ammo.Start();
                    }
                    else if (AmmoStart)
                    {
                        AmmoStart = false;
                        AmmoToggle = "off";
                        InfiniteAmmo.resetAmmo();
                    }

                }

                if ((Keys)vkCode == Keys.F2)
                {
                    if (!GrenadeStart)
                    {
                        Thread grenade = new Thread(() => InfiniteAmmo.Throwables());
                        GrenadeStart = true;
                        GrenadeToggle = "on";
                        grenade.Start();
                    }
                    else if (GrenadeStart)
                    {
                        GrenadeStart = false;
                        GrenadeToggle = "off";
                        InfiniteAmmo.resetThrowables();
                    }
                }

                if ((Keys)vkCode == Keys.F3)
                {
                    if (!HealthStart)
                    {
                        Thread health = new Thread(() => InfiniteHealth.Health());
                        HealthStart = true;
                        HealthToggle = "on";
                        health.Start();
                    }
                    else if (HealthStart)
                    {
                        HealthStart = false;
                        HealthToggle = "off";
                        InfiniteHealth.resetHealth();
                    }
                }

                if ((Keys)vkCode == Keys.F4)
                {
                    if (!ArmourStart)
                    {
                        Thread Armour = new Thread(() => InfiniteHealth.Armour());
                        ArmourStart = true;
                        ArmourToggle = "on";
                        Armour.Start();
                    }
                    else if (ArmourStart)
                    {
                        ArmourStart = false;
                        ArmourToggle = "off";
                        InfiniteHealth.resetArmour();
                    }
                }

                if ((Keys)vkCode == Keys.F5)
                {
                    Thread tp = new Thread(() => Movements.SavePosition());
                    TpPositionSet = true;
                    TpPositionToggle = "Position saved";
                    tp.Start();
                    Thread menuReset = new Thread(() => ThreadManager.PosistionSavedText());
                    menuReset.Start();
                }

                if ((Keys)vkCode == Keys.F6)
                {
                    if (TpPositionSet)
                    {
                        Thread tp = new Thread(() => Movements.LoadPosition());
                        TpPositionLoaded = "TP'ed to prevoius location";
                        tp.Start();
                        Thread menuReset = new Thread(() => ThreadManager.PositionLoadedText());
                        menuReset.Start();
                    }
                    else if (!TpPositionSet)
                    {
                        TpPositionLoaded = "Cannot TP as no position has been saved";
                    }
                }

                if ((Keys)vkCode == Keys.F7)
                {
                    if (!GunTimerStart)
                    {
                        Thread timer = new Thread(() => Timer.WeaponTimer());
                        GunTimerStart = true;
                        GunTimerToggle = "on";
                        timer.Start();
                    }
                    else if (GunTimerStart)
                    {
                        GunTimerStart = false;
                        GunTimerToggle = "off";
                    }
                }

                if ((Keys)vkCode == Keys.F8)
                {
                    if (!RapidFireStart)
                    {
                        Thread shoot = new Thread(() => Timer.RapidFire());
                        RapidFireStart = true;
                        RapidFireToggle = "on";
                        shoot.Start();
                    }
                    else if (RapidFireStart)
                    {
                        RapidFireStart = false;
                        RapidFireToggle = "off";
                    }
                }

                if ((Keys)vkCode == Keys.F9)
                {
                    if (!SpeedHackStart)
                    {
                        Thread timer = new Thread(() => Movements.SpeedHack());
                        SpeedHackStart = true;
                        SpeedHackToggle = "on";
                        timer.Start();
                    }
                    else if (SpeedHackStart)
                    {
                        SpeedHackStart = false;
                        SpeedHackToggle = "off";
                        Movements.SpeedHackReset();
                    }
                }

                if ((Keys)vkCode == Keys.F10)
                {
                    if (!NoRecoilStart)
                    {
                        Thread Recoil = new Thread(() => Movements.NoRecoil());
                        NoRecoilStart = true;
                        NoRecoilToggle = "on";
                        Recoil.Start();
                    }
                    else if (NoRecoilStart)
                    {
                        NoRecoilStart = false;
                        NoRecoilToggle = "off";
                        Movements.NoRecoilReset();
                    }
                }


                if ((Keys)vkCode == Keys.Pause)
                {
                    Environment.Exit(1);
                }

            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
