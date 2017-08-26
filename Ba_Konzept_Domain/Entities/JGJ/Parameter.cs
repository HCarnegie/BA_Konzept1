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
 *		Domainclass to map the Entitytype parameter of 
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
	/// EF Code First Domain class to map the Entitytype parameter of the storemodel to the conceptual model.
	/// </summary>
	[Table("parameter")]
    public class Parameter : EntityBase
    {
		// ### Attributes ###
        [Column(TypeName = "int")]
        public int ParameterId { get; set; }

        [Column(TypeName = "int")]
        public int FkId { get; set; }

        [Column(TypeName = "int")]
        public int? TnDisplayName { get; set; }

        [Column(TypeName = "double")]
        public double? CurValue { get; set; }

        // ### Relations ### 

        //public virtual limit limit { get; set; }
		[XmlIgnore]
        public virtual Plant Plant { get; set; }
		[XmlIgnore]
		public virtual Machine Machine { get; set; }
		[XmlIgnore]
		public virtual Module Module { get; set; }
		[XmlIgnore]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parameterchange> Parameterchanges { get; set; }

        // ### Constructor ###

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Parameter()
        {
            Parameterchanges = new HashSet<Parameterchange>();
        }

		/// <summary>
		/// define example datarecord for XML-BaseDataTemplate 
		/// </summary>
		public override void FillTemplateData()
		{

		}

	}

    public class ParameterMap : EntityTypeConfiguration<Parameter>
    {
        public ParameterMap()
        {
            // ### Properties ###

        }
    }
}
