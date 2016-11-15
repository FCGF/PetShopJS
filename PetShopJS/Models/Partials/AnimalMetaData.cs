using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models {
    [MetadataType(typeof(AnimalMetaData))]
    public partial class Animal {

    }
    public class AnimalMetaData {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Owner", ResourceType =typeof(Resources.Resource))]
        public int IdDono { get; set; }
        [Required]
        [Display(Name = "Animal", ResourceType = typeof(Resources.Resource))]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Race", ResourceType = typeof(Resources.Resource))]
        public int IdRaca { get; set; }
        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "BirthDate", ResourceType = typeof(Resources.Resource))]
        public System.DateTime DataNascimento { get; set; }
        [Required]
        [Display(Name = "Color", ResourceType = typeof(Resources.Resource))]
        [StringLength(50, MinimumLength = 3)]
        public string Cor { get; set; }
        [Required]
        [Display(Name = "Sex", ResourceType = typeof(Resources.Resource))]
        public string Sexo { get; set; }
        [Required]
        [Display(Name = "Observations", ResourceType = typeof(Resources.Resource))]
        [StringLength(255, MinimumLength = 3)]
        public string Observacoes { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        [Display(Name = "Owner", ResourceType = typeof(Resources.Resource))]
        public Cliente Cliente { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        [Display(Name = "Race", ResourceType = typeof(Resources.Resource))]
        public Raca Raca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [ScriptIgnore]
        [JsonIgnore]
        public ICollection<Produto> Produtos { get; set; }
    }
}