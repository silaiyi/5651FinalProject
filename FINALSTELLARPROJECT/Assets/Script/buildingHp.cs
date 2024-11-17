using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingHp : MonoBehaviour
{
    public float Totallife,life = 20f;
    // Start is called before the first frame update
    void Start()
    {
        Totallife=life+Player.InGameMaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Totallife <= 0){
             Kill();
        }
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
        Destroy(gameObject);
    }
}
