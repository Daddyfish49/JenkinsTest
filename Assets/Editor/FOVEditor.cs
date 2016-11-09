using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(FOV))]
public class FOVEditor : Editor {
    void OnSceneGUI()
    {
        FOV fov = (FOV)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.fovRadius);
        Vector3 viewAngleA = fov.AngleDir(-fov.fovAngle / 2, false);
        Vector3 viewAngleB = fov.AngleDir(fov.fovAngle / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.fovRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.fovRadius);

        Handles.color = Color.red;
        foreach(Transform visibleTargets in fov.visibleTarget)
        {
            Handles.DrawLine(fov.transform.position, visibleTargets.position);
        }



    }


}
