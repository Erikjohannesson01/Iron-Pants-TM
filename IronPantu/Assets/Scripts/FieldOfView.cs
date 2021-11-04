using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask layermask;
    private Mesh mesh;
    private Vector3 origin;
    private float startingAngle;
    private float fov;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 90f;
        origin = Vector3.zero;
    }

    private void LateUpdate()
    {        
        int rayCount = 100;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 5f;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for(int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D rcHit = Physics2D.Raycast(origin, VectorFromAngle(angle), viewDistance, layermask);
            if(rcHit.collider == null)
            {
                vertex = origin + VectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = rcHit.point;
            }
            vertices[vertexIndex] = vertex;

            if(i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }


    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDir(Vector2 aimDir)
    {
        startingAngle = AngleFromVectorFloat(aimDir) - fov / 2f;
    }
    Vector3 VectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180);

        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    float AngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;

        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (n < 0)
            n += 360;

        return n + 90;
    }
}
