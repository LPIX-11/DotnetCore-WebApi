using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApi.Models
{
    public class Doctor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int doctorId { get; set; }

        [ForeignKey("doctorId")]
        public virtual Person person { get; set; }

        [MaxLength(80, ErrorMessage = "Maximum Specialty Name Length Outpassed"), Required(ErrorMessage = "*")]
        [Display(Name = "Specialty")]
        public string doctorSpecialty { get; set; }
    }

}