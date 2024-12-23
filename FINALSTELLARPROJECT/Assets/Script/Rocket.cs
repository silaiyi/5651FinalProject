using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rocket : MonoBehaviour
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
        Destroy(gameObject,10f);
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
        //this rocket = hit.GetComponent<This>();
        if (collision.gameObject.tag == targetTag)
        {
            Destroy(gameObject);
            Instantiate(explo,this.transform.position,this.transform.rotation);
        }      
    }
}
