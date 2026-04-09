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
   private float timeToSpawn = 15f;
   [SerializeField]
   private UnityEvent<Transform> onShipDestroyed;
   public void OnDestroyShip(Transform transform)
    {
        onShipDestroyed.Invoke(transform);
    }
    private void Satrt()
    {
        StartCoroutine(SpawnSpaceships());
    }
    private IEnumerator SpawnSpaceships()
    {
        numberOfSpaceShips--;
        yield return new WaitForSeconds(timeToSpawn);
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
