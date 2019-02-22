using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.A2b.Models
{
    public class Meal
    {
        public int MealId { get; set; }

        public string MealTypeCode { get; set; }

        public int Price { get; set; }

        public Guid ExternalId { get; set; }
    }


}
