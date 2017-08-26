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
 *		Domainclass to map the Entitytype limit of 
 *		the storemodel to the conceptual model.
 *  
 ******************************************************************************/

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Xml.Serialization;

namespace ZWAULineController.Model
{
	[Table("limit")]
    public class Limit : EntityBase
    {
		[Column(TypeName = "int")]
        public int FkParameterId { get; set; }

        [Column(TypeName = "int")]
        public int FkId { get; set; }

        [Column(TypeName = "int")]
        public int FkMeasurementtypeId { get; set; }

		[Column(TypeName = "smallint")]
		public short FkLimittypeId { get; set; }

		[Column(TypeName = "varchar")]
        public string Comment { get; set; }

        // ### Relations ###  
		[XmlIgnore]
        public virtual Measurementtype Measurementtype { get; set; }
		[XmlIgnore]
		public virtual Parameter Parameter { get; set; }
		[XmlIgnore]
		public virtual Limittype Limittype { get; set; }

		// ### Constructor ###
		public Limit(){ }

		/// <summary>
		/// define example datarecord for XML-BaseDataTemplate 
		/// </summary>
		public override void FillTemplateData()
		{

		}
	}

    public class LimitMap : EntityTypeConfiguration<Limit>
    {
        public LimitMap()
        {

		}
    }
}
