using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [JsonIgnore]
        public int? ProjectId { get; set; }
        [JsonIgnore]
        public Project? Project { get; set; }
    }
}