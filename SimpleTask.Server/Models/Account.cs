using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SimpleTask.Server.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("_id")]
        public int Id { get; set; }

        [Column("first_name")]
        [Required]
        public string Firstname { get; set; } = "";

        [Column("last_name")]
        public string Lastname { get; set; } = "";

        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("user_name")]
        [Required]
        public string Username { get; set; }

        [Column("user_secret")]
        [Required]
        public string Password { get; set; }

        [Column("created_at")]
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }

    public class AccountLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ResponseResult
    {
        public bool success { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Account user { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Object userTasks { get; set; }
    }
}
