using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalApi.Models
{
    public class Bed
    {
        [Key]
        public int bedId { get; set; }

        [MaxLength(2, ErrorMessage = "Maximum Bed Code Length Outpassed"), Required(ErrorMessage = "*")]
        [Display(Name = "Bed Code")]
        public string bedCode { get; set; }


        public int roomId { get; set; }

        [ForeignKey("roomId")]
        public virtual Room room { get; set; }
    }
}