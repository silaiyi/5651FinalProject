using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterPoint : MonoBehaviour
{
    public GameObject PlayerChar;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(PlayerChar,this.transform.position,this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
