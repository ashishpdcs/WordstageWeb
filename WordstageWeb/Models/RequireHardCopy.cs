namespace WordstageWeb.Models
{
    public class RequireHardCopy
    {
        public int Id { get; set; }
        public string? Details { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
