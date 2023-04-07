namespace WordstageWeb.Models
{
    public class Product
    {
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string ProductTypeId { get; set; }
        public string? FromLanguage { get; set; }
        public string? ToLanguage { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public List<ProductType> productTypes { get; set; }
        public List<ProductPlan> planTypes { get; set; }
        public List<Language> Tolanguages { get; set; }
        public List<Language> Fromlanguages { get; set; }
    }
}
