using Admix.AdmixCore;
using Admix.AdmixCore.Data;
using Admix.AdmixCore.Editor;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

#if UNITY_2018_1_OR_NEWER
using UnityEditor.Build.Reporting;
#endif

namespace Assets.Admix.AdmixAssets.Editor
{
#if UNITY_2018_1_OR_NEWER
    // ReSharper disable once UnusedMember.Global
    public class AdmixBuildPreprocessor : IPreprocessBuildWithReport
    {
#else
    // ReSharper disable once UnusedMember.Global
    public class AdmixBuildPreprocessor : IPreprocessBuild
    {
#endif

        public int callbackOrder { get { return 0; } }
        /// <summary>
        /// This method will be called before build start.
        /// </summary>
#if UNITY_2018_1_OR_NEWER
        public void OnPreprocessBuild(BuildReport report)
#else
        public void OnPreprocessBuild(BuildTarget target, string path)
#endif
        {
            if (AdmixSharedSettings.DebugMode == AppStateMode.ForceSandbox)
            {
                EditorUtility.DisplayDialog("Forced Sandbox Build",
                    "Attention! Forced Sandbox mode is in use. Make sure that this build isn't uploaded to the app store, " +
                    "as it won't generate any revenue.", "OK");
            }

            MaterialBuildHelper.TurnOffPlacementsTextures();

            if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS && PlayerSettings.stripEngineCode)
            {
                if (EditorUtility.DisplayDialog("Admix",
                    "Strip engine code may break Admix web view!\nPlease, use managed stripping only.",
                    "OK"))
                {
                    PlayerSettings.stripEngineCode = false;
                }
                else
                {
                    Debug.LogError("Admix: Strip engine code enabled.");
                }
            }
        }
    }
}