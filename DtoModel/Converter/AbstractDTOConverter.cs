using System;
using System.Collections.Generic;
using System.Linq;

namespace DtoModel.Converter
{
        public abstract class AbstractDtoConverter<T, TD>
        {
            public IEnumerable<TD> Convert(IEnumerable<T> toConvert)
            {
                return toConvert.Select(item => Convert(item)).ToList();
            }

            public abstract TD Convert(T item);
        }
   
}
