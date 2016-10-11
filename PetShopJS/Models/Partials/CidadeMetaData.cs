using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(CidadeMetaData))]
    public partial class Cidade {

    }
    public class CidadeMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Cidade")]
        public string Nome { get; set; }
        [Required]
        public int IdEstado { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bairro> Bairros { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Estado Estado { get; set; }

    }
}