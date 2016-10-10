using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(AnimalMetaData))]
    public partial class Animal {

    }
    public class AnimalMetaData {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdDono { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int IdRaca { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public System.DateTime DataNascimento { get; set; }
        [Required]
        public string Cor { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public Cliente Cliente { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        [Display(Name = "Raça")]
        public Raca Raca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [ScriptIgnore]
        [JsonIgnore]
        public ICollection<Produto> Produtos { get; set; }
    }
}