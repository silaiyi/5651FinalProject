using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankShop : MonoBehaviour
{
    public static int Coin,Cost,ExCost;
    public static float ShopLaserDamege,ShopPistolRange,ShopPistolDamege,ShopPistolForce;
    public static float ShopBolterSpeed,ShopBolterGrow,ShopBolterAtk,ShopBolterPush;
    public Text LaserDamege,PistolRange,PistolDamege,PistolForce,BolterSpeed,BolterGrow,BolterAtk,BolterPush,NumOfCoin;
    public static float ShopExHp,ShopDef;
    public static int ShopLaserDamegeLv=1,ShopPistolRangeLv=1,ShopPistolDamegeLv=1,ShopPistolForceLv=1,ShopBolterSpeedLv=1,ShopBolterGrowLv=1,ShopBolterAtkLv=1,ShopBolterPushLv=1;
    public static int ShopLaserDamegeEX,ShopPistolRangeEX,ShopPistolDamegeEX,ShopPistolForceEX,ShopBolterSpeedEX,ShopBolterGrowEX,ShopBolterAtkEX,ShopBolterPushEX;
    public static int ShopLaserDamegeC=500,ShopPistolRangeC=500,ShopPistolDamegeC=500,ShopPistolForceC=500,ShopBolterSpeedC=500,ShopBolterGrowC=500,ShopBolterAtkC=500,ShopBolterPushC=500;
    public GameObject LaserBtn,HeavyBtn,RocketBtn,ShopBtn,ShopMenu;
    public static int UnlockLaser=0,UnlockHeavy=0,UnlockRocket=0;
    public static int ShopExHpLv=1,ShopExHpEx,ShopExHpC=500,ShopDefLv=1,ShopDefEx,ShopDefC=500;
    public Text ExHp,Def;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ExCost=Cost/2;
        ShopLaserDamegeEX=ShopLaserDamegeC/2;
        ShopPistolRangeEX=ShopPistolRangeC/2;
        ShopPistolDamegeEX=ShopPistolDamegeC/2;
        ShopPistolForceEX=ShopPistolForceC/2;
        ShopBolterSpeedEX=ShopBolterSpeedC/2;
        ShopBolterGrowEX=ShopBolterGrowC/2;
        ShopBolterAtkEX=ShopBolterAtkC/2;
        ShopBolterPushEX=ShopBolterPushC/2;
        ShopDefEx=ShopDefC/2;
        ShopExHpEx=ShopExHpC/2;
        NumOfCoin.text=Coin + " G";
        if(UnlockLaser==0){
            LaserBtn.SetActive(true);
        }
        if(UnlockHeavy==0){
            HeavyBtn.SetActive(true);
        }
        if(UnlockRocket==0){
            RocketBtn.SetActive(true);
        }
        if(UnlockLaser==1&&UnlockHeavy==1&&UnlockRocket==1){
            ShopBtn.SetActive(false);
            //ShopMenu.SetActive(false);
        }else{
            ShopBtn.SetActive(true);
            //ShopMenu.SetActive(true);
        }
        menuText();
    }
    public void menuText(){
        ExHp.text = ShopExHpC + " G  LV: "+ShopExHpLv;
        Def.text = ShopDefC + " G  LV: "+ShopDefLv;
        LaserDamege.text = ShopLaserDamegeC + " G  LV: "+ShopLaserDamegeLv;
        PistolRange.text = ShopPistolRangeC + " G  LV: "+ShopPistolRangeLv;
        PistolDamege.text = ShopPistolDamegeC + " G  LV: "+ShopPistolDamegeLv;
        //PistolForce.text = ShopPistolForceC + " G  LV: "+ShopPistolForceLv;
        BolterSpeed.text = ShopBolterSpeedC + " G  LV: "+ShopBolterSpeedLv;
        BolterGrow.text = ShopBolterGrowC + " G  LV: "+ShopBolterGrowLv;
        BolterAtk.text = ShopBolterAtkC + " G  LV: "+ShopBolterAtkLv;
        BolterPush.text = ShopBolterPushC + " G  LV: "+ShopBolterPushLv;
    }
    public void UpdateHp(){
        if(Coin-ShopExHpC>=0){
            ShopExHp += 5;
            Coin-=ShopExHpC;
            ShopExHpC+=ShopExHpEx;
            ShopExHpLv++;
            ExHp.text = ShopExHpC + " G  LV: "+ShopExHpLv;
            if(ShopExHpLv%10==0){
                ShopExHp*=5;
            }
        }
    }
    public void UpdateDef(){
        if(Coin-ShopDefC>=0){
            ShopDef += 1;
            Coin-=ShopDefC;
            ShopDefC+=ShopDefEx;
            ShopDefLv++;
            Def.text = ShopDefC + " G  LV: "+ShopDefLv;
            if(ShopDefLv%10==0){
                ShopDef*=5;
            }
        }
        //ShopDefEx=ShopDefC/2;ShopDef;ShopDefLv=1,ShopDefEx,ShopDefC=50;
    }
    public void UpdateLaserDamege(){
        if(Coin-ShopLaserDamegeC>=0){
            ShopLaserDamege += 100;
            Coin-=ShopLaserDamegeC;
            ShopLaserDamegeC+=ShopLaserDamegeEX;
            ShopLaserDamegeLv++;
            LaserDamege.text = ShopLaserDamegeC + " G  LV: "+ShopLaserDamegeLv;
            if(ShopLaserDamegeLv%10==0){
                ShopLaserDamege*=5;
            }
        }
    }
    public void UpdateShopPistolRange(){
        if(Coin-ShopPistolRangeC>=0){
            ShopPistolRange += 5;
            Coin-=ShopPistolRangeC;
            ShopPistolRangeC+=ShopPistolRangeEX;
            ShopPistolRangeLv++;
            PistolRange.text = ShopPistolRangeC + " G  LV: "+ShopPistolRangeLv;
            if(ShopPistolRangeLv%10==0){
                ShopPistolRange*=2;
            }
        }
    }
    public void UpdatePistolDamege(){
        if(Coin-ShopPistolDamegeC>=0){
            ShopPistolDamege += 1;
            Coin-=ShopPistolDamegeC;
            ShopPistolDamegeC+=ShopPistolDamegeEX;
            ShopPistolDamegeLv++;
            PistolDamege.text = ShopPistolDamegeC + " G  LV: "+ShopPistolDamegeLv;
            if(ShopPistolDamegeLv%10==0){
                ShopPistolDamege*=5;
            }
        }
    }
    public void UpdatePistolForce(){
        if(Coin-ShopPistolForceC>=0){
            ShopPistolForce += 1;
            Coin-=ShopPistolForceC;
            ShopPistolForceC+=ShopPistolForceEX;
            ShopPistolForceLv++;
            PistolForce.text = ShopPistolForceC + " G  LV: "+ShopPistolForceLv;
        }
    }
    public void UpdateBolterSpeed(){
        if(Coin-ShopBolterSpeedC>=0){
            ShopBolterSpeed += 1;
            Coin-=ShopBolterSpeedC;
            ShopBolterSpeedC+=ShopBolterSpeedEX;
            ShopBolterSpeedLv++;
            BolterSpeed.text = ShopBolterSpeedC + " G  LV: "+ShopBolterSpeedLv;
        }
    }
    public void UpdateBolterGrow(){
        if(Coin-ShopBolterGrowC>=0){
            ShopBolterGrow += 1;
            Coin-=ShopBolterGrowC;
            ShopBolterGrowC+=ShopBolterGrowEX;
            ShopBolterGrowLv++;
            BolterGrow.text = ShopBolterGrowC + " G  LV: "+ShopBolterGrowLv;
        }
    }
    public void UpdateBolterAtk(){
        if(Coin-ShopBolterAtkC>=0){
            ShopBolterAtk += 10;
            Coin-=ShopBolterAtkC;
            ShopBolterAtkC+=ShopBolterAtkEX;
            ShopBolterAtkLv++;
            BolterAtk.text = ShopBolterAtkC + " G  LV: "+ShopBolterAtkLv;
            if(ShopBolterAtkLv%10==0){
                ShopBolterAtk*=5;
            }
        }
    }
    public void UpdateBolterPush(){
        if(Coin-ShopBolterPushC>=0){
            ShopBolterPush += 10;
            Coin-=ShopBolterPushC;
            ShopBolterPushC+=ShopBolterPushEX;
            ShopBolterPushLv++;
            BolterPush.text = ShopBolterPushC + " G  LV: "+ShopBolterPushLv;
        }
    }
    public void UnlockLaserBtn(){
        if(Coin - 2500 >= 0){
            Coin -= 2500;
            UnlockLaser = 1;
            PlayerPrefs.SetInt("UnlockLaser",UnlockLaser);
            LaserBtn.SetActive(false);
        }
    }
    public void UnlockHeavyBtn(){
        if(Coin - 2500 >= 0){
            Coin -= 2500;
            UnlockHeavy = 1;
            PlayerPrefs.SetInt("UnlockHeavy",UnlockHeavy);
            HeavyBtn.SetActive(false);
        }
    }
    public void UnlockRocketBtn(){
        if(Coin - 2500 >= 0){
            Coin -= 2500;
            UnlockRocket = 1;
            PlayerPrefs.SetInt("UnlockRocket",UnlockRocket);
            RocketBtn.SetActive(false);
        }
    }
}
