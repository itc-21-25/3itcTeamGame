using UnityEngine;
using TMPro;

public class BaseUI : MonoBehaviour
{
     [field: SerializeField] TMP_Text gameText;

    void Start()
    {
        GameManager.Instance.OnStateChange += UpdateGameStatus;
        UpdateGameStatus();
    }

    void UpdateGameStatus()
    {
        gameText.text = $"Game is {GameManager.Instance.GameState}";
    }
}