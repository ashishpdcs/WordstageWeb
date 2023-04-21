namespace WordstageWeb.Models
{
    public class ProductService
    {
        public int Id { get; set; }
        public Guid? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? ParentId { get; set; }
        public string? TypeOfElement { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string? SetDefault { get; set; }
    }
}
