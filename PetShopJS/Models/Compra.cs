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
    
    public partial class Compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compra()
        {
            this.Compra_Produto_Empresa = new HashSet<Compra_Produto_Empresa>();
        }
    
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdCondicao { get; set; }
        public string Codigo { get; set; }
        public decimal Desconto { get; set; }
        public int IdFormaPagamento { get; set; }
        public int IdParcela { get; set; }
        public decimal Total { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Condicao Condicao { get; set; }
        public virtual Forma_Pagamento Forma_Pagamento { get; set; }
        public virtual Parcela Parcela { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra_Produto_Empresa> Compra_Produto_Empresa { get; set; }
    }
}
