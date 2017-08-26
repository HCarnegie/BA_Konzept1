/******************************************************************************
 *  (c) by Zeltwanger Automation GmbH, 72144 Duﬂlingen
 *-----------------------------------------------------------------------------
 * vv.rr| dd.mm.yy |Author    | Description
 * -----+----------+-----+-----------------------------------------------------
 * 01.00| 18.02.17 |HK        | original
 *
 ******************************************************************************
 *		ZWAU_LineController - Model
 *
 *		Entity Framework Code First
 *		Domainclass to map the Entitytype product of 
 *		the storemodel to the conceptual model.
 *  
 ******************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZWAULineController.Model
{
	/// <summary>
	/// EF Code First Domain class to map the Entitytype product of the storemodel to the conceptual model.
	/// </summary>
	[Table("product")]
    public class Product : EntityBase
    {
		// ### Attributes ###
		[Column(TypeName = "bigint")]
        public Int64 Product_VSn { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string ProductSn { get; set; }

        [Column(TypeName = "int")]
        public int FkProductTypeId { get; set; }

        [Column(TypeName = "int")]
        public int FkOrderId { get; set; }

        [Column(TypeName = "int")]
        public int FkRoadmapId { get; set; }

        [Column(TypeName = "int")]
        public int? WtId { get; set; }

        //[Timestamp]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public byte[] RowVersion { get; set; }

        [Column(TypeName = "int")]
        public int Productstatus { get; set; }


        // ### Relations ### 
        public virtual Order Order { get; set; }
        public virtual Roadmap Roadmap { get; set; }
        public virtual Producttype Producttype { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Processing> Processings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Measurementvalue> Measurementvalues { get; set; }

        // ### Constructor ###

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Processings = new HashSet<Processing>();
            Measurementvalues = new HashSet<Measurementvalue>();
        }

		/// <summary>
		/// define example datarecord for XML-BaseDataTemplate 
		/// </summary>
		public override void FillTemplateData()
		{

		}
	}

	/// <summary>
	/// Entitytypeconfiguration for Product-Entity 
	/// Caution: property-configurations are called from modelBuilder after run methode OnModelCreating().
	/// If you ignore a property that you configurate in OnModelCreating(), you'll get an exception.
	/// </summary>
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
			HasKey(e => e.Product_VSn);
			Property(e => e.Product_VSn).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
    }
}
