using Newtonsoft.Json;
using SSC.DataStorage.Interfaces;
using SSC.DataStorage.Videos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SSC.DataStorage
{
	public class VSS_RedeemBridgeSoundAward : IVSSRedeem
	{
		public Guid VSS_Guid { get; set; } = Guid.NewGuid();
		public Keys VSS_KeyCode { get; set; } = Keys.None;

		SoundEntry soundReference;
		public Guid SoundReferenceGuid = Guid.NewGuid();
		[JsonIgnore] public string VSS_Name => $"{VSS_KeyCode} - {soundReference?.RewardName ?? "Unknown"}";
		[JsonIgnore] public List<IVSSRedeem> VSS_Children => null;
		[JsonIgnore] public IVSSRedeem Parent_Node { get; set; }

		public VSS_RedeemBridgeSoundAward() { }

		internal VSS_RedeemBridgeSoundAward(SoundEntry entry, Keys key)
		{
			this.soundReference = entry;
			this.SoundReferenceGuid = entry.Id;
			this.VSS_KeyCode = key;
		}

		public void Execute()
		{
		}

		public object Clone()
		{
			return new VSS_RedeemBridgeSoundAward
			{
				VSS_Guid = VSS_Guid,
				VSS_KeyCode = VSS_KeyCode,
				SoundReferenceGuid = SoundReferenceGuid,
				soundReference = soundReference
			};
		}

		public bool RecreateReferences()
		{
			var f = MainForm.Instance.SoundDB.SoundList.FirstOrDefault(x => x.Id == SoundReferenceGuid);
			if (f != null)
			{
				soundReference = f;
				return true;
			}
			else
			{
				Debug.WriteLine($"Could not find sound reference for redeem {VSS_Name} with guid {VSS_Guid}");
				return false;
			}
		}
	}

	public class VSS_RedeemBridgeVideoAward : IVSSRedeem
	{
		public Guid VSS_Guid { get; set; } = Guid.NewGuid();
		public Keys VSS_KeyCode { get; set; } = Keys.None;
		private OBS_VideoReward obsVideoReward;
		public Guid VideoGuid = Guid.NewGuid();

		[JsonIgnore] public string VSS_Name => $"{VSS_KeyCode} - {obsVideoReward?.RewardName ?? "Unknown"}";

		[JsonIgnore] public List<IVSSRedeem> VSS_Children => null;
		[JsonIgnore] public IVSSRedeem Parent_Node { get; set; }

		public VSS_RedeemBridgeVideoAward() { }

		public VSS_RedeemBridgeVideoAward(OBS_VideoReward reward, Keys key)
		{
			this.obsVideoReward = reward;
			this.VideoGuid = reward.Id;
			this.VSS_KeyCode = key;
		}

		public void Execute()
		{
		}

		public object Clone()
		{
			return new VSS_RedeemBridgeVideoAward
			{
				VSS_Guid = VSS_Guid,
				VSS_KeyCode = VSS_KeyCode,
				VideoGuid = VideoGuid,
				obsVideoReward = obsVideoReward,
			};
		}

		public bool RecreateReferences()
		{
			var f = MainForm.Instance.VideoDB.StorableData.VideoRewards.FirstOrDefault(x => x.Id == VideoGuid);
			if (f != null)
			{
				obsVideoReward = f;
				return true;
			}
			else
			{
				Debug.WriteLine($"Could not find video reward reference for redeem {VSS_Name} with guid {VSS_Guid}");
				return false;
			}
		}
	}

	public class VSS_Container : IVSSRedeem
	{
		public Guid VSS_Guid { get; set; } = Guid.NewGuid();
		public Keys VSS_KeyCode { get; set; }

		public string Name;
		public List<Guid> Children = new List<Guid>();
		public bool IsExpended = true;
		[JsonIgnore] public List<IVSSRedeem> ChildrenObjectsReferences = new List<IVSSRedeem>();

		[JsonIgnore] public string VSS_Name => Name;

		[JsonIgnore] public List<IVSSRedeem> VSS_Children => ChildrenObjectsReferences;
		[JsonIgnore] public IVSSRedeem Parent_Node { get; set; }

		public VSS_Container() { }

		public VSS_Container(string name, Keys key)
		{
			this.Name = name;
			this.VSS_KeyCode = key;
		}

		public object Clone()
		{
			var ch = new IVSSRedeem[ChildrenObjectsReferences.Count];
			for (int i = 0; i < ChildrenObjectsReferences.Count; i++)
			{
				ch[i] = ChildrenObjectsReferences[i].Clone() as IVSSRedeem;
			}

			return new VSS_Container
			{
				VSS_Guid = VSS_Guid,
				VSS_KeyCode = VSS_KeyCode,
				Name = Name,
				Children = [.. Children],
				IsExpended = IsExpended
			};
		}

		public void Append(IVSSRedeem redeem)
		{
			ChildrenObjectsReferences.Add(redeem);
			Children.Add(redeem.VSS_Guid);
			redeem.Parent_Node = this;
		}

		public void Remove(IVSSRedeem redeem)
		{
			ChildrenObjectsReferences.Remove(redeem);
			Children.Remove(redeem.VSS_Guid);
			Parent_Node = null;
		}

		public bool RecreateReferences()
		{
			return true;
		}
	}

	[Serializable]
	public class VSS_Database : ICloneable
	{
		internal static string GetPath() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSC", "VSS.json");

		[NonSerialized][JsonIgnore] public Dictionary<Guid, IVSSRedeem> VSS_Redeems_Dict = new Dictionary<Guid, IVSSRedeem>();
		[NonSerialized][JsonIgnore] public List<IVSSRedeem> VSS_RootNodes = new();
		public List<IVSSRedeem> VSS_TreeNodes = new();

		public List<Guid> VSS_RootNodeGuids = new();
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
			m_Instance.Initialize();
		}

		private void Initialize()
		{
			VSS_Redeems_Dict.Clear();

			for (int i = VSS_TreeNodes.Count - 1; i >= 0; i--)
			{
				//Get rid of rewards that no longer have references
				if (!VSS_TreeNodes[i].RecreateReferences())
					VSS_TreeNodes.RemoveAt(i);
			}

			//Create a copy of elements and then treverse the tree to remove elements that are orphan now
			HashSet<IVSSRedeem> possibleOrphanNodes = VSS_TreeNodes.ToHashSet();
			//HashSet<IVSSRedeem> loopDetection = new HashSet<IVSSRedeem>();  //possibly in the future?

			//This will need to be cleared again
			foreach (var redeem in VSS_TreeNodes)
				VSS_Redeems_Dict.Add(redeem.VSS_Guid, redeem);

			//Build container references
			foreach (var redeem in VSS_TreeNodes)
			{
				if (redeem is not VSS_Container)
					continue;

				var cast = redeem as VSS_Container;
				cast.ChildrenObjectsReferences.Clear();
				for (int i = cast.Children.Count - 1; i >= 0; i--)
				{
					Guid guid = cast.Children[i];
					if (VSS_Redeems_Dict.TryGetValue(guid, out IVSSRedeem obj))
					{
						cast.ChildrenObjectsReferences.Add(obj);
						obj.Parent_Node = cast;
					}
					else
						cast.Children.RemoveAt(i);
				}
			}

			foreach (Guid rootNodeGuid in VSS_RootNodeGuids)
			{
				if (VSS_Redeems_Dict.TryGetValue(rootNodeGuid, out IVSSRedeem rootNode))
				{
					VSS_RootNodes.Add(rootNode);
					VerifyOrphanNodes(possibleOrphanNodes, rootNode);
				}
			}

			foreach (var orpanNode in possibleOrphanNodes)
				VSS_TreeNodes.Remove(orpanNode);

			VSS_Redeems_Dict.Clear();
			foreach (var redeem in VSS_TreeNodes)
				VSS_Redeems_Dict.Add(redeem.VSS_Guid, redeem);
		}

		private void VerifyOrphanNodes(HashSet<IVSSRedeem> possibleOrphanNodes, IVSSRedeem node)
		{
			if (node == null)
				return;

			possibleOrphanNodes.Remove(node);
			if (node is VSS_Container)
			{
				var cast = node as VSS_Container;
				foreach (Guid childGuid in cast.Children)
				{
					if (VSS_Redeems_Dict.TryGetValue(childGuid, out IVSSRedeem redeem))
					{
						VerifyOrphanNodes(possibleOrphanNodes, redeem);
					}
				}
			}
		}

		public void Save()
		{
			m_Instance = this;
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
				copy.VSS_RootNodeGuids = [.. VSS_RootNodeGuids];
				copy.Initialize();
			}
			return copy;
		}

		internal void RemoveElement(IVSSRedeem elementToDelete)
		{
			if (elementToDelete == null)
				return;

			if (elementToDelete.Parent_Node == null)
			{
				_ = VSS_RootNodes.Remove(elementToDelete);
				_ = VSS_RootNodeGuids.Remove(elementToDelete.VSS_Guid);
			}
			else
			{
				//Technically it always has to be?
				if (elementToDelete.Parent_Node is VSS_Container)
				{
					var parent = (VSS_Container)elementToDelete.Parent_Node;
					_ = parent.Children.Remove(elementToDelete.VSS_Guid);
					_ = parent.ChildrenObjectsReferences.Remove(elementToDelete);
				}

				if (elementToDelete.VSS_Children != null && elementToDelete.VSS_Children.Count > 0)
				{
					for (int i = elementToDelete.VSS_Children.Count - 1; i >= 0; i--)
					{
						var child = elementToDelete.VSS_Children[i];
						if (child == null)
							continue;

						RemoveElement(elementToDelete.VSS_Children[i]);
					}
				}
			}

			VSS_Redeems_Dict.Remove(elementToDelete.VSS_Guid);
			_ = VSS_TreeNodes.Remove(elementToDelete);
		}
	}
}
