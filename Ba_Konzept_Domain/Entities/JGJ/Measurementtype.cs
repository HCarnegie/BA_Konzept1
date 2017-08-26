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
 *		Domainclass to map the Entitytype measurementtype of 
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
	/// EF Code First Domain class to map the Entitytype Mesurementtype of the storemodel to the conceptual model.
	/// </summary>
	[Table("measurementtype")]
    public class Measurementtype : EntityBase
    {
		// ### Attributes ###
        [Column(TypeName = "int")]
        public int MeasurementtypeId { get; set; }

        [Column(TypeName = "int")]
        public int? FkProcessId { get; set; }

        [Column(TypeName = "int")]
        public int? TnDisplayName { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Unit { get; set; }

		// ### Relations ### 
		[XmlIgnore]
		public virtual Process Process { get; set; }

		[XmlIgnore]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Limit> Limits { get; set; }

		[XmlIgnore]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Measurementvalue> Measurementvalues { get; set; }

		// ### Constructor ###

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Measurementtype()
        {
            Limits = new HashSet<Limit>();
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
	/// Entitytypeconfiguration for Measurementtype-Entity 
	/// Caution: property-configurations are called from modelBuilder after run methode OnModelCreating().
	/// If you ignore a property that you configurate in OnModelCreating(), you'll get an exception.
	/// </summary>
	public class MeasurementtypeMap : EntityTypeConfiguration<Measurementtype>
    {
        public MeasurementtypeMap()
        {
            // ### Properties ###
            Property(e => e.Unit).HasMaxLength(10).IsUnicode(false);

	        HasKey(e => e.MeasurementtypeId);
        }
    }
}
