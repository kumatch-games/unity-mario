using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Player;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private float JumpPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player.AddForce(Vector2.left * Speed);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            Player.AddForce(Vector2.right * Speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.AddForce(Vector2.up * JumpPower);
        }
    }
}
