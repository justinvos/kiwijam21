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
    Dictionary<string, GameObject> adaptorPrefabs = new Dictionary();
    adaptorPrefabs.Add("A", armourAdaptor);
    adaptorPrefabs.Add("B", buzzAdaptor);
    adaptorPrefabs.Add("C", droidAdaptor);
    adaptorPrefabs.Add("D", semiAdaptor);


    Generator generator = new Generator();

    for (int i = 0; i < 6; i++) {
      GameObject pickedAdaptorPrefab = adaptorPrefabs[generator.adaptors[i].shape];

      GameObject adaptor = Instantiate(pickedAdaptorPrefab, Vector3.zero, Quaternion.identity);
      adaptor.transform.SetParent(adaptorButtons[i].transform);
      adaptor.transform.localPosition = new Vector3(0f, 1.44f, -0.12f);
    }
  }
}
