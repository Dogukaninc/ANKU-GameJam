using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainGameEvents : MonoBehaviour
{
    private UIDocument _document;

    private Button _button;

    private Button _button2;

    private List<Button> _menubuttons = new List<Button>();

    private AudioSource _audiosource;

    private void Awake()
    {

        _audiosource = GetComponent<AudioSource>();
        _document = GetComponent<UIDocument>();

        _button = _document.rootVisualElement.Q("play") as Button;

        _button2 = _document.rootVisualElement.Q("quit") as Button;

        _button.RegisterCallback<ClickEvent>(OnPlayGameClick);
        _button2.RegisterCallback<ClickEvent>(QuitGame);

        _menubuttons = _document.rootVisualElement.Query<Button>().ToList();

        for (int i = 0; i < _menubuttons.Count; i++)
        {
            _menubuttons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);

        }
        _button2.RegisterCallback<ClickEvent>(QuitGame);


    }

    public void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnPlayGameClick);


        for (int i = 0; i < _menubuttons.Count; i++)
        {
            _menubuttons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("oyun başlatma tuşuna bastınız.");
        SceneManager.LoadSceneAsync("IntroScene");
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {
        _audiosource.Play();
    }
    
    public void QuitGame(ClickEvent evt)
    {
        Debug.Log("OYUN KAPATILDI");
        Application.Quit();
    }
}
