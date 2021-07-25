using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class ControllerScript : MonoBehaviour {
  public GameObject armourAdaptor;
  public GameObject buzzAdaptor;
  public GameObject droidAdaptor;
  public GameObject semiAdaptor;
  
  public CinemachineVirtualCamera pinsVirtualCamera;

  public TextMeshProUGUI amperageText;

  public Button chargeButton;

  public int activeAdaptor = -1;

  public AudioManager audioManager;
  public AudioClip successAudioClip;
  public AudioClip failAudioClip;

  private Generator generator;

  public Image brandImage;

  public Sprite manufacturerSpriteA;
  public Sprite manufacturerSpriteB;
  public Sprite manufacturerSpriteC;
  public Sprite manufacturerSpriteD;
  public Sprite manufacturerSpriteE;
  public Sprite manufacturerSpriteF;


  void Start() {
    audioManager = FindObjectOfType<AudioManager>();

    GameObject[] adaptorButtons = new GameObject[6];
    
    for (int i = 0; i < 6; i++) {
      adaptorButtons[i] = GameObject.Find("AdaptorButton" + i);
      Button button = adaptorButtons[i].GetComponent<Button>();
      int index = i;

      button.onClick.AddListener(() => HandleAdaptorButtonClick(index));
    }

    // GameObject[] adaptorPrefabs = new GameObject[] { armourAdaptor, buzzAdaptor, droidAdaptor, semiAdaptor };
    Dictionary<string, GameObject> adaptorPrefabs = new Dictionary<string, GameObject>();
    adaptorPrefabs.Add("A", armourAdaptor);
    adaptorPrefabs.Add("B", buzzAdaptor);
    adaptorPrefabs.Add("C", droidAdaptor);
    adaptorPrefabs.Add("D", semiAdaptor);

    Dictionary<string, Sprite> manufacturerSprites = new Dictionary<string, Sprite>();
    manufacturerSprites.Add("A", manufacturerSpriteA);
    manufacturerSprites.Add("B", manufacturerSpriteB);
    manufacturerSprites.Add("C", manufacturerSpriteC);
    manufacturerSprites.Add("D", manufacturerSpriteD);
    manufacturerSprites.Add("E", manufacturerSpriteE);
    manufacturerSprites.Add("F", manufacturerSpriteF);

    generator = new Generator();


    // set phone brand sprite
    brandImage.sprite = manufacturerSprites[generator.phoneModel.manufacturer];

    // set phone amperage
    amperageText.text = generator.phoneModel.amperage + "A";

    for (int i = 0; i < 6; i++) {
      GameObject pickedAdaptorPrefab = adaptorPrefabs[generator.adaptors[i].shape];

      GameObject adaptor = Instantiate(pickedAdaptorPrefab, Vector3.zero, Quaternion.identity);
      adaptor.transform.SetParent(adaptorButtons[i].transform);
      adaptor.transform.localPosition = new Vector3(0f, 1.44f, -0.24f);
    }

    chargeButton.onClick.AddListener(HandleChargeButtonClick);
  }

  void HandleAdaptorButtonClick(int index) {
    float startX = -3.62f;
    float incrementX = 1.46f;
    Debug.Log("HandleButtonClick:" + index);
    pinsVirtualCamera.gameObject.transform.position = new Vector3(startX + (incrementX * index), pinsVirtualCamera.gameObject.transform.position.y, pinsVirtualCamera.transform.position.z);
    pinsVirtualCamera.Priority = 22;

    activeAdaptor = index;
  }

  void HandleChargeButtonClick() {
    if (activeAdaptor == -1) {
      Debug.Log("activeAdaptor is negative");
      return;
    }

    AdaptorModel clickedAdaptor = generator.adaptors[activeAdaptor];

    Debug.Log("clickedAdaptor: " + activeAdaptor);

    if (clickedAdaptor.isCorrect(generator.phoneModel)) {
      Debug.Log("you win");
      audioManager.Play("win");
    } else {
      Debug.Log("you lose");
      audioManager.Play("wrong");
    }
  }
}
