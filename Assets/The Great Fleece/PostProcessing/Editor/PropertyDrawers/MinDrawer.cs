using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEditor;

// Alias kullanarak namespace'leri daha belirgin hale getirme
using EngineMinAttribute = UnityEngine.MinAttribute;
using PostProcessingMinAttribute = UnityEngine.PostProcessing.MinAttribute;

namespace UnityEditor.PostProcessing
{
    [CustomPropertyDrawer(typeof(PostProcessingMinAttribute))] // veya EngineMinAttribute, ihtiyaca göre deðiþtirin
    sealed class MinDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            PostProcessingMinAttribute attribute = (PostProcessingMinAttribute)base.attribute; // veya EngineMinAttribute, ihtiyaca göre deðiþtirin

            if (property.propertyType == SerializedPropertyType.Integer)
            {
                int v = EditorGUI.IntField(position, label, property.intValue);
                property.intValue = (int)Mathf.Max(v, attribute.min);
            }
            else if (property.propertyType == SerializedPropertyType.Float)
            {
                float v = EditorGUI.FloatField(position, label, property.floatValue);
                property.floatValue = Mathf.Max(v, attribute.min);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use Min with float or int.");
            }
        }
    }
}
