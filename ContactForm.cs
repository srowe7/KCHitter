using System.ComponentModel.DataAnnotations;

namespace KCHitterDAD.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = "You must provide your name.")]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "You must provide your email."), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must include a message.")]
        public string Message { get; set; }
    }
}