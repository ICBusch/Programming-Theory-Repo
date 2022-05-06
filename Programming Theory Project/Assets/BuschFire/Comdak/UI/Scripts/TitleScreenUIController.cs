using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleScreenUIController : MonoBehaviour
{
    [SerializeField]
    Button singlePlayerButton;
    [SerializeField]
    Button multiPlayerButton;
    [SerializeField]
    TMP_InputField inputField;

    private string localPlayerName;

    private void Start()
    {
        singlePlayerButton.interactable = false;
        multiPlayerButton.interactable = false;
        //inputField.onValueChanged.AddListener(delegate { EnableButtons(); });
        //singlePlayerButton.onClick.AddListener(delegate { StartSinglePlayerGame(); });
        //multiPlayerButton.onClick.AddListener(delegate { StartMultiPlayerGame(); });    
    }
    public void EnableButtons()
    {
        singlePlayerButton.interactable = true;
        multiPlayerButton.interactable = true;
        localPlayerName = inputField.text;
    }
   public void StartSinglePlayerGame()
    {
        //SceneManager.LoadScene(1);
        Debug.Log("Enter Single Player Mode");
    }

    public void StartMultiPlayerGame()
    {
        //SceneManager.LoadScene(1);
        Debug.Log("Enter Multi Player Mode");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Exit();
#endif
    }
}
