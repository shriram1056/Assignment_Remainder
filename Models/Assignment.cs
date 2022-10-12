using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsnRemaninderAPI.Models
{
    [Table("assignment")]
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("asn_name")]
        public string? AsnName { get; set; }

        [Required]
        [Column("is_complete")]
        public bool IsComplete { get; set; }

        [Required]
        [Column("due_date")]
        public DateTime DueDate { get; set; }

        [Column("course_id")]
        public long CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course? Course { get; set; }
            
    }
}
