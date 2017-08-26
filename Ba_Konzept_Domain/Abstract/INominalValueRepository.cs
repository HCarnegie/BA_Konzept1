using System.Collections.Generic;
using BA_Konzept.Domain.Entities;

namespace BA_Konzept.Domain.Abstract
{
	public interface INominalValueRepository
	{
		IEnumerable<NominalValue> NominalValues { get; }
	}
}
