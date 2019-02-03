using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinFall : MonoBehaviour {

    public GameManager manager;

    private GameObject pin;
    public int pinFallCount = 0;
	// Use this for initialization
	void Start () {
        pin = this.gameObject;
        print(pin.transform.name + pin.transform.rotation);
        //print(pin.transform.tag);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            //pinFallCount += 1;
            Destroy(pin);
            manager.Score();
            //print("PinFall: " + pinFallCount.ToString());
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(pin.transform.rotation.x >= -.3f || pin.transform.rotation.z < -0.3f || pin.transform.rotation.y < -0.3f)
        {
            //pinFallCount += 1;
            Destroy(pin);
            manager.Score();
            //print("Pin Falls: " + pinFallCount.ToString());
        }
    }

}
