using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explo;
    public float speed = 15f;
    public float xs=0;
    public float ys=0;
    public static float zs=0;
    
    AudioSource Bombaudio;
    public AudioClip BoomAudio;
    public string targetTag = "Ground";

    // Start is called before the first frame update
    void Start()
    {
        zs = speed + BankShop.ShopBolterSpeed + InGameUpdate.InGameBolterSpeed;
        Bombaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(xs*Time.deltaTime, ys * Time.deltaTime, zs * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider collision)
    {
        GameObject hit = collision.gameObject;
        EnemyAi laser = hit.GetComponent<EnemyAi>();
        if(laser!=null){
            Destroy(gameObject);
            Instantiate(explo,this.transform.position,this.transform.rotation);
            Bombaudio.PlayOneShot(BoomAudio);
        }
        if (collision.gameObject.tag == targetTag)
        {
            Destroy(gameObject);
            Instantiate(explo,this.transform.position,this.transform.rotation);
        }  
            
    }
}
