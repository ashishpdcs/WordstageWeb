using Microsoft.AspNetCore.Mvc.Rendering;
using WordstageWeb.Models.Login;

namespace WordstageWeb.Models.Language
{
    public partial class Language : Pagination
    {
        public Guid LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
