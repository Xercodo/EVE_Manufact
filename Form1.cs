using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Runtime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Xml;
using System.Drawing.Design;

namespace EVE_Manufact
{
	public partial class MainForm : Form
	{
		public static Ores allOres = new Ores();
		List<Ore> tritList = new List<Ore>();
		List<Ore> pyerList = new List<Ore>();
		List<Ore> mexList = new List<Ore>();
		List<Ore> isoList = new List<Ore>();
		List<Ore> nocxList = new List<Ore>();
		List<Ore> zydList = new List<Ore>();
		List<Ore> megaList = new List<Ore>();
		List<Ore> morphList = new List<Ore>();

		List<List<Ore>> allSortedOres = new List<List<Ore>>();

		struct RegionDef
		{
			public string name;
			public string typeID;

			public override string ToString()
			{
				return name;
			}
		}

		public MainForm()
		{
			InitializeComponent();

			//
		}

		#region LoadLists

		Ore newOre;
		private void LoadOreList()
		{
			newOre = new Ore();
			string[] lines = EVE_Manufact.Properties.Resources.minerals.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

			int oreCounter = 0;

			for (int x = 0; x < lines.Length; x++)
			{
				string[] parts = lines[x].Split(new char[] { '\t' }, StringSplitOptions.None);

				for (int i = 0; i < parts.Length; i++)
				{
					if (parts[i] == "")
						parts[i] = "0";
				}

				if (!parts[0].Contains("//"))
				{
					if (parts[0].Contains("+5%"))
					{
						newOre.FivePercentName = parts[0];
						newOre.fivePercentID = parts[12];
						newOre.compressedFivePercentID = parts[13];
					}
					else if (parts[0].Contains("+10%"))
					{
						newOre.TenPercentName = parts[0];
						newOre.tenPercentID = parts[12];
						newOre.compressedTenPercentID = parts[13];

						allOres[oreCounter] = newOre;
						oreCounter++;
					}
					else
					{
						newOre = new Ore();

						newOre.name = parts[0];

						newOre.uncompressed = Convert.ToSingle(parts[1]);
						newOre.compressed = Convert.ToSingle(parts[2]);

						newOre.trit = Convert.ToInt32(parts[3]);
						newOre.pyer = Convert.ToInt32(parts[4]);
						newOre.mex = Convert.ToInt32(parts[5]);
						newOre.iso = Convert.ToInt32(parts[6]);
						newOre.nocx = Convert.ToInt32(parts[7]);
						newOre.mega = Convert.ToInt32(parts[8]);
						newOre.zyd = Convert.ToInt32(parts[9]);
						newOre.morph = Convert.ToInt32(parts[10]);

						newOre.location = parts[11];
						newOre.baseID = parts[12];
						newOre.compressedBaseID = parts[13];
						newOre.skillID = parts[14];
					}
				}
			}
		}
		
		private void LoadRegions()
		{
			newOre = new Ore();
			string[] lines = EVE_Manufact.Properties.Resources.regions.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			List<RegionDef> sortList = new List<RegionDef>();

			for (int x = 0; x < lines.Length; x++)
			{
				string[] parts = lines[x].Split(new char[] { '\t' }, StringSplitOptions.None);

				for (int i = 0; i < parts.Length; i++)
				{
					if (parts[i] == "")
						parts[i] = "0";
				}

				if (!parts[0].Contains("//"))
				{
					RegionDef region = new RegionDef();
					region.name = parts[1];
					region.typeID = parts[0];
					sortList.Add(region);
				}				
			}
			sortList.Sort(CompareRegions);
			object[] copyList = sortList.Cast<object>().ToArray<object>();
			comboRegions.Items.AddRange(copyList);
		}

		private static int CompareRegions(RegionDef x, RegionDef y)
		{
			return String.Compare(x.name, y.name, StringComparison.InvariantCulture);
		}

		#endregion

		#region Events

		bool loading = false;
		private void Form1_Load(object sender, EventArgs e)
		{
			loading = true;
			bool upgrade = Properties.Settings.Default.DoUpgrade;
			if (upgrade)
			{
				Properties.Settings.Default.Upgrade();
				Properties.Settings.Default.DoUpgrade = false;
				Properties.Settings.Default.Save();
			}

			string oreData = Properties.Settings.Default.MainData;
			byte[] data = Convert.FromBase64String(oreData);
			if (data.Length > 0)
			{
				IFormatter format = new BinaryFormatter();
				MemoryStream stream = new MemoryStream(data);
				allOres = (Ores)format.Deserialize(stream);
			}

			bool L = Properties.Settings.Default.Loaded;
			if (!L)
			{
				LoadOreList();
				Properties.Settings.Default.Loaded = true;
				Properties.Settings.Default.Save();
			}

			LoadRegions();

			propertyGrid1.SelectedObject = allOres;
			this.trackRepro.Value = Properties.Settings.Default.repro;
			this.trackRepro.Value = Properties.Settings.Default.reproEff;
			this.chkCompressed.Checked = Properties.Settings.Default.compressed;
			this.numBaseRepro.Value = Convert.ToDecimal(Properties.Settings.Default.baseRepro);


			this.grpRepro.Text = "Reprocessing Level: " + Properties.Settings.Default.repro;
			this.grpReproEff.Text = "Reprocessing Efficiency Level: " + Properties.Settings.Default.reproEff;

			CalculateMinerals();
			SetToolTips();

			Point pos = Properties.Settings.Default.windowPos;
			Size size = Properties.Settings.Default.windowSize;

			RegionDef sel = new RegionDef();
			sel.name = Properties.Settings.Default.region;
			sel.typeID = Properties.Settings.Default.regionID;

			comboRegions.SelectedItem = sel;

			if(!pos.IsEmpty && !size.IsEmpty)
			{
				this.Location = pos;
				this.Size = size;
			}

			loading = false;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			IFormatter format = new BinaryFormatter();
			MemoryStream stream = new MemoryStream();
			format.Serialize(stream, allOres);
			Properties.Settings.Default.MainData = Convert.ToBase64String(stream.ToArray());

			Properties.Settings.Default.windowPos = this.Location;
			Properties.Settings.Default.windowSize = this.Size;

			Properties.Settings.Default.region = ((RegionDef)comboRegions.SelectedItem).name;
			Properties.Settings.Default.regionID = ((RegionDef)comboRegions.SelectedItem).typeID;

			Properties.Settings.Default.Loaded = true;
			Properties.Settings.Default.Save();
		}

		private void chkCompressed_CheckedChanged(object sender, EventArgs e)
		{
			if (!loading)
			{
				Properties.Settings.Default.compressed = chkCompressed.Checked;
				Properties.Settings.Default.Save();

				CalculateMinerals();
				SetToolTips();
				UpdateAllOreValues();
				FinalCalc();
			}
		}

		private void ValueChanged(object sender, EventArgs e)
		{
			FinalCalc();
		}

		private void trackReproEff_ValueChanged(object sender, EventArgs e)
		{
			if (!loading)
			{
				Properties.Settings.Default.reproEff = Convert.ToInt32(this.trackReproEff.Value);
				Properties.Settings.Default.Save();
				this.grpReproEff.Text = "Reprocessing Efficiency Level: " + Properties.Settings.Default.reproEff;
				FinalCalc();
			}
		}

		private void trackRepro_ValueChanged(object sender, EventArgs e)
		{
			if (!loading)
			{
				Properties.Settings.Default.repro = Convert.ToInt32(this.trackRepro.Value);
				Properties.Settings.Default.Save();
				this.grpRepro.Text = "Reprocessing Level: " + Properties.Settings.Default.repro;
				FinalCalc();
			}
		}

		private void numBaseRepro_ValueChanged(object sender, EventArgs e)
		{
			if (!loading)
			{
				Properties.Settings.Default.baseRepro = this.numBaseRepro.Value;
				Properties.Settings.Default.Save();
				FinalCalc();
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			UpdateAllOreValues();
		}

		bool asking = false;
		private void MainForm_Activated(object sender, EventArgs e)
		{
			if (!loading)
			{
				if (Clipboard.ContainsText())
				{
					string data = Clipboard.GetText();
					if (data.Contains("Minerals") && data.Contains("typeID\tItem\tAvailable\tRequired\tEst. Unit price"))
					{
						if (!asking)
						{
							asking = true;
							DialogResult result = MessageBox.Show(this, "Bill of Material data detected on the clipboard.\r\n\r\nDo you wish to import requirments?", "Detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
							if (result == System.Windows.Forms.DialogResult.Yes)
							{
								string[] lines = data.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
								foreach (string line in lines)
								{
									string[] chunks = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
									if (chunks.Length >= 4)
									{
										int ava = 0;
										int req = 0;
										int remaining = 0;
										try
										{
											ava = Convert.ToInt32(chunks[2]);
											req = Convert.ToInt32(chunks[3]);
											remaining = (req - ava);
											if (remaining < 0)
												continue;
										}
										catch { }
										switch (chunks[1])
										{
											case "Tritanium":
												this.numTrit.Value = remaining;
												break;
											case "Pyerite":
												this.numPyer.Value = remaining;
												break;
											case "Mexallon":
												this.numMex.Value = remaining;
												break;
											case "Isogen":
												this.numIso.Value = remaining;
												break;
											case "Nocxium":
												this.numNocx.Value = remaining;
												break;
											case "Zydrine":
												this.numZyd.Value = remaining;
												break;
											case "Megacyte":
												this.numMega.Value = remaining;
												break;
											case "Morphite":
												this.numMorph.Value = remaining;
												break;
											default:
												break;
										}
									}
								}
							}
							Clipboard.Clear();
							asking = false;
						}
					}
				}
			}
		}

		#endregion

		#region Load, Compare, and Sort Minerals

		public static int mineralCompareIndex = 0;
		private static int CompareMinerals(Ore x, Ore y)
		{
			if (x == null)
			{
				if (y == null)
					return 0;
				else
					return -1;
			}
			else
			{
				if (y == null)
					return 1;
				else
				{
					float xDiv = Properties.Settings.Default.compressed ? x.compressed : x.uncompressed;
					float yDiv = Properties.Settings.Default.compressed ? y.compressed : y.uncompressed;

					float xVal = ((float)x[mineralCompareIndex] / xDiv);
					float yVal = ((float)y[mineralCompareIndex] / yDiv);
					bool retVal = xVal < yVal;

					if (retVal)
						return 1;
					else
						return -1;
				}
			}
		}

		private void CalculateMinerals()
		{
			this.allSortedOres.Clear();

			for (int i = 0; i < (int)Ore.Minerals.Morph; i++)
			{
				List<Ore> currentMineralList = new List<Ore>();
				for (int x = 0; x < allOres.Count; x++)
				{
					Ore current = allOres[x];
					if (current[i] != 0)
					{
						currentMineralList.Add(current);
					}
				}
				mineralCompareIndex = i;
				currentMineralList.Sort(CompareMinerals);
				allSortedOres.Add(currentMineralList);
			}
		}

		private void SetToolTips()
		{
			string tritTT = "";
			foreach (Ore item in this.tritList)
			{
				tritTT += item.ToString() + "\r\n";
			}
			toolTip1.SetToolTip(this.lblTrit, tritTT);

			string pyerTT = "";
			foreach (Ore item in this.pyerList)
			{
				pyerTT += item.ToString() + "\r\n";
			}
			toolTip1.SetToolTip(this.lblPyer, pyerTT);

			string mexTT = "";
			foreach (Ore item in this.mexList)
			{
				mexTT += item.ToString() + "\r\n";
			}
			toolTip1.SetToolTip(this.lblMex, mexTT);

			string isoTT = "";
			foreach (Ore item in this.isoList)
			{
				isoTT += item.ToString() + "\r\n";
			}
			toolTip1.SetToolTip(this.lblIso, isoTT);

			string nocxTT = "";
			foreach (Ore item in this.nocxList)
			{
				nocxTT += item.ToString() + "\r\n";
			}
			toolTip1.SetToolTip(this.lblNocx, nocxTT);

			string zydTT = "";
			foreach (Ore item in this.zydList)
			{
				zydTT += item.ToString() + "\r\n";
			}
			toolTip1.SetToolTip(this.lblZyd, zydTT);

			string megaTT = "";
			foreach (Ore item in this.megaList)
			{
				megaTT += item.ToString() + "\r\n";
			}
			toolTip1.SetToolTip(this.lblMega, megaTT);

			string morphTT = "";
			foreach (Ore item in this.morphList)
			{
				morphTT += item.ToString() + "\r\n";
			}
			toolTip1.SetToolTip(this.lblMorph, morphTT);
		}

		#endregion

		private struct OreValue
		{
			public string name;
			public int qty;
			public decimal value;
			public Ore baseOre;
		}

		private void FinalCalc()
		{
			decimal tritReq = this.numTrit.Value;
			decimal pyerReq = this.numPyer.Value;
			decimal mexReq = this.numMex.Value;
			decimal isoReq = this.numIso.Value;
			decimal nocxReq = this.numNocx.Value;
			decimal zydReq = this.numZyd.Value;
			decimal megaReq = this.numMega.Value;
			decimal morphReq = this.numMorph.Value;

			List<decimal> requirments = new List<decimal>();
			requirments.Add(morphReq);
			requirments.Add(megaReq);
			requirments.Add(nocxReq);
			requirments.Add(zydReq);
			requirments.Add(isoReq);
			requirments.Add(mexReq);
			requirments.Add(pyerReq);
			requirments.Add(tritReq);

			List<List<OreValue>> allMinerals = new List<List<OreValue>>();

			for (int i = 0, j = (int)Ore.Minerals.Morph; i <= (int)Ore.Minerals.Morph; i++, j--)
			{
				List<OreValue> sortedOres = CheckMinerals((Ore.Minerals)j, requirments[i]);
				allMinerals.Add(sortedOres);
				if (sortedOres.Count > 0)
				{
					for (int x = (int)Ore.Minerals.Morph - 1, y = i; x > i; x--, y++)
					{
						requirments[x] -= allMinerals[i][0].baseOre[y];
					}
				}
			}

			txtMain.Clear();
			decimal totalValue = 0;
			decimal totalVolume = 0;
			foreach (List<OreValue> item in allMinerals)
			{
				if (item.Count > 0)
				{
					string comp = "";
					if (Properties.Settings.Default.compressed)
					{
						comp = "Compressed ";
						totalVolume += item[0].qty * (decimal)item[0].baseOre.compressed;
					}
					else
					{
						totalVolume += item[0].qty * (decimal)item[0].baseOre.uncompressed;
					}

					string quant = item[0].qty.ToString("N0").PadRight(12);
					string name = (comp + item[0].name).PadRight(40);

					totalValue += item[0].value;

					txtMain.AppendText(quant + " of " + name + " at " + item[0].value.ToString("N2") + " ISK\r\n");
				}
			}

			txtMain.AppendText("\r\n\r\n\r\n");
			txtMain.AppendText("Total Volume :".PadRight(20) + totalVolume.ToString("N2") + " m3\r\n");
			txtMain.AppendText("Total Value  :".PadRight(20) + totalValue.ToString("N2") + " ISK\r\n");
		}

		private List<OreValue> CheckMinerals(Ore.Minerals min, decimal requirement)
		{
			int reproLvl = Properties.Settings.Default.repro;
			int reproEffLvl = Properties.Settings.Default.reproEff;
			decimal baseRepro = Properties.Settings.Default.baseRepro;
			bool comp = Properties.Settings.Default.compressed;

			List<OreValue> selectedOres = new List<OreValue>();
			if (requirement > 0 && allSortedOres.Count > 0)
			{
				foreach (Ore item in allSortedOres[(int)min])
				{
					int val;
					decimal prelim;
					decimal multiplier;
					decimal reproAbility = (baseRepro *
						(1.0m + (reproLvl * 0.03m) *
						(1.0m + (reproEffLvl * 0.02m)) *
						(1.0m + (item.Reprocess * 0.02m)))) / 100;
					int quantityMod = comp ? 1 : 100;

					//========================================================== 10% Ore
					multiplier = (decimal)item[(int)min] * 1.10m;
					multiplier *= reproAbility;
					if (multiplier != 0)
					{
						prelim = (requirement / multiplier);
						val = Convert.ToInt32(prelim + 0.5m);
						val *= quantityMod;

						OreValue ten = new OreValue();
						ten.name = item.TenPercentName;
						ten.qty = val;
						ten.value = (decimal)val * item.TenPercentPrice;
						ten.baseOre = item;

						selectedOres.Add(ten);
					}

					//========================================================== 5% Ore
					multiplier = (decimal)item[(int)min] * 1.10m;
					multiplier *= reproAbility;
					if (multiplier != 0)
					{
						prelim = (requirement / multiplier);
						val = Convert.ToInt32(prelim + 0.5m);
						val *= quantityMod;

						OreValue five = new OreValue();
						five.name = item.FivePercentName;
						five.qty = val;
						five.value = (decimal)val * item.FivePrecentPrice;
						five.baseOre = item;

						selectedOres.Add(five);
					}

					//========================================================== Base Ore
					multiplier = (decimal)item[(int)min] * 1.10m;
					multiplier *= reproAbility;
					if (multiplier != 0)
					{
						prelim = (requirement / multiplier);
						val = Convert.ToInt32(prelim + 0.5m);
						val *= quantityMod;

						OreValue baseOre = new OreValue();
						baseOre.name = item.name;
						baseOre.qty = val;
						baseOre.value = (decimal)val * item.BasePrice;
						baseOre.baseOre = item;

						selectedOres.Add(baseOre);
					}
				}

				selectedOres.Sort(CompareValue);
			}

			return selectedOres;
		}

		private static int CompareValue(OreValue x, OreValue y)
		{
			bool retVal = x.value > y.value;

			if (retVal)
				return 1;
			else
				if (x.value == y.value)
					return 0;
			return -1;
		}

		private decimal GetMarketData(string typeID)
		{
			string selectedRegion = ((RegionDef)comboRegions.SelectedItem).typeID;
			string sURL = "http://api.eve-central.com/api/marketstat?typeid=" + typeID + "&regionlimit=" + selectedRegion;
			WebRequest wrGETURL = WebRequest.Create(sURL);
			Stream objStream = wrGETURL.GetResponse().GetResponseStream();
			StreamReader reader = new StreamReader(objStream);
			string data = reader.ReadToEnd();
			XmlReader xReader = XmlReader.Create(new StringReader(data));

			decimal price = 0;

			if (xReader.ReadToFollowing("sell"))
			{
				if (xReader.ReadToFollowing("avg"))
				{
					price = xReader.ReadElementContentAsDecimal();
				}
			}

			return price;
		}

		private void UpdateAllOreValues()
		{
			float step = (100.0f / ((float)allOres.Count * 3.0f)) + 0.5f;
			int currentTotal = 0;
			toolStripStatusLabel1.Text = "Getting market data...";

			for (int i = 0; i < allOres.Count; i++)
			{
				string sendID = "";

				sendID = Properties.Settings.Default.compressed ? allOres[i].compressedBaseID : allOres[i].baseID;
				allOres[i].BasePrice = GetMarketData(sendID);
				currentTotal += Convert.ToInt32(step);
				UpdateProgressBar(toolStripProgressBar1, currentTotal);


				sendID = Properties.Settings.Default.compressed ? allOres[i].compressedFivePercentID : allOres[i].fivePercentID;
				allOres[i].FivePrecentPrice = GetMarketData(sendID);
				currentTotal += Convert.ToInt32(step);
				UpdateProgressBar(toolStripProgressBar1, currentTotal);

				sendID = Properties.Settings.Default.compressed ? allOres[i].compressedTenPercentID : allOres[i].tenPercentID;
				allOres[i].TenPercentPrice = GetMarketData(sendID);
				currentTotal += Convert.ToInt32(step);
				UpdateProgressBar(toolStripProgressBar1, currentTotal);
			}

			propertyGrid1.Refresh();
			UpdateProgressBar(toolStripProgressBar1, 0);
			toolStripStatusLabel1.Text = "    ";

			propertyGrid1.Refresh();
		}

		private void UpdateProgressBar(ToolStripProgressBar bar, int value)
		{
			if (value <= 100)
			{
				bar.Value = 100;
				bar.GetCurrentParent().Refresh();
				bar.Value = value;
				bar.GetCurrentParent().Refresh();
			}
			else
			{
				bar.Value = 100;
				bar.GetCurrentParent().Refresh();
			}
		}

		private void btnCharImport_Click(object sender, EventArgs e)
		{
			DialogResult result = openXML.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.OK)
			{				
				string fileName = openXML.FileName;
				for (int i = 0; i < allOres.Count; i++)
				{
					allOres[i].Reprocess = GetSkillLevelFromXML(fileName, allOres[i].skillID);
				}

				this.trackRepro.Value = GetSkillLevelFromXML(fileName, "3385");
				this.trackReproEff.Value = GetSkillLevelFromXML(fileName, "3389");

				propertyGrid1.Refresh();
			}
		}

		private int GetSkillLevelFromXML(string fileName, string skillID)
		{
			StreamReader reader = new StreamReader(openXML.FileName);
			string fullFile = reader.ReadToEnd();
			reader.Close();

			reader = new StreamReader(openXML.FileName);
			XmlReader xReader = XmlReader.Create(reader);
			if (fullFile.Contains("typeID=\"" + skillID + "\""))
			{
				xReader.ReadToFollowing("row");
				string data = xReader.GetAttribute("typeID");
				while (data != skillID)
				{
					xReader.ReadToFollowing("row");
					data = xReader.GetAttribute("typeID");
				}

				string level = xReader.GetAttribute("level");
				xReader.Close();
				return Convert.ToInt32(level);
			}

			return 0;
		}
	}

	[Serializable]
	public class Ores
	{
		[BrowsableAttribute(false)]
		public int Count { get { return 16; } }

		public Ore this[int i]
		{
			get
			{
				switch (i)
				{
					case 0:
						return veldspar;
					case 1:
						return scordite;
					case 2:
						return pyroxeres;
					case 3:
						return plagioclase;
					case 4:
						return omber;
					case 5:
						return kernite;
					case 6:
						return jaspet;
					case 7:
						return hemorphite;
					case 8:
						return hedbergite;
					case 9:
						return gneiss;
					case 10:
						return dark_Ochre;
					case 11:
						return spodumain;
					case 12:
						return crokite;
					case 13:
						return bistot;
					case 14:
						return arkonor;
					case 15:
						return mercoxit;
					default:
						throw new IndexOutOfRangeException();
				}
			}
			set
			{
				switch (i)
				{
					case 0:
						veldspar = value;
						break;
					case 1:
						scordite = value;
						break;
					case 2:
						pyroxeres = value;
						break;
					case 3:
						plagioclase = value;
						break;
					case 4:
						omber = value;
						break;
					case 5:
						kernite = value;
						break;
					case 6:
						jaspet = value;
						break;
					case 7:
						hemorphite = value;
						break;
					case 8:
						hedbergite = value;
						break;
					case 9:
						gneiss = value;
						break;
					case 10:
						dark_Ochre = value;
						break;
					case 11:
						spodumain = value;
						break;
					case 12:
						crokite = value;
						break;
					case 13:
						bistot = value;
						break;
					case 14:
						arkonor = value;
						break;
					case 15:
						mercoxit = value;
						break;
					default:
						throw new IndexOutOfRangeException();
				}
			}
		}

		#region Highsec Ores

		//Highsec
		Ore veldspar;
		[CategoryAttribute("Highsec Ore"),
		DisplayName("Veldspar"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Veldspar
		{
			get { return veldspar; }
			set { veldspar = value; }
		}
		Ore scordite;
		[CategoryAttribute("Highsec Ore"),
		DisplayName("Scordite"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Scordite
		{
			get { return scordite; }
			set { scordite = value; }
		}
		Ore pyroxeres;
		[CategoryAttribute("Highsec Ore"),
		DisplayName("Pyroxeres"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Pyroxeres
		{
			get { return pyroxeres; }
			set { pyroxeres = value; }
		}
		Ore plagioclase;
		[CategoryAttribute("Highsec Ore"),
		DisplayName("Plagioclase"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Plagioclase
		{
			get { return plagioclase; }
			set { plagioclase = value; }
		}
		Ore omber;
		[CategoryAttribute("Highsec Ore"),
		DisplayName("Omber"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Omber
		{
			get { return omber; }
			set { omber = value; }
		}
		Ore kernite;
		[CategoryAttribute("Highsec Ore"),
		DisplayName("Kernite"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Kernite
		{
			get { return kernite; }
			set { kernite = value; }
		}

		#endregion

		#region Lowsec Ores

		//Lowsec
		Ore jaspet;
		[CategoryAttribute("Lowsec Ore"),
		DisplayName("Jaspet"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Jaspet
		{
			get { return jaspet; }
			set { jaspet = value; }
		}
		Ore hemorphite;
		[CategoryAttribute("Lowsec Ore"),
		DisplayName("Hemorphite"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Hemorphite
		{
			get { return hemorphite; }
			set { hemorphite = value; }
		}
		Ore hedbergite;
		[CategoryAttribute("Lowsec Ore"),
		DisplayName("Hedbergite"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Hedbergite
		{
			get { return hedbergite; }
			set { hedbergite = value; }
		}

		#endregion

		#region Nullsec Ores

		//Nullsec
		Ore gneiss;
		[CategoryAttribute("Nullsec Ore"),
		DisplayName("Gneiss"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Gneiss
		{
			get { return gneiss; }
			set { gneiss = value; }
		}
		Ore dark_Ochre;
		[CategoryAttribute("Nullsec Ore"),
		DisplayName("Dark Ochre"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Dark_Ochre
		{
			get { return dark_Ochre; }
			set { dark_Ochre = value; }
		}
		Ore spodumain;
		[CategoryAttribute("Nullsec Ore"),
		DisplayName("Spodumain"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Spodumain
		{
			get { return spodumain; }
			set { spodumain = value; }
		}
		Ore crokite;
		[CategoryAttribute("Nullsec Ore"),
		DisplayName("Crokite"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Crokite
		{
			get { return crokite; }
			set { crokite = value; }
		}
		Ore bistot;
		[CategoryAttribute("Nullsec Ore"),
		DisplayName("Bistot"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Bistot
		{
			get { return bistot; }
			set { bistot = value; }
		}
		Ore arkonor;
		[CategoryAttribute("Nullsec Ore"),
		DisplayName("Arkonor"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Arkonor
		{
			get { return arkonor; }
			set { arkonor = value; }
		}
		Ore mercoxit;
		[CategoryAttribute("Nullsec Ore"),
		DisplayName("Mercoxit"),
		 TypeConverterAttribute(typeof(OreTypeConverter))]
		public Ore Mercoxit
		{
			get { return mercoxit; }
			set { mercoxit = value; }
		}

		#endregion
	}

	[Serializable]
	public class Ore
	{
		public enum Minerals : int
		{
			Trit = 0, Pyer, Mex, Iso, Nocx, Zyd, Mega, Morph
		};

		#region Properties

		public string name;
		public string FivePercentName;
		public string TenPercentName;

		decimal basePrice, fivePrecentPrice, tenPercentPrice;
		[DisplayName("Value of 10%+ Ore"),
		TypeConverterAttribute(typeof(PriceTypeConverter))]
		public decimal TenPercentPrice
		{
			get { return tenPercentPrice; }
			set { tenPercentPrice = value; }
		}

		[DisplayName("Value of 5%+ Ore"),
		TypeConverterAttribute(typeof(PriceTypeConverter))]
		public decimal FivePrecentPrice
		{
			get { return fivePrecentPrice; }
			set { fivePrecentPrice = value; }
		}

		[DisplayName("Value of Base Ore"),
		TypeConverterAttribute(typeof(PriceTypeConverter))]
		public decimal BasePrice
		{
			get { return basePrice; }
			set { basePrice = value; }
		}

		int reprocess;
		[DisplayName("Reprocessing ability of Ore")]
		public int Reprocess
		{
			get { return reprocess; }
			set { reprocess = value; }
		}

		#endregion

		public float uncompressed;
		public float compressed;
		public int trit, pyer, mex, iso, nocx, zyd, mega, morph;
		public string location;

		public string skillID;

		public int this[int i]
		{
			get
			{
				switch (i)
				{
					case 0:
						return trit;
					case 1:
						return pyer;
					case 2:
						return mex;
					case 3:
						return iso;
					case 4:
						return nocx;
					case 5:
						return zyd;
					case 6:
						return mega;
					case 7:
						return morph;
					default:
						throw new IndexOutOfRangeException();
				}
			}
			set
			{
				switch (i)
				{
					case 0:
						trit = value;
						break;
					case 1:
						pyer = value;
						break;
					case 2:
						mex = value;
						break;
					case 3:
						iso = value;
						break;
					case 4:
						nocx = value;
						break;
					case 5:
						zyd = value;
						break;
					case 6:
						mega = value;
						break;
					case 7:
						morph = value;
						break;
					default:
						throw new IndexOutOfRangeException();
				}
			}
		}

		public string baseID, fivePercentID, tenPercentID;
		public string compressedBaseID, compressedFivePercentID, compressedTenPercentID;

		public override string ToString()
		{
			return name;
		}
	}

	#region Converters

	public class OreTypeConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(Ore);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType)
		{
			if (destinationType == typeof(System.String) && value is Ore)
			{
				Ore so = (Ore)value;
				return so.name;
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}

	public class PriceTypeConverter : StringConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return (sourceType == typeof(string));
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string) && value is decimal)
			{
				decimal outVal = (decimal)value;
				return (outVal.ToString("N2") + "  ISK");
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				string outVal = (string)value;
				int iskIndex = outVal.IndexOf(" ISK");

				if (iskIndex != -1)
					outVal = outVal.Substring(0, iskIndex);

				return Convert.ToDecimal(outVal);
			}
			return base.ConvertFrom(context, culture, value);
		}
	}

	#endregion
}
