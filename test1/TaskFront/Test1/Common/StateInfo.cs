﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFront.Common
{
    public class StateInfo
    {
        public int status { get; set; } = 200;

        public string msg { get; set; }

        public Object data { get; set; }
    }
}
