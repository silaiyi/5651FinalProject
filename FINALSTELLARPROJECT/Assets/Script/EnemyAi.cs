using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent pathfinder;
    public static Transform Player;
    //public float atk=50,TotalAtk;
    public Animator anim;
    public float atkRange = 7f,moveingSpeed = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //TotalAtk = atk + SystemMenu.EnemyAtk;
    }

    // Update is called once per frame
    void Update()
    {
        Doanim();
        pathfinder.speed = moveingSpeed;
        pathfinder.SetDestination(Player.position);
    }
    void Doanim(){
        Vector3 direction = Player.position - this.transform.position;
            if (direction.magnitude > atkRange)
            {
                anim.SetBool("Walk", true);
                anim.SetBool("idle", false);
                anim.SetBool("Attack", false);
            }
            else
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Attack", true);
                anim.SetBool("idle", false);
            }
    }
}
