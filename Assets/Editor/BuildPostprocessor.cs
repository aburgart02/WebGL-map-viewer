using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

namespace Editor
{
    public class BuildPostprocessor
    {
        private const string MapFolder = "Maps";
        private const string BuildDataSuffix = "_Data";

        [PostProcessBuild]
        public static void OnPostprocessBuild(BuildTarget target, string pathToExecutionFile)
        {
            var pathToBuildFolder = Path.GetDirectoryName(pathToExecutionFile);
            var pathToMaps = Path.Combine(Application.dataPath, MapFolder);
            var pathToDataFolder = Path.Combine(pathToBuildFolder!, Application.productName + BuildDataSuffix);
            Directory.CreateDirectory(Path.Combine(pathToDataFolder, MapFolder));
            foreach (var mapFileName in Directory.GetFiles(pathToMaps, $"*{Constants.RchExtension}")
                         .Union(Directory.GetFiles(pathToMaps, $"*{Constants.VxlExtension}")))
            {
                File.Copy(Path.Combine(mapFileName),
                    Path.Combine(pathToDataFolder, MapFolder, Path.GetFileName(mapFileName)),
                    true);
                Debug.Log(Path.Combine(pathToDataFolder, MapFolder, Path.GetFileName(mapFileName)));
            }
        }
    }
}