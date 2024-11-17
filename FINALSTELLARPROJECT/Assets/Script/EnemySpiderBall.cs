using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpiderBall : MonoBehaviour
{
    public float speed = 15f;
    public float xs=0;
    public float ys=0;
    public static float zs=0;
    public float grow=20,atk=20,push=5,TotalGrow,TotalAtk,TotalPush;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        zs = speed + SystemMenu.EnemyAtk+WaveCount.exAtk;
        TotalAtk = atk + SystemMenu.EnemyAtk+WaveCount.exAtk;
        TotalGrow = grow + SystemMenu.EnemyAtk+WaveCount.exAtk;
        Destroy(gameObject,5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(xs*Time.deltaTime, ys * Time.deltaTime, zs * Time.deltaTime);
        rb.mass = TotalPush;
    }
    private void OnTriggerEnter(Collider collision)
    {
        GameObject hit = collision.gameObject;
        Player hp2 = hit.GetComponent<Player>();
        if (hp2 != null)
        {
            Destroy(gameObject);
            hp2.TakeDamege(TotalAtk);
            //Instantiate(explo,this.transform.position,this.transform.rotation);
            //Debug.Log("Boom!");
        }
    }
}
