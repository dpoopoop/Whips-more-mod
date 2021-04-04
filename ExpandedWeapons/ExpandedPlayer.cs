using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Localization;

namespace ExpandedWeapons
{
	// This is the ModPlayer class. Make note of the classname, which is whipplayer, since we will be using this in the accessory item below.
	public class ExpandedPlayer : ModPlayer
	{
		// Here we declare the overheadminion variable which will represent whether this player has the effect or not.
		public bool overheadMinion;
		private const int saveVersion = 0;

		// ResetEffects is used to reset effects back to their default value. Terraria resets all effects every frame back to defaults so we will follow this design. (You might think to set a variable when an item is equipped and unassign the value when the item in unequipped, but Terraria is not designed that way.)
		public override void ResetEffects() {
			overheadMinion = false;
		}
	}
}