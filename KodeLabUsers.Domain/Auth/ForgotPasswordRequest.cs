using System.ComponentModel.DataAnnotations;

namespace KodeLabUsers.Domain.Auth
{
    public class ForgotPasswordRequest
    {
        [Required] [EmailAddress] public string Email { get; set; }
    }
}