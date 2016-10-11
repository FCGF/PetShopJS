using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(EspecieMetaData))]
    public partial class Especie {

    }
    public class EspecieMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Especie")]
        public string Nome { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Raca> Racas { get; set; }

    }
}