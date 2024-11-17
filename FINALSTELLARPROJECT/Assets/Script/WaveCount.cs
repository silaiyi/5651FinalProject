using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCount : MonoBehaviour
{
    // Start is called before the first frame update
    public static float MonExHp=50,SpwanChange=0,TotalExHp=0,exAtk;
    public static int exCoin=0,exExp=0;
    public static float currentTime = 20f;
    private float invokeTime;
    public static int spawnWave = 1;
    public int seeWave;
    void Start()
    {
        spawnWave = 1;
        MonExHp=0;exCoin=0;exAtk=0;exExp=0;SpwanChange=0;
    }

    // Update is called once per frame
    void Update()
    {
        WaveInCount();
        seeWave = spawnWave;
    }
    void WaveInCount(){
        invokeTime +=Time.deltaTime;
        if(invokeTime-currentTime>=0){
            TotalExHp += MonExHp + SystemMenu.EnemyHp;
            exAtk += 50 + SystemMenu.EnemyAtk;
            exCoin += 50+  SystemMenu.moreCoin;exExp += 50 + SystemMenu.moreExp;SpwanChange+=5+SystemMenu.SpwanChange;
            spawnWave+=1;
            invokeTime=0;
        }
    }
}
