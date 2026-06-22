using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    internal class Logger
    {
        public static void Log(string message)
        {
            File.AppendAllText("C:\\Users\\Giviko\\source\\repos\\FinalProject\\FinalProject\\log.txt",
                $"{DateTime.Now} - {message}\n");
        }
    }
}

