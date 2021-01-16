using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent nm;
    private Transform target;
    private GameObject target2;

    public enum AIState { idle, chasing, attack};

    public AIState aiState = AIState.idle;

    public Animator animator;
    // Start is called before the first frame update
	

	///////////
	
	
	
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        target2 = GameObject.FindGameObjectWithTag("Target");
        nm = GetComponent<NavMeshAgent>();
        StartCoroutine(Think());

        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        if (dist < 1.7f)
        {
            target2.GetComponent<PlayerStats>().TakeDamage();
		    target2.GetComponent<PlayerStats>().CheckHealth();
        }


    }

    IEnumerator Think()
    {
        while(true){
            switch (aiState){
                case AIState.idle:
                    float dist = Vector3.Distance(target.position, transform.position);
                    if (dist < 50000f) //distance for chasing
                    {
                        aiState = AIState.chasing;
                        animator.SetBool("Chasing", true);
                    }
                    nm.SetDestination(transform.position);
                    break;
                case AIState.chasing:
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > 4000000000000f) //distance for being idle
                    { 
                        aiState = AIState.idle;
                        animator.SetBool("Chasing", false);
                    }
                    if (dist < 1.7f)
                    {
                        aiState = AIState.attack;
                        animator.SetBool("Attacking", true);
                    }
                    nm.SetDestination(target.position);
                    break;
                case AIState.attack:				
                    nm.SetDestination(transform.position);
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > 2.5f)
                    {
                        aiState = AIState.chasing;
                        animator.SetBool("Attacking", false);
                    }
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0f);
        }
    }
    
}
