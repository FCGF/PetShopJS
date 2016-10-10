using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(RacaMetaData))]
    public partial class Raca {

    }
    public class RacaMetaData {

        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdEspecie { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Animal> Animals { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Especie Especie { get; set; }
    }
}