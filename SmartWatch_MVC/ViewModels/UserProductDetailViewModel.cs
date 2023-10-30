using SmartWatch_MVC.Models;

namespace SmartWatch_MVC.ViewModels
{
    public class UserProductDetailViewModel
    {
        public TDanhMucSp product {  get; set; }
        public List<TAnhSp> productImages { get; set; }
    }
}
