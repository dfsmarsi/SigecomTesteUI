using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string WinAppDriver = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";
            Process.Start(WinAppDriver);
        }
    }    
}

