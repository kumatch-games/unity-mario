using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Rigidbody;

    [SerializeField]
    private float MaxSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Rigidbody.velocity.x) > MaxSpeed)
        {
            Rigidbody.velocity =
                new Vector2(
                    MaxSpeed * Mathf.Sign(Rigidbody.velocity.x),
                    Rigidbody.velocity.y);
        }
    }
}
