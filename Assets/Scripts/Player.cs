using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BulletPool _pool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _pool.GetObject(transform);
        }
    }    
}
