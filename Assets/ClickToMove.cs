using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ClickToMove : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] LayerMask movementMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(clickRay, out RaycastHit hit,100f, movementMask))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }
    }
}
