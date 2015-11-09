using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DtoModel
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
}
