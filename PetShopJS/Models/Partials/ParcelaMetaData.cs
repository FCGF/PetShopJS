using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models {
    [MetadataType(typeof(ParcelaMetaData))]
    public partial class Parcela {

    }
    public class ParcelaMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(0, 999)]
        public decimal Quantidade { get; set; }
        [Required]
        [Range(0, 99999)]
        public decimal Juros { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compras { get; set; }

    }
}