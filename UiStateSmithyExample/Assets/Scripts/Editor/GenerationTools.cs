using System;
using System.IO;
using GameDevWare.TextTransform;
// using UI.UiCanvases;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class GenerationTools
    {
        private static string gameStatesPath;
        private static string canvasesPath;
        private static string uiStatesPath;

        [MenuItem("GameTools/Generate/GenerateGameStates")]
        public static void GenerateGameStates()
        {
            CreateGameStatesFolder();
            CreateGameStates();

            AssetDatabase.Refresh();
        }

        [MenuItem("GameTools/Generate/GenerateUiCanvases")]
        public static void GenerateUiCanvases()
        {
            CreateUiCanvasesFolders();
            CreateUiCanvases();

            AssetDatabase.Refresh();

            var filePath = "Assets/Scripts/UI/UiCanvases/" + "CanvasesTemplates" + ".dsl";

            var lines = Array.ConvertAll(
                File.ReadAllText(filePath).Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries),
                l => l.Trim());

            foreach (var line in lines) {
                var partsLine = line.Split('#');
                if (partsLine.Length < 2)
                    continue;

                var name = partsLine[0].Trim();
                CreateCanvasPartialScriptFile(name);
            }

            AssetDatabase.Refresh();
        }

        [MenuItem("GameTools/Generate/GenerateUiCanvasesPrefabs")]
        public static void GenerateUiCanvasesPrefabs()
        {
            var filePath = "Assets/Scripts/UI/UiCanvases/" + "CanvasesTemplates" + ".dsl";

            var lines = Array.ConvertAll(
                File.ReadAllText(filePath).Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries),
                l => l.Trim());

            foreach (var line in lines) {
                var partsLine = line.Split('#');
                if (partsLine.Length < 2)
                    continue;

                var name = partsLine[0].Trim();
                CreateCanvasPrefab(name);
            }

            AssetDatabase.Refresh();
        }

        [MenuItem("GameTools/Generate/GenerateUiStates")]
        public static void GenerateUiStates()
        {
            CreateUiStatesFolders();
            CreateUiStates();

            AssetDatabase.Refresh();

            var filePath = "Assets/Scripts/UI/UiStates/" + "UiStatesTemplates" + ".dsl";

            var lines = Array.ConvertAll(
                File.ReadAllText(filePath).Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries),
                l => l.Trim());

            foreach (var line in lines) {
                var partsLine = line.Split('#');
                if (partsLine.Length < 2)
                    continue;

                var name = partsLine[0].Trim();
                CreateUiStatePartialScriptFile(name);
            }
        }

        private static void CreateCanvasPartialScriptFile(string canvasName)
        {
            var canvasPath = "Assets/Scripts/UI/UiCanvases/";

            var filePath = canvasPath + canvasName + ".cs";

            if (File.Exists(filePath) == false) {
                var outfile = new StreamWriter(filePath);
                outfile.WriteLine("namespace UI.UiCanvases");
                outfile.WriteLine("{");
                outfile.WriteLine("public partial class " + canvasName);
                outfile.WriteLine("{");
                outfile.WriteLine("}");
                outfile.WriteLine("}");
                outfile.Close();
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private static void CreateUiStatePartialScriptFile(string uiStateName)
        {
            var uiStatePath = "Assets/Scripts/UI/UiStates/";

            var filePath = uiStatePath + uiStateName + ".cs";

            if (File.Exists(filePath) == false) {
                var outfile = new StreamWriter(filePath);
                outfile.WriteLine("namespace UI.UiStates");
                outfile.WriteLine("{");
                outfile.WriteLine("public partial class " + uiStateName);
                outfile.WriteLine("{");
                outfile.WriteLine("}");
                outfile.WriteLine("}");
                outfile.Close();
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private static void CreateCanvasPrefab(string canvasName)
        {
            // var canvasPath = "Assets/Art/Prefabs/Resources/";
            //
            // var prefabPath = canvasPath + canvasName + ".prefab";
            //
            // if (File.Exists(prefabPath))
            //     return;
            //
            // prefabPath = AssetDatabase.GenerateUniqueAssetPath(prefabPath);
            //
            // var basePath = canvasPath + "BaseCanvas.prefab";
            // var loadAsset = AssetDatabase.LoadAssetAtPath<GameObject>(basePath);
            //
            // var dummy = GameObject.Instantiate(loadAsset);
            //
            // var uiBaseCanvas = dummy.GetComponent<BaseUiCanvas>();
            //
            // GameObject.DestroyImmediate(uiBaseCanvas);
            //
            // try {
            //     var className = "UI.UiCanvases." + canvasName;
            //     var assembly = Assembly.Load("Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
            //     var type = assembly.GetType(className);
            //     dummy.AddComponent(type);
            //
            //     PrefabUtility.SaveAsPrefabAsset(dummy, prefabPath);
            //
            //     AssetDatabase.SaveAssets();
            //     AssetDatabase.Refresh();
            // }
            // catch (Exception e) {
            //     Debug.LogError(e);
            // }
            //
            // GameObject.DestroyImmediate(dummy);
        }

        private static void CreateGameStatesFolder()
        {
            if (!AssetDatabase.IsValidFolder("Assets/Scripts/GameStates")) {
                var statesGuid = AssetDatabase.CreateFolder("Assets/Scripts", "GameStates");
                gameStatesPath = statesGuid;
            }
            else {
                gameStatesPath = "Assets/Scripts/GameStates";
            }
        }

        private static void CreateGameStates()
        {
            var filePath = "Assets/Scripts/GameStates/" + "StatesTemplates" + ".tt";
            UnityTemplateGenerator.RunForTemplate(filePath);
        }

        private static void CreateUiCanvases()
        {
            var filePath = "Assets/Scripts/UI/UiCanvases/" + "CanvasesTemplates" + ".tt";
            UnityTemplateGenerator.RunForTemplate(filePath);
        }

        private static void CreateUiStates()
        {
            var filePath = "Assets/Scripts/UI/UiStates/" + "UiStatesTemplates" + ".tt";
            UnityTemplateGenerator.RunForTemplate(filePath);
        }

        private static void CreateUiStatesFolders()
        {
            if (!AssetDatabase.IsValidFolder("Assets/Scripts/Ui/UiStates")) {
                var statesGuid = AssetDatabase.CreateFolder("Assets/Scripts/Ui", "UiStates");
                uiStatesPath = statesGuid;
            }
            else {
                uiStatesPath = "Assets/Scripts/Ui/UiStates";
            }
        }

        private static void CreateUiCanvasesFolders()
        {
            if (!AssetDatabase.IsValidFolder("Assets/Scripts/Ui/UiCanvases")) {
                var canvasGuid = AssetDatabase.CreateFolder("Assets/Scripts/Ui", "UiCanvases");
                canvasesPath = AssetDatabase.GUIDToAssetPath(canvasGuid);
            }
            else {
                canvasesPath = AssetDatabase.GUIDToAssetPath("Assets/Scripts/Ui/UiCanvases");
            }
        }
    }
}