﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_consoleapp
{
    internal interface IReporter
    {
        double GetAllProfit();
        double GetAlcoholProfit();
        double GetNonAlcoholProfit();
    }
}
