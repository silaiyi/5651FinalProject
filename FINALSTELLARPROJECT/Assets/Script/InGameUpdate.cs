using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUpdate : MonoBehaviour
{
    public static float InGameLaserDamege,InGamePistolRange,InGamePistolDamege,InGamePistolForce;
    public static float InGameBolterSpeed,InGameBolterGrow,InGameBolterAtk,InGameBolterPush;
    public static int InGameLaserDamegeLv,InGamePistolRangeLv,InGamePistolDamegeLv,InGamePistolForceLv;
    public static int InGameBolterSpeedLv,InGameBolterGrowLv,InGameBolterAtkLv,InGameBolterPushLv;
    public static float InGameExHp,InGameDef;
    public static int Exp,ExtraExp,ExpTop=100,InGameMoreExp,InGameMoreCoin;
    public static int InGameExHpLv,InGameDefLv,InGameMoreExpLv,InGameMoreCoinLv;
    public int RandomUpdate,seeExp,RandomUpdateL,RandomUpdateR,seeNowExp;
    public static bool inUpdating=false;
    public GameObject UpMenu,MH,MD,ME,MC,MBS,MBG,MBA,MBP,MLD,MPR,MPD,MPF;
    public GameObject LaserDrone,BulletDrone,ExplodeDrone;
    public static bool DroneON,LaserDroneOn,BulletDroneOn,ExplodeDroneOn;
    public Text coin;
    public Slider HpSl,ExpSl,TimerSl;
    public const float MaxTimer=300f;
    public float Timer;
    public GameObject LoseMenu,WinMenu;
    public GameObject LegSpeed,LegJump,LegEnergy;
    public static bool LegOn,LegSpeedOn,LegJumpOn,LegEnergyOn;

    // Start is called before the first frame update
    void Start()
    {
        Timer = MaxTimer;
        InGameLaserDamege=0;InGamePistolRange=0;InGamePistolDamege=0;InGamePistolForce=0;
        InGameBolterSpeed=0;InGameBolterGrow=0;InGameBolterAtk=0;InGameBolterPush=0;
        InGameLaserDamegeLv=0;InGamePistolRangeLv=0;InGamePistolDamegeLv=0;InGamePistolForceLv=0;
        InGameBolterSpeedLv=0;InGameBolterGrowLv=0;InGameBolterAtkLv=0;InGameBolterPushLv=0;
        InGameExHp=0;InGameDef=0;InGameMoreExp=0;InGameMoreCoin=0;
        InGameExHpLv=0;InGameDefLv=0;InGameMoreExpLv=0;InGameMoreCoinLv=0;
        Exp=0;ExpTop=100;
        MH.SetActive(false);MD.SetActive(false);ME.SetActive(false);MC.SetActive(false);
        MBS.SetActive(false);MBG.SetActive(false);MBA.SetActive(false);MBP.SetActive(false);
        MLD.SetActive(false);MPR.SetActive(false);MPD.SetActive(false);MPF.SetActive(false);
        LoseMenu.SetActive(false);WinMenu.SetActive(false);
        LaserDrone.SetActive(false);BulletDrone.SetActive(false);ExplodeDrone.SetActive(false);
        LegSpeed.SetActive(false);LegJump.SetActive(false);LegEnergy.SetActive(false);
        DroneON=false;//LaserDroneOn=false;BulletDroneOn=false;ExplodeDroneOn=false;
        LegOn=false;
        HpSl.maxValue = Player.InGameMaxHp;
        HpSl.value = Player.Hp;
        ExpSl.maxValue = ExpTop;
        ExpSl.value = Exp;
        TimerSl.maxValue = 300f;
        TimerSl.value = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = BankShop.Coin + " G";
        ExtraExp=ExpTop/2;
        if(Exp>=ExpTop){
            ExpTop+=ExtraExp;
            Time.timeScale = 0f;
            Exp=0;
            InGame();
        }
        seeExp = ExpTop;
        seeNowExp = Exp;
        HpSl.maxValue = Player.InGameMaxHp;
        HpSl.value = Player.Hp;
        ExpSl.maxValue = ExpTop;
        ExpSl.value = Exp;
        Timer-=Time.deltaTime;
        TimerSl.value = Timer;
        GemeEnd();
    }
    void InGame(){
        RandomUpdate = UnityEngine.Random.Range(1,101);
        RandomUpdateL = UnityEngine.Random.Range(1,101);
        RandomUpdateR = UnityEngine.Random.Range(1,101);
        UpMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        inUpdating=true;
        GameUpdate();
        //TestUpdate();
    }
    void TestUpdate(){
        if(RandomUpdate>0){
            if(LegOn==false){
                MH.SetActive(false);MD.SetActive(false);ME.SetActive(false);LegEnergy.SetActive(true);
            }else{
                MH.SetActive(true);MD.SetActive(false);ME.SetActive(false);LegEnergy.SetActive(false);
            }
        }
        if(RandomUpdateL>0){
            if(LegOn==false){
                MBS.SetActive(false);MBG.SetActive(false);MBA.SetActive(false);LegJump.SetActive(true);
            }else{
                MBS.SetActive(true);MBG.SetActive(false);MBA.SetActive(false);LegJump.SetActive(false);
            }
        }
        if(RandomUpdateR>0){
            if(LegOn==false){
                MLD.SetActive(false);MPR.SetActive(false);MPD.SetActive(false);LegSpeed.SetActive(true);
            }else{
                MLD.SetActive(true);MPR.SetActive(false);MPD.SetActive(false);LegSpeed.SetActive(false);
            }
        }
    }
    void GameUpdate(){
        if(RandomUpdate<21){
            MH.SetActive(true);MD.SetActive(false);ME.SetActive(false);MC.SetActive(false);LaserDrone.SetActive(false);BulletDrone.SetActive(false);LegSpeed.SetActive(false);
        }else if(RandomUpdate<41&&RandomUpdate>=21){
            MH.SetActive(false);MD.SetActive(true);ME.SetActive(false);MC.SetActive(false);LaserDrone.SetActive(false);BulletDrone.SetActive(false);LegSpeed.SetActive(false);
        }else if(RandomUpdate<61&&RandomUpdate>=41){
            MH.SetActive(false);MD.SetActive(false);ME.SetActive(true);MC.SetActive(false);LaserDrone.SetActive(false);BulletDrone.SetActive(false);LegSpeed.SetActive(false);
        }else if(RandomUpdate<81&&RandomUpdate>=61){
            if(DroneON==false){
                MH.SetActive(false);MD.SetActive(false);ME.SetActive(false);MC.SetActive(false);BulletDrone.SetActive(true);LegSpeed.SetActive(false);
            }else if(DroneON==true){
                MH.SetActive(false);MD.SetActive(false);ME.SetActive(false);MC.SetActive(true);BulletDrone.SetActive(false);LegSpeed.SetActive(false);
            }
        }else if(RandomUpdate>=81){
            if(LegOn==false){
                MH.SetActive(false);MD.SetActive(false);ME.SetActive(false);MC.SetActive(false);BulletDrone.SetActive(false);LegSpeed.SetActive(true);
            }else if(LegOn==true){
                MH.SetActive(false);MD.SetActive(false);ME.SetActive(false);MC.SetActive(true);BulletDrone.SetActive(false);LegSpeed.SetActive(false);
            }
        }
        if(RandomUpdateR<21){
            MBS.SetActive(true);MBG.SetActive(false);MBA.SetActive(false);MBP.SetActive(false);ExplodeDrone.SetActive(false);LegEnergy.SetActive(false);
        }else if(RandomUpdateR<41&&RandomUpdateR>=21){
            MBS.SetActive(false);MBG.SetActive(true);MBA.SetActive(false);MBP.SetActive(false);ExplodeDrone.SetActive(false);LegEnergy.SetActive(false);
        }else if(RandomUpdateR<61&&RandomUpdateR>=41){
            MBS.SetActive(false);MBG.SetActive(false);MBA.SetActive(true);MBP.SetActive(false);ExplodeDrone.SetActive(false);LegEnergy.SetActive(false);
        }else if(RandomUpdateR<81&&RandomUpdateR>=61){
            if(DroneON==false){
                MBS.SetActive(false);MBG.SetActive(false);MBA.SetActive(false);ExplodeDrone.SetActive(true);LegEnergy.SetActive(false);
            }else{
                MBS.SetActive(true);MBG.SetActive(false);MBA.SetActive(false);ExplodeDrone.SetActive(false);LegEnergy.SetActive(false);
            }
        }else if(RandomUpdateR>=81){
            if(LegOn==false){
                MBS.SetActive(false);MBG.SetActive(false);MBA.SetActive(false);ExplodeDrone.SetActive(false);LegEnergy.SetActive(true);
            }else{
                MBS.SetActive(true);MBG.SetActive(false);MBA.SetActive(false);ExplodeDrone.SetActive(false);LegEnergy.SetActive(false);
            }
        }
        if(RandomUpdateL<21){
            MLD.SetActive(true);MPR.SetActive(false);MPD.SetActive(false);MPF.SetActive(false);LaserDrone.SetActive(false);LegJump.SetActive(false);
        }else if(RandomUpdateL<41&&RandomUpdateL>=21){
            MLD.SetActive(false);MPR.SetActive(true);MPD.SetActive(false);MPF.SetActive(false);LaserDrone.SetActive(false);LegJump.SetActive(false);
        }else if(RandomUpdateL<61&&RandomUpdateL>=41){
            MLD.SetActive(false);MPR.SetActive(false);MPD.SetActive(true);MPF.SetActive(false);LaserDrone.SetActive(false);LegJump.SetActive(false);
        }else if(RandomUpdateL<81&&RandomUpdateL>=61){
            if(DroneON==false){
                MLD.SetActive(false);MPR.SetActive(false);MPD.SetActive(false);LaserDrone.SetActive(true);LegJump.SetActive(false);
            }else{
                MLD.SetActive(true);MPR.SetActive(false);MPD.SetActive(false);LaserDrone.SetActive(false);LegJump.SetActive(false);
            }
        }else if(RandomUpdateL>=81){
            if(LegOn==false){
                MLD.SetActive(false);MPR.SetActive(false);MPD.SetActive(false);LaserDrone.SetActive(false);LegJump.SetActive(true);
            }else{
                MLD.SetActive(true);MPR.SetActive(false);MPD.SetActive(false);LaserDrone.SetActive(false);LegJump.SetActive(false);
            }
        }
    }
    public void UnlockLegSpeed(){
        LegOn=true;
        //LegSpeed.SetActive(true);LegJump.SetActive(false);LegEnergy.SetActive(false);
        LegSpeedOn=true;LegJumpOn=false;LegEnergyOn=false;
        Debug.Log("Leg Speed");
    }
    public void UnlockLegJump(){
        LegOn=true;
        //LegSpeed.SetActive(false);LegJump.SetActive(true);LegEnergy.SetActive(false);
        LegSpeedOn=false;LegJumpOn=true;LegEnergyOn=false;
    }
    public void UnlockLegEnergy(){
        LegOn=true;
        //LegSpeed.SetActive(false);LegJump.SetActive(false);LegEnergy.SetActive(true);
        LegSpeedOn=false;LegJumpOn=false;LegEnergyOn=true;
    }
    public void UnlockLaserDrone(){
        DroneON=true;
        //LaserDroneOn=true;BulletDroneOn=false;ExplodeDroneOn=false;
        DroneAi.LaserDroneOn=true;DroneAi.BulletDroneOn=false;DroneAi.ExplodeDroneOn=false;
        Debug.Log("Unlock Laser");
    }
    public void UnlockBulletDrone(){
        DroneON=true;
        //LaserDroneOn=false;BulletDroneOn=true;ExplodeDroneOn=false;
        DroneAi.LaserDroneOn=false;DroneAi.BulletDroneOn=true;DroneAi.ExplodeDroneOn=false;
        Debug.Log("Unlock Bullet");
    }
    public void UnlockExploDrone(){
        DroneON=true;
        //LaserDroneOn=false;BulletDroneOn=false;ExplodeDroneOn=true;
        DroneAi.LaserDroneOn=false;DroneAi.BulletDroneOn=false;DroneAi.ExplodeDroneOn=true;
        Debug.Log("Unlock Explode");
    }
    public void CloseMenu(){
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        inUpdating=false;
        UpMenu.SetActive(false);
        
    }
    public void MoreHp(){
        InGameExHp+=10;
        //Player.Hp=Player.InGameMaxHp;
        InGameExHpLv++;
        if(InGameExHpLv%5==0){
            InGameExHp*=2;
        }
        Player.Hp=Player.InGameMaxHp;
        MH.SetActive(false);
    }
    public void MoreDef(){
        InGameDef+=1;
        InGameDefLv++;
        if(InGameDefLv%5==0){
            InGameDef*=2;
        }
        MD.SetActive(false);
    }
    public void MoreExp(){
        InGameMoreExp+=5;
        InGameMoreExpLv++;
        if(InGameMoreExpLv%5==0){
            InGameMoreExp*=2;
        }
        ME.SetActive(false);
    }
    public void MoreCoin(){
        InGameMoreCoin+=1;
        InGameMoreCoinLv++;
        if(InGameMoreCoinLv%5==0){
            InGameMoreCoin*=2;
        }
        MC.SetActive(false);
    }
    public void MoreBS(){
        InGameBolterSpeed+=5;InGameBolterSpeedLv++;
        if(InGameBolterSpeedLv%5==0){
            InGameBolterSpeed*=5;
        }
        MBS.SetActive(false);
    }
    public void MoreBG(){
        InGameBolterGrow+=5;InGameBolterGrowLv++;
        if(InGameBolterGrowLv%5==0){
            InGameBolterGrow*=5;
        }
        MBG.SetActive(false);
    }
    public void MoreBA(){
        InGameBolterAtk+=5;InGameBolterAtkLv++;
        if(InGameBolterAtkLv%5==0){
            InGameBolterAtk*=5;
        }
        MBA.SetActive(false);
    }
    public void MoreBP(){
        InGameBolterPush+=5;InGameBolterPushLv++;
        if(InGameBolterPushLv%5==0){
            InGameBolterPush*=5;
        }
        MBP.SetActive(false);
    }
    public void MoreLD(){
        InGameLaserDamege+=5;InGameLaserDamegeLv++;
        if(InGameLaserDamegeLv%5==0){
            InGameLaserDamege*=5;
        }
        MLD.SetActive(false);
    }
    public void MorePR(){
        InGamePistolRange+=5;InGamePistolRangeLv++;
        if(InGamePistolRangeLv%5==0){
            InGamePistolRange*=5;
        }
        MPR.SetActive(false);
    }
    public void MorePD(){
        InGamePistolDamege+=5;InGamePistolDamegeLv++;
        if(InGamePistolDamegeLv%5==0){
            InGamePistolDamege*=5;
        }
        MPD.SetActive(false);
    }
    public void MorePF(){
        InGamePistolForce+=5;InGamePistolForceLv++;
        if(InGamePistolForceLv%5==0){
            InGamePistolForce*=5;
        }
        MPF.SetActive(false);
    }
    public void GemeEnd(){
        if(Player.Hp<=0&&Timer>0){
            Time.timeScale = 0f;
            LoseMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if(Player.Hp>0&&Timer<=0){
            Time.timeScale = 0f;
            WinMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if(Player.Hp<=0&&Timer<=0){
            Time.timeScale = 0f;
            WinMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

}
