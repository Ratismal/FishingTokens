using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.Localization;

namespace FishingTokens
{
	public class FishingTokenCurrency : CustomCurrencySingleCoin
	{
		public Color TokenColor = new Color(170, 191, 226);
		public string amountcheck;

		public FishingTokenCurrency(int coinItemID, long currencyCap) : base(coinItemID, currencyCap)
		{
		}

		public override void GetPriceText(string[] lines, ref int currentLine, int price)
		{
			Color color = TokenColor * ((float)Main.mouseTextColor / 255f);
			if (price != 1)
			{
				amountcheck = Language.GetTextValue("Mods.FishingTokens.Common.CurrencyNamePlural");
            }
			else
            {
				amountcheck = Language.GetTextValue("Mods.FishingTokens.Common.CurrencyName");
			}
			lines[currentLine++] = string.Format("[c/{0:X2}{1:X2}{2:X2}:{3} {4} {5}]", new object[]
				{
					color.R,
					color.G,
					color.B,
					Language.GetTextValue("LegacyTooltip.50"),
					price,
					amountcheck
				});
		}
	}
}
