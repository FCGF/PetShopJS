using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(ClienteMetaData))]
    public partial class Cliente {

        [NotMapped]
        public string CompareSenha { get; set; }
    }
    public class ClienteMetaData {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Cliente")]
        public string Nome { get; set; }
        [Required]
        public int IdEndereco { get; set; }
        public string Email { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [RegularExpression(@"^ ((?=.*[a - z])(?=.*[A - Z])(?=.*\d)).+$)")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Repetir Senha")]
        [Compare("Senha", ErrorMessage = "Senhas devem bater")]
        public string CompareSenha { get; set; }
        public string Telefone { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Animal> Animals { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compras { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }

    }
}