namespace Blogfelhasznalok.Models
{
    public class Dto
    {
        public record CreateUserDto(string title, string description, DateTime createdtime, DateTime lastupdate);
        public record UpdateUserDto(string title, string description, DateTime createdtime, DateTime lastupdate);
    }
}
