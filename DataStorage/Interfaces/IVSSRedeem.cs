using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SSC.DataStorage.Interfaces
{
	public interface IVSSRedeem : ICloneable
	{
		public Guid VSS_Guid { get; }
		public string VSS_Name { get; }
		public List<IVSSRedeem> VSS_Children { get; }
		public Keys VSS_KeyCode { get; }

		public void Execute() { }

		bool RecreateReferences();
	}
}
