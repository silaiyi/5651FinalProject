using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolGun : MonoBehaviour
{
    //public GameObject pistolbullet;
    public static float currentTime = 0.49f;
    public static float invokeTime=0.5f,cdtime=0,laserTime=0,BloterCD=5f,RocketCD=10f;
    public float TotalPistolRange,TotalPistolDamege,TotalBolterRange,TotalBolterDamege,TotalPistolForce;
    public float range = 100;
    public float force = 1,PistolDamege = 20;
    public GameObject hitFX,bomb,laserBullet,rocket,bullet;
    private AudioSource Gunaudio;
    public AudioClip PistolAudio,BolterAudio,RocketAudio,LaserAudio;
    //public AudioClip hitSound;
    // Start is called before the first frame update
    void Start()
    {
        Gunaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        TotalPistolRange = range + BankShop.ShopPistolRange + InGameUpdate.InGamePistolRange;
        TotalPistolDamege = PistolDamege + BankShop.ShopPistolDamege + InGameUpdate.InGamePistolDamege;
        TotalPistolForce = force + BankShop.ShopPistolForce + InGameUpdate.InGamePistolForce;
        invokeTime += Time.deltaTime;
        BloterCD += Time.deltaTime;
        RocketCD += Time.deltaTime;
        if(Player.atktype2 == true){
            if(Input.GetMouseButtonDown(0)){
                PistolShot();
            }
        }
        if(Player.atktype3==true){
            if(Input.GetMouseButtonDown(0)){
                BolterShot();
            }
        }
        if(Player.atktype4==true){
            if(Input.GetMouseButton(0)){
                EgunShot();
            }
            if(Input.GetMouseButtonUp(0)){
                cdtime = 0;
                laserTime = 0;
            }
        }
        if(Player.atktype5==true){
            if(Input.GetMouseButton(0)){
                HeavyShot();
            }
        }
        if(Player.atktype6==true){
            if(Input.GetMouseButtonDown(0)){
                RocketShot();
            }
        }
    }
    void PistolShot(){
        //Instantiate(pistolbullet, transform.position, transform.rotation);
        if(invokeTime - currentTime >= 0)
        {   
            Instantiate(bullet, transform.position, transform.rotation);
            Gunaudio.PlayOneShot(PistolAudio);
            invokeTime=0;
        }
    }
    void BolterShot(){
        if(BloterCD - 2f >= 0)
        {
            Instantiate(bomb, transform.position, transform.rotation);
            BloterCD=0;
            Gunaudio.PlayOneShot(BolterAudio);
        }
    }
    void EgunShot(){
        cdtime += Time.deltaTime;
        laserTime += Time.deltaTime;
        if(laserTime - 0.5f >= 0&&cdtime<0.55f)
        {
            Instantiate(laserBullet, transform.position, transform.rotation);
            if(cdtime-2f>=0){
                cdtime=0;
                laserTime=0;  
            }
            Gunaudio.PlayOneShot(LaserAudio);
            //cdtime=0;            
        }
    }
    void HeavyShot(){
        if(invokeTime - 0.05f >= 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            Gunaudio.PlayOneShot(PistolAudio);
            invokeTime=0;
        }
    }
    void RocketShot(){
        if(RocketCD - 5f >= 0)
        {
            Instantiate(rocket, transform.position, transform.rotation);
            Gunaudio.PlayOneShot(RocketAudio);
            RocketCD=0;
        }
    }


}
