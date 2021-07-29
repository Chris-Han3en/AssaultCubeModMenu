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
    class InfiniteAmmo
    {

        public static void Ammo()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");

            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");

            var ammoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x150 });

            var PistolAmmoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x13C });

            var SniperAmmoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x14C });

            var SubMachineAmmoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x148 });

            var ShotgunAmmoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x144 });

            var MarksmanAmmoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x140 });

            var AkimboAmmoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x15C });

            int newAmmo = 2000;
            while (Keyboard.AmmoStart)
            {
                MainFunctions.WriteProcessMemory(hProc, ammoAddr, newAmmo, 4, out _);
                MainFunctions.WriteProcessMemory(hProc, PistolAmmoAddr, newAmmo, 4, out _);
                MainFunctions.WriteProcessMemory(hProc, SniperAmmoAddr, newAmmo, 4, out _);
                MainFunctions.WriteProcessMemory(hProc, SubMachineAmmoAddr, newAmmo, 4, out _);
                MainFunctions.WriteProcessMemory(hProc, ShotgunAmmoAddr, newAmmo, 4, out _);
                MainFunctions.WriteProcessMemory(hProc, MarksmanAmmoAddr, newAmmo, 4, out _);
                MainFunctions.WriteProcessMemory(hProc, AkimboAmmoAddr, newAmmo, 4, out _);
                Thread.Sleep(1000);
            }
        }
    
        public static void resetAmmo()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");

            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");

            var ammoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x150 });

            var PistolAmmoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x13C });

            var SniperAmmoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x14C });

            var SubMachineAmmoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x148 });

            var ShotgunAmmoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x144 });

            var MarksmanAmmoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x140 });

            var AkimboAmmoAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x15C });

            int newAmmo = 20;
            int newPistolAmmo = 8;
            int newSniperAmmo = 5;
            int newSubAmmo = 30;
            int newShotgunAmmo = 7;
            int newMarksmanAmmo = 10;
            int newAkimboAmmo = 16;
            MainFunctions.WriteProcessMemory(hProc, ammoAddr, newAmmo, 4, out _);
            MainFunctions.WriteProcessMemory(hProc, PistolAmmoAddr, newPistolAmmo, 4, out _);
            MainFunctions.WriteProcessMemory(hProc, SniperAmmoAddr, newSniperAmmo, 4, out _);
            MainFunctions.WriteProcessMemory(hProc, SubMachineAmmoAddr, newSubAmmo, 4, out _);
            MainFunctions.WriteProcessMemory(hProc, ShotgunAmmoAddr, newShotgunAmmo, 4, out _);
            MainFunctions.WriteProcessMemory(hProc, MarksmanAmmoAddr, newMarksmanAmmo, 4, out _);
            MainFunctions.WriteProcessMemory(hProc, AkimboAmmoAddr, newAkimboAmmo, 4, out _);

            return;
        }

        public static void Throwables()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");

            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");

            var GrenadeAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x158 });

            int newAmmo = 2000;
            while (Keyboard.GrenadeStart)
            {
                MainFunctions.WriteProcessMemory(hProc, GrenadeAddr, newAmmo, 4, out _);
                Thread.Sleep(1000);
            }
        }

        public static void resetThrowables()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");

            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");

            var GrenadeAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x158 });

            int newGrandaeAmmo = 3;

            MainFunctions.WriteProcessMemory(hProc, GrenadeAddr, newGrandaeAmmo, 4, out _);
            return;
        }
    }
    
    class InfiniteHealth
    {
        public static void Health()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];
    
            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);
    
            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");
    
            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");
    
            var healthAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0xF8 });

            int newHealth = 5000;
            while (Keyboard.HealthStart)
            {
                MainFunctions.WriteProcessMemory(hProc, healthAddr, newHealth, 4, out _);
                Thread.Sleep(1000);
            }
        }
    
        public static void resetHealth()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];
    
            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);
    
            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");
    
            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");

            var healthAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0xF8 });

            int newHealth = 100;
            MainFunctions.WriteProcessMemory(hProc, healthAddr, newHealth, 4, out _);
            return;
        }

        public static void Armour()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");

            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");

            var ArmourAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0xFC });


            int newArmour = 5000;
            while (Keyboard.ArmourStart)
            {
                MainFunctions.WriteProcessMemory(hProc, ArmourAddr, newArmour, 4, out _);
                Thread.Sleep(1000);
            }
        }

        public static void resetArmour()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");

            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");

            var ArmourAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0xFC });

            int newArmour = 100;
            MainFunctions.WriteProcessMemory(hProc, ArmourAddr, newArmour, 4, out _);
            return;
        }
    }

    class Movements
    {
        public static float YAxisLocation;
        public static float ZAxisLocation;
        public static float XAxisLocation;


        public static void SavePosition()//at the end of code make it change the menu text back to normal
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");

            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");

            var yaxis = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x3C });

            var zaxis = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x38 });

            var xaxis = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x34 });

            byte[] buffer1 = new byte[4];
            IntPtr bytesRead1;
            byte[] buffer2 = new byte[4];
            IntPtr bytesRead2;
            byte[] buffer3 = new byte[4];
            IntPtr bytesRead3;

            MainFunctions.ReadProcessMemory(hProc, yaxis, buffer1, 4, out bytesRead1);
            MainFunctions.ReadProcessMemory(hProc, zaxis, buffer2, 4, out bytesRead2);
            MainFunctions.ReadProcessMemory(hProc, xaxis, buffer3, 4, out bytesRead3);

            YAxisLocation = BitConverter.ToSingle(buffer1, 0);
            ZAxisLocation = BitConverter.ToSingle(buffer2, 0);
            XAxisLocation = BitConverter.ToSingle(buffer3, 0);
        }

        public static void LoadPosition()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");

            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");

            var yaxis = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x3C });

            var zaxis = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x38 });

            var xaxis = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x34 });

            MainFunctions.WriteProcessMemory(hProc, yaxis, YAxisLocation, 4, out _);
            MainFunctions.WriteProcessMemory(hProc, zaxis, ZAxisLocation, 4, out _);
            MainFunctions.WriteProcessMemory(hProc, xaxis, XAxisLocation, 4, out _);
        }

        public static void SpeedHack()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");

            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");

            var MovementAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x80 });

            int newSpeed = 2;
            while (Keyboard.SpeedHackStart)
            {
                MainFunctions.WriteProcessMemory(hProc, MovementAddr, newSpeed, 4, out _);
            }
            return;
        }

        public static void SpeedHackReset()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");

            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");

            var MovementAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x80 });

            int newSpeed = 0;
            MainFunctions.WriteProcessMemory(hProc, MovementAddr, newSpeed, 4, out _);
            return;
        }

        public static void NoRecoil()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            MainFunctions.WriteProcessMemory(hProc, (IntPtr)0x4FCB14, 0, 4, out _);
            MainFunctions.WriteProcessMemory(hProc, (IntPtr)0x4FCB16, 0, 4, out _);
            return;
        }

        public static void NoRecoilReset()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            MainFunctions.WriteProcessMemory(hProc, (IntPtr)0x4FCB14, "\x19\x00\x32\x00\x73\x00\x01\x00\x01\x00\x63\x70\x69\x73\x74\x6F\x6C", 4, out _);
            MainFunctions.WriteProcessMemory(hProc, (IntPtr)0x4FCB16, "\x32\x00\x73\x00\x01\x00\x01\x00\x63\x70\x69\x737\x4\x6F\x6C", 4, out _);
            return;
        }
    }

    class Timer
    {
        public static void WeaponTimer()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");

            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");

            var SniperTimerAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x174 });
            var KnifeTimerAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x160 });
            var PistolTimerAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x164 });
            var CarbineTimerAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x168 });
            var ShotgunTimerAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x16C });
            var MachineGunTimerAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x170 });
            var AssaultRifleTimerAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x178 });
            var GrenadeTimerAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x180 });


            int newTimer = 0;
            while (Keyboard.GunTimerStart)
            {
                MainFunctions.WriteProcessMemory(hProc, SniperTimerAddr, newTimer, 4, out _);
                MainFunctions.WriteProcessMemory(hProc, KnifeTimerAddr, newTimer, 4, out _);
                MainFunctions.WriteProcessMemory(hProc, PistolTimerAddr, newTimer, 4, out _);
                MainFunctions.WriteProcessMemory(hProc, CarbineTimerAddr, newTimer, 4, out _);
                MainFunctions.WriteProcessMemory(hProc, ShotgunTimerAddr, newTimer, 4, out _);
                MainFunctions.WriteProcessMemory(hProc, MachineGunTimerAddr, newTimer, 4, out _);
                MainFunctions.WriteProcessMemory(hProc, AssaultRifleTimerAddr, newTimer, 4, out _);
                MainFunctions.WriteProcessMemory(hProc, GrenadeTimerAddr, newTimer, 4, out _);
            }
        }

        public static void RapidFire()
        {
            Process proc = Process.GetProcessesByName("ac_client")[0];

            var hProc = MainFunctions.OpenProcess(MainFunctions.ProcessAccessFlags.All, false, proc.Id);

            var modBase = MainFunctions.GetModuleBaseAddress(proc, "ac_client.exe");

            var modBase2 = MainFunctions.GetModuleBaseAddress(proc.Id, "ac_client.exe");

            var ShootButtonAddr = MainFunctions.FindDMAAddy(hProc, (IntPtr)(modBase + 0x109B74), new int[] { 0x224 });

            int newHealth = 1;
            while (Keyboard.RapidFireStart)
            {
                MainFunctions.WriteProcessMemory(hProc, ShootButtonAddr, newHealth, 4, out _);
                Thread.Sleep(1);
            }
        }
    }
}
