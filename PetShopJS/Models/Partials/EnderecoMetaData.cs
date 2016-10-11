using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(EnderecoMetaData))]
    public partial class Endereco {

    }
    public class EnderecoMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdBairro { get; set; }
        [Required]
        public string Endereco1 { get; set; }
        public string Endereco2 { get; set; }
        [Required]
        public string CEP { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public virtual Bairro Bairro { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Clientes { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empresa> Empresas { get; set; }

    }
}