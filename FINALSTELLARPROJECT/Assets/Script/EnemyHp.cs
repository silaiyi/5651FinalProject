using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public float Totallife,life = 20f,PistolDef,EnergyDef,BolterDef;
    public int GiveExp=10,GiveCoin=10;
    // Start is called before the first frame update
    void Start()
    {
        Totallife=life+SystemMenu.EnemyHp+WaveCount.MonExHp;
        GiveCoin += WaveCount.exCoin+SystemMenu.moreCoin+InGameUpdate.InGameMoreCoin;
        GiveExp += WaveCount.exExp+SystemMenu.moreExp+InGameUpdate.InGameMoreExp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Totallife <= 0){
             Kill();
        }
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
