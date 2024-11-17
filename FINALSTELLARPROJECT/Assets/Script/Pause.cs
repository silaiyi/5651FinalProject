using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InGameUpdate.inUpdating == false){
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                Resume();
                }
                else
                {
                Paused();
                }
            }
        }
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LoadMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;        
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading Menu");
    }

    public void QuitGame()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        Application.Quit();
        Debug.Log("Quitting game");
    }
    public void WinLv2(){
        MainMenu.openLv2=1;
        PlayerPrefs.SetInt("openLv2",MainMenu.openLv2);

    }
    public void WinLv3(){
        MainMenu.openLv3=1;
        PlayerPrefs.SetInt("openLv3",MainMenu.openLv3);
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
    }
}
