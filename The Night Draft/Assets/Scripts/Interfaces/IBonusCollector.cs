﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface IBonusCollector 
    {
        public bool ReadyToTake { get; set; }
    }

}
