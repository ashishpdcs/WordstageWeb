using System.ComponentModel.DataAnnotations;

namespace WordstageWeb.Models
{
    public partial class Login
    {
        public Guid Id { get; set; }
        public string? emailid { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
