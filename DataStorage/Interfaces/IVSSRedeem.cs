using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace SSC.DataStorage.Interfaces
{
	public interface IVSSRedeem : ICloneable
	{
		[JsonIgnore] public Guid VSS_Guid { get; }
		[JsonIgnore] public string VSS_Name { get; }
		[JsonIgnore] public List<IVSSRedeem> VSS_Children { get; }
		[JsonIgnore] public Keys VSS_KeyCode { get; }

		public void Execute() { }

		bool RecreateReferences();
	}
}
