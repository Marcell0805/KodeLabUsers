using System.ComponentModel.DataAnnotations;

namespace KodeLabUsers.Domain
{
    public class BaseEntity
    {
        [Key] public int Id { get; set; }
    }
}