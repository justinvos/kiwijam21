using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRaycast : MonoBehaviour
{

    [SerializeField]
    private int sortOrder = 0;

    public Camera playCamera;
    public float rayLength;
    public LayerMask layerMask;



        void Start()
        {
            playCamera = this.GetComponent<Camera>();
           
        }
        private void Update()
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("good job you just clicked the mouse");
                RaycastHit hit;
                Ray ray = playCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit)) //, rayLength, layerMask))
                {
                    Debug.DrawRay(Input.mousePosition, Vector3.forward, Color.green);

                    Transform objectHit = hit.transform;
                    if (objectHit.CompareTag("Cable"))
                    {
                        Debug.Log("you clicked on a cable --- " + objectHit.gameObject.name);
                    } else
                    {
                        Debug.Log("clicked on nothing");
                    }
                    // Do something with the object that was hit by the raycast.
                }
            }
        }
        }
    
