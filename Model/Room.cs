﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasGG.Model
{
    public class Room
    {
        public int id { get; set; }
        public string name { get; set; }
        public string floor { get; set; }
        public int capacity { get; set; }
        public bool status { get; set; }
    }
}
