using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FishingTokens.Items
{
	public class MermaidSet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults() 
		{
			Item.width = 26;
			Item.height = 34;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.White;
		}

        public override bool CanRightClick()
        {
			return true;
        }

        public override void RightClick(Player player)
        {
			var source = player.GetItemSource_OpenItem(Type);
			player.QuickSpawnItem(source, ItemID.SeashellHairpin);
			player.QuickSpawnItem(source, ItemID.MermaidAdornment);
			player.QuickSpawnItem(source, ItemID.MermaidTail);
		}
    }
}