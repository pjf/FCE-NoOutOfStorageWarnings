using System.Reflection;
using Harmony;
using UnityEngine;

namespace NoOutOfStorageWarnings
{
	public class NoOutOfStorageWarnings : FortressCraftMod
    {
		private static bool modInitialised = false;

		public override ModRegistrationData Register()
		{
			Debug.Log("NoOutOfStorageWarnings loading...");

			if (!modInitialised)
			{
				applyHarmonyPatches();
				modInitialised = true;
			}
            else
			{
				Debug.Log("Unexpected double init in NoOutOfStorageWarnings");
			}

			return new ModRegistrationData();
		}

		private void applyHarmonyPatches()
		{
			Debug.Log("...Applying Harmony patches.");
			var harmony = HarmonyInstance.Create("au.id.pjf.quietercrafting");
			harmony.PatchAll(Assembly.GetExecutingAssembly());
			Debug.Log("...Harmony patches applied.");
		}
    }
}
