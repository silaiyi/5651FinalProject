using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 30f;
    public float xs=0;
    public float ys=0;
    public static float zs=0;
    public float atk = 5;
    public static float TotalAtk=0;
    public float seeSpeed;
    void Start()
    {
        zs = speed;
        TotalAtk = atk + BankShop.ShopLaserDamege + InGameUpdate.InGameLaserDamege;
        //hp = 1; 
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(xs*Time.deltaTime, ys * Time.deltaTime, zs * Time.deltaTime);
        seeSpeed = zs; 
    }
    private void OnTriggerStay(Collider collision)
    {
        GameObject hit = collision.gameObject;
        EnemyHp hp2 = hit.GetComponent<EnemyHp>();
        if (hp2 != null)
        {
            hp2.EnergyDamege(TotalAtk);
        }

    }
}
