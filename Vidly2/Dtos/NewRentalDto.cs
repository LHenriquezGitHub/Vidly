
using System.Collections.Generic;

namespace Vidly2.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MoviesIds { get; set; }
    }
}