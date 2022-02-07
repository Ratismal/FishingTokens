using System.Collections.Generic;
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
		public static RewardConfig config;
		public override void Load()
		{
			// Fishing Token currency
			FishingTokenCurrencyID = CustomCurrencyManager.RegisterCurrency(new FishingTokenCurrency(ModContent.ItemType<Items.FishingToken>(), 999L));
			// Config
			config = GetConfig("RewardConfig") as RewardConfig;
		}
		public static void TokenRewards(int anglerQuestsFinished, List<Item> rewardItems)
		{
			Item item6 = new Item();
			int tokenmin = config.tokenMin;
			int tokenmax = config.tokenMax;
			int tokenexpertbonus = config.tokenExpertBonus;
			int tokenscalebonus = config.tokenScaleBonus;
			int tokenquestscale;
			if (anglerQuestsFinished >= 75)
			{
				tokenquestscale = 5;
			}
			else
			{
				tokenquestscale = anglerQuestsFinished / 15;
			}
				int num3 = Main.rand.Next(tokenmin, tokenmax);
			num3 += tokenscalebonus* tokenquestscale;
			if (Main.expertMode)
			{
				num3 += tokenexpertbonus;
			}
			item6.SetDefaults(ModContent.ItemType<FishingToken>(), false);
			item6.stack = num3;
			rewardItems.Add(item6);
		}
	}
}