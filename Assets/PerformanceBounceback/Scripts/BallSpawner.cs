using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject pooledBall; //the prefab of the object in the object pool
    
    private const int BallsAmount = 1000; 
    private GameObject[] pooledBalls_;
    private static int _poolIndex = -1; 

    
    private float cooldown_;
    private const float CooldownLength = 0.5f;



    private void Start()
    {
        pooledBalls_ = new GameObject[BallsAmount];
        for (var i = 0; i < pooledBalls_.Length; ++i)
        {
            pooledBall = Instantiate(pooledBall);
            pooledBall.SetActive(false);
            pooledBall.transform.parent = transform;
            pooledBall.name = "ball" + i.ToString();
            pooledBalls_[i] = pooledBall;
        }
        System.GC.Collect(); // to clean garbage possibly created by string
    }

    private GameObject GetPooledBall()
    {
        _poolIndex++;
        if (_poolIndex > (BallsAmount - 1))
        {
            _poolIndex = 0;
        }
        return pooledBalls_[_poolIndex];
    }

    private void Update()
    {
        cooldown_ -= Time.deltaTime;
        if (!(cooldown_ <= 0)) return;
        cooldown_ = CooldownLength;
        SpawnBall();
    }

    private void SpawnBall()
    {
        var selectedBall = GetPooledBall();
        selectedBall.transform.localPosition = Vector3.zero;
        var selectedRigidbody = selectedBall.GetComponent<Rigidbody>();
        selectedRigidbody.velocity = Vector3.zero;
        selectedRigidbody.angularVelocity = Vector3.zero;
        selectedBall.SetActive(true);
    }
}