using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(EstadoMetaData))]
    public partial class Estado {

    }
    public class EstadoMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public string Nome { get; set; }
        [Required]
        public string Abreviacao { get; set; }
        [Required]
        public int IdPais { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cidade> Cidades { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Pais Pais { get; set; }

    }
}