//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetShopJS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Compra_Produto_Empresa
    {
        public int Id { get; set; }
        public int IdProdutoEmpresa { get; set; }
        public int IdCompra { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Total { get; set; }
    
        public virtual Compra Compra { get; set; }
        public virtual Produto_Empresa Produto_Empresa { get; set; }
    }
}
