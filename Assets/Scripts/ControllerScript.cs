using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {
  public GameObject armourAdaptor;
  public GameObject buzzAdaptor;
  public GameObject droidAdaptor;
  public GameObject semiAdaptor;

  void Start() {
    GameObject[] adaptorButtons = new GameObject[6];
    
    for (int i = 0; i < 6; i++) {
      adaptorButtons[i] = GameObject.Find("AdaptorButton" + i);
    }

    GameObject[] adaptorPrefabs = new GameObject[] { armourAdaptor, buzzAdaptor, droidAdaptor, semiAdaptor };


    for (int i = 0; i < 6; i++) {
      int pickedAdaptorIndex = Mathf.FloorToInt(Random.value * adaptorPrefabs.Length);
      GameObject pickedAdaptorPrefab = adaptorPrefabs[pickedAdaptorIndex];

      GameObject adaptor = Instantiate(pickedAdaptorPrefab, Vector3.zero, Quaternion.identity);
      adaptor.transform.SetParent(adaptorButtons[i].transform);
      adaptor.transform = new Vector3(0f, adaptor.transform.position.y, adaptor.transform.position.y);
    }
  }
}
