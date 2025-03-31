using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne.Company.Storage.Entities
{
    [Table("ContactTypes", Schema = "Dictionaries")]
    public class ContactType
    {
        [MinLength(2)]
        [MaxLength(50)]
        [Required]
        public string Code { get; set; } = null!;
        public ICollection<ContactTypeTranslation> Translations { get; set; } = new HashSet<ContactTypeTranslation>();
    }
}
