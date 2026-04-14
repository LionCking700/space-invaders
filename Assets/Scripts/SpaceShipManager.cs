using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SpaceShipManager : MonoBehaviour
{
   [SerializeField]
   private Health playerHealth;
   [SerializeField]
   private int  numberOfSpaceShips = 5;
   [SerializeField]
   private InstantiatePoolObjects spaceshipPool;
   [SerializeField]
   private InstantiatePoolObjects bulletPool;
   [SerializeField]
   private UnityEvent onInstantiateShip;
    [SerializeField]
   private float timeToSpawn = 15f;
   [SerializeField]
   private UnityEvent<Transform> onShipDestroyed;
   [SerializeField]
   private UnityEvent onAllShipsDestroyed;
   private int destroyedSpaceShips = 0;
   public void OnDestroyShip(Transform transform)
    {
        destroyedSpaceShips++;
        onShipDestroyed.Invoke(transform);
        if (destroyedSpaceShips >= numberOfSpaceShips)
        {
            onAllShipsDestroyed?.Invoke();
        }
    }
    public void SatrtShips()
    {
        StartCoroutine(SpawnSpaceships());
    }
    public void StopShips()
    {
        StopAllCoroutines();
        spaceShipsPool.DeasctivateAllObjects();
    }
    private IEnumerator SpawnSpaceships()
    {
        numberOfSpaceShips--;
        yield return new WaitForSeconds(timeToSpawn);
        onInstantiateShip?.Invoke();
        spaceshipPool.InstantiateObject(transform);
        EnemySpaceship spaceship =spaceshipPool.GetCurrentObject().GetComponent<EnemySpaceship>();
        spaceship.TargetHealth = playerHealth;
        spaceship.BulletPool = bulletPool;
        spaceship.OnDestroyed.AddListener(OnDestroyShip);
        if (numberOfSpaceShips > 0)
        {
            StartCoroutine(SpawnSpaceships());
        }
    }
}
