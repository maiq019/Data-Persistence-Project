using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick brickPrefab;
    public int lineCount = 6;
    public Rigidbody ball;

    public Text bestScoreText;
    public Text scoreText;
    public GameObject gameOverText;
    
    private bool _mStarted;
    private int _mPoints;
    
    private bool _mGameOver;

    
    // Start is called before the first frame update
    private void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < lineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(brickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

        bestScoreText.text = $"Best Score:/n{GameManager.GetInstance().GetBestName()} : {GameManager.GetInstance().GetBestScore()}";
        scoreText.text = $"Name : {GameManager.GetInstance().GetName()}/nScore : 0";
    }

    private void Update()
    {
        if (!_mStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _mStarted = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                ball.transform.SetParent(null);
                ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (_mGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void AddPoint(int point)
    {
        _mPoints += point;
        scoreText.text = $"Name : {GameManager.GetInstance().GetName()}/nScore : {_mPoints}";
    }

    public void GameOver()
    {
        _mGameOver = true;
        gameOverText.SetActive(true);
    }
}
