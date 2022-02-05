using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FishingTokens.Items;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using Terraria.Localization;

namespace FishingTokens.NPCs
{
	public class Angler : GlobalNPC
	{
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.Angler)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Taiyaki>());
				shop.item[nextSlot].shopCustomPrice = 3;
				shop.item[nextSlot].shopSpecialCurrency = FishingTokens.FishingTokenCurrencyID;
				nextSlot++;
			}
		}

		public override bool Autoload(ref string name)
		{
			IL.Terraria.Main.GUIChatDrawInner += Main_GUIChatDrawInner;
			return base.Autoload(ref name);
		}

		private void Main_GUIChatDrawInner(MonoMod.Cil.ILContext il)
		{
			var c = new ILCursor(il);

			var anglerQuestLabel = c.DefineLabel();
			var nextNpcSecondButtonLabel = c.DefineLabel();

			c.GotoNext(i => i.MatchCall(typeof(NPCLoader), nameof(NPCLoader.OnChatButtonClicked)));

			c.GotoNext(i => i.MatchLdcI4(369));
			c.GotoNext();
			c.GotoNext();

			// Open Shop
			c.Emit(OpCodes.Ldc_I4_1);
			c.Emit(OpCodes.Stsfld, typeof(Main).GetField(nameof(Main.playerInventory)));
			c.Emit(OpCodes.Ldstr, "");
			c.Emit(OpCodes.Stsfld, typeof(Main).GetField(nameof(Main.npcChatText)));
			c.Emit(OpCodes.Ldsfld, typeof(Main).GetField(nameof(Main.MaxShopIDs)));
			c.Emit(OpCodes.Ldc_I4_1);
			c.Emit(OpCodes.Sub);
			c.Emit(OpCodes.Stsfld, typeof(Main).GetField(nameof(Main.npcShop)));
			c.Emit(OpCodes.Ldarg_0);
			c.Emit(OpCodes.Ldfld, typeof(Main).GetField(nameof(Main.shop)));
			c.Emit(OpCodes.Ldsfld, typeof(Main).GetField(nameof(Main.npcShop)));
			c.Emit(OpCodes.Ldelem_Ref);
			c.Emit(OpCodes.Ldc_I4, NPCID.Angler);
			c.Emit(OpCodes.Callvirt, typeof(Chest).GetMethod(nameof(Chest.SetupShop)));

			// Play sound
			c.Emit(OpCodes.Ldc_I4_S, (sbyte)12);
			c.Emit(OpCodes.Ldc_I4_M1);
			c.Emit(OpCodes.Ldc_I4_M1);
			c.Emit(OpCodes.Ldc_I4_1);
			c.Emit(OpCodes.Ldc_R4, (float)1);
			c.Emit(OpCodes.Ldc_R4, (float)0.0);
			c.Emit(OpCodes.Call, typeof(Main).GetMethod(nameof(Main.PlaySound), new[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(float), typeof(float) }));

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
			c.Emit(OpCodes.Ldfld, typeof(Player).GetField(nameof(Player.talkNPC)));
			c.Emit(OpCodes.Ldelem_Ref);
			c.Emit(OpCodes.Ldfld, typeof(NPC).GetField(nameof(NPC.type)));
			c.Emit(OpCodes.Ldc_I4, 369);
			c.Emit(OpCodes.Bne_Un, nextNpcSecondButtonLabel);

			// Go to Angler Quest label
			c.Emit(OpCodes.Br_S, anglerQuestLabel);

			c.MarkLabel(nextNpcSecondButtonLabel);
		}
	}
}
