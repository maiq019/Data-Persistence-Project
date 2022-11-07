using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Text bestScoreText;
    [SerializeField]
    private TextMeshProUGUI newName;
    
    private void Start()
    {
        GameManager.GetInstance().LoadData();
        bestScoreText.text = $"Best Score:\n{GameManager.GetInstance().GetBestName()} : {GameManager.GetInstance().GetBestScore()}";
    }

    public void StartMain()
    {
        GameManager.GetInstance().SetName(newName.text);
        SceneManager.LoadScene(1);
    }

}
