using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainMenu");
        LoadData();

        //PlayerPrefs.DeleteAll();
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }
    void LoadData(){
        BankShop.Coin = PlayerPrefs.GetInt("Coin");
        BankShop.ShopLaserDamege = PlayerPrefs.GetFloat("ShopLaserDamege");
        BankShop.ShopPistolRange = PlayerPrefs.GetFloat("ShopPistolRange");
        BankShop.ShopPistolDamege = PlayerPrefs.GetFloat("ShopPistolDamege");
        BankShop.ShopPistolForce = PlayerPrefs.GetFloat("ShopPistolForce");
        BankShop.ShopBolterSpeed = PlayerPrefs.GetFloat("ShopBolterSpeed");
        BankShop.ShopBolterGrow = PlayerPrefs.GetFloat("ShopBolterGrow");
        BankShop.ShopBolterAtk = PlayerPrefs.GetFloat("ShopBolterAtk");
        BankShop.ShopBolterPush = PlayerPrefs.GetFloat("ShopBolterPush");
        BankShop.ShopExHp = PlayerPrefs.GetFloat("ShopExHp");
        BankShop.ShopDef = PlayerPrefs.GetFloat("ShopDef");
        BankShop.ShopLaserDamegeC = PlayerPrefs.GetInt("ShopLaserDamegeC");
        BankShop.ShopPistolRangeC = PlayerPrefs.GetInt("ShopPistolRangeC");
        BankShop.ShopPistolDamegeC = PlayerPrefs.GetInt("ShopPistolDamegeC");
        BankShop.ShopPistolForceC = PlayerPrefs.GetInt("ShopPistolForceC");
        BankShop.ShopBolterSpeedC = PlayerPrefs.GetInt("ShopBolterSpeedC");
        BankShop.ShopBolterGrowC = PlayerPrefs.GetInt("ShopBolterGrowC");
        BankShop.ShopBolterAtkC = PlayerPrefs.GetInt("ShopBolterAtkC");
        BankShop.ShopBolterPushC = PlayerPrefs.GetInt("ShopBolterPushC");
        BankShop.ShopLaserDamegeLv = PlayerPrefs.GetInt("ShopLaserDamegeLv");
        BankShop.ShopPistolRangeLv = PlayerPrefs.GetInt("ShopPistolRangeLv");
        BankShop.ShopPistolDamegeLv = PlayerPrefs.GetInt("ShopPistolDamegeLv");
        BankShop.ShopPistolForceLv = PlayerPrefs.GetInt("ShopPistolForceLv");
        BankShop.ShopBolterSpeedLv = PlayerPrefs.GetInt("ShopBolterSpeedLv");
        BankShop.ShopBolterGrowLv = PlayerPrefs.GetInt("ShopBolterGrowLv");
        BankShop.ShopBolterAtkLv = PlayerPrefs.GetInt("ShopBolterAtkLv");
        BankShop.ShopBolterPushLv = PlayerPrefs.GetInt("ShopBolterPushLv");
        BankShop.UnlockRocket = PlayerPrefs.GetInt("UnlockRocket");
        BankShop.UnlockHeavy = PlayerPrefs.GetInt("UnlockHeavy");
        BankShop.UnlockLaser = PlayerPrefs.GetInt("UnlockLaser");
        SystemMenu.easy = PlayerPrefs.GetInt("easy");
        SystemMenu.normal = PlayerPrefs.GetInt("normal");
        SystemMenu.hard = PlayerPrefs.GetInt("hard");
        MainMenu.openLv2 = PlayerPrefs.GetInt("openLv2");
        MainMenu.openLv3 = PlayerPrefs.GetInt("openLv3");
        BankShop.ShopExHpC = PlayerPrefs.GetInt("ShopExHpC");
        BankShop.ShopExHpEx = PlayerPrefs.GetInt("ShopExHpEx");
        BankShop.ShopExHpLv = PlayerPrefs.GetInt("ShopExHpLv");
        BankShop.ShopDefC = PlayerPrefs.GetInt("ShopDefC");
        BankShop.ShopDefEx = PlayerPrefs.GetInt("ShopDefEx");
        BankShop.ShopDefLv = PlayerPrefs.GetInt("ShopDefLv");

    }
}
