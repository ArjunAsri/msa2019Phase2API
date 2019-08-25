using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public partial class Tasks
    {
        [Column("TaskID")]
        public int TaskId { get; set; }
        [Required]
        [StringLength(255)]
        public string TaskName { get; set; }
        public int TaskPriority { get; set; }
        [Required]
        [StringLength(255)]
        public string CourseNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string TaskDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateAndTime { get; set; }
    }
}
