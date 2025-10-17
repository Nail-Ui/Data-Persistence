using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MainUIHandler : MonoBehaviour
{
    public TMP_InputField _usernameField;
    public TextMeshProUGUI bestScoreText; // Menüde göstermek için

    private void Start()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.LoadBestData();
            bestScoreText.text = $"Best Score: {GameManager.Instance._bestPlayerName} : {GameManager.Instance._bestScore}";
        }
    }

    public void StartNew()
    {
        if (_usernameField.text.Length > 0)
        {
            GameManager.Instance.SetUserName(_usernameField.text);
        }
        else
        {
            GameManager.Instance.SetUserName("Unkown");
        }
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ReadStringInput()
    {
        if (_usernameField.text != null)
        {
            GameManager.Instance.SetUserName(_usernameField.text);
        }
    }
}
