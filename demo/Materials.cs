//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace demo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Materials
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materials()
        {
            this.ProductMaterials = new HashSet<ProductMaterials>();
        }
    
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int MaterialTypeId { get; set; }
        public decimal PricePerUnit { get; set; }
        public int QuantityInStock { get; set; }
        public int MinQuantity { get; set; }
        public int QuantityPerPackage { get; set; }
        public string UnitOfMeasure { get; set; }
    
        public virtual MaterialTypes MaterialTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductMaterials> ProductMaterials { get; set; }
    }
}
