 using UnityEditor;
 using System.Reflection;
 using System;
 using UnityEditorInternal;
 
 [CustomEditor (typeof(LineRendererLayer))]
 public class LineRendererLayerEditor : Editor 
 {
     string[] layers;
     public LineRendererLayerEditor()
     {
         Type internalEditorUtilityType = typeof(InternalEditorUtility);
         PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
         layers=(string[])sortingLayersProperty.GetValue(null, new object[0]);
     }
 
 
     public override void OnInspectorGUI() 
     {
         LineRendererLayer myTarget=(LineRendererLayer)target;
         //EditorGUI.EnumPopup(new Rect(0,0,100,50),layers);
         int selectedIndex;
         if(myTarget.sortingLayer=="")
         {
             myTarget.sortingLayer=layers[0];
             selectedIndex=0;
         }
         else
         {
             selectedIndex=Array.IndexOf<string>(layers,myTarget.sortingLayer);
             if(selectedIndex==-1)
             {
                 myTarget.sortingLayer=layers[0];
                 selectedIndex=0;
             }
         }
         myTarget.sortingLayer=layers[EditorGUILayout.Popup(selectedIndex,layers)];
         myTarget.enabled = false;
         myTarget.enabled = true;
     }
 }
 