using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AquaLearn.Domain.Models
{
    public class WaterType
    {
        public int WaterTypeId { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public object Exhibit { get; set; }
    }
}
