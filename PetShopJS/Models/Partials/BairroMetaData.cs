using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models {
    [MetadataType(typeof(BairroMetaData))]
    public partial class Bairro {

    }

    public class BairroMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdCidade { get; set; }
        [Display(Name = "Bairro")]
        [Required]
        public string Nome { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public virtual Cidade Cidade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [ScriptIgnore]
        [JsonIgnore]
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }

}