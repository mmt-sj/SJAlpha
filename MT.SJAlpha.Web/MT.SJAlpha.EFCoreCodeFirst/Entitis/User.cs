using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MT.SJAlpha.EFCoreCodeFirst.Entitis
{
    [Table("user")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(32), Required]
        public string Account { get; set; }
        [MaxLength(32), Required]
        public string Password { get; set; }
        [MaxLength(32), Required]
        public string PhoneNumber { get; set; }
        [MaxLength(32), Required]
        public string Name { get; set; }
        [MaxLength(8), Required]
        public string Sex { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [MaxLength(32), Required]
        public string Type{ get; set; }
        [MaxLength(1024)]
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
