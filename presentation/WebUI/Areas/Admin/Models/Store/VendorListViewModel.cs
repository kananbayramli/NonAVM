namespace ECommerse.WebUI.Areas.Admin.Models.Store;

public class VendorListViewModel
{
    public string StoreName { get; set; } = null!;
    public string? StoreLogo { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? OwnerID { get; set; }
    public string OwnerName { get; set; } = string.Empty!;
    public int ProductCount { get; set; }
    public decimal TotalProfit { get; set; }

}
