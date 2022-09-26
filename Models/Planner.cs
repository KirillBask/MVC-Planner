using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcPlanner.Models
{
    public class Planner
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Planned Work")]
        [Required]
        public string PlannedWork { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsDone { get; set; }
        public bool IsActualPressed { get; set; }
    }
}
