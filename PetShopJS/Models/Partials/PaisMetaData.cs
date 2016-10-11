using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(PaisMetaData))]
    public partial class Pais {

    }
    public class PaisMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Pais")]
        public string Nome { get; set; }
        [Required]
        public string Abreviacao { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estado> Estados { get; set; }

    }
}