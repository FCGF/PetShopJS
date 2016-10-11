using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models {
    [MetadataType(typeof(EspecificacaoMetaData))]
    public partial class Especificacao {

    }
    public class EspecificacaoMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdProduto { get; set; }
        [Required]
        [Display(Name = "Especificação")]
        public string Nome { get; set; }
        public string Valor { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public virtual Produto Produto { get; set; }

    }
}