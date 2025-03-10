using UnityEngine;
using UnityEngine.AI;

public class DrawPath : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    LineRenderer lineRenderer;
    NavMeshPath path;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Target").GetComponent<Transform>();
        lineRenderer = GameObject.Find("LineRender").GetComponent<LineRenderer>();
        path = new NavMeshPath();

        lineRenderer.positionCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        DrawNavPath();
    }

    void DrawNavPath()
    {
        agent.CalculatePath(target.position, path);
        lineRenderer.positionCount = path.corners.Length;
        lineRenderer.SetPosition(0, transform.position);

        if(path.corners.Length < 2)
        {
            return;
        }

        for(int i = 1; i < path.corners.Length; i++)
        {
            Vector3 pointPosition = new Vector3(path.corners[i].x, path.corners[i].y, path.corners[i].z);
            lineRenderer.SetPosition(i, pointPosition); 
        }
    }
}
