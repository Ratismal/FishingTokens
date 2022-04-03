using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FishingTokens.Items
{
	public class NauticalTreasureBox : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

        public override void SetDefaults() 
		{
			Item.width = 32;
			Item.height = 22;
			Item.maxStack = 99;
			Item.value = Item.sellPrice(0, 0, 25, 0);
			Item.rare = ItemRarityID.Blue;
		}

        public override bool CanRightClick()
        {
			return true;
        }

		public override void RightClick(Player player)
		{
			var source = player.GetItemSource_OpenItem(Type);
			void NauticalTreasureBoxRewards(int reward)
			{
				switch (reward)
				{
					case 0:
						player.QuickSpawnItem(source, ItemID.LifePreserver);
						break;
					case 1:
						player.QuickSpawnItem(source, ItemID.ShipsWheel);
						break;
					case 2:
						player.QuickSpawnItem(source, ItemID.CompassRose);
						break;
					case 3:
						player.QuickSpawnItem(source, ItemID.WallAnchor);
						break;
					case 4:
						player.QuickSpawnItem(source, ItemID.PillaginMePixels);
						break;
					case 5:
						player.QuickSpawnItem(source, ItemID.TreasureMap);
						break;
					case 6:
						player.QuickSpawnItem(source, ItemID.GoldfishTrophy);
						break;
					case 7:
						player.QuickSpawnItem(source, ItemID.BunnyfishTrophy);
						break;
					case 8:
						player.QuickSpawnItem(source, ItemID.SwordfishTrophy);
						break;
					case 9:
						player.QuickSpawnItem(source, ItemID.SharkteethTrophy);
						break;
					case 10:
						player.QuickSpawnItem(source, ItemID.ShipInABottle);
						break;
					case 11:
						player.QuickSpawnItem(source, ItemID.SeaweedPlanter);
						break;
				}
			}

			int item1 = Main.rand.Next(13);

			NauticalTreasureBoxRewards(item1);

			if (Main.rand.Next(2) == 1)
            {
				int item2 = Main.rand.Next(13);
				if (item2 != item1)
                {
					NauticalTreasureBoxRewards(item2);
				}
			}
		}
    }
}