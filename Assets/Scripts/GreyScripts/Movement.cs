using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f; // Rychlost pohybu
    public float forceMultiplier = 10f; // Násobitel síly

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        // Získání vstupu od hráèe
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Vytvoøení vektoru pohybu na základì vstupu
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Pohyb objektu na základì vektoru pohybu
        rb.MovePosition(rb.position + transform.TransformDirection(movement) * movementSpeed * Time.deltaTime);

        // Použití síly pro pohyb (pro realistiètìjší efekt)
        Vector3 force = new Vector3(horizontalInput, 0f, verticalInput) * forceMultiplier;
        rb.AddForce(force);
    }
}
