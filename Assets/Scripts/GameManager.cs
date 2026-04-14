using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onLoseGame;
    [SerializeField]
    private UnityEvent onWinGame;
    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField]
    private UnityEvent<int> onUpdateBestScore;
     [SerializeField]
    private SpaceShipManager spaceshipManager;
    [SerializeField] 
    private AsteroidManager asteroidManager;
    private  bool gameLost = false;
    private bool allShipsDestroyed = false;
    private bool allAsteroidDestroyed = false;
    public void LoseGame()
    {
        onUpdateBestScore?.Invoke(scoreManager.Score);
        gameLost = true;
        onLoseGame?.Invoke();
        spaceshipManager.StopShips();
        asteroidManager.StopAsteroid();
    }
    private void Start()
    {
        spaceshipManager.StartShips();
        asteroidManager.StartAsteroids();
        scoreManager.InitializeScore();
    }
    public void AllShipsDestroyed()
    {
        allShipsDestroyed = true;
        CheckWindCondition();
    }
    public void AllAsteroidDestroyed()
    {
        allAsteroidDestroyed = true;
        CheckWidCondition();
    }
    private void CheckWindCondition()
    {
        if (!gameLost && allShipsDestroyed && allAsteroidDestroyed)
        {
            onUpdateBastScore?.Invoke(scoreManager.Score);
            onWinGame?.Invoke();
        }
    }
}
