﻿using StockData.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure.BusinessObjects
{
    public class StockPrice
    {
        public Guid Id { get; set; }
        public double? LastTradingPrice { get; set; }
        public double? High { get; set; }
        public double? Low { get; set; }
        public double? ClosePrice { get; set; }
        public double? YesterdayClosePrice { get; set; }
        public double? Change { get; set; }
        public double? Trade { get; set; }
        public double? Value { get; set; }
        public double? Volume { get; set; }
        public Guid CompanyId { get; set; }
    }
}
