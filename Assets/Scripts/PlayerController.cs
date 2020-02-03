using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool canMove = true;

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float maxPosX;
    [SerializeField]
    float maxPosY;
    public static PlayerController instance;

    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (canMove)
        {
            Move();
        }

	}

    private void Move()
    {
        float inputX =  Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;
        transform.position += Vector3.up * inputY * moveSpeed * Time.deltaTime;
        float xPos = Mathf.Clamp(transform.position.x,-maxPosX,maxPosX);
        float yPos = Mathf.Clamp(transform.position.y, -maxPosY, maxPosY);

        transform.position = new Vector3(xPos, yPos);
    }
}
