using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float xs=0;
    public float ys=0;
    public static float zs=0;
    public float atk = 5;
    public static float TotalAtk=0;
    public float seeSpeed;
    void Start()
    {
        zs = speed + BankShop.ShopPistolRange + InGameUpdate.InGamePistolRange;
        TotalAtk = atk + BankShop.ShopLaserDamege + InGameUpdate.InGameLaserDamege;
        //hp = 1; 
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(xs*Time.deltaTime, ys * Time.deltaTime, zs * Time.deltaTime);
        seeSpeed = zs; 
    }
    private void OnTriggerEnter(Collider collision){
        GameObject hit = collision.gameObject;
        EnemyHp hp2 = hit.GetComponent<EnemyHp>();
        if (hp2 != null)
        {
            hp2.PistolDamege(TotalAtk);
            Destroy(gameObject);
        }
    }
}
