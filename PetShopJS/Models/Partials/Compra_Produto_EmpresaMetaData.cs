using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace PetShopJS.Models {
    [MetadataType(typeof(Compra_Produto_EmpresaMetaData))]
    public partial class Compra_Produto_Empresa {

    }
    public class Compra_Produto_EmpresaMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdProdutoEmpresa { get; set; }
        [Required]
        public int IdCompra { get; set; }
        [Required]
        [Range(1, 9999999999)]
        public decimal Quantidade { get; set; }
        [Required]
        [Display(Name = "Valor Unitario")]
        [Range(0, 99999999999)]
        public decimal ValorUnitario { get; set; }
        [Required]
        [Range(0, 99999999999)]
        public decimal Total { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public virtual Compra Compra { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Produto_Empresa Produto_Empresa { get; set; }

    }
}