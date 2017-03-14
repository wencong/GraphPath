using UnityEngine;
using System.Collections;

public class GraphEdge : MonoBehaviour {
    public GraphPoint start;
    public GraphPoint end;


    void OnDrawGizmos() {
        if (start != null && end != null) {
            Color old = Gizmos.color;
            Gizmos.color = Color.red;

            Gizmos.DrawLine(start.transform.position, end.transform.position);

            Gizmos.color = old;
        }
    }
}
