using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIPatrol : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer, playerLayer;

    Animator animator;

    //patrol
    Vector3 destPoint;
    Vector3 lastKnownPlayerPosition;
    bool walkpointSet;
    [SerializeField] float range;

    //state change
    [SerializeField] float sightRange, attackRange;
    bool playerInSight, playerInAttackRange, investigateLastScene;
    // Start is called before the first frame update
    void Start()
    {
        investigateLastScene = false;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        StateControl();
    }
  
    void StateControl()
    {
        if (!playerInSight && !playerInAttackRange) Patrol();
        if (playerInSight && !playerInAttackRange) Chase();
        if (playerInSight && playerInAttackRange) Attack();
    }
    void Patrol()
    {
        Debug.Log("Patrolling");
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) agent.SetDestination(destPoint);
        if (investigateLastScene) Investigate();
        if (Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false;
    }

    void Chase ()
    {
        agent.SetDestination(player.transform.position);
        investigateLastScene = true;
        Debug.Log("Chase");
    }

    void Investigate()
    {
        agent.SetDestination(player.transform.position);
        Debug.Log("Investigating");
        StartCoroutine(WaitToInvestigate());
    }

    void Attack()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Mutant Swiping"))
        {
            animator.SetTrigger("Attack");
            agent.SetDestination(transform.position);
        }
    }
    void SearchForDest()
    {
        if (investigateLastScene == true)
            return;
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }

    IEnumerator WaitToInvestigate()
    {
        yield return new WaitForSeconds(10.53f);
        investigateLastScene = false;
    }
}
