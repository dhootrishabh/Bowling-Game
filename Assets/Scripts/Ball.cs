using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    public Rigidbody player;
    public float moveSpeed;
    private bool positionSet = false;
    private bool holding;
    private bool shooting = false;
    private float ballForce = 0f;
    private Vector3 newPosition;

    public GameObject[] positions;
    private Vector3 startPosition;
    private int currentPoint;
    private Vector3 spawnPosition;

    private int count;
    public GameManager manager;
    private int score;

    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody>();
        spawnPosition = player.transform.position;
        currentPoint = 0;
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if(!positionSet)
        {
            SetPosition();
        }
        
        if(holding)
        {
            SetPower();
        }

        if(!holding && shooting)
        {
            Shoot();

        }
        
        //player.AddForce(transform.forward * 10f);
	}

    void SetPosition()
    {
        if(player.transform.position == positions[currentPoint].transform.position)
        {
            currentPoint = (currentPoint + 1) % 2;
        }
        else
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, positions[currentPoint].transform.position, moveSpeed * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            positionSet = true;
            holding = true;
        }
    }

    void SetPower()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            ballForce += 50f;
            //print(ballForce);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            holding = false;
            shooting = true;
            print("Time to shoot");
        }
    }
    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.AddForce(Vector3.forward * ballForce);
            print("Boom!!!");
            shooting = false;
        }

        
    }
    public void Respawn()
    {
        count += 1;
        if(count == 1)
        {
            manager.roundFinish();
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Finish")
        {
            Invoke("Respawn", 5f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            Invoke("Respawn", 3f);
        }
    }


}
