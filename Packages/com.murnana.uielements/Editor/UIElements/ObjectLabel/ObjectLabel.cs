// Copyright (c) 2021 murnana.
// 
// This software is released under the MIT License.
// http://opensource.org/licenses/mit-license.php

namespace Murnana.UIElements.Editor
{
    /// <summary>
    /// <see cref="UnityEditor.EditorGUIUtility.ObjectContent" /> label
    /// </summary>
    public sealed class ObjectLabel : UnityEngine.UIElements.VisualElement
    {
        /// <summary>
        /// USS Class name
        /// </summary>
        public const string USSClassName = "murnana-object-label";

        public const string ImageUssClassName = USSClassName + "__icon";
        public const string LabelUssClassName = USSClassName + "__label";

        /// <summary>
        /// Default StyleSheet Path
        /// </summary>
        public const string DefaultStyleSheetPath =
            "Packages/com.murnana.uielements/Editor/UIElements/ObjectLabel/ObjectLabel.uss";

        /// <summary>
        /// object images
        /// </summary>
        private readonly UnityEngine.UIElements.Image m_Image;

        /// <summary>
        /// object label
        /// </summary>
        private readonly UnityEngine.UIElements.Label m_Label;

        /// <summary>
        /// ObjectType using this label
        /// </summary>
        private readonly System.Type m_Type;

        /// <summary>
        /// ObjectField value
        /// </summary>
        private readonly UnityEngine.Object m_Value;

        public ObjectLabel() : this(
            obj: null,
            type: null
        )
        {
        }

        public ObjectLabel(
            UnityEngine.Object obj,
            System.Type        type
        )
        {
            styleSheets.Add(
                UnityEditor.AssetDatabase
                           .LoadAssetAtPath<UnityEngine.UIElements.StyleSheet>(
                                DefaultStyleSheetPath
                            )
            );

            AddToClassList(USSClassName);

            m_Value = obj;
            m_Type  = type;

            m_Image = new()
            {
                scaleMode   = UnityEngine.ScaleMode.ScaleAndCrop,
                pickingMode = UnityEngine.UIElements.PickingMode.Ignore,
            };
            m_Label = new()
            {
                pickingMode = UnityEngine.UIElements.PickingMode.Ignore,
            };

            m_Image.AddToClassList(ImageUssClassName);
            hierarchy.Add(m_Image);

            m_Label.AddToClassList(LabelUssClassName);
            hierarchy.Add(m_Label);

            Update();
        }

        public void Update()
        {
            var context = UnityEditor.EditorGUIUtility.ObjectContent(
                obj: m_Value,
                type: m_Type
            );

            m_Image.image = context.image;
            m_Label.text  = context.text;
            tooltip       = context.tooltip;
        }

        /// <summary>
        /// <para>Instantiates an ObjectField using the data read from a UXML file.</para>
        /// </summary>
        public new sealed class UxmlFactory : UnityEngine.UIElements.UxmlFactory
        <
            ObjectLabel,
            UxmlTraits
        >
        {
        }

        /// <summary>
        /// <para>Defines UxmlTraits for the ObjectField.</para>
        /// </summary>
        public new sealed class UxmlTraits :
            UnityEngine.UIElements.VisualElement.UxmlTraits
        {
        }
    }
}
