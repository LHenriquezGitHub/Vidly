using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly2.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        private List<Movie> _Movies;
        public List<Movie> Movies
        {
            get { return _Movies; }
            set { _Movies = value; }
        }

        [Display(Name= "Is Subcribed To NewsLetter")]
        public bool IsSubcribedToNewsLetter { get; set; }

        [Display(Name = "Membership Type Name")]
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; } = new DateTime(2000, 1, 1);
    }
}