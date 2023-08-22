using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class Product
    {
        private int id;
        private string? productName;
        private decimal productPrice;
        private int productQuantity;

        public Product()
        {
        }

        public Product(int id, string? productName, decimal productPrice, int productQuantity)
        {
            this.id = id;
            this.productName = productName;
            this.ProductPrice = productPrice;
            this.productQuantity = productQuantity;
        }

        [Key]
        public int Id { get => id; set => id = value; }
        [Column(TypeName = "NVARCHAR")]
        [Required(ErrorMessage = "")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "")]
        public string? ProductName { get => productName; set => productName = value; }
        public int ProductQuantity { get => productQuantity; set => productQuantity = value; }
        public decimal ProductPrice { get => productPrice; set => productPrice = value; }
    }
}