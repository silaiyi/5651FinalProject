using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneAi : MonoBehaviour
{
    public static Transform Enemy;
    public Transform Gun;
    private float TurnSpeed = 0.3f;
    //public static bool canFire = false;
    public float AtkRange=100f;
    public GameObject Laser,Bullet,Bomb;
    public float LaserCd,BulletCd,BombCd;
    public static bool LaserDroneOn=false,BulletDroneOn=false,ExplodeDroneOn=false;
    public GameObject[] targets;
    public string enemyTag = "Enemy";

    //public static Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        //Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;

        //LaserDroneOn=false;BulletDroneOn=false;ExplodeDroneOn=false;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        //targets =  GameObject.FindGameObjectWithTag("Enemy");
        LaserCd+=Time.deltaTime;
        BulletCd+=Time.deltaTime;
        BombCd+=Time.deltaTime;
        if(LaserDroneOn==true){
            LaserShoot();
        }else if(BulletDroneOn==true){
            BulletShoot();
        }else if(ExplodeDroneOn==true){
            ExplodeShoot();
        }
        //LookAtEnemy();
        FindNearEnemy();        
    }
    void FindNearEnemy(){
        GameObject nearestEnemy = FindNearestEnemy();
        
        if (nearestEnemy != null)
        {
            Vector3 direction = nearestEnemy.transform.position - transform.position;
            direction.y+=5;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
    void LaserShoot(){
        //Instantiate(Laser, Gun.position, Gun.rotation);
        if(LaserCd-1f>=0){
            Instantiate(Laser, Gun.position, Gun.rotation);
            //Debug.Log("Laser Fire");
            LaserCd=0;
        }
    }
    void BulletShoot(){
        //Instantiate(Bullet, Gun.position, Gun.rotation);
        if(BulletCd-0.5f>=0){
            Instantiate(Bullet, Gun.position, Gun.rotation);
            BulletCd=0;
        }
    }
    void ExplodeShoot(){
        //Instantiate(Bomb, Gun.position, Gun.rotation);
        if(BombCd-5f>=0){
            Instantiate(Bomb, Gun.position, Gun.rotation);
            BombCd=0;
        }
    }
    private void LookAtEnemy(){
        //direction.y = -5;
        //direction.x = -180;
        //direction.z = 15;
        Vector3 direction = Enemy.transform.position - this.transform.position;
        //direction.y = -5;
        //direction.x = 0;
        //direction.z = 15;
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),TurnSpeed);
        this.transform.rotation = Quaternion.LookRotation(direction);
    }
    private void OnTriggerStay(Collider collision)
    {/*
        GameObject hit = collision.gameObject;
        EnemyAi touch2 = hit.GetComponent<EnemyAi>();
        if(touch2 != null){
            Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
            LookAtEnemy();
            //canFire=true;
        }*/

    }
   GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        GameObject nearest = null;
        float minDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = enemy;
            }
        }

        return nearest;
    } 
}
