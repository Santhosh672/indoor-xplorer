using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class DrawPath : MonoBehaviour
{
    Transform targetPos;
    LineRenderer lineRenderer;
    NavMeshPath path;
    
    int selectedValue;

    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] GameObject[] targets;
    [SerializeField] NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GameObject.Find("LineRender").GetComponent<LineRenderer>();
        path = new NavMeshPath();

        lineRenderer.positionCount = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        selectedValue = dropdown.value;
        DrawNavPath(targets[selectedValue]);
    }

    void DrawNavPath(GameObject target)
    {
        targetPos = target.transform;
        agent.CalculatePath(targetPos.position, path);
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
