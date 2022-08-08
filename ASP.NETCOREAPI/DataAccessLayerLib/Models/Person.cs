using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayerLib.Models
{
    [Table("Persons", Schema = "dbo")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string Email { get; set; }
        [Required]
        public DateTime Createon { get; set; }
        [Required]
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}
