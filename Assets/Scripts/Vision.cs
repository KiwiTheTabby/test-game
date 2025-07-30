using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{

    public float rangeOfVision;
    public float angleOfVision;
    public LayerMask obstacleLayers;

    public GameObject player;

    public bool playerDetected;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerDetected = false;

        Vector3 directionToTarget = Vector3.Normalize(player.transform.position - transform.position);

        float angleToTarget = Vector3.Angle(transform.right, directionToTarget);

        float distanceToTarget = Vector3.Distance(player.transform.position, transform.position);

        if (angleToTarget < angleOfVision)
        {
            if (distanceToTarget < rangeOfVision)
            {
                if (!Physics.Linecast(transform.position, player.transform.position, obstacleLayers))
                {
                    playerDetected = true;
                }
            }

        }






    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangeOfVision);

    }
}
