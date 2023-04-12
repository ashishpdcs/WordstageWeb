namespace WordstageWeb.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string? OrderNo { get; set; }
        public Guid? ProductId { get; set; }
        public string? FromLanguageId { get; set; }
        public string? ToLanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid? SampleId { get; set; }
        public int? Items { get; set; }
        public int? NoofWords { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string? OrderDescription { get; set; }
    }
}
