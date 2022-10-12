using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsnRemaninderAPI.Models
{
    [Table("course")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("course_name")]
        public string? CourseName { get; set; }

        [Column("asn_due_count")]
        public long AsnDueCount { get; set; }

        
        public List<Assignment>? Assignments { get; set; }

    }
}
