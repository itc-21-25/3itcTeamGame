using UnityEngine;
using TMPro;

public class GameStatusDisplay : MonoBehaviour
{
    public TextMeshProUGUI gameText;

    private string gameStatus = "stopped"; 

    void Start()
    {
        gameText = GetComponent<TextMeshProUGUI>();

        UpdateGameStatus();
    }

    public void UpdateGameStatus()
    {
        gameText.text = "Game is " + gameStatus;
    }

    public void SetGameStatus(string newStatus)
    {
        gameStatus = newStatus;
        UpdateGameStatus(); 
    }
}