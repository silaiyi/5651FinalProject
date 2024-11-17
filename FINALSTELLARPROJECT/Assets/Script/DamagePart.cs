using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePart : MonoBehaviour
{
    public float Totallife=100,PistolDef,EnergyDef,BolterDef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PistolDamege(float GetHit){
        Hit(GetHit - PistolDef);
    }
    public void EnergyDamege(float GetHit){
        Hit(GetHit - EnergyDef);
    }
    public void BolterDamege(float GetHit){
        Hit(GetHit - BolterDef);
    }
    public void Hit(float damage)
    {
        if (Totallife > 0)
            Totallife -= damage;
        else
             Kill();
    }

    void Kill()
    {
        //Destroy(gameObject);
        //this.
    }
}
