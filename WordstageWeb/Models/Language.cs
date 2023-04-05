using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordstageWeb.Models
{
    public partial class Language : Pagination
    {
        public string LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
