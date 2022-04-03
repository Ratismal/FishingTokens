using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FishingTokens.Items
{
	public class FishingToken : ModItem
	{
		public override void SetDefaults() 
		{
			Item.width = 28;
			Item.height = 28;
			Item.maxStack = 9999;
			Item.value = 0;
			Item.rare = ItemRarityID.Orange;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			var priceTooltip = tooltips.Find(line => line.Name == "Price");
			if (priceTooltip != null)
			{
				tooltips.Remove(priceTooltip);
			}
		}
	}
}