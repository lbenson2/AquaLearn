﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AquaLearn.Domain.Models
{
    public class Trash
    {
        public int TrashId { get; set; }
        public string Name { get; set; }
        public bool Schooling { get; set; }
        public WaterType WaterType { get; set; }
        public string Description { get; set; }
    }
}
