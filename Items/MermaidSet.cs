using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FishingTokens.Items
{
	public class MermaidSet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mermaid Set");
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
			player.QuickSpawnItem(ItemID.SeashellHairpin);
			player.QuickSpawnItem(ItemID.MermaidAdornment);
			player.QuickSpawnItem(ItemID.MermaidTail);
		}
    }
}