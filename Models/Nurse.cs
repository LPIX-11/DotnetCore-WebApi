using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApi.Models
{
    public class Nurse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nurseId { get; set; }

        [ForeignKey("nurseId")]
        public virtual Person person { get; set; }

        [MaxLength(80, ErrorMessage = "Maximum Specialty Name Length Outpassed"), Required(ErrorMessage = "*")]
        [Display(Name = "Specialty")]
        public string nurseSpecialty { get; set; }
    }
}