using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleTask.Server.Models
{
    public class AccountTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("_id")]
        public int Id { get; set; }

        [Column("created_by")]
        public string CreatedBy { get; set; }

        [Column("created_at")]
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Column("task_title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; } = "";

        [Column("task_status")]
        public string TaskStatus { get; set; } = "To-Do";

        [Column("start_date")]
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddDays(1));

        [Column("due_date")]
        public DateOnly DueDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddDays(14));
    }
}
