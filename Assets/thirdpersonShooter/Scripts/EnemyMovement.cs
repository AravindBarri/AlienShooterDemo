using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float chasingPoint;
    Vector3 startingPoint;
    public bool isChasing;
    NavMeshAgent navMesh;
    private Animation anim;

    public static EnemyMovement enemyInstance;

    public bool isDead=false;
    public bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animation>();
        navMesh = this.GetComponent<NavMeshAgent>();
        startingPoint = this.transform.position;
        enemyInstance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < chasingPoint )
        {
            isChasing = true;
            anim.Play("run");
        }
        else if(!isDead && !isHit)
        {
            isChasing = false;
            anim.Play("idle_lookaround");
        }
        if (isChasing && !isDead)
        {
            navMesh.SetDestination(PlayerMovement.instance.transform.position);
        }
        else if(!isDead)
        {
            navMesh.SetDestination(startingPoint);
        }
        if (Vector3.Distance(transform.position,PlayerMovement.instance.transform.position)<3 && !isDead)
        {
            anim.Play("attack1");
            Debug.Log("attacking");
            Health.healthinstance.TakeDamage(0.1f);
            
        }
        if (isDead)
        {
            anim.Play("die1");
        }
    }
    public void enemyDead()
    {
        isDead = true;
        
    }
    public void HitEffect()
    {
        anim.Play("hit1");
        isHit = true;
        Invoke("stopHitBool", 1f);
    }
    public void stopHitBool()
    {
        isHit = false;
    }
   
}
