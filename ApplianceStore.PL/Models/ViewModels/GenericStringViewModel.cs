using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplianceStore.PL.Models.ViewModels
{
    public class GenericStringViewModel<TSource>
    {
        [Required]
        [StringLength(50)]
        public string String { get; set; }
        public IEnumerable<TSource> Source { get; set; }
    }
}
