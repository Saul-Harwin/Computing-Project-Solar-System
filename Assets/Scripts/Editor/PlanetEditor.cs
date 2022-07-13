using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{  
    Planet planet; 
    Editor shapeEditor;
    Editor colourEditor;
    public override void OnInspectorGUI() {
        using (var check = new EditorGUI.ChangeCheckScope()) {
            base.OnInspectorGUI(); // Override the onInspectorGUI method.
            if (check.changed) {
                planet.GeneratePlanet(); // The is like the a onValidate method.
            }
        }
        DrawSettingsEditor(planet.shapeSettings, planet.OnShapeSettingsUpdated, ref planet.shapeSettingsFoldOut, ref shapeEditor);
        DrawSettingsEditor(planet.colourSettings, planet.OnColourSettingsUpdated, ref planet.colourSettingsFoldOut, ref colourEditor);
    }

    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref bool foldOut, ref Editor editor) { // Draw an editor for the shape settings. Takes in the setting object. To be able change the value of the foldout varialbe that is actualt in the planet class the foldout bool needs to be passed in by reference
        if (settings != null) { // Only try and draw the settings editor if the setting editor is not null.
            foldOut = EditorGUILayout.InspectorTitlebar(foldOut, settings); // Adds a title bar to the editor.

            using (var check = new EditorGUI.ChangeCheckScope()) { // Check if anything in the editor has changed.    
                if (foldOut) {
                    CreateCachedEditor(settings, null, ref editor); // Creates the editor. Null for the editor type so that it uses the default editor type. 
                    editor.OnInspectorGUI(); // Displays the editor.
                    
                    if (check.changed) {
                        if (onSettingsUpdated != null) {
                            onSettingsUpdated();
                        }
                    }
                }
            }
        }
    }

    private void OnEnable() {
        planet = (Planet)target; // Casting target object to the planet.
    }
}
