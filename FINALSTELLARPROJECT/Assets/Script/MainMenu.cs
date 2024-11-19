using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Main,Planet,Upgrade,Shop,Options,showPlayer,UpgradeMenu,ManualofArms;
    public GameObject ShowLv2,ShowLv3,OpenTut;
    public static int openLv2=0,openLv3=0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(openLv2==1){
            ShowLv2.SetActive(true);
        }else{
            ShowLv2.SetActive(false);
        }
        if(openLv3==1){
            ShowLv3.SetActive(true);
        }else{
            ShowLv3.SetActive(false);
        }
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("StartnMenu");
        //PlayerPrefs.DeleteAll();
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }
    public void OpenMainMenu()
    {
        Main.SetActive(true);
        Planet.SetActive(false);
        Upgrade.SetActive(false);
        Options.SetActive(false);
        OpenTut.SetActive(false);
        showPlayer.SetActive(true);
        SaveData();
    }
    public void OpenTutorial(){
        Main.SetActive(false);
        showPlayer.SetActive(false);
        OpenTut.SetActive(true);
    }
    public void OpenPlanet()
    {
        Main.SetActive(false);
        Planet.SetActive(true);
        showPlayer.SetActive(false);
    }
    public void OpenUpgrade()
    {
        Main.SetActive(false);
        Upgrade.SetActive(true);
        showPlayer.SetActive(false);
    }
    public void OpenShop()
    {
        UpgradeMenu.SetActive(false);
        Shop.SetActive(true);
    }
    public void CloseShop()
    {
        Shop.SetActive(false);
        UpgradeMenu.SetActive(true);
    }
    public void OpenOptions()
    {
        Main.SetActive(false);
        Options.SetActive(true);
        showPlayer.SetActive(false);
    }
    public void OpenManualofArms(){
        ManualofArms.SetActive(true);
        UpgradeMenu.SetActive(false);
    }
    public void CloseManualofArms(){
        ManualofArms.SetActive(false);
        UpgradeMenu.SetActive(true);
    }
    public void ChooseLv1(){
        //PlayerLab
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lv1");
    }
    public void ChooseLv2(){
        //PlayerLab
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lv2");
    }
    public void ChooseLv3(){
        //PlayerLab
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lv3");
    }
    public void DeleteData(){
        PlayerPrefs.DeleteAll();
    }
    public void SaveData(){
        PlayerPrefs.SetInt("Coin",BankShop.Coin);
        PlayerPrefs.SetFloat("ShopLaserDamege",BankShop.ShopLaserDamege);
        PlayerPrefs.SetFloat("ShopPistolRange",BankShop.ShopPistolRange);
        PlayerPrefs.SetFloat("ShopPistolDamege",BankShop.ShopPistolDamege);
        PlayerPrefs.SetFloat("ShopPistolForce",BankShop.ShopPistolForce);
        PlayerPrefs.SetFloat("ShopBolterSpeed",BankShop.ShopBolterSpeed);
        PlayerPrefs.SetFloat("ShopBolterGrow",BankShop.ShopBolterGrow);
        PlayerPrefs.SetFloat("ShopBolterAtk",BankShop.ShopBolterAtk);
        PlayerPrefs.SetFloat("ShopBolterPush",BankShop.ShopBolterPush);
        PlayerPrefs.SetFloat("ShopExHp",BankShop.ShopExHp);
        PlayerPrefs.SetFloat("ShopDef",BankShop.ShopDef);
        PlayerPrefs.SetInt("ShopLaserDamegeC",BankShop.ShopLaserDamegeC);
        PlayerPrefs.SetInt("ShopPistolRangeC",BankShop.ShopPistolRangeC);
        PlayerPrefs.SetInt("ShopPistolDamegeC",BankShop.ShopPistolDamegeC);
        PlayerPrefs.SetInt("ShopPistolForceC",BankShop.ShopPistolForceC);
        PlayerPrefs.SetInt("ShopBolterSpeedC",BankShop.ShopBolterSpeedC);
        PlayerPrefs.SetInt("ShopBolterGrowC",BankShop.ShopBolterGrowC);
        PlayerPrefs.SetInt("ShopBolterAtkC",BankShop.ShopBolterAtkC);
        PlayerPrefs.SetInt("ShopBolterPushC",BankShop.ShopBolterPushC);
        PlayerPrefs.SetInt("ShopLaserDamegeLv",BankShop.ShopLaserDamegeLv);
        PlayerPrefs.SetInt("ShopPistolRangeLv",BankShop.ShopPistolRangeLv);
        PlayerPrefs.SetInt("ShopPistolDamegeLv",BankShop.ShopPistolDamegeLv);
        PlayerPrefs.SetInt("ShopPistolForceLv",BankShop.ShopPistolForceLv);
        PlayerPrefs.SetInt("ShopBolterSpeedLv",BankShop.ShopBolterSpeedLv);
        PlayerPrefs.SetInt("ShopBolterGrowLv",BankShop.ShopBolterGrowLv);
        PlayerPrefs.SetInt("ShopBolterAtkLv",BankShop.ShopBolterAtkLv);
        PlayerPrefs.SetInt("ShopBolterPushLv",BankShop.ShopBolterPushLv);
        PlayerPrefs.SetInt("ShopExHpC",BankShop.ShopExHpC);
        PlayerPrefs.SetInt("ShopExHpEx",BankShop.ShopExHpEx);
        PlayerPrefs.SetInt("ShopExHpLv",BankShop.ShopExHpLv);
        PlayerPrefs.SetInt("ShopDefC",BankShop.ShopDefC);
        PlayerPrefs.SetInt("ShopDefEx",BankShop.ShopDefEx);
        PlayerPrefs.SetInt("ShopDefLv",BankShop.ShopDefLv);
        PlayerPrefs.SetInt("isLoad",1);
        Debug.Log("Save Game");
    }
}
