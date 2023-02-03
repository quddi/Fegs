using UnityEditor;
using System.IO;
using UnityEditor.Callbacks;
using Admix.AdmixCore.Editor;

#if UNITY_IOS
using UnityEditor.iOS.Xcode;
#endif

namespace Admix.WebView
{
    public class AdmixBuildPostProcessor
    {
        [PostProcessBuild(700)]
        public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
        {
            MaterialBuildHelper.TurnOnPlacementsTextures();
#if UNITY_IOS
            if (target != BuildTarget.iOS)
            {
                return;
            }
            string projectPath = pathToBuiltProject + "/Unity-iPhone.xcodeproj/project.pbxproj";
            var project = new PBXProject();
            project.ReadFromString(File.ReadAllText(projectPath));
        #if UNITY_2019_3_OR_NEWER
            string targetGuid = project.GetUnityFrameworkTargetGuid();
        #else
            string targetGuid = project.TargetGuidByName("Unity-iPhone");
        #endif
            project.AddFrameworkToProject(targetGuid, "WebKit.framework", false);
            project.AddBuildProperty(targetGuid, "OTHER_LDFLAGS", "-ObjC");
            project.AddBuildProperty(targetGuid, "ENABLE_BITCODE", "NO");
            File.WriteAllText(projectPath, project.WriteToString());

#endif

        }
    }
}
