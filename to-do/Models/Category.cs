using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Models
{
    [Table("Categories")]
    public class Category
    {
		[Key]
		public int CategoryId { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Item> Items { get; set; }

        public Category()
        {
            this.Items = new HashSet<Item>();
        }
    }
}
