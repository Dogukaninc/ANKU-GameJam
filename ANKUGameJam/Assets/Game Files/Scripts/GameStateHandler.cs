using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    public PlayerController playerController;

    public static GameStateHandler instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            return;
        }

    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void PauseGame()
    {
        playerController.enabled = false;
        //TODO: Burada oyuncuyu idle animasyona sokarýz böylece donup kalmamýþ olur
        //Oyuncunun animatoru bu pause efektinden etkilenmemeli
    }

    public void ContinueGame()
    {
        playerController.enabled |= true;
    }
}
