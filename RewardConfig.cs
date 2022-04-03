using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader.Config;

namespace FishingTokens
{
    public class RewardConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("$Mods.FishingTokens.RewardConfig.Header.AnglerShopUnlocks")]

        [DrawTicks]
        [Label("$Mods.FishingTokens.RewardConfig.Label.BaitUnlocks")]
        [Tooltip("$Mods.FishingTokens.RewardConfig.Tooltip.BaitUnlocks")]
        [OptionStrings(new string[] { "Boss defeat milestones", "Fishing quests completed", "Always available" })]
        [DefaultValue("Boss defeat milestones")]
        public string baitUnlocks { get; set; }

        [DrawTicks]
        [Label("$Mods.FishingTokens.RewardConfig.Label.GearUnlocks")]
        [Tooltip("$Mods.FishingTokens.RewardConfig.Tooltip.GearUnlocks")]
        [OptionStrings(new string[] { "Fishing quests completed", "Always available" })]
        [DefaultValue("Fishing quests completed")]
        public string gearUnlocks { get; set; }

        [Header("$Mods.FishingTokens.RewardConfig.Header.BaseReward")]

        [Label("$Mods.FishingTokens.RewardConfig.Label.MinimumFishingTokens")]
        [Tooltip("$Mods.FishingTokens.RewardConfig.Tooltip.MinimumFishingTokens")]
        [Range(0, 40)]
        [DefaultValue(4)]
        [Slider]
        public int tokenMin;

        [Label("$Mods.FishingTokens.RewardConfig.Label.MaximumFishingTokens")]
        [Tooltip("$Mods.FishingTokens.RewardConfig.Tooltip.MaximumFishingTokens")]
        [Range(0, 40)]
        [DefaultValue(14)]
        [Slider]
        public int tokenMax;

        [Header("$Mods.FishingTokens.RewardConfig.Header.Bonuses")]

        [Label("$Mods.FishingTokens.RewardConfig.Label.ExpertBonus")]
        [Tooltip("$Mods.FishingTokens.RewardConfig.Tooltip.ExpertBonus")]
        [Range(0, 20)]
        [DefaultValue(2)]
        [Slider]
        public int tokenExpertBonus;

        [Label("$Mods.FishingTokens.RewardConfig.Label.ScaleBonus")]
        [Tooltip("$Mods.FishingTokens.RewardConfig.Tooltip.ScaleBonus")]
        [Range(0, 20)]
        [DefaultValue(2)]
        [Slider]
        public int tokenScaleBonus;

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            tokenMin = Utils.Clamp(tokenMin, 0, tokenMax);
            tokenMax = Utils.Clamp(tokenMax, tokenMin, 20);
            tokenExpertBonus = Utils.Clamp(tokenExpertBonus, 0, 20);
            tokenScaleBonus = Utils.Clamp(tokenScaleBonus, 0, 20);
            string[] baitUnlocksArray = { "Boss defeat milestones", "Fishing quests completed", "Always available" };
            string[] gearUnlocksArray = { "Fishing quests completed", "Always available" };
            if (!baitUnlocksArray.Any(baitUnlocks.Contains))
            {
                baitUnlocks = "Boss defeat milestones";
            }
            if (!gearUnlocksArray.Any(gearUnlocks.Contains))
            {
                gearUnlocks = "Fishing quests completed";
            }
        }

    }
}