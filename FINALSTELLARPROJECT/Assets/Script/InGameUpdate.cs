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
    public Text coin;
    public Slider HpSl,ExpSl,TimerSl;
    public const float MaxTimer=300f;
    public float Timer;
    public GameObject LoseMenu,WinMenu;

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
        if(RandomUpdate<26){
            MH.SetActive(true);MD.SetActive(false);ME.SetActive(false);MC.SetActive(false);
        }else if(RandomUpdate<51&&RandomUpdate>=26){
            MH.SetActive(false);MD.SetActive(true);ME.SetActive(false);MC.SetActive(false);
        }else if(RandomUpdate<76&&RandomUpdate>=51){
            MH.SetActive(false);MD.SetActive(false);ME.SetActive(true);MC.SetActive(false);
        }else{
            MH.SetActive(false);MD.SetActive(false);ME.SetActive(false);MC.SetActive(true);
        }
        if(RandomUpdateL<26){
            MBS.SetActive(true);MBG.SetActive(false);MBA.SetActive(false);MBP.SetActive(false);
        }else if(RandomUpdateL<51&&RandomUpdateL>=26){
            MBS.SetActive(false);MBG.SetActive(true);MBA.SetActive(false);MBP.SetActive(false);
        }else if(RandomUpdateL<76&&RandomUpdateL>=51){
            MBS.SetActive(false);MBG.SetActive(false);MBA.SetActive(true);MBP.SetActive(false);
        }else if(RandomUpdateL>=76){
            MBS.SetActive(false);MBG.SetActive(false);MBA.SetActive(true);MBP.SetActive(false);
        }
        if(RandomUpdateR<26){
            MLD.SetActive(true);MPR.SetActive(false);MPD.SetActive(false);MPF.SetActive(false);
        }else if(RandomUpdateR<51&&RandomUpdateR>=26){
            MLD.SetActive(false);MPR.SetActive(true);MPD.SetActive(false);MPF.SetActive(false);
        }else if(RandomUpdateR<76&&RandomUpdateR>=51){
            MLD.SetActive(false);MPR.SetActive(false);MPD.SetActive(true);MPF.SetActive(false);
        }else if(RandomUpdateR>=76){
            MLD.SetActive(true);MPR.SetActive(false);MPD.SetActive(false);MPF.SetActive(false);
        }

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
