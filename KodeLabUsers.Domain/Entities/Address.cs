using System.ComponentModel.DataAnnotations;

namespace KodeLabUsers.Domain.Entities
{
    public class Address
    {
        [Key]
        [Required]
        public int AddressId { get; set; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
    }
}