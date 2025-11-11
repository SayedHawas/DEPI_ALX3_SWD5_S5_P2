using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemoLab.Models
{
    //Database First
    [ModelMetadataType(typeof(ProductDataAnnotation))]
    public partial class Product
    {

    }

    public class ProductDataAnnotation
    {
        [Required(ErrorMessage = "Must Enter Name ....")]
        [MaxLength(150, ErrorMessage = "Must Enter Only 150 letters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Must Enter price ....")]
        [Range(0.00, 99999.00)]
        //[CustomValidation(typeof(PriceAttribute), "ValidateValue", ErrorMessage = "Product Price must be at Greater than 500.")]
        [Remote("CheckPrice", "Productsfull", ErrorMessage = "Price Must greater than 100")]
        public decimal Price { get; set; }
        [MaxLength(300, ErrorMessage = "Must Enter Only 300 letters.")]
        public string? Description { get; set; }
        [NotMapped]
        public byte[]? Image { get; set; }
        [MaxLength(255)]
        [DisplayName("Photo")]
        public string? ImagePath { get; set; }
        [ForeignKey("Category")]
        public int CategotyId { get; set; }
    }
}
