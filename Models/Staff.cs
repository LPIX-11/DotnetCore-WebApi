using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApi.Models
{
    public class Staff
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int staffId { get; set; }
        [ForeignKey("staffId")]
        public virtual Person person { get; set; }

        [MaxLength(80, ErrorMessage = "Maximum Specialty Length Outpassed"), Required(ErrorMessage = "*")]
        [Display(Name = "Specialty")]
        public string roleSpecialty { get; set; }
    }
}