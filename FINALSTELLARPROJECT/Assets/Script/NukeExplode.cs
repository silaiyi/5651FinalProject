using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeExplode : MonoBehaviour
{
    public float grow=20,atk=200,push=10,TotalGrow,TotalAtk,TotalPush;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        TotalAtk = atk + BankShop.ShopBolterAtk + InGameUpdate.InGameBolterAtk;
        TotalGrow = grow  + BankShop.ShopBolterGrow + InGameUpdate.InGameBolterGrow;
        TotalPush = push  + BankShop.ShopBolterPush + InGameUpdate.InGameBolterPush;
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
        EnemyHp hp2 = hit.GetComponent<EnemyHp>();
        if (hp2 != null)
        {
            hp2.BolterDamege(TotalAtk);
        }

    }
}
