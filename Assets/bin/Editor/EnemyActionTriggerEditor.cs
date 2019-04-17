using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MoreMountains.Tools;

namespace DBREnemies
{
    [CustomEditor(typeof(EnemiesSpawner))]
    [InitializeOnLoad]
    public class EnemyActionTriggerEditor : Editor
    {
        //This is the value of the Slider
        [DrawGizmo(GizmoType.InSelectionHierarchy | GizmoType.NotInSelectionHierarchy)]
        static void DrawGameObjectName(EnemyActionTrigger enemyActionTrigger, GizmoType gizmoType)
        {
            GUIStyle style = new GUIStyle();

            Vector3 v3FrontTopLeft;
            if (enemyActionTrigger._collider2D == null)
            {
                enemyActionTrigger._collider2D = enemyActionTrigger.GetComponent<BoxCollider2D>();
            }
            if (enemyActionTrigger.boxSize.size != Vector3.zero)
            {
                enemyActionTrigger.boxSize.center = enemyActionTrigger.transform.position;
                style.normal.textColor = Color.yellow;
                v3FrontTopLeft = new Vector3(enemyActionTrigger.boxSize.center.x - enemyActionTrigger.boxSize.extents.x, enemyActionTrigger.boxSize.center.y + enemyActionTrigger.boxSize.extents.y + 1, enemyActionTrigger.boxSize.center.z - enemyActionTrigger.boxSize.extents.z);  // Front top left corner
                Handles.Label(v3FrontTopLeft, "Enemy Action Trigger", style);
                MMDebug.DrawHandlesBounds(enemyActionTrigger.boxSize, Color.yellow);
                enemyActionTrigger._collider2D.size = enemyActionTrigger.boxSize.extents * 1.95f;

            }
        }
    }
}
