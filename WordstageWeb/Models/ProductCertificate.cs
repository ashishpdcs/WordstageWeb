namespace WordstageWeb.Models
{
    public class ProductCertificate
    {
        public Guid ProductCertificateId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Noofapplicants { get; set; }
        public bool? Requiredservices { get; set; }
        public bool? DocumentsApostilled { get; set; }
        public bool? CanadaImmigrationVisa { get; set; }
        public int? NotarizedAndCertyIndianAddressId { get; set; }
        public bool? NotarizedTranslation { get; set; }
        public int? RequireHardCopyId { get; set; }
        public string? CourierServiceAddress { get; set; }
        public int? NeedApostilleId { get; set; }
        public bool? CourierEntireIndianAddress { get; set; }
        public string? AvailingApostilleService { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
