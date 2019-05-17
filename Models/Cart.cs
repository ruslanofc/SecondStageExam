using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondStageExam.Models
{
    public class Cart
    {
        [Key]
        public string Id { get; set; }
        public List<string> Vehicles { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
    }
}
