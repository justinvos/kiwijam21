using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public float xRotation = 0f;
    public float yRotation = 0f;

    private float smooth = 5.0f;
    public float lastRotateTime = 0f;
    public Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hey there");
    }

    void Update() {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if ((Time.time - lastRotateTime) > 0.5f) {
          Debug.Log("ready");

          if (vertical > 0) {
            flip(90f, 0f);
          } else if (vertical < 0) {
            flip(-90f, 0f);
          } else if (horizontal > 0) {
            flip(0f, 90f);
          } else if (horizontal < 0) {
            flip(0f, -90f);
          }
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
    }

    void flip(float deltaXRotation, float deltaYRotation) {
      lastRotateTime = Time.time;
      xRotation = xRotation + deltaXRotation;
      yRotation = yRotation + deltaYRotation;
      targetRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
