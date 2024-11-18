using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findenemy : MonoBehaviour
{
    Transform Enemy;
    private float TurnSpeed = 0.3f;
    public static bool canFire = false;
    // Start is called before the first frame update
    void Start()
    {
        //Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        //LookAtEnemy();
    }
    private void LookAtEnemy(){
        Vector3 direction = Enemy.transform.position - this.transform.position;
        //direction.y= 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),TurnSpeed);

    }
    private void OnTriggerStay(Collider collision)
    {
        GameObject hit = collision.gameObject;
        EnemyAi touch = hit.GetComponent<EnemyAi>();
        if(touch != null){
            Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
            LookAtEnemy();
            canFire=true;
        }
    }
}
