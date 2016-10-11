using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models {
    [MetadataType(typeof(CompraMetaData))]
    public partial class Compra {

    }
    public class CompraMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdCondicao { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public decimal Desconto { get; set; }
        [Required]
        public int IdFormaPagamento { get; set; }
        [Required]
        public int IdParcela { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public System.DateTime Data { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Condicao Condicao { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Forma_Pagamento Forma_Pagamento { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Parcela Parcela { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra_Produto_Empresa> Compra_Produto_Empresa { get; set; }

    }
}