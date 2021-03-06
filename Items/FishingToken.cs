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
			item.width = 28;
			item.height = 28;
			item.maxStack = 999;
			item.value = 0;
			item.rare = ItemRarityID.Orange;
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