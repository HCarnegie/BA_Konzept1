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
 *		Domainclass to map the Entitytype settingvalue of 
 *		the storemodel to the conceptual model.
 *  
 ******************************************************************************/


using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Xml.Serialization;

namespace ZWAULineController.Model
{
	[Table("settingvalue")]
    public class Settingvalue : EntityBase
    {
		// ### Attributes ###

		[Column(TypeName = "int")]
		public int FkParameterId { get; set; }

		[Column(TypeName = "int")]
		public int FkId { get; set; }

		[Column(TypeName = "int")]
        public int FkMachineId { get; set; }

        [Column(TypeName = "int")]
        public int FkModuleId { get; set; }

        [Column(TypeName = "int")]
        public int FkProcessId { get; set; }

        // ### Relations ### 

		[XmlIgnore]
        public virtual HwProcess HwProcess { get; set; }
		[XmlIgnore]
		public virtual Typedata Typedata { get; set; }

		// ### Constructor ###
	    public Settingvalue()
	    {
			
	    }
		/// <summary>
		/// define example datarecord for XML-BaseDataTemplate 
		/// </summary>
		public override void FillTemplateData()
		{

		}
	}

    public class SettingvalueMap : EntityTypeConfiguration<Settingvalue>
    {
        public SettingvalueMap()
        {
	        Property(e => e.FkParameterId).HasColumnOrder(0);
			Property(e => e.FkId).HasColumnOrder(1);
		}
    }
}
