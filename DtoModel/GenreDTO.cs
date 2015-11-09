using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoModel
{
    public class GenreDTO
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MovieDTO> Movies { get; set; }
    }
}
