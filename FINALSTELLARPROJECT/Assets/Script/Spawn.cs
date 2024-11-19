using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy1,enemy2,enemy3;
    public int randomSpawn = 0,willSpawn = 0;
    public static float currentTime = 5f;
    private float invokeTime=5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }
    void SpawnEnemy(){
        invokeTime +=Time.deltaTime;
        willSpawn = Random.Range(1,101);
        if(invokeTime - currentTime >= 0){
            if(willSpawn + WaveCount.spawnWave+SystemMenu.SpwanChange - 70>=0){
                WillSpawn();
            }
            invokeTime = 0;
        }
    }
    void WillSpawn(){
        randomSpawn = Random.Range(1,101);
        if(WaveCount.spawnWave>=1 && WaveCount.spawnWave<  3){
                Spawnwave1();
            }else if(WaveCount.spawnWave>=3&&WaveCount.spawnWave<  5){
                Spawnwave2();
            }else if(WaveCount.spawnWave>=5&&WaveCount.spawnWave < 7){
                Spawnwave3();
            }else if(WaveCount.spawnWave>=7&&WaveCount.spawnWave < 9){
                Spawnwave4();
            }else if(WaveCount.spawnWave>=9&&WaveCount.spawnWave < 11){
                Spawnwave5();
            }else if(WaveCount.spawnWave>=11&&WaveCount.spawnWave < 13){
                Spawnwave6();
            }else{
                Spawnwave7();
            }
    }
    void Spawnwave1(){
        Instantiate(enemy1,this.transform.position,this.transform.rotation);
    }
    void Spawnwave2(){
        if(randomSpawn <= 90){
            Instantiate(enemy1,this.transform.position,this.transform.rotation);
        }else{
            Instantiate(enemy2,this.transform.position,this.transform.rotation);
        }
    }
    void Spawnwave3(){
        if(randomSpawn <= 50){
            Instantiate(enemy1,this.transform.position,this.transform.rotation);
        }else{
            Instantiate(enemy2,this.transform.position,this.transform.rotation);
        }
    }
    void Spawnwave4(){
        if(randomSpawn <= 20){
            Instantiate(enemy1,this.transform.position,this.transform.rotation);
        }else{
            Instantiate(enemy2,this.transform.position,this.transform.rotation);
        }
    }
    void Spawnwave5(){
        if(randomSpawn <= 50){
            Instantiate(enemy1,this.transform.position,this.transform.rotation);
        }else if(randomSpawn <= 70 && randomSpawn > 50){
            Instantiate(enemy2,this.transform.position,this.transform.rotation);
        }else{
            Instantiate(enemy3,this.transform.position,this.transform.rotation);
        }
    }
    void Spawnwave6(){
        if(randomSpawn <= 20){
            Instantiate(enemy1,this.transform.position,this.transform.rotation);
        }else if(randomSpawn <= 70 && randomSpawn > 20){
            Instantiate(enemy2,this.transform.position,this.transform.rotation);
        }else{
            Instantiate(enemy3,this.transform.position,this.transform.rotation);
        }
    }
    void Spawnwave7(){
        if(randomSpawn <= 10){
            Instantiate(enemy1,this.transform.position,this.transform.rotation);
        }else if(randomSpawn <= 55 && randomSpawn > 10){
            Instantiate(enemy2,this.transform.position,this.transform.rotation);
        }else{
            Instantiate(enemy3,this.transform.position,this.transform.rotation);
        }
    }
}
