using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library
{
    public class TimeReport
    {
        [Key]
        public int TimeReportId { get; set; }
        [Required]
        public int Week { get; set; }
        [Required]
        public int Hours { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee? Employee { get; set; }

    }
}
