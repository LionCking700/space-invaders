using UnityEngine;

public class SpaceShipManager : MonoBehaviour
{
   [SerializeField]
   private Health palyerHealth;
   [SerializeField]
   private int  numberOfSpaceShips = 5;
   [SerializeField]
   private Instantiate PoolObjcts spaceShipPool;
   [SerializeField]
   private InstantiatePoolObjcts spaceshipPool;
   [SerializeField]
   private Instantiate PoolObjects bulletpool;
   [SerializeField]
   private float timeToSpawn = 15f;
   [SerializeField]
   private UnityEvent<TransformZ> onShipDestroyed;
   public void OnDestroyShip(Transform transform)
    {
        onShipDestroyed.Invoke(transform);
    }
    private void Satrt()
    {
        StartCoroutine(SpawnSpaceShips());
    }
    private IEnumerator SpawnSpaceShips()
    {
        numberOfSpaceShips--;
        yield return new WaitForSeconds(timeToSpawn);
        spaceshipPool.InstantiateObject(transform);
        EnemySpaceShip = spaceshipPool.GetCurrentObject().GetComponent<EnemySpaceShip>();
        spaceshipPool.TargetHealth = palyerHealth;
        spaceshipPool.OnDestroyed.AddListener(OnDestroyShip);
        if (numberOfSpaceShips > 0)
        {
            StartCoroutine(SpawnSpaceShips());
        }
    }
}
