using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MoreMountains.Tools;

namespace DBRObjects
{
    [CustomEditor(typeof(ObjectSpawner))]
    [InitializeOnLoad]
    public class ObjectSpawnerEditor : Editor
    {
        //This is the value of the Slider
        [DrawGizmo(GizmoType.InSelectionHierarchy | GizmoType.NotInSelectionHierarchy)]
        static void DrawGameObjectName(ObjectSpawner objectsSpawner, GizmoType gizmoType)
        {
            GUIStyle style = new GUIStyle();

            Vector3 v3FrontTopLeft;

            if (objectsSpawner.boxSize.size != Vector3.zero)
            {
                objectsSpawner.boxSize.center = objectsSpawner.transform.position;
                style.normal.textColor = Color.red;
                v3FrontTopLeft = new Vector3(objectsSpawner.boxSize.center.x - objectsSpawner.boxSize.extents.x, objectsSpawner.boxSize.center.y + objectsSpawner.boxSize.extents.y + 1, objectsSpawner.boxSize.center.z - objectsSpawner.boxSize.extents.z);  // Front top left corner
                Handles.Label(v3FrontTopLeft, "Object Spawner", style);
                MMDebug.DrawHandlesBounds(objectsSpawner.boxSize, Color.cyan);
            }
        }
    }
}
