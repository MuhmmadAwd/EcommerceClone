using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Desc { get; set; }
        public decimal Price { get; set; }
        [Required]
        public string PictureUrl { get; set; }

        public ProductType productType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand productBrand { get; set; }
        public int ProductBrandId { get; set; }

    }
}