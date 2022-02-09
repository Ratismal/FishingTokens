using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FishingTokens.Items
{
	public class NauticalTreasureBox : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Nautical Treasure Box");
			Tooltip.SetDefault("Contains 1-2 pieces of furniture"
				+ "\n<right> to open");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 22;
			item.maxStack = 99;
			item.value = Item.sellPrice(0, 0, 25, 0);
			item.rare = ItemRarityID.Blue;
		}

        public override bool CanRightClick()
        {
			return true;
        }

		public override void RightClick(Player player)
		{	
			void NauticalTreasureBoxRewards(int reward)
			{
				switch (reward)
				{
					case 0:
						player.QuickSpawnItem(ItemID.LifePreserver);
						break;
					case 1:
						player.QuickSpawnItem(ItemID.ShipsWheel);
						break;
					case 2:
						player.QuickSpawnItem(ItemID.CompassRose);
						break;
					case 3:
						player.QuickSpawnItem(ItemID.WallAnchor);
						break;
					case 4:
						player.QuickSpawnItem(ItemID.PillaginMePixels);
						break;
					case 5:
						player.QuickSpawnItem(ItemID.TreasureMap);
						break;
					case 6:
						player.QuickSpawnItem(ItemID.GoldfishTrophy);
						break;
					case 7:
						player.QuickSpawnItem(ItemID.BunnyfishTrophy);
						break;
					case 8:
						player.QuickSpawnItem(ItemID.SwordfishTrophy);
						break;
					case 9:
						player.QuickSpawnItem(ItemID.SharkteethTrophy);
						break;
					case 10:
						player.QuickSpawnItem(ItemID.ShipInABottle);
						break;
					case 11:
						player.QuickSpawnItem(ItemID.SeaweedPlanter);
						break;
					case 12:
						player.QuickSpawnItem(ItemID.CoralstoneBlock, 50 + Main.rand.Next(101));
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