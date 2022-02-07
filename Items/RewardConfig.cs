using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace FishingTokens
{
    public class RewardConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Base Reward")]

        [Label("Minimum Fishing Tokens")]
        [Tooltip("The minimum number of Fishing Tokens randomly chosen as a reward")]
        [Range(0, 20)]
        [DefaultValue(2)]
        [Slider]
        public int tokenMin;

        [Label("Maximum Fishing Tokens")]
        [Tooltip("The maximum number of Fishing Tokens randomly chosen as a reward")]
        [Range(0, 20)]
        [DefaultValue(6)]
        [Slider]
        public int tokenMax;

        [Header("Bonuses")]

        [Label("Expert Bonus")]
        [Tooltip("How many additional Fishing Tokens are rewarded if playing on Expert")]
        [Range(0, 20)]
        [DefaultValue(1)]
        [Slider]
        public int tokenExpertBonus;

        [Label("Scale Bonus")]
        [Tooltip("How many additional Fishing Tokens are rewarded per every 15 quests previously completed (capped at 75 quests)")]
        [Range(0, 20)]
        [DefaultValue(1)]
        [Slider]
        public int tokenScaleBonus;

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            tokenMin = Utils.Clamp(tokenMin, 0, tokenMax);
            tokenMax = Utils.Clamp(tokenMax, tokenMin, 20);
            tokenExpertBonus = Utils.Clamp(tokenExpertBonus, 0, 20);
            tokenScaleBonus = Utils.Clamp(tokenScaleBonus, 0, 20);
        }

    }
}