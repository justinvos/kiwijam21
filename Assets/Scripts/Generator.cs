using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

enum Colour
{
    Red,
    Blue,
    Green,
}

enum Shape
{
    A,
    B,
    C,
    D,
}

enum Manufacturer
{
    A,
    B,
    C,
    D,
    E,
    F
}

// string[] colours = { "red", "blue", "green" };
// string[] shapes = { "a", "b", "c", "d" };
// string[] manufacturers = { "a", "b", "c", "d" };


public class Generator {
  public PhoneModel phoneModel;

  public AdaptorModel correctAdaptor;
  public AdaptorModel[] adaptors = new AdaptorModel[6];

  public Generator() {
      Debug.Log("hey there");
      this.phoneModel = CreateRandomPhone();
      phoneModel.Log();
      
      this.adaptors = generateAdaptors(phoneModel);

      Debug.Log("====================");
      foreach (AdaptorModel adaptorModel in adaptors) {
        adaptorModel.Log(phoneModel);
      }
  }

  public AdaptorModel[] generateAdaptors(PhoneModel phoneModel) {
    while(true) {
      AdaptorModel correctAdaptorModel = null;
      
      while (correctAdaptorModel == null) {
        AdaptorModel newAdaptor = CreateRandomAdaptor();
        if (newAdaptor.isCorrect(phoneModel)) {
          correctAdaptorModel = newAdaptor;
        }
      }

      // Debug.Log("Correct Adaptor");
      // correctAdaptorModel.Log();


      // Debug.Log("Incorrect adaptors");
      AdaptorModel[] incorrectAdaptorModels = new AdaptorModel[5];

      for (int i = 0; i < 5; i++) {
          AdaptorModel newAdaptor = CreateRandomAdaptor();
          // Debug.Log("- " + i);
          incorrectAdaptorModels[i] = CreateIncorrectAdaptor(phoneModel);
      }

      AdaptorModel[] allAdaptorModels = new AdaptorModel[6];
      incorrectAdaptorModels.CopyTo(allAdaptorModels, 0);
      allAdaptorModels[5] = correctAdaptorModel;

      if (isBalancedAdaptors(allAdaptorModels)) {
        this.correctAdaptor = correctAdaptorModel;

        AdaptorModel[] shuffledAdaptorModels = allAdaptorModels.OrderBy(x => Mathf.FloorToInt(Random.value * allAdaptorModels.Length)).ToArray();

        return shuffledAdaptorModels;
      }
    }
  }

  public bool isBalancedAdaptors(AdaptorModel[] allAdaptorModels) {
    Dictionary<string, int> colourCounts = new Dictionary<string, int>();
    Dictionary<int, int> numberPinCounts = new Dictionary<int, int>();
    Dictionary<string, int> shapeCounts = new Dictionary<string, int>();


    foreach (AdaptorModel adaptorModel in allAdaptorModels) {
      if (!colourCounts.ContainsKey(adaptorModel.colour)) {
        colourCounts[adaptorModel.colour] = 0;
      }

      colourCounts[adaptorModel.colour] = colourCounts[adaptorModel.colour] + 1;

      if (!numberPinCounts.ContainsKey(adaptorModel.numberPins)) {
        numberPinCounts[adaptorModel.numberPins] = 0;
      }

      numberPinCounts[adaptorModel.numberPins] = numberPinCounts[adaptorModel.numberPins] + 1;

      if (!shapeCounts.ContainsKey(adaptorModel.shape)) {
        shapeCounts[adaptorModel.shape] = 0;
      }

      shapeCounts[adaptorModel.shape] = shapeCounts[adaptorModel.shape] + 1;
    }

    foreach (KeyValuePair<string, int> colourCount in colourCounts) {
      if (colourCount.Value > 3) {
        return false;
      }
    }

    foreach (KeyValuePair<int, int> numberPinCount in numberPinCounts) {
      if (numberPinCount.Value > 2) {
        return false;
      }
    }

    foreach (KeyValuePair<string, int> shapeCount in shapeCounts) {
      if (shapeCount.Value > 2) {
        return false;
      }
    }

    return true;
  }


  public AdaptorModel CreateIncorrectAdaptor(PhoneModel phoneModel) {
    while (true) {
      AdaptorModel newAdaptor = CreateRandomAdaptor();

      if (!newAdaptor.isCorrect(phoneModel)) {
        return newAdaptor;
      }
    }
  }

  public AdaptorModel CreateRandomAdaptor() {
    string[] colours = System.Enum.GetNames(typeof(Colour));
    string[] shapes = System.Enum.GetNames(typeof(Shape));

    int numberPins = Mathf.FloorToInt(Random.value * (AdaptorModel.MAX_PINS - 1)) + 1;

    return new AdaptorModel(pickRandom(colours), pickRandom(shapes), numberPins);
  }

  public PhoneModel CreateRandomPhone() {
    string[] manufacturers = System.Enum.GetNames(typeof(Manufacturer));
    float amperage = Mathf.Round(Random.value * AdaptorModel.MAX_AMPERAGE * 10) / 10;

    return new PhoneModel(pickRandom(manufacturers), amperage);
  }

  public string pickRandom(string[] options) {
    // Debug.Log("pickRandom: " + options.Length);
    int pickedIndex = Mathf.FloorToInt(Random.value * options.Length);
    return options[pickedIndex];
  }
}
