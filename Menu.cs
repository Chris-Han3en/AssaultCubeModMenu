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
    class Menu
    {
        public static void start()
        {
            while (true)//make it so when keyboard is pressed it changes the values here as well as start the thing
            {
                if (GameStatus.NotFound)
                {
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("                        chrishansen.tk");
                    Console.WriteLine("                      Chris Hansen's Cheat");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\n\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("GAME STATUS:  Assault Cube is not running");
                    Console.ResetColor();
                }
                else if (!GameStatus.NotFound)
                {
                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("                        chrishansen.tk");
                    Console.WriteLine("                      Chris Hansen's Cheat");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("GAME STATUS:  Assault Cube is running");
                    Console.ResetColor();
                    Console.WriteLine("\n");
                    Console.WriteLine($"[F1] Infinite Ammo                => {Keyboard.AmmoToggle} <=");
                    Console.WriteLine($"[F2] Infinite Throwables          => {Keyboard.GrenadeToggle} <=");
                    Console.WriteLine($"[F3] Infinite Health              => {Keyboard.HealthToggle} <=");
                    Console.WriteLine($"[F4] Infinite Armour              => {Keyboard.ArmourToggle} <=");
                    Console.WriteLine($"[F5] Set TP Point                 => {Keyboard.TpPositionToggle} <=");
                    Console.WriteLine($"[F6] TP to save                   => {Keyboard.TpPositionLoaded} <=");
                    Console.WriteLine($"[F7] Remove Weapon Shoot Time     => {Keyboard.GunTimerToggle} <=");
                    Console.WriteLine($"[F8] Rapid Fire                   => {Keyboard.RapidFireToggle} <=");
                    Console.WriteLine($"[F9] Speed Hack                   => {Keyboard.SpeedHackToggle} <=");
                    Console.WriteLine($"[F10] No Recoil                   => {Keyboard.NoRecoilToggle} <=");

                    Console.WriteLine("\n[Pause Key] Exit");
                }
                Thread.Sleep(1000);
            }
        }
    }
}
