using Realms;
namespace resto_api.Modal
{
    public class OrderOptionModel : RealmObject
{
    public ProductOptionModel ProductOption { get; set; }
    public ProductModel Product { get; set; }
}
}