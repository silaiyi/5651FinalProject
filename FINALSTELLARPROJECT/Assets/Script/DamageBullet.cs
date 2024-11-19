using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBullet : MonoBehaviour
{
    public float TotalPistolDamge,PistolDamge=200;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalPistolDamge=PistolDamge + BankShop.ShopBolterAtk + InGameUpdate.InGameBolterAtk;
    }
    private void OnTriggerEnter(Collider collision)
    {
        GameObject hit = collision.gameObject;
        EnemyHp hp2 = hit.GetComponent<EnemyHp>();
        if (hp2 != null)
        {
            hp2.PistolDamege(TotalPistolDamge);
        }
    }
}
