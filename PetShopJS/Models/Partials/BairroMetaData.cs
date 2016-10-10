using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(BairroMetaData))]
    public partial class Bairro {
    }

    public class BairroMetaData {
        [Key]
        public int Id { get; set; }
        public int IdCidade { get; set; }
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