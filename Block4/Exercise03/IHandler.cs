﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03
{
    public interface IHandler
    {
        string Process(IContext context, string text);
    }

    public interface IContext
    {
    }
}
