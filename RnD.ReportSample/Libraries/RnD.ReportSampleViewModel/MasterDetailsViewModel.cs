﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RnD.ReportSampleViewModel
{
    public class MasterDetailsViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
