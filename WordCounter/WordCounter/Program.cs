﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            CounterEngine.Instance.LoadInputStatementFromArgs(args);
            CounterEngine.Instance.ProcessStatement();
            CounterEngine.Instance.OutputResultToConsole();
        }
    }
}
