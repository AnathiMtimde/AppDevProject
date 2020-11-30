using AssessmentBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DGSappSem2.Models
{
    public class Blackboard
    {
      
            [Key]
            //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int BlackboardID { get; set; }


            [Required(ErrorMessage = "Please Speficy Subject Name")]
            [DisplayName("Subject Name")]
            public string Subject { get; set; }


            [Required(ErrorMessage = "Please Grade")]
            [DisplayName("Grade")]
            public string Grade { get; set; }


            [Required(ErrorMessage = "Please State Cstegory")]
            [DisplayName("Material Category")]
            public string Category { get; set; }


            [Required(ErrorMessage = "Please Uplaod Course Material")]
            [DisplayName("Upload Material")]
            public string Upload { get; set; }

        public int ClassRoomID { get; set; }
        public virtual ClassRoom ClassRooms { get; set; }

        
    }
}