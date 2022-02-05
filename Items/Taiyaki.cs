using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FishingTokens.Items
{
	public class Taiyaki : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Taiyaki");
            Tooltip.SetDefault("FISH WAFFLE LETS FUCKING GO");
        }

        public override void SetDefaults()
        {
            item.width = 900;
            item.height = 553;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item2;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.buffType = BuffID.WellFed;
            item.buffTime = 54000; //15 minutes
        }
    }
}
