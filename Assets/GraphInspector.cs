using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Graph))]
public class GraphInspector : Editor {
    Graph graph = null;
    int nStart = 0;
    int nEnd = 0;
    public override void OnInspectorGUI() {
        graph = target as Graph;

        nStart = EditorGUILayout.IntField(nStart);
        nEnd = EditorGUILayout.IntField(nEnd);

        if (GUILayout.Button("Find")) {
            int[] point = new int[128];
            int length = 0;
            graph.FindPath(nStart, nEnd, ref point, ref length);
        }
    }
}
