using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelSample.Data.Entities
{
    public class PetQueryEntity
    {
        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        public int BreedID { get; set; }
        public BreedEntity? Breed { get; set; }
        public int LocationId { get; set; }
        public LocationEntity? Location { get; set; }
    }
}
