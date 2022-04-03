using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FishingTokens.Items
{
	public class Taiyaki : ModItem
	{
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 34;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item2;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.buffType = BuffID.WellFed2;
            Item.buffTime = 43200; //12 minutes
        }
    }
}
