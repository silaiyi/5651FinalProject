using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explo;
    public float speed = 15f;
    public float xs=0;
    public float ys=0;
    public static float zs=0;

    // Start is called before the first frame update
    void Start()
    {
        zs = speed + BankShop.ShopBolterSpeed + InGameUpdate.InGameBolterSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(xs*Time.deltaTime, ys * Time.deltaTime, zs * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider collision)
    {
        GameObject hit = collision.gameObject;
        Player player = hit.GetComponent<Player>();
        if(player == null){
            Destroy(gameObject);
            Instantiate(explo,this.transform.position,this.transform.rotation);
        }
            
    }
}