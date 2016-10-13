using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models {
    [MetadataType(typeof(RacaMetaData))]
    public partial class Raca {

    }
    public class RacaMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Raça")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
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