using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{

    public float range = 20;
    public float force = 20;
    public GameObject hitFX;
    public AudioClip hitSound;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * range, Color.green);
            RaycastHit hit;
            audio.PlayOneShot(hitSound);
            if (Physics.Raycast(ray, out hit, range))
            {
                Instantiate(hitFX, hit.point, Quaternion.identity);
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(force * ray.direction,
                                                     hit.point, ForceMode.Impulse);
                    hit.transform.SendMessage("Hit", 1);
                }
            }
        }
    }
}
