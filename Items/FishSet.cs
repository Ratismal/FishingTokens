using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FishingTokens.Items
{
	public class FishSet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Fish Costume Set");
			Tooltip.SetDefault("<right> to open");
		}

		public override void SetDefaults() 
		{
			item.width = 26;
			item.height = 34;
			item.maxStack = 1;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.rare = ItemRarityID.White;
		}

        public override bool CanRightClick()
        {
			return true;
        }

        public override void RightClick(Player player)
        {
			player.QuickSpawnItem(ItemID.FishCostumeMask);
			player.QuickSpawnItem(ItemID.FishCostumeShirt);
			player.QuickSpawnItem(ItemID.FishCostumeFinskirt);
		}
    }
}