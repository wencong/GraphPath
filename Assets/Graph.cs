using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Graph : MonoBehaviour {
    private GraphPoint[] points = null;
    private float[,] distance = null;

    void Awake() {
        points = GetComponentsInChildren<GraphPoint>();
        distance = new float[points.Length, points.Length];

        visited = new bool[points.Length];
        parentIndex = new int[points.Length];

        GraphEdge[] edges = GetComponentsInChildren<GraphEdge>();

        for (int i = 0; i < edges.Length; ++i) {
            GraphEdge edge = edges[i];

            int nStart = Array.IndexOf(points, edge.start);
            int nEnd = Array.IndexOf(points, edge.end);

            float d = Vector3.Distance(edge.start.transform.position, edge.end.transform.position);

            distance[nStart, nEnd] = d;
            distance[nEnd, nStart] = d;
        }
    }

    private bool[] visited;
    private bool bFind = false;
    private Queue<int> queue = new Queue<int>();

    private int[] parentIndex = null;
    public void FindPath(int nStart, int nEnd, ref int[] points, ref int length) {
        if (nStart == nEnd) {
            length = 1;
            points[0] = nStart;
            return;
        }

        bFind = false;
        for (int i = 0; i < visited.Length; ++i) {
            visited[i] = false;
        }

        for (int i = 0; i < visited.Length; ++i) {
            parentIndex[i] = -1;
        }

        visited[nStart] = true;
        points[length] = nStart;
        length++;

        queue.Clear();

        queue.Enqueue(nStart);

        if (BFS(nEnd, ref points, ref length)) {
            length = 0;

            do {
                points[length] = nEnd;
                length++;
                nEnd = parentIndex[nEnd];
                if (nEnd == -1) {
                    break;
                }
            } while (true);

            Debug.Log(points.ToString());
        }
    }


    // 广度优先
    private bool BFS(int end, ref int[] path, ref int length) {

        while (queue.Count != 0) {
            int root = queue.Dequeue();

            Debug.Log(root);
            if (root == end) {
                return true;
            }

            for (int i = 0; i < points.Length; ++i) {
                if (distance[root, i] != 0.0f &&
                    visited[i] == false) {
                    visited[i] = true;
                    queue.Enqueue(i);
                    parentIndex[i] = root;
                }
            }
        }
        
        return false;
    }

    // 深度优先
    private void DFS() {

    }
}
