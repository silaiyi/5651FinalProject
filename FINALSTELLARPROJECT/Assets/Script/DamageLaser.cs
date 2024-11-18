using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLaser : MonoBehaviour
{
    // Start is called before the first frame update
    public float TotalLaserDamge,LaserDamage=20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalLaserDamge=(LaserDamage + BankShop.ShopLaserDamege + InGameUpdate.InGameLaserDamege)/3;
    }
    private void OnTriggerStay(Collider collision)
    {
        GameObject hit = collision.gameObject;
        EnemyHp hp2 = hit.GetComponent<EnemyHp>();
        if (hp2 != null)
        {
            hp2.EnergyDamege(TotalLaserDamge);
            hit.transform.SendMessage("PistolDamege", TotalLaserDamge);
            //Debug.Log("On Hit");
        }
    }
}
