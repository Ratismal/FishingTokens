using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.Config;
using FishingTokens.Items;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using Terraria.Localization;
using Terraria.Audio;

namespace FishingTokens.NPCs
{
	public class Angler : GlobalNPC
	{
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.Angler)
			{
				// Bait
				bool apprentice = false;
				bool journeyman = false;
				bool master = false;
				if (FishingTokens.config.baitUnlocks == "Boss defeat milestones")
				{
					if (NPC.downedBoss1) { apprentice = true; }
					if (NPC.downedBoss3) { journeyman = true; }
					if (Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3) { master = true; }
				}
				else if (FishingTokens.config.baitUnlocks == "Fishing quests completed")
				{
					if (Main.player[Main.myPlayer].anglerQuestsFinished >= 5) { apprentice = true; }
					if (Main.player[Main.myPlayer].anglerQuestsFinished >= 15) { journeyman = true; }
					if (Main.player[Main.myPlayer].anglerQuestsFinished >= 25) { master = true; }
				}
				else
				{
					apprentice = true;
					journeyman = true;
					master = true;
				}
				if (apprentice)
				{
					shop.item[nextSlot].SetDefaults(ItemID.ApprenticeBait);
					shop.item[nextSlot].shopCustomPrice = 1;
					shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
					nextSlot++;
				}
				if (journeyman)
				{
					shop.item[nextSlot].SetDefaults(ItemID.JourneymanBait);
					shop.item[nextSlot].shopCustomPrice = 2;
					shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
					nextSlot++;
				}
				if (master)
				{
					shop.item[nextSlot].SetDefaults(ItemID.MasterBait);
					shop.item[nextSlot].shopCustomPrice = 4;
					shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
					nextSlot++;
				}

				// Potions
				shop.item[nextSlot].SetDefaults(ItemID.FishingPotion);
				shop.item[nextSlot].shopCustomPrice = 1;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.SonarPotion);
				shop.item[nextSlot].shopCustomPrice = 1;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.CratePotion);
				shop.item[nextSlot].shopCustomPrice = 1;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;

				// Tackle Bag ingredients
				shop.item[nextSlot].SetDefaults(ItemID.HighTestFishingLine);
				shop.item[nextSlot].shopCustomPrice = 30;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.AnglerEarring);
				shop.item[nextSlot].shopCustomPrice = 30;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.TackleBox);
				shop.item[nextSlot].shopCustomPrice = 30;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;

				// Fish finder ingredients
				shop.item[nextSlot].SetDefaults(ItemID.FishermansGuide);
				shop.item[nextSlot].shopCustomPrice = 24;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.WeatherRadio);
				shop.item[nextSlot].shopCustomPrice = 24;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Sextant);
				shop.item[nextSlot].shopCustomPrice = 24;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;

				// Based on quests
				if (FishingTokens.config.gearUnlocks == "Always available" || Main.player[Main.myPlayer].anglerQuestsFinished >= 5)
				{
					shop.item[nextSlot].SetDefaults(ItemID.FuzzyCarrot);
					shop.item[nextSlot].shopCustomPrice = 20;
					shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
					nextSlot++;
				}
				if (Main.hardMode && (FishingTokens.config.gearUnlocks == "Always available" || Main.player[Main.myPlayer].anglerQuestsFinished >= 10))
				{
					shop.item[nextSlot].SetDefaults(ItemID.BottomlessBucket);
					shop.item[nextSlot].shopCustomPrice = 40;
					shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.SuperAbsorbantSponge);
					shop.item[nextSlot].shopCustomPrice = 40;
					shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.FinWings);
					shop.item[nextSlot].shopCustomPrice = 40;
					shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
					nextSlot++;
				}
				if (FishingTokens.config.gearUnlocks == "Always available" || Main.player[Main.myPlayer].anglerQuestsFinished >= 10)
				{
					shop.item[nextSlot].SetDefaults(ItemID.AnglerHat);
					shop.item[nextSlot].shopCustomPrice = 20;
					shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
					nextSlot++;
				}
				if (FishingTokens.config.gearUnlocks == "Always available" || Main.player[Main.myPlayer].anglerQuestsFinished >= 15)
				{
					shop.item[nextSlot].SetDefaults(ItemID.AnglerVest);
					shop.item[nextSlot].shopCustomPrice = 20;
					shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
					nextSlot++;
				}
				if (FishingTokens.config.gearUnlocks == "Always available" || Main.player[Main.myPlayer].anglerQuestsFinished >= 20)
				{
					shop.item[nextSlot].SetDefaults(ItemID.AnglerPants);
					shop.item[nextSlot].shopCustomPrice = 20;
					shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
					nextSlot++;
				}
				if (Main.hardMode && (FishingTokens.config.gearUnlocks == "Always available" || Main.player[Main.myPlayer].anglerQuestsFinished >= 25))
				{
					shop.item[nextSlot].SetDefaults(ItemID.HotlineFishingHook);
					shop.item[nextSlot].shopCustomPrice = 60;
					shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
					nextSlot++;
				}
				if (FishingTokens.config.gearUnlocks == "Always available" || Main.player[Main.myPlayer].anglerQuestsFinished >= 30)
				{
					shop.item[nextSlot].SetDefaults(ItemID.GoldenFishingRod);
					shop.item[nextSlot].shopCustomPrice = 140;
					shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
					nextSlot++;
				}

				// Misc
				shop.item[nextSlot].SetDefaults(ItemID.GoldenBugNet);
				shop.item[nextSlot].shopCustomPrice = 44;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.FishHook);
				shop.item[nextSlot].shopCustomPrice = 36;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.FishMinecart);
				shop.item[nextSlot].shopCustomPrice = 36;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;

				// Costumes
				shop.item[nextSlot].SetDefaults(ItemType<MermaidSet>());
				shop.item[nextSlot].shopCustomPrice = 26;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemType<FishSet>());
				shop.item[nextSlot].shopCustomPrice = 26;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemType<NauticalTreasureBox>());
				shop.item[nextSlot].shopCustomPrice = 16;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemType<Taiyaki>());
				shop.item[nextSlot].shopCustomPrice = 14;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;
			}
		}

		public override void Load()
		{
			IL.Terraria.Main.GUIChatDrawInner += Main_GUIChatDrawInner;
			IL.Terraria.Player.GetAnglerReward += Player_GetAnglerReward;
		}

		private void Main_GUIChatDrawInner(MonoMod.Cil.ILContext il)
		{
			var c = new ILCursor(il);

			var anglerQuestLabel = c.DefineLabel();
			var nextNpcSecondButtonLabel = c.DefineLabel();

			c.GotoNext(i => i.MatchLdsfld(typeof(Lang), nameof(Lang.inter)));

			c.GotoNext(i => i.MatchLdcI4(NPCID.Angler));
			
			// Change first button to Shop
			c.GotoNext(i => i.MatchLdcI4(64));
			c.Remove();
			c.Emit(OpCodes.Ldc_I4_S, (sbyte)28);

			c.GotoNext();
			c.GotoNext();
			c.GotoNext();
			c.GotoNext();

			// Add Quest button
			c.Emit(OpCodes.Ldsfld, typeof(Lang).GetField(nameof(Lang.inter)));
			c.Emit(OpCodes.Ldc_I4_S, (sbyte)64);
			c.Emit(OpCodes.Ldelem_Ref);
			c.Emit(OpCodes.Callvirt, typeof(LocalizedText).GetMethod("get_Value"));
			c.Emit(OpCodes.Stloc_S, (byte)10);

			c.GotoNext(i => i.MatchCall(typeof(NPCLoader), nameof(NPCLoader.OnChatButtonClicked)));

			c.GotoNext(i => i.MatchLdcI4(NPCID.Angler));
			c.GotoNext();
			c.GotoNext();


			// Open Shop
			c.Emit(OpCodes.Ldarg_0);
			c.Emit(OpCodes.Ldsfld, typeof(Main).GetField(nameof(Main.MaxShopIDs)));
			c.Emit(OpCodes.Ldc_I4_1);
			c.Emit(OpCodes.Sub);
			c.Emit(OpCodes.Ldc_I4_1);
			c.Emit(OpCodes.Stsfld, typeof(Main).GetField(nameof(Main.playerInventory)));
			c.Emit(OpCodes.Ldc_I4, 9999);
			c.Emit(OpCodes.Stsfld, typeof(Main).GetField(nameof(Main.stackSplit)));
			c.Emit(OpCodes.Ldstr, "");
			c.Emit(OpCodes.Stsfld, typeof(Main).GetField(nameof(Main.npcChatText)));
			c.Emit(OpCodes.Ldarg_1);
			c.Emit(OpCodes.Call, typeof(Main).GetMethod(nameof(Main.SetNPCShopIndex)));
			c.Emit(OpCodes.Ldarg_0);
			c.Emit(OpCodes.Ldfld, typeof(Main).GetField(nameof(Main.shop)));
			c.Emit(OpCodes.Call, typeof(Main).GetProperty(nameof(Main.npcShop)));
			c.Emit(OpCodes.Ldelem_Ref);
			c.Emit(OpCodes.Call, typeof(Main).GetProperty(nameof(Main.npcShop)));
			c.Emit(OpCodes.Callvirt, typeof(Chest).GetMethod(nameof(Chest.SetupShop)));

			// Play sound
			c.Emit(OpCodes.Ldc_I4_S, (sbyte)12);
			c.Emit(OpCodes.Ldc_I4_M1);
			c.Emit(OpCodes.Ldc_I4_M1);
			c.Emit(OpCodes.Ldc_I4_1);
			c.Emit(OpCodes.Ldc_R4, (float)1);
			c.Emit(OpCodes.Ldc_R4, (float)0.0);
			c.Emit(OpCodes.Call, typeof(SoundEngine).GetMethod(nameof(SoundEngine.PlaySound), new[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(float), typeof(float) }));

			// Return
			c.Emit(OpCodes.Pop);
			c.Emit(OpCodes.Ret);

			c.MarkLabel(anglerQuestLabel);

			c.GotoNext(i => i.MatchCall(typeof(NPCLoader), nameof(NPCLoader.OnChatButtonClicked)));

			c.GotoNext();
			
			// Check if NPC ID is 369, otherwise go to next check
			c.Emit(OpCodes.Ldsfld, typeof(Main).GetField(nameof(Main.npc)));
			c.Emit(OpCodes.Ldsfld, typeof(Main).GetField(nameof(Main.player)));
			c.Emit(OpCodes.Ldsfld, typeof(Main).GetField(nameof(Main.myPlayer)));
			c.Emit(OpCodes.Ldelem_Ref);
			c.Emit(OpCodes.Ldfld, typeof(Player).GetProperty(nameof(Player.talkNPC)));
			c.Emit(OpCodes.Ldelem_Ref);
			c.Emit(OpCodes.Ldfld, typeof(NPC).GetField(nameof(NPC.type)));
			c.Emit(OpCodes.Ldc_I4, NPCID.Angler);
			c.Emit(OpCodes.Bne_Un, nextNpcSecondButtonLabel);

			// Go to Angler Quest label
			c.Emit(OpCodes.Br_S, anglerQuestLabel);

			c.MarkLabel(nextNpcSecondButtonLabel);
		}

		private void Player_GetAnglerReward(MonoMod.Cil.ILContext il)
		{
			var c = new ILCursor(il);

			var skipRewardsLabel = c.DefineLabel();
			var endOfIfLabel = c.DefineLabel();

			// Go to the 75 check
			c.GotoNext(i => i.MatchLdcI4(75));
			// Since this is an else-if statement, we actually want to go a bit back to the branch statement that brought us here (bne.un.s at IL_00F7).
			c.GotoPrev(i => i.OpCode == OpCodes.Bne_Un_S);
			// Now that we're here, we're going to forward this to the end of the if chunk (IL_0538). This turns the else-if into a straight else.
			c.Emit(OpCodes.Bne_Un_S, endOfIfLabel);
			c.Remove();

			// Skip to the end of the primary if statement chunk (IL_0538)
			c.GotoNext(i => i.OpCode == OpCodes.Ldloc_0);
			// We are currently on a ldloc.0 statement (rewardItems). Skip forward to after the item is added.
			c.MarkLabel(endOfIfLabel);
			c.GotoNext();
            c.GotoNext();
            c.GotoNext();
            // Push rewardItems again
            c.Emit(OpCodes.Ldloc_0);
            // Push the player instance (this)
            c.Emit(OpCodes.Ldarg_0);
			// We now have (rewardItems, this) allocated to stack, call FishingTokens.TokenRewards(List<Item> rewardItems, Player player)
			c.Emit(OpCodes.Call, typeof(FishingTokens).GetMethod(nameof(FishingTokens.TokenRewards)));
            // Skip rewards to the bait section
			c.Emit(OpCodes.Br_S, skipRewardsLabel);

			// Skip all rewards until bait
			c.GotoNext(i => i.MatchLdcI4(2676));
			c.GotoPrev(i => i.MatchLdsfld(typeof(Main), nameof(Main.rand)));
			c.GotoPrev(i => i.MatchLdsfld(typeof(Main), nameof(Main.rand)));
			c.MarkLabel(skipRewardsLabel);
		}
	}
}
