using System.ComponentModel.DataAnnotations;

namespace Zainab_Baloch_cultural_.Model
{
    public class SignIn
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
