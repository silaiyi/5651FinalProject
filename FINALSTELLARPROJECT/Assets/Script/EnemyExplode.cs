using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplode : MonoBehaviour
{
    public float grow=20,atk=20,push=5,TotalGrow,TotalAtk,TotalPush;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        TotalAtk = atk + SystemMenu.EnemyAtk+WaveCount.exAtk;
        TotalGrow = grow + SystemMenu.EnemyAtk+WaveCount.exAtk;
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(TotalGrow * Time.deltaTime,TotalGrow * Time.deltaTime, TotalGrow * Time.deltaTime);
        rb.mass = TotalPush;
    }
    private void OnTriggerEnter(Collider collision)
    {
        GameObject hit = collision.gameObject;
        Player hp2 = hit.GetComponent<Player>();
        if (hp2 != null)
        {
            hp2.TakeDamege(TotalAtk);
            //Debug.Log("Fire!");
        }
    }
}
