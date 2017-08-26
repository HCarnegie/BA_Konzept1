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
 *		Domainclass to map the Entitytype measurementvalue of 
 *		the storemodel to the conceptual model.
 *  
 ******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Xml.Serialization;

namespace ZWAULineController.Model
{
	/// <summary>
	/// EF Code First Domain class to map the Entitytype measurementvalue of the storemodel to the conceptual model.
	/// </summary>

	[Table("measurementvalue")]
    public class Measurementvalue : EntityBase
    {
		// ### Attributes ###
        [Column(TypeName = "bigint")]
        public Int64 AutoId { get; set; }

        [Column(TypeName = "int")]
        public int FkMeasurementtypeId { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? FkProduct_VSn { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime Ts { get; set; }

        [Column(TypeName = "double")]
        public double? ResultValue { get; set; }

		// ### Relations ### 
		[XmlIgnore]
		public virtual Product Product { get; set; }
		[XmlIgnore]
		public virtual Measurementtype Measurementtype { get; set; }


		// ### Constructor ###
		public Measurementvalue() { }

		/// <summary>
		/// define example datarecord for XML-BaseDataTemplate 
		/// </summary>
		public override void FillTemplateData()
		{

		}
	}

	/// <summary>
	/// Entitytypeconfiguration for Measurementvalue-Entity 
	/// Caution: property-configurations are called from modelBuilder after run methode OnModelCreating().
	/// If you ignore a property that you configurate in OnModelCreating(), you'll get an exception.
	/// </summary>
	public class MeasurementvalueMap : EntityTypeConfiguration<Measurementvalue>
    {
        public MeasurementvalueMap()
        {
	        Property(e => e.AutoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(e => e.Ts).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

	        HasKey(k => k.AutoId);
        }
    }
}
