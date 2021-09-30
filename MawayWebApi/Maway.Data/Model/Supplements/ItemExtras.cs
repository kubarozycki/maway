using Maway.Data.Model.Supplements;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Maway.Data.Model.Supplements
{
    public class ItemExtras
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ItemTypeId")]
        public int ItemTypeId { get; set; }
        public ItemType ItemType { get; set; }
        [ForeignKey("ExtrasId")]
        public int ExtrasId { get; set; }
        public Extras Extras { get; set; }
    }
}
