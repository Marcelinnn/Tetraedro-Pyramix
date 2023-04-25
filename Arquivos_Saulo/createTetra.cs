using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class createTetra : MonoBehaviour {


    public bool sharedVertices = false;

    Vector3 p0 = new Vector3(0, 0, 0);
    Vector3 p1 = new Vector3(1, 0, 0);
    Vector3 p2 = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f));
    Vector3 p3 = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3);
    Mesh mesh;

    public Vector3[] getVectors()
    {

        Vector3[] vertex = new Vector3[] { p0, p1, p2, p3 };
        return vertex;

    }

    public void Rebuild()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogError("MeshFilter not found!");
            return;
        }

        //Vector3 p0 = new Vector3(0, 0, 0);
        //Vector3 p1 = new Vector3(1, 0, 0);
        //Vector3 p2 = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f));
        //Vector3 p3 = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3);

        mesh = meshFilter.sharedMesh;
        if (mesh == null)
        {
            meshFilter.mesh = new Mesh();
            mesh = meshFilter.sharedMesh;
        }
        mesh.Clear();
        if (sharedVertices)
        {
            mesh.vertices = new Vector3[] { p0, p1, p2, p3 };
            mesh.triangles = new int[]{
                0,1,2,
                0,2,3,
                2,1,3,
                0,3,1
            };
            // basically just assigns a corner of the texture to each vertex
            mesh.uv = new Vector2[]{
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(0,1),
                new Vector2(1,1),
            };
        }
        else
        {
            mesh.vertices = new Vector3[]{
                p0,p1,p2,
                p0,p2,p3,
                p2,p1,p3,
                p0,p3,p1
            };
            mesh.triangles = new int[]{ // 3 vertices por face
                0,1,2,
                3,4,5,
                6,7,8,
                9,10,11
            };

            Vector2 uv0 = new Vector2(0, 0);
            Vector2 uv1 = new Vector2(1, 0);
            Vector2 uv2 = new Vector2(0.5f, 1);

            mesh.uv = new Vector2[]{
                uv0,uv1,uv2,
                uv1,uv0,uv1,
                uv2,uv1,uv0,
                uv1,uv2,uv0
            };

        }

        Color[] color = new Color[mesh.vertices.Length]; // 12 vetores
        color[0] = Color.blue;
        color[1] = Color.blue;
        color[2] = Color.blue;

        color[3] = Color.red;
        color[4] = Color.red;
        color[5] = Color.red;

        color[6] = Color.yellow;
        color[7] = Color.yellow;
        color[8] = Color.yellow;

        color[9] = Color.magenta;
        color[10] = Color.magenta;
        color[11] = Color.magenta;

        mesh.colors = color;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        //mesh.Optimize();
    }

    // Use this for initialization
    void Start () {
        Rebuild();
        //Rebuild();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
