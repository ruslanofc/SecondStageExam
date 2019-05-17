using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondStageExam.Models
{
    public class Vehicle
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Taken { get; set; }
    }
}
