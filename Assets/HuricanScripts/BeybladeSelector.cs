using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeybladeSelector : MonoBehaviour
{
    public List<Beyblade> beybladeList;
    public Image displayImage;

    private int currentShowIndex = 0;

    private void Start()
    {
        UpdateBeybladeDisplay();
    }

    public void NextBeyblade()
    {
        currentShowIndex++;
        if (currentShowIndex >= beybladeList.Count) currentShowIndex = 0;
        UpdateBeybladeDisplay();
    }

    public void PreviousBeyblade()
    {
        currentShowIndex--;
        if (currentShowIndex < 0) currentShowIndex = beybladeList.Count - 1;
        UpdateBeybladeDisplay();
    }

    private void UpdateBeybladeDisplay()
    {
        displayImage.sprite = beybladeList[currentShowIndex].image;
    }

    public void ConfirmSelection()
    {
        // Show beybladeList[currentIndex].name
    }
}
