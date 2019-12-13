using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoCTest.Domain
{
    [Table("Catalog")]
    public class Catalog
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
