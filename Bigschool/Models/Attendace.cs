using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bigschool.Models
{
    public class Attendace
    {
        public Source Source { get; set; }
        [Key]
        [Column(Order = 1)]
        public string SourceId { get; set;}
        public ApplicationUser Attendee { get; set; }
        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
    }

}