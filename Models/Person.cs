using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicalApi.Models
{
    public class Person
    {
        [Key]
        public int personId { get; set; }

        [MaxLength(80, ErrorMessage = "Maximum Name Length Outpassed"), Required(ErrorMessage = "*")]
        [Display(Name = "Name")]
        public string personName { get; set; }

        [MaxLength(80, ErrorMessage = "Maximum Surname Length Outpassed"), Required(ErrorMessage = "*")]
        [Display(Name = "Surname")]
        public string prenomPers { get; set; }


        [MaxLength(150, ErrorMessage = "Maximum Adress Length Outpassed"), Required(ErrorMessage = "*")]
        [Display(Name = "Adress")]
        public string adressePers { get; set; }


        [Required(ErrorMessage = "*")]
        [Display(Name = "Birth Date")]
        public DateTime personBirthDate { get; set; }


        [MaxLength(10, ErrorMessage = "Maximum Gender Length Outpassed"), Required(ErrorMessage = "*")]
        [Display(Name = "Gender")]
        public string personGender { get; set; }



        [MaxLength(30, ErrorMessage = "Maximum NIC Length Outpassed"), Required(ErrorMessage = "*")]
        [Display(Name = "NIC")]
        public string personNIC { get; set; }

        [MaxLength(40, ErrorMessage = "Maximum Marital Status Length Outpassed"), Required(ErrorMessage = "*")]
        [Display(Name = "Marital Status")]
        public string personMaritalStatus { get; set; }

        [MaxLength(80, ErrorMessage = "Maximum Email Length Outpassed"), Required(ErrorMessage = "*")]
        [Display(Name = "Email"), DataType(DataType.EmailAddress)]
        public string personEmail { get; set; }
    }

}