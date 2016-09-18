using UnityEditor;
using UnityEngine;
using Run.Pug.WTFUnity;
using Run.Pug.Util;
using Run.Pug.Util.Unity;
using System;
using System.Collections.Generic;

namespace Run.Pug.Ugh.Unity.Editor
{
    public class UghPreferencesWindow : WTFEditorWindow
    {
        private Boolean showGeneratorList; 
        private UghPreferencesConfig config;
        private List<IGenerator> generators;

        [MenuItem("Window/Unity Generator Hub Preferences")]
        public static void ShowWindow()
        {
            EditorWindow window = EditorWindow.GetWindow<UghPreferencesWindow>();
            window.ShowTab();
        }

        protected override void Initialize()
        {
            showGeneratorList = true;
            config = new UghPreferencesConfig();
            generators = new List<IGenerator>();
        }

        protected override void Enable()
        {
            config.Load();

            titleContent = new GUIContent("UGH Settings");
            generators = ActivatorUtil.CreateInstancesFromInterface<IGenerator>();
        }

        protected override void Disable()
        {
            config.Save();
        }

        protected override void Draw()
        {
            EditorGUILayout.LabelField("Unity Generator Hub", EditorStyles.boldLabel);

            DrawGlobalPreferences();

            // Draw Generators List
            GUILayout.BeginVertical(GUI.skin.box);
            {
                showGeneratorList = EditorGUILayout.Foldout(showGeneratorList, "Generators");
                if (showGeneratorList)
                {
                    if (0 == generators.Count)
                    {
                        EditorGUILayout.LabelField("No generators found :(");
                    }
                    else
                    {
                        foreach (IGenerator generator in generators)
                        {
                            DrawGeneratorListItem(generator, config.GetGeneratorConfig(generator));
                        }
                    }
                }
            }
            GUILayout.EndVertical();

            // Draw Generate Button
            if (GUILayout.Button("Generate"))
            {
                OnGenerateButtonClick();
            }

            if (GUI.changed)
            {
                config.Save();
            }
        }

        private void DrawGlobalPreferences()
        {
            config.GeneratePath =
                    EditorGUILayout.TextField("Generate Path:", config.GeneratePath);
            config.CustomNamespace =
                    EditorGUILayout.TextField("Namespace:", config.CustomNamespace);
            config.ClassNamePrefix =
                    EditorGUILayout.TextField("Class prefix:", config.ClassNamePrefix);
            config.ClassNameSuffix =
                    EditorGUILayout.TextField("Class suffix:", config.ClassNameSuffix);
        }

        private void DrawGeneratorListItem(IGenerator generator,
                UghPreferencesConfig.GeneratorConfig config)
        {
            GUIStyle richText = new GUIStyle();
            richText.richText = true;

            GUILayout.BeginHorizontal();
            {
                config.IsEnabled = EditorGUILayout.Toggle(config.IsEnabled, GUILayout.Width(20));
                EditorGUILayout.LabelField(generator.Name, richText);
            }
            GUILayout.EndHorizontal();
        }

        private void OnGenerateButtonClick()
        {
            foreach (var generator in generators)
            {
                UghPreferencesConfig.GeneratorConfig generatorConfig =
                        config.GetGeneratorConfig(generator);

                string path = Application.dataPath + UnityConstants.DIRECTORY_SEPERATOR +
                        config.GeneratePath;

                if (generatorConfig.IsEnabled)
                {
                    try
                    {
                        Ugh.GenerateClass(generator, path, generator.Name);
                    }
                    catch(Exception exception)
                    {
                        string format = "Error while running IGenerator: {0}";
                        Debug.LogException(exception);
                        Debug.LogWarningFormat(format, generator.Name);
                    }

                    AssetDatabase.Refresh();
                }
            }
        }
    }
}
