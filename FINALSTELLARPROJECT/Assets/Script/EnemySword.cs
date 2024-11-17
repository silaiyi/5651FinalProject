using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    // Start is called before the first frame update
    public float atk=50,TotalAtk;
    void Start()
    {
        TotalAtk = atk + SystemMenu.EnemyAtk;
    }

    // Update is called once per frame
    void Update()
    {
        TotalAtk = atk + SystemMenu.EnemyAtk+WaveCount.exAtk;
    }
    private void OnTriggerEnter(Collider collision)
    {
        GameObject hit = collision.gameObject;
        Player hp2 = hit.GetComponent<Player>();
        if (hp2 != null)
        {
            hp2.TakeDamege(TotalAtk);
            //Debug.Log("Hit Player");
        }
        buildingHp hp = hit.GetComponent<buildingHp>();
        if (hp != null)
        {
            hp.Hit(TotalAtk);
            //Debug.Log("Hit Player");
        }
    }
}
