/******************************************************************************
 *  (c) by Zeltwanger Automation GmbH, 72144 Dußlingen
 *-----------------------------------------------------------------------------
 * vv.rr| dd.mm.yy |Author    | Description
 * -----+----------+-----+-----------------------------------------------------
 * 01.00| 18.02.17 |HK        | original
 *
 ******************************************************************************
 *		ZWAU_LineController - Model - ENUM
 *
 *		Entity Framework Code First
 *		Domainclass to map the Entitytype limittype of 
 *		the storemodel to the conceptual model.
 *  
 ******************************************************************************/

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ZWAULineController;

namespace ZWAULineController.Model
{
	/// <summary>
	/// EF Code First Domain class to map the Entitytype limittype of the storemodel to the conceptual model.
	/// Represents the Enum Limittype.
	/// </summary>
	[Table("limittype")]
	public class Limittype : EntityBase
	{
		/// Attributes 

		[Column(TypeName = "smallint")]
		public short LimittypeId { get; set; }

		[Column(TypeName = "VARCHAR")]
		public string Name { get; set; }

		[Column(TypeName = "VARCHAR")]
		public string Description { get; set; }

		/// Relations/Navigations

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Limit> Limits { get; set; }

		/// <summary>
		/// Constructor for Entitytype Enum Limittype
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Limittype()
		{
			Limits = new HashSet<Limit>();
		}

		/// Map Enum to limittype table
		public Limittype(EnumLimittype @enum)
		{
			LimittypeId = (short)@enum;
			Name = @enum.ToString();
			Description = @enum.GetEnumDescription();
		}

		public static implicit operator Limittype(EnumLimittype @enum) => new Limittype(@enum);
		public static implicit operator EnumLimittype(Limittype type) => (EnumLimittype)type.LimittypeId;

		/// <summary>
		/// define example datarecord for XML-BaseDataTemplate 
		/// </summary>
		public override void FillTemplateData()
		{

		}
	}

	/// <summary>
	/// Entitytypeconfiguration for Limittype-Entity 
	/// Caution: property-configurations are called from modelBuilder after run methode OnModelCreating().
	/// If you ignore a property that you configurate in OnModelCreating(), you'll get an exception.
	/// </summary>
	public class LimittypeMap : EntityTypeConfiguration<Limittype>
	{
		public LimittypeMap()
		{
			// ### Properties ###
			HasKey(e => e.LimittypeId);
			Property(e => e.LimittypeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
			Property(e => e.Description).HasMaxLength(30).IsUnicode(false);
		}
	}
}
