using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SummonWhips.Items.Neutral
{
	// This class stores necessary player info for our custom damage class, such as damage multipliers, additions to knockback and crit, and our custom resource that governs the usage of the weapons of this damage class.
	public class NeutralPlayer : ModPlayer
	{
		public static NeutralPlayer ModPlayer(Player player) {
			return player.GetModPlayer<NeutralPlayer>();
		}

		// Vanilla only really has damage multipliers in code
		// And crit and knockback is usually just added to
		// As a modder, you could make separate variables for multipliers and simple addition bonuses
		public float neutralDamageAdd;
		public float neutralDamageMult = 1f;
		public float neutralKnockback;
		public int neutralCrit = 5;

		public override void ResetEffects() {
			ResetVariables();
		}

		public override void UpdateDead() {
			ResetVariables();
		}

		private void ResetVariables() {
			neutralDamageAdd = 0f;
			neutralDamageMult = 1f;
			neutralKnockback = 0f;
			neutralCrit = 5;
		}
	}
}
