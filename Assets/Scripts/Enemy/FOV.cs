using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FOV : MonoBehaviour {
    private PlayerMovement player;
    public Vector3 dirTarget;
    public Transform target;
    public float fovRadius;
    [Range(0,360)]
    public float fovAngle;

    public LayerMask playermask;
    public LayerMask obstacles;

    public List<Transform> visibleTarget = new List<Transform>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        StartCoroutine("FindTargets", 0f);
    }

    IEnumerator FindTargets(float delay)
    {
        while (true)
        {
            //gives the enemy a reaction time
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visibleTarget.Clear();
        //checking if player is in radius of enemy
        Collider[] targetsInView = Physics.OverlapSphere(transform.position, fovRadius, playermask);
        for (int i = 0; i < targetsInView.Length; i++)
        {
            target = targetsInView[i].transform;
             dirTarget = (target.position - transform.position).normalized;
            //making sure target is in view angle
            if (Vector3.Angle(transform.forward, dirTarget) < fovAngle / 2)
            {
                //checking distance between enemy and player
                float dstTarget = Vector3.Distance(transform.position, target.position);
                //if there is no obstacles between player an enemy
                if (!Physics.Raycast(transform.position, dirTarget, dstTarget, obstacles))
                {
                    visibleTarget.Add(target);
                    //looks and shoots at target
                    transform.LookAt(target);
                    GetComponent<EnemyScript>().Shoot();
                    
                }
            }
        }
    }

    //when using an angle in unity sin and cos are swapped
    public Vector3 AngleDir(float angle,bool globalAngle)
    {
        if (!globalAngle)
        {
            angle += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad),0 , Mathf.Cos(angle * Mathf.Deg2Rad));
    }
}
