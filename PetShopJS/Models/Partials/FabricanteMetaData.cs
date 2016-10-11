using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(FabricanteMetaData))]
    public partial class Fabricante {

    }
    public class FabricanteMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Fabricante")]
        public string Nome { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produto> Produtos { get; set; }

    }
}