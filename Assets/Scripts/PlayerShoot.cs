using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private BulletPool _pool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _pool.GetObject(transform);
        }
    }

    public void Reset()
    {
        _pool.Reset();
    }
}
