namespace WordstageWeb.Models.Login
{
    public class Pagination
    {
        public string? GlobalSearch { get; set; } = "";
        public int? PageSize { get; set; } = 0;
        public int? PageIndex { get; set; } = 0;
        public string? OrderBy { get; set; } = "";
        public string? OrderDirection { get; set; } = "";
    }
}
