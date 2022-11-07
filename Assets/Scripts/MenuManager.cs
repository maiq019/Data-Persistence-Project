using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Text bestScoreText;
    //[SerializeField]
    //private TextMeshProUGUI nameDisplay;
    [SerializeField]
    private TextMeshProUGUI newName;
    
    private void Start()
    {
        GameManager.GetInstance().LoadData();
        //nameDisplay.text = GameManager.GetInstance().GetBestName();
        bestScoreText.text = $"Best Score:\n{GameManager.GetInstance().GetBestName()} : {GameManager.GetInstance().GetBestScore()}";
    }

    private void Update()
    {
       GameManager.GetInstance().SetName(newName.text);
    }
    
    public void StartMain()
    {
        SceneManager.LoadScene(1);
    }

}
