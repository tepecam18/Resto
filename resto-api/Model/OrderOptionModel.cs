using Realms;

public class OrderOptionModel : RealmObject
{
    public ProductOptionModel ProductOption { get; set; }
    public ProductModel Product { get; set; }
}