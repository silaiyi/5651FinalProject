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
    //public AudioClip hitSound;
    // Start is called before the first frame update
    void Start()
    {
        
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
        {   /*
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * range, Color.green);
            RaycastHit hit;
            Debug.Log("Go Go!");
            //audio.PlayOneShot(hitSound);
            if (Physics.Raycast(ray, out hit, TotalPistolRange))
            {
                Instantiate(hitFX, hit.point, Quaternion.identity);
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(TotalPistolForce * ray.direction,hit.point, ForceMode.Impulse);
                    hit.transform.SendMessage("PistolDamege", TotalPistolDamege);
                    Debug.Log("On Hit");
                }
            }*/
            Instantiate(bullet, transform.position, transform.rotation);
            invokeTime=0;
        }
    }
    void BolterShot(){
        if(BloterCD - 5f >= 0)
        {
            Instantiate(bomb, transform.position, transform.rotation);
            BloterCD=0;
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
            //cdtime=0;            
        }
    }
    void HeavyShot(){
        if(invokeTime - 0.01f >= 0)
        {/*
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * range, Color.green);
            RaycastHit hit;
            //audio.PlayOneShot(hitSound);
            if (Physics.Raycast(ray, out hit, TotalPistolRange+100))
            {
                Instantiate(hitFX, hit.point, Quaternion.identity);
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(TotalPistolForce * ray.direction,hit.point, ForceMode.Impulse);
                    hit.transform.SendMessage("PistolDamege", TotalPistolDamege);
                }
            }*/
            Instantiate(bullet, transform.position, transform.rotation);
            invokeTime=0;
        }
    }
    void RocketShot(){
        if(RocketCD - 10f >= 0)
        {
            Instantiate(rocket, transform.position, transform.rotation);
            RocketCD=0;
        }
    }


}
