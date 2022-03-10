using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace KodeLabUsers.Domain.Entities
{
    // UserDetails myDeserializedClass = JsonConvert.DeserializeObject<UserDetails>(myJsonResponse);

    public class UserDetails
    {
        [Key]
        [Required]
        public int CustId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }


}
