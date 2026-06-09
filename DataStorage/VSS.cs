using Newtonsoft.Json;
using SSC.DataStorage.Interfaces;
using SSC.DataStorage.Videos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SSC.DataStorage
{
	public class VSS_RedeemBridgeSoundAward : IVSSRedeem
	{
		SoundEntry soundReference;
		public Guid Guid = Guid.NewGuid();
		public Guid SoundReferenceGuid = Guid.NewGuid();

		public Keys KeyCode;

		[JsonIgnore] public Guid VSS_Guid => SoundReferenceGuid;

		[JsonIgnore] public string VSS_Name => $"{KeyCode} - {soundReference?.RewardName ?? "Unknown"}";

		[JsonIgnore] public List<IVSSRedeem> VSS_Children => null;

		[JsonIgnore] public Keys VSS_KeyCode => KeyCode;

		public VSS_RedeemBridgeSoundAward() { }

		internal VSS_RedeemBridgeSoundAward(SoundEntry entry, Keys key)
		{
			this.soundReference = entry;
			this.SoundReferenceGuid = entry.Id;
			this.KeyCode = key;
		}

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

		public bool RecreateReferences()
		{
			var f = MainForm.Instance.SoundDB.SoundList.FirstOrDefault(x => x.Id == VSS_Guid);
			if (f != null)
			{
				soundReference = f;
				return true;
			}
			else
			{
				Debug.WriteLine($"Could not find sound reference for redeem {VSS_Name} with guid {Guid}");
				return false;
			}
		}
	}

	public class VSS_RedeemBridgeVideoAward : IVSSRedeem
	{
		private OBS_VideoReward obsVideoReward;
		public Guid Guid = Guid.NewGuid();
		public Guid VideoGuid = Guid.NewGuid();
		public Keys KeyCode;

		[JsonIgnore] public Guid VSS_Guid => VideoGuid;

		[JsonIgnore] public string VSS_Name => $"{KeyCode} - {obsVideoReward?.RewardName ?? "Unknown"}";

		[JsonIgnore] public List<IVSSRedeem> VSS_Children => null;

		[JsonIgnore] public Keys VSS_KeyCode => KeyCode;

		public VSS_RedeemBridgeVideoAward() { }

		public VSS_RedeemBridgeVideoAward(OBS_VideoReward reward, Keys key)
		{
			this.obsVideoReward = reward;
			this.VideoGuid = reward.Id;
			this.KeyCode = key;
		}

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

		public bool RecreateReferences()
		{
			var f = MainForm.Instance.VideoDB.StorableData.VideoRewards.FirstOrDefault(x => x.Id == VSS_Guid);
			if (f != null)
			{
				obsVideoReward = f;
				return true;
			}
			else
			{
				Debug.WriteLine($"Could not find video reward reference for redeem {VSS_Name} with guid {Guid}");
				return false;
			}
		}
	}

	public class VSS_Container : IVSSRedeem
	{
		public Guid Guid = Guid.NewGuid();
		public Keys KeyCode;
		public string Name;
		public Guid[] Children = new Guid[0];
		[JsonIgnore] public List<IVSSRedeem> ChildrenObjects;

		[JsonIgnore] public Guid VSS_Guid => Guid;

		[JsonIgnore] public string VSS_Name => Name;

		[JsonIgnore] public List<IVSSRedeem> VSS_Children => ChildrenObjects;

		[JsonIgnore] public Keys VSS_KeyCode => KeyCode;

		public VSS_Container() { }

		public VSS_Container(string name, Keys key)
		{
			this.Name = name;
			this.KeyCode = key;
		}

		public object Clone()
		{
			var ch = new IVSSRedeem[ChildrenObjects.Count];
			for (int i = 0; i < ChildrenObjects.Count; i++)
			{
				ch[i] = ChildrenObjects[i].Clone() as IVSSRedeem;
			}

			return new VSS_Container
			{
				Guid = Guid,
				KeyCode = KeyCode,
				Name = Name,
				Children = Children.Clone() as Guid[],
			};
		}

		public bool RecreateReferences()
		{
			return false;

		}
	}

	[Serializable]
	public class VSS_Database : ICloneable
	{
		internal static string GetPath() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSC", "VSS.json");

		[NonSerialized][XmlIgnore] public Dictionary<Guid, IVSSRedeem> VSS_Redeems_Dict = new Dictionary<Guid, IVSSRedeem>();
		public List<IVSSRedeem> VSS_TreeNodes = new();
		public Keys MasterKey;

		private static VSS_Database m_Instance;
		public static VSS_Database Instance
		{
			get
			{
				if (m_Instance == null)
					Load();

				return m_Instance;
			}
		}

		private static void Load()
		{
			m_Instance = JsonUtils.Load(GetPath(), new VSS_Database());
			m_Instance.VSS_Redeems_Dict.Clear();

			List<IVSSRedeem> elementsToRemove = new List<IVSSRedeem>();

			foreach (var redeem in m_Instance.VSS_TreeNodes)
			{
				if(!redeem.RecreateReferences())
					elementsToRemove.Add(redeem);
			}

			foreach(IVSSRedeem elementToRemove in elementsToRemove)
			{
				m_Instance.VSS_TreeNodes.Remove(elementToRemove);
			}

			foreach (var redeem in m_Instance.VSS_TreeNodes)
			{
				m_Instance.VSS_Redeems_Dict.Add(redeem.VSS_Guid, redeem);
			}
		}

		public void Save()
		{
			JsonUtils.Save(GetPath(), this);
		}

		public object Clone()
		{
			VSS_Database copy = new VSS_Database();
			{
				copy.MasterKey = MasterKey;
				copy.VSS_TreeNodes = new List<IVSSRedeem>(VSS_TreeNodes.Count);
				for (int i = 0; i < VSS_TreeNodes.Count; i++)
				{
					if (VSS_TreeNodes[i] is IVSSRedeem)
					{
						copy.VSS_TreeNodes.Add(VSS_TreeNodes[i].Clone() as IVSSRedeem);
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

		internal void RemoveElement(IVSSRedeem cast, IVSSRedeem node)
		{
			if (node == null)
			{
				var rootNodes = VSS_TreeNodes;
				for (int i = VSS_TreeNodes.Count - 1; i >= 0; i--)
				{
					if (VSS_TreeNodes[i] == cast)
					{
						rootNodes.RemoveAt(i);
						break;
					}
					else if (VSS_TreeNodes[i] != null)
					{
						RemoveElement(cast, VSS_TreeNodes[i]);
					}
				}
			}
			else if (node.VSS_Children != null && node.VSS_Children.Count > 0)
			{
				for (int i = node.VSS_Children.Count - 1; i >= 0; i--)
				{
					if (node.VSS_Children[i] == cast)
					{
						node.VSS_Children.RemoveAt(i);
						break;
					}
					else if (node.VSS_Children[i] != null)
					{
						RemoveElement(cast, node.VSS_Children[i]);
					}
				}
			}
		}
	}
}
