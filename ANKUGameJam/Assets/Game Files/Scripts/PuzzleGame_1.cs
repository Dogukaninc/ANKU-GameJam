using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGame_1 : MonoBehaviour, IInteractable
{

    [Header(" Puzzle Settings ")]
    public GameObject puzzlePanel;

    public void Interaction()
    {
        puzzlePanel.SetActive(true);
        Debug.Log("Puzzle Etkile�ime Girildi!!!");
        GameStateHandler.instance.PauseGame();
    }

    void Start()
    {

    }

    void Update()
    {

    }


}
