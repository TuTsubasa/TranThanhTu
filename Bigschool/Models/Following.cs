using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bigschool.Models
{
    public class Following
    {
        [Key]
        [Column(Order =1)]
        public string FollowerId { get; set; }
        public ApplicationUser Follower { get; set; }
        public ApplicationUser Followee { get; set; }
        public string FolloweeId { get; set; }
    }
}