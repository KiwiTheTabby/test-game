using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{

    public float rangeOfVision;
    public float angleOfVision;
    public LayerMask targetLayers;
    public LayerMask obstacleLayers;

    public Collider targetObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, rangeOfVision, targetLayers);

        for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];

            Vector3 directionToTarget = Vector3.Normalize(collider.bounds.center - transform.position);

            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

            if (angleToTarget < angleOfVision)
            {
                if (!Physics.Linecast(transform.position, collider.bounds.center, obstacleLayers))
                {
                    targetObject = collider;
                    break;
                }

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangeOfVision);

        Vector3 rightDirection = Quaternion.Euler(0, 0, angleOfVision) * transform.forward;
        Gizmos.DrawRay(transform.position, rightDirection * rangeOfVision);

        Vector3 leftDirection = Quaternion.Euler(0, 0, -angleOfVision) * transform.forward;
        Gizmos.DrawRay(transform.position, leftDirection * rangeOfVision);
    }
}
