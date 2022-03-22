namespace Anbe.Models.ViewModels
{
    public class ProductDiscountViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int PriceToziKonande { get; set; }
        public string ProductDescription { get; set; }
        public string ImagePath { get; set; }
        public byte DiscountPercent { get; set; }

    }
}
