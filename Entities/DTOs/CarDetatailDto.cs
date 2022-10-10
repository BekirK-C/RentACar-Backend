using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetatailDto : IDto
    {
        public string CarName { get; set; }
        public string Brandname { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
    }
}
