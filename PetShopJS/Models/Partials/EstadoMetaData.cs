using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(EstadoMetaData))]
    public partial class Estado {

    }
    public class EstadoMetaData {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Abreviacao { get; set; }
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