using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MoreMountains.Tools;

namespace DBREnemies
{
    [CustomEditor(typeof(EnemiesSpawner))]
    [InitializeOnLoad]
    public class EnemySpawnerEditor : Editor
    {
        //This is the value of the Slider
        [DrawGizmo(GizmoType.InSelectionHierarchy | GizmoType.NotInSelectionHierarchy)]
        static void DrawGameObjectName(EnemiesSpawner enemiesSpawner, GizmoType gizmoType)
        {
            GUIStyle style = new GUIStyle();

            Vector3 v3FrontTopLeft;

            if (enemiesSpawner.boxSize.size != Vector3.zero)
            {
                enemiesSpawner.boxSize.center = enemiesSpawner.transform.position;
                style.normal.textColor = Color.red;
                v3FrontTopLeft = new Vector3(enemiesSpawner.boxSize.center.x - enemiesSpawner.boxSize.extents.x, enemiesSpawner.boxSize.center.y + enemiesSpawner.boxSize.extents.y + 1, enemiesSpawner.boxSize.center.z - enemiesSpawner.boxSize.extents.z);  // Front top left corner
                Handles.Label(v3FrontTopLeft, "Enemy Spawner", style);
                MMDebug.DrawHandlesBounds(enemiesSpawner.boxSize, Color.red);
            }
        }
    }
}
