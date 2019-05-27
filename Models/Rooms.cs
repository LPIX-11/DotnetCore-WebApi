using System.ComponentModel.DataAnnotations;

namespace ClinicalApi.Models {
    public class Room {
        [Key]
        public int roomId { get; set; }

        [MaxLength (5, ErrorMessage = "Maximum Room Code Length Outpassed"), Required (ErrorMessage = "*")]
        [Display (Name = "Room Code")]
        public string roomCode { get; set; }

        [MaxLength (80, ErrorMessage = "Maximum Room Name Length Outpassed"), Required (ErrorMessage = "*")]
        [Display (Name = "Room Name")]
        public string roomName { get; set; }
    }
}