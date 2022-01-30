namespace Dashboard.Domain.Dtos
{
    public class UserReadDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime DateLastActivity { get; set; }
    }
}
