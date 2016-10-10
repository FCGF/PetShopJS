using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(Produto_EmpresaMetaData))]
    public partial class Produto_Empresa {

    }
    public class Produto_EmpresaMetaData {

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int IdProduto { get; set; }
        public decimal Valor { get; set; }
        public decimal Estoque { get; set; }
        public bool Ativo { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra_Produto_Empresa> Compra_Produto_Empresa { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Empresa Empresa { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Produto Produto { get; set; }
    }
}