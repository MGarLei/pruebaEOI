using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float speedRot;

    private void Start()
    {
        //Bloquear el cursor y hacer que desaparezca 
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Para que el movimiento del pj se bloquee cuando está en la pantalla de game over
        //(si el tiempo está a 0 se sale del Update)
        if (Time.timeScale == 0)
            return;
        
        //Giro de cámara con mouse 

        transform.Rotate(Vector3.up * speedRot * Input.GetAxis("Mouse X"));

        transform.Rotate(Vector3.right * -speedRot * Input.GetAxis("Mouse Y"));

        //Limitar rotación de la cámara fijando la rotación en el eje Z
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z = 0;

        //Limitar el ángulo de rotación
        if(rot.x > 50 && rot.x < 180) 

            rot.x = 50;

        if (rot.x < 310 && rot.x > 180) 

            rot.x = 310;
        //cuando el if tiene 1 sola instrucción no es necesario ponerlo entre {}

        transform.rotation = Quaternion.Euler(rot);

        
    }
    private void FixedUpdate()
    {
        //Movimiento con RigidBody

        GetComponent<Rigidbody>().velocity =
            transform.forward * speed * Input.GetAxis("Vertical") +
            transform.right * speed * Input.GetAxis("Horizontal");
    }
}
