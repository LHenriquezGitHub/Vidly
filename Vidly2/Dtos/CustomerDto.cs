using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
                
        [StringLength(255)]
        public string Name { get; set; }       

        public bool IsSubcribedToNewsLetter { get; set; }
        
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; } = new DateTime(2000, 1, 1);
    }
}