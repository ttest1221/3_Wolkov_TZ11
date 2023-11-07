using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    
    private void Awake()
    {
        _gameManager.Play();
        _gameManager.HideGame();
    }
    public void NewGameClick()
    {
        _gameManager.Play();
        StartCoroutine(Waiter());
    }
    private IEnumerator Waiter()
    {
        yield return new WaitForSeconds(1);
        _gameManager.ShowGame();
        _gameManager.startText.SetActive(true);
        _gameManager.StartCoroutine(_gameManager.StartGame());
    }

    
}
