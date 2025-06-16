using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.01f;

    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float fastSpeed = 20f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

    }

    void OnCollisionEnter2D(Collision2D slow)
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D boost)
    {
        if (boost.tag == "Boost")
        {
            moveSpeed = fastSpeed;
        }
    }
}
