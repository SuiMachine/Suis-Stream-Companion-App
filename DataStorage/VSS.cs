using SSC.DataStorage.Interfaces;
using SSC.DataStorage.Videos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SSC.DataStorage
{
	public class VSS_RedeemBridgeSoundAward : IVSSRedeem
	{
		SoundEntry soundReference;
		public Guid Guid = Guid.NewGuid();
		public Keys KeyCode;

		public Guid VSS_Guid => soundReference.Id;

		public string VSS_Name => $"{KeyCode} - {soundReference.RewardName}";

		public IVSSRedeem[] VSS_Children => null;

		public Keys VSS_KeyCode => KeyCode;

		public void Execute()
		{
		}

		public object Clone()
		{
			return new VSS_RedeemBridgeSoundAward
			{
				Guid = Guid,
				KeyCode = KeyCode,
				soundReference = soundReference
			};
		}
	}

	public class VSS_RedeemBridgeVideoAward : IVSSRedeem
	{
		private OBS_VideoReward obsVideoReward;
		public Guid Guid = Guid.NewGuid();

		public Keys KeyCode;

		public Guid VSS_Guid => Guid;

		public string VSS_Name => obsVideoReward.RewardName;

		public IVSSRedeem[] VSS_Children => null;

		public Keys VSS_KeyCode => KeyCode;

		public void Execute()
		{
		}

		public object Clone()
		{
			return new VSS_RedeemBridgeVideoAward
			{
				Guid = Guid,
				KeyCode = KeyCode,
				obsVideoReward = obsVideoReward
			};
		}
	}

	public class VSS_Container : IVSSRedeem
	{
		public Guid Guid = Guid.NewGuid();
		public Keys KeyCode;
		public string Name;
		public Guid[] Children = new Guid[0];
		[NonSerialized] public IVSSRedeem[] ChildrenObjects;

		public Guid VSS_Guid => Guid;

		public string VSS_Name => Name;

		public IVSSRedeem[] VSS_Children => ChildrenObjects;

		public Keys VSS_KeyCode => KeyCode;

		public object Clone()
		{
			var ch = new IVSSRedeem[ChildrenObjects.Length];
			for(int i=0; i<ChildrenObjects.Length; i++)
			{
				ch[i] = ChildrenObjects[i].Clone() as IVSSRedeem;
			}

			return new VSS_Container
			{
				Guid = Guid,
				KeyCode = KeyCode,
				Name = Name,
				Children = Children.Clone() as Guid[],
				ChildrenObjects = ch
			};
		}
	}

	[Serializable]
	public class VSS_Database : ICloneable
	{
		internal static string GetPath() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSC", "VSS.xml");

		public Dictionary<Guid, IVSSRedeem> VSS_Redeems_Dict = new Dictionary<Guid, IVSSRedeem>();
		public object[] VSS_TreeNodes = [];
		public Keys MasterKey;

		private static VSS_Database m_Instance;
		public static VSS_Database Instance
		{
			get
			{
				if (m_Instance == null)
					m_Instance = XML_Utils.Load(GetPath(), new VSS_Database());

				return m_Instance;
			}
		}

		public void Save()
		{
			XML_Utils.Save(GetPath(), this);
		}

		public object Clone()
		{
			VSS_Database copy = new VSS_Database();
			{
				copy.MasterKey = MasterKey;
				copy.VSS_TreeNodes = new object[VSS_TreeNodes.Length];
				for(int i=0; i<VSS_TreeNodes.Length; i++)
				{
					if(VSS_TreeNodes[i] is IVSSRedeem)
					{
						copy.VSS_TreeNodes[i] = (VSS_TreeNodes[i] as IVSSRedeem).Clone();
					}
					else
					{
						Debug.WriteLine($"Non clonable type!");
					}

				}
				copy.VSS_TreeNodes = VSS_TreeNodes;
				copy.VSS_Redeems_Dict = VSS_Redeems_Dict;
			}
			return copy;
		}
	}
}
