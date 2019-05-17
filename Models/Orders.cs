using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondStageExam.Models
{
    public class Orders
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public List<string> Vehicles { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Cost { get; set; }
    }
}
