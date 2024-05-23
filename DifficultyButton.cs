using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name);
        gameManager.StartGame(difficulty);
    }
}
