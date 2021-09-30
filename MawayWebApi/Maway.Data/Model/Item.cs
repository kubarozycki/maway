using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Maway.Data.Model
{
    public class Item : BaseEntity
    {
        [ForeignKey("ItemTypeId")]
        public int ItemTypeId { get; set; }
        [Required]
        public ItemType ItemType { get; set; }
        [Required]
        public string CompanyRegistryId { get; set; }
        public ICollection<Order> ItemOrders { get; set; }
    }
}
