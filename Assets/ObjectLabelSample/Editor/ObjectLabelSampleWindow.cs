// Copyright (c) 2021 murnana.
// 
// This software is released under the MIT License.
// http://opensource.org/licenses/mit-license.php

namespace Murnana.UIElements.ObjectLabelSample.Editor
{
    /// <summary>
    /// <see cref="UIElements.Editor.ObjectLabel" /> Sample Window
    /// </summary>
    public sealed class ObjectLabelSampleWindow : UnityEditor.EditorWindow
    {
        /// <summary>
        /// Window title name
        /// </summary>
        private const string TitleName = "ObjectLabel Sample";

        /// <summary>
        /// Menu name
        /// </summary>
        private const string
            MenuName = "Window/Murnana/UIElements/" + TitleName;

        private UnityEngine.AnimationClip m_Clip;

        /// <summary>
        /// This function is called when the object is loaded.
        /// </summary>
        private void OnEnable()
        {
            titleContent = new(TitleName);
        }

        /// <summary>
        /// CreateGUI is called when the EditorWindow's rootVisualElement is ready to be populated.
        /// </summary>
        private void CreateGUI()
        {
            var root = rootVisualElement;

            //  Window title
            root.Add(
                new UnityEngine.UIElements.Label(TitleName)
                {
                    style =
                    {
                        fontSize = 18.0f,

                        marginBottom = 10.0f,
                        marginLeft   = 10.0f,
                        marginRight  = 10.0f,
                        marginTop    = 10.0f,
                    },
                }
            );

            root.Add(CreateIMGUI());
            root.Add(CreateVisualElement());
        }

        private UnityEngine.UIElements.VisualElement CreateIMGUI()
        {
            var root = new UnityEngine.UIElements.VisualElement
            {
                style =
                {
                    marginBottom = 10.0f,
                    marginLeft   = 10.0f,
                    marginRight  = 10.0f,
                    marginTop    = 10.0f,
                },
            };

            root.Add(new UnityEngine.UIElements.Label("IMGUI"));
            root.Add(
                new UnityEngine.UIElements.IMGUIContainer(
                    OnIMGUIHandler
                )
            );

            return root;
        }

        private UnityEngine.UIElements.VisualElement CreateVisualElement()
        {
            var root = new UnityEngine.UIElements.VisualElement
            {
                style =
                {
                    marginBottom = 10.0f,
                    marginLeft   = 10.0f,
                    marginRight  = 10.0f,
                    marginTop    = 10.0f,
                },
            };

            root.Add(new UnityEngine.UIElements.Label("VisualElement"));
            root.Add(
                new Murnana.UIElements.Editor.ObjectLabel(
                    obj: m_Clip,
                    type: typeof(
                        UnityEngine.AnimationClip)
                )
            );

            return root;
        }

        private void OnIMGUIHandler()
        {
            var label = UnityEditor.EditorGUIUtility.ObjectContent(
                obj: m_Clip,
                type: typeof(UnityEngine.AnimationClip)
            );

            UnityEditor.EditorGUILayout.LabelField(label);
        }

        /// <summary>
        /// Execute From Menu
        /// </summary>
        [UnityEditor.MenuItem(MenuName)]
        private static void ExecuteFromMenu()
        {
            var window = GetWindow<ObjectLabelSampleWindow>();
            window.ShowPopup();
            window.Focus();
        }
    }
}
