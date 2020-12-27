using System.ComponentModel.DataAnnotations;

namespace ApplianceStore.PL.Models.BindingModels
{
    public class RangeBindingModel
    {
        [Range(1, int.MaxValue)]
        public int Start { get; set; }
        [Range(1, int.MaxValue)]
        public int End { get; set; }
    }
}
