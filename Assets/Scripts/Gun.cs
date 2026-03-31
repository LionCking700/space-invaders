using UnityEngine;

public class Gun : MonoBehaviour
{
    private Camera cameraUsed;
    public Camera camera
    {
        set{cameraUsed = value;}
    }
[SerializeField]
private Transform bulletPivot;
[SerializeField]
private InstantiatePoolObjects bulletPool;
private float rayDistance = 1000;
public void shoot()
    {
        Ray ray = camera.ViewportPointToRay(new Vector(0.5f, 0.5f, 0f));
        RaycastHit hit;
        Vector3 targetPoint;
        if (physics.Raycast(ray, out hit, rayDistance))
        {
            targetPoint = hit.points;
        }
        else
        {
            targetPoint = ray.origin + ray.direction * rayDistance;
        }
        Vector3 direction = (targetPoint = transform.position).normalized;
        bulletPivot.forward = direction;
        bulletPool.InstantiateObject(bulletPivot.position);
        Transform bullet = bulletPool.GetCurrentObject().transform;
        bullet.transform.LookAt(targetPoint);
    }
}
