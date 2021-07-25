using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptorModel {
  public string colour;
  public string shape;
  public int numberPins;

  

  public AdaptorModel(string colour, string shape, int numberPins) {
    this.colour = colour;
    this.shape = shape;
    this.numberPins = numberPins;
  }

  public static int MAX_PINS = 4;
  public static float MAX_AMPERAGE = 17f;

  public void Log(PhoneModel phoneModel) {
    Debug.Log("Colour: " + this.colour + " | Shape: " + this.shape + " | Number of Pins: " + this.numberPins + " | isCorrect: " + isCorrect(phoneModel));
  }

  public bool isCorrect(PhoneModel phoneModel) {
    if (phoneModel.manufacturer == "A") {
      if (this.colour != "Blue" && this.colour != "Green") {
        return false;
      }

      if (this.numberPins == 4) {
        return false;
      }

      return isAmperageCorrect(phoneModel, this.shape);
    }

    if (phoneModel.manufacturer == "B") {
      if (this.numberPins != 2 && this.numberPins != 3) {
        return false;
      }

      return isAmperageCorrect(phoneModel, this.shape);
    }

    if (phoneModel.manufacturer == "C") {
      if (this.colour == "Blue") {
        return false;
      }

      return isAmperageCorrect(phoneModel, this.shape);
    }

    if (phoneModel.manufacturer == "D" || phoneModel.manufacturer == "E") {
      if (this.colour == "Green") {
        return false;
      }

      return isAmperageCorrect(phoneModel, this.shape);
    }

    if (phoneModel.manufacturer == "F") {
      if (this.numberPins != 1 && this.numberPins != 3) {
        return false;
      }

      return isAmperageCorrect(phoneModel, this.shape);
    }

    return false;
  }

  public bool isAmperageCorrect(PhoneModel phoneModel, string shape) {
    if (shape == "A") {
      if (phoneModel.amperage < 1.2f || phoneModel.amperage > 12.4f) {
        return false;
      }

      return true;
    }

    if (shape == "B") {
      if (phoneModel.amperage < 10.5f || phoneModel.amperage > 18.3f) {
        return false;
      }

      return true;
    }

    if (shape == "C") {
      if (phoneModel.amperage > 8.1f) {
        return false;
      }

      return true;
    }

    if (shape == "D") {
      if (phoneModel.amperage > 7.2f) {
        return false;
      }

      return true;
    }

    if (shape == "E") {
      if (phoneModel.amperage < 7.0f || phoneModel.amperage > 18.3f) {
        return false;
      }

      return true;
    }

    if (shape == "F") {
      if (phoneModel.amperage < 5.2f || phoneModel.amperage > 22.0f) {
        return false;
      }

      return true;
    }

    return false;
  }

  // public bool meetsManufacturerRequirements(PhoneModel phoneModel) {
  //   if (phoneModel.manufacturer == "A") {
  //     if (this.colour == "Blue" || this.colour == "Green") {
  //       return true;
  //     }
  //     return false;
  //   }

  //   if (phoneModel.manufacturer == "B") {
  //     if (this.numberPins == 2 || this.numberPins == 3) {
  //       return true;
  //     }
  //     return false;
  //   }

  //   if (phoneModel.manufacturer == "C") {
  //     if (this.colour != "Blue") {
  //       return true;
  //     }
  //     return false;
  //   }

  //   if (phoneModel.manufacturer == "D") {
  //     if (this.colour != "Green") {
  //       return true;
  //     }
  //     return false;
  //   }

  //   if (phoneModel.manufacturer == "E") {
  //     if (this.colour != "Green") {
  //       return true;
  //     }
  //     return false;
  //   }

  //   if (phoneModel.manufacturer == "F") {
  //     if (this.numberPins == 1 || this.numberPins == 3) {
  //       return true;
  //     }
  //     return false;
  //   }

  //   return false;
  // }
}