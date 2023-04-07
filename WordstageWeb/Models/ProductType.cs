namespace WordstageWeb.Models
{
    public partial class ProductType
    {
        public Guid? TypeId { get; set; }
        public string? ProductTypeName { get; set; }
        public string? ProductTypeDescription { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
