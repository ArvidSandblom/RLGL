using UnityEngine;

public class enemyFOV : MonoBehaviour
{

    public float fov = 90f;         // Width of cone in degrees
    public float viewDistance = 6f; // How far enemy can see
    public int rayCount = 50;       // Smoothness of the cone

    private Mesh mesh;
    private float angle;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void LateUpdate()
    {
        GenerateFOV();
    }

    void GenerateFOV()
    {
        float angleStep = fov / rayCount;
        float startAngle = transform.eulerAngles.z - fov / 2f;

        Vector3 origin = transform.position;

        Vector3[] vertices = new Vector3[rayCount + 2];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = Vector3.zero; // center of cone

        int vertIndex = 1;
        int triIndex = 0;

        for (int i = 0; i <= rayCount; i++)
        {
            float ang = startAngle + angleStep * i;
            float rad = ang * Mathf.Deg2Rad;

            Vector3 dir = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));

            RaycastHit2D hit = Physics2D.Raycast(origin, dir, viewDistance);

            Vector3 vertex;

            if (hit.collider == null)
                vertex = dir * viewDistance;
            else
                vertex = hit.point - (Vector2)origin;

            vertices[vertIndex] = vertex;

            if (i > 0)
            {
                triangles[triIndex + 0] = 0;
                triangles[triIndex + 1] = vertIndex - 1;
                triangles[triIndex + 2] = vertIndex;
                triIndex += 3;
            }

            vertIndex++;
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    /*public float fov = 45f;
    public float viewDistance = 4f;
    public int rayCount = 50;

    private Mesh mesh;
    private float angle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;            
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateFOV()
    {
        float angleStep = fov / rayCount;
        float startAngle = transform.eulerAngles.z - fov / 2f;

        Vector3 origin = transform.position;

        Vector3[] vertices = new Vector3[rayCount + 2];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = Vector3.zero;

        int verticesIndex = 1;
        int triangleIndex = 0;

        for (int i = 0; i <= rayCount; i++)
        {
            float ang = startAngle + angleStep * i;
            float rad = ang * Mathf.Deg2Rad;

            Vector3 dir = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
            
            RaycastHit2D hit = Physics2D.Raycast(origin,dir,viewDistance);

            Vector3 vertex;

            if (hit.collider == null)
            {
                vertex = hit.point - (Vector2)origin;
            }
            else
            {
                vertex = hit.point - (Vector2)origin;
            }

            vertices[verticesIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = verticesIndex - 1;
                triangles[triangleIndex + 2] = verticesIndex;
                triangleIndex += 3;
            }
            verticesIndex++;
        }
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }*/
}
