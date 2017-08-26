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
 *		Domainclass to map the Entitytype user of 
 *		the storemodel to the conceptual model.
 *  
 ******************************************************************************/

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Xml.Serialization;

namespace ZWAULineController.Model
{
	/// <summary>
	/// EF Code First Domain class to map the Entitytype producttype of the storemodel to the conceptual model.
	/// </summary>
	[Table("producttype")]
    public class Producttype : EntityBase
    {
		// ### Attributes ###
        [Column(TypeName = "int")]
        public int ProductTypeId { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string DrawingNo { get; set; }


        // ### Relations ### 
		[XmlIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
		[XmlIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Typedata> Typedatas { get; set; }

		// ### Constructor ###
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Producttype()
        {
            Products = new HashSet<Product>();
			Typedatas = new HashSet<Typedata>();
        }

		/// <summary>
		/// define example datarecord for XML-BaseDataTemplate 
		/// </summary>
		public override void FillTemplateData()
		{

		}
	}

    public class ProducttypeMap : EntityTypeConfiguration<Producttype>
    {
        public ProducttypeMap()
        {
            // ### Properties ###
	        Property(e => e.ProductTypeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
		    Property(e => e.DrawingNo).HasMaxLength(20).IsUnicode(false);

	        HasKey(k => k.ProductTypeId);
        }
    }
}
