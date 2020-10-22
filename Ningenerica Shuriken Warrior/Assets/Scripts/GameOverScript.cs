using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    private Button[] buttons_;

    void Awake()
    {
        buttons_ = GetComponentsInChildren<Button>();
        hideButtons();
    }

    public void hideButtons()
    {
        foreach (var b in buttons_)
        {
            b.gameObject.SetActive(false);
        }
    }

    public void showButtons()
    {
        foreach (var b in buttons_)
        {
            b.gameObject.SetActive(true);
        }
    }

    public void exitToMenu()
    {
        SceneManager.LoadScene("TitleMenuScene");
    }

    public void restartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }


// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
