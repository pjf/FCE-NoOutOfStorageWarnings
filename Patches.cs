using Harmony;
using UnityEngine;

namespace NoOutOfStorageWarnings
{
	[HarmonyPatch(typeof(OreExtractor))]
	[HarmonyPatch("UpdateState")]
    public static class Patch_OreExtractor_UpdateState
	{
        // Warnings about being out of storage only happen if they persist beyond a certain
        // time. Rather than changing the OreExtractor state, or trying to transpile out the
        // case in MissionManager, we instead hook OreExtractor.UpdateState and lock the issue
        // time to zero if we're out of storage. This has the effect of meaning the extractor
        // reports storage problems when looked at, but doesn't trigger a mission warning otherwise.
		public static void Postfix(ref OreExtractor __instance)
		{
        	if (__instance.meState == OreExtractor.eState.eOutOfStorage)
			{
				__instance.mrIssueTime = 0;
			}
		}
	}
}
