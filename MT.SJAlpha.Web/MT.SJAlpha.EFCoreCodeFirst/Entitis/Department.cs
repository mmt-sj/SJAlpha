using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace MT.SJAlpha.EFCoreCodeFirst.Entitis
{
    [Table("department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(256),Required]
        public string Name { get; set; }
    }
}
