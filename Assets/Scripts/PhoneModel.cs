using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneModel {
  public string manufacturer;
  public float amperage;
  
  public PhoneModel(string manufacturer, float amperage) {
    this.manufacturer = manufacturer;
    this.amperage = amperage;
  }

  public void Log() {
    Debug.Log("Manufacturer: " + this.manufacturer + " | Amperage: " + this.amperage);
  }
}
