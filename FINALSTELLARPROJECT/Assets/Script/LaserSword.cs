using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSword : MonoBehaviour
{
    // Start is called before the first frame update
    public float TotalLaserDamge,LaserDamage=20;
    void Start()
    {
        //TotalLaserDamge=LaserDamage;
    }

    // Update is called once per frame
    void Update()
    {
        TotalLaserDamge=LaserDamage + BankShop.ShopLaserDamege + InGameUpdate.InGameLaserDamege;
    }
    private void OnTriggerEnter(Collider collision)
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
