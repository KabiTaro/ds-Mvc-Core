﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ds.NorthwindApp.Web.Models
{
    public partial class Products
    {
        public Products()
        {
            Order_Details = new HashSet<Order_Details>();
        }

        [Key]
        public int ProductID { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        [ForeignKey(nameof(CategoryID))]
        [InverseProperty(nameof(Categories.Products))]
        public virtual Categories Category { get; set; }
        [ForeignKey(nameof(SupplierID))]
        [InverseProperty(nameof(Suppliers.Products))]
        public virtual Suppliers Supplier { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<Order_Details> Order_Details { get; set; }
    }
}