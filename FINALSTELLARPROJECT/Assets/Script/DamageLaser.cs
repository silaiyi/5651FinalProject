using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLaser : MonoBehaviour
{
    // Start is called before the first frame update
    public float laserCD=1f;
    public float TotalLaserDamge,LaserDamage=20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalLaserDamge=LaserDamage + BankShop.ShopLaserDamege + InGameUpdate.InGameLaserDamege;
        //laserCD+=Time.deltaTime;
    }
    private void OnTriggerStay(Collider collision)
    {
        GameObject hit = collision.gameObject;
        EnemyHp hp2 = hit.GetComponent<EnemyHp>();
        if (hp2 != null)
        {
            laserCD+=Time.deltaTime;
            if(laserCD-1f>=0){
                hp2.EnergyDamege(TotalLaserDamge);
                laserCD=0;
            }
            //hp2.EnergyDamege(TotalLaserDamge);
            //hit.transform.SendMessage("PistolDamege", TotalLaserDamge);
            //Debug.Log("On Hit");
        }
    }
}
