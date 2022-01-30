using System.ComponentModel.DataAnnotations;

namespace Dashboard.Domain.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateRegistration { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateLastActivity { get; set; }
    }
}
