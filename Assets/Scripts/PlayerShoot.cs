using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private BulletPool _pool;

    public void Reset()
    {
        _pool.Reset();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _pool.GetBullet(transform);
        }
    }    
}
