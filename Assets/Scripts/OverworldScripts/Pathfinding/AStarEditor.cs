using UnityEditor;
using UnityEditor.UIElements;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ^ This is the script we are making a custom editor for.
[CustomEditor(typeof(AStarComponent))]
public class AStarEditor : Editor {
   
    public override void OnInspectorGUI () {
        //Called whenever the inspector is drawn for this object.
        DrawDefaultInspector();
        //This draws the default screen.  You don't need this if you want
        //to start from scratch, but I use this when I'm just adding a button or
        //some small addition and don't feel like recreating the whole inspector.

        if(GUILayout.Button("Generate Grid")) {
            //add everthing the button would do.
            AStarComponent currentSelected = (AStarComponent) target;
            if(currentSelected.pathfinding == null){
                currentSelected.pathfinding = new(currentSelected.width, currentSelected.height);
            }else currentSelected.pathfinding.Init(currentSelected.width, currentSelected.height);
        }
   }

    //https://gist.github.com/Arakade/9dd844c2f9c10e97e3d0
    public static void DrawString(string text, Vector3 worldPos, Color? colour = null)
    {
        UnityEditor.Handles.BeginGUI();
        Color defaultColor = GUI.color;
        if (colour.HasValue) GUI.color = colour.Value;
        var view = UnityEditor.SceneView.currentDrawingSceneView;
        Vector3 screenPos = view.camera.WorldToScreenPoint(worldPos);
        Vector2 size = GUI.skin.label.CalcSize(new GUIContent(text));
        GUI.Label(new Rect(screenPos.x - (size.x / 2), -screenPos.y + view.position.height - size.y * 2, size.x, size.y), text);
        GUI.color = defaultColor;
        UnityEditor.Handles.EndGUI();
    }
}