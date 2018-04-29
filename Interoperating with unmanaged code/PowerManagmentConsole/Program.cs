using PowerManagmentLibrary;
using System;
using System.IO;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintLastSleepTime();
            PrintLastWakeTime();
            PrintSystemPowerInformation();
            PrintSystemBatteryState();
            Console.ReadKey();
        }

        public static void PrintLastSleepTime()
        {
            var returnValue = PowerManagment.GetLastSleepTime();
            var time = GetDTCTime(returnValue);
            Console.WriteLine(time);
        }

        public static void PrintLastWakeTime()
        {
            var returnValue = PowerManagment.GetLastWakeTime();
            var time = GetDTCTime(returnValue);
            Console.WriteLine(time);
        }

        public static void PrintSystemPowerInformation()
        {
            var returnValue = PowerManagment.GetPowerInformation();
            Console.WriteLine($"TimeRemaining = {returnValue.TimeRemaining}, MaxIdlenessAloowed = {returnValue.MaxIdlenessAllowed}, Idleness = {returnValue.Idleness}, CoolingMode = {returnValue.CoolingMode}");
        }

        public static void PrintSystemBatteryState()
        {
            var returnValue = PowerManagment.GetBatteryState();
            Console.WriteLine($"BatteryPresent={returnValue.BatteryPresent}, MaxCapacity={returnValue.MaxCapacity}, Rate={returnValue.Rate}, RemainingCapacity={returnValue.RemainingCapacity}, EstimatedTime={returnValue.EstimatedTime}, Discharging={returnValue.Discharging}, Charging={returnValue.Charging}, AcOnLine={returnValue.AcOnLine}");
        }

        public static TimeSpan GetDTCTime(ulong ticks)
        {
            return TimeSpan.FromTicks((long)ticks);
        }

        public static void ReserveHiberFile()
        {
            PowerManagment.ReserveHiberFile();
        }

        public static void RemoveHiberFile()
        {
            PowerManagment.RemoveHiberFile();
        }

        public static void WorkWithHiberFile()
        {
            if (IsHiberFileExist())
            {
                PrintHiberFile();
                Console.WriteLine("Remove hiberfile");
                RemoveHiberFile();
                PrintHiberFile();
            }
            else
            {
                PrintHiberFile();
                Console.WriteLine("Add hiberfile");
                ReserveHiberFile();
                PrintHiberFile();
            }
        }

        private static void PrintHiberFile()
        {
            Console.WriteLine($"Hiber file {(IsHiberFileExist() ? "" : "not")} exists");
        }

        private static bool IsHiberFileExist()
        {
            return File.Exists(@"C:\hiberfil.sys");
        }

        public static void SuspendState()
        {
            var result = PowerManagment.SetSuspendState(false);
            Console.WriteLine($"Suspend result = {result}");
        } 
    }
}
