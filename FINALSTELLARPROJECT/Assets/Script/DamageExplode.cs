using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageExplode : MonoBehaviour
{
    public float TotalBolterDamge,BolterDamge=20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalBolterDamge=(BolterDamge + BankShop.ShopBolterAtk + InGameUpdate.InGameBolterAtk)/2;
    }
    private void OnTriggerEnter(Collider collision)
    {
        GameObject hit = collision.gameObject;
        EnemyHp hp2 = hit.GetComponent<EnemyHp>();
        if (hp2 != null)
        {
            hp2.BolterDamege(TotalBolterDamge);
        }
    }
}
