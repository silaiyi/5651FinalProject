using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanon : MonoBehaviour
{
    public static Transform Player;
    public static float currentTime = 5f;
    private float invokeTime=0;
    public GameObject bomb;
    public float atkRange = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.position - this.transform.position;
        if (direction.magnitude < atkRange)
            {
                invokeTime+=Time.deltaTime;
                CanonFire();
                //Instantiate(bomb, transform.position, transform.rotation);
            }
    }
    void CanonFire(){
        if(invokeTime - currentTime >= 0)
        {
            Instantiate(bomb, transform.position, transform.rotation);
            invokeTime=0;
            //Debug.Log("Fire!");
        }
        
    }
}
