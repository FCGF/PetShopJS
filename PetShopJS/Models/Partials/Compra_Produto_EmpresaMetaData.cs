using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PetShopJS.Models.Partials {
    [MetadataType(typeof(Compra_Produto_EmpresaMetaData))]
    public partial class Compra_Produto_Empresa {

    }
    public class Compra_Produto_EmpresaMetaData {
        public int Id { get; set; }
        public int IdProdutoEmpresa { get; set; }
        public int IdCompra { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Total { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public virtual Compra Compra { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public virtual Produto_Empresa Produto_Empresa { get; set; }

    }
}