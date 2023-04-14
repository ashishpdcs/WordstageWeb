using System.ComponentModel.DataAnnotations;

namespace WordstageWeb.Models
{
    public partial class Login
    {
        public Guid Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? emailid { get; set; }
       
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$")]

        public string? Password { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

    }
}
