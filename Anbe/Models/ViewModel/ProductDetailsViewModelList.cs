namespace Anbe.Models.ViewModel
{

    public class ProductDetailsViewModelList
        
    {
        public ProductDetailsViewModelList()
        {

        }
        public ProductDetailsViewModelList(string display, string vizhegi)
        {
            Display = display;
            Vizhegi = vizhegi;
                
        }
        public string Display { get; set; }
        public string Vizhegi { get; set; }
    }
}
