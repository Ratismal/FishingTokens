using Terraria;
using Terraria.GameContent.UI;
using Terraria.ModLoader;
using FishingTokens.Items;
using MonoMod.Cil;

namespace FishingTokens
{
	public class FishingTokens : Mod
	{

		public static int FishingTokenCurrencyID;
		public override void Load()
		{
			// Fishing Token Currency
			FishingTokenCurrencyID = CustomCurrencyManager.RegisterCurrency(new FishingTokenCurrency(ModContent.ItemType<Items.FishingToken>(), 999L));
		}
	}
}