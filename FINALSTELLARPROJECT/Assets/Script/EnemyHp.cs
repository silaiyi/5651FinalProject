using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public float Totallife,life = 20f,PistolDef,EnergyDef,BolterDef,TotalPistolGetHit,TotalEnergyGetHit,TotalBolterGetHit;
    public int GiveExp=10,GiveCoin=10;
    // Start is called before the first frame update
    void Start()
    {
        Totallife=life+SystemMenu.EnemyHp+WaveCount.MonExHp;
        GiveCoin += WaveCount.exCoin+SystemMenu.moreCoin+InGameUpdate.InGameMoreCoin;
        GiveExp += WaveCount.exExp+SystemMenu.moreExp+InGameUpdate.InGameMoreExp;
        if(GiveCoin<=0){
            GiveCoin=1;
        }
        if(GiveExp<=0){
            GiveExp=1;
        }
        /*
        if(Totallife<=0){
            Totallife=20;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Totallife <= 0){
             Kill();
        }
    }
    public void PistolDamege(float GetHit){
        TotalPistolGetHit=GetHit-PistolDef;
        if(TotalPistolGetHit<=0){
            TotalPistolGetHit=5;
        }
        Hit(TotalPistolGetHit);
    }
    public void EnergyDamege(float GetHit){
        TotalEnergyGetHit=GetHit-EnergyDef;
        if(TotalEnergyGetHit<=0){
            TotalEnergyGetHit=5;
        }
        Hit(TotalEnergyGetHit);

    }
    public void BolterDamege(float GetHit){
        TotalBolterGetHit=GetHit-BolterDef;
        if(TotalBolterGetHit<=0){
            TotalBolterGetHit=5;
        }
        Hit(TotalBolterGetHit);
    }
    public void Hit(float damage)
    {
        if (Totallife > 0)
            Totallife -= damage;
        else if(Totallife <= 0){
             Kill();
            }
    }

    void Kill()
    {
        BankShop.Coin+=GiveCoin;
        InGameUpdate.Exp+=GiveExp;
        Destroy(gameObject);
    }
    
}
