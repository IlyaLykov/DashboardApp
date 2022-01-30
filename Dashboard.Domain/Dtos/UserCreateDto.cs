using System.ComponentModel.DataAnnotations;

namespace Dashboard.Domain.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateRegistration { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateLastActivity { get; set; }
    }
}
