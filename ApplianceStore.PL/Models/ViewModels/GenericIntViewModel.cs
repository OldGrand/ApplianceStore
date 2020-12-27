using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplianceStore.PL.Models.ViewModels
{
    public class GenericIntViewModel<TSource>
    {
        [Range(1, int.MaxValue)]
        public int Integer { get; set; }
        public IEnumerable<TSource> Source { get; set; }
    }
}
