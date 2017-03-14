using UnityEngine;
using System.Collections;

public class GraphPoint : MonoBehaviour {

	// Use this for initialization
    void OnDrawGizmos() {
        Color old = Gizmos.color;
        Gizmos.color = Color.green;

        Gizmos.DrawSphere(transform.position, 1.0f);

        Gizmos.color = old;
        
    }
}
