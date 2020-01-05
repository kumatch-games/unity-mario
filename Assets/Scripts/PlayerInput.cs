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

    private float JumpTime;

    private bool IsLand;

    private bool IsJumping;

    // Start is called before the first frame update
    void Start()
    {
        JumpTime = 0;
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

        if (IsLand || IsJumping)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                JumpTime += Time.deltaTime;

                if (JumpTime <= 0.3f)
                {
                    Player.AddForce(Vector2.up * JumpPower);
                }

                IsJumping = true;
            }
            else
            {
                IsJumping = false;
                JumpTime = 0;
            }
        }
        else
        {
            IsJumping = false;
            JumpTime = 0f;
        }

        IsLand = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach(var contact in collision.contacts)
        {
            var normal = contact.normal;
            var ip = Vector2.Dot(normal, Vector2.up);

            if (ip > 0.9f)
            {
                IsLand = true;
            }
        }
    }
}
