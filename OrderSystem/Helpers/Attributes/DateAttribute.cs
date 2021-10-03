﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Helpers.Attributes
{
    public class DateAttribute : RangeAttribute
    {
        public DateAttribute()
          : base(typeof(DateTime), DateTime.Now.AddYears(-1).ToShortDateString(), DateTime.Now.AddYears(1).ToShortDateString()) { }
    }
}
