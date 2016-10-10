using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(CidadeMetaData))]
    public partial class Cidade {

    }
    public class CidadeMetaData {
        public int Id { get; set; }
        public string Nome { get; set; }
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