using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Title : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField]
    private Button gameStart;
    [SerializeField]
    private Button gameDeck;
    [SerializeField]
    private Button gameExit;

    private void Awake()
    {
        
    }
    private void Start()
    {
        
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
