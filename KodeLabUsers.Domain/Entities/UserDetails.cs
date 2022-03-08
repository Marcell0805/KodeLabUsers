using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodeLabUsers.Domain.Entities
{
    // UserDetails myDeserializedClass = JsonConvert.DeserializeObject<UserDetails>(myJsonResponse);

    public class UserDetails
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string dateOfBirth { get; set; }
        public string idNumber { get; set; }
        public Address address { get; set; }
    }


}
