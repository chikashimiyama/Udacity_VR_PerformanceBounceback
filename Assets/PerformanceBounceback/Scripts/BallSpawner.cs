using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public static BallSpawner current;

    public GameObject pooledBall; //the prefab of the object in the object pool
    public int ballsAmount = 20; //the number of objects you want in the object pool
    public List<GameObject> pooledBalls; //the object pool
    private static int ballPoolNum_; //a number used to cycle through the pooled objects

    private float cooldown_;
    private const float CooldownLength = 0.5f;

    private void Awake()
    {
        current = this; //makes it so the functions in ObjectPool can be accessed easily anywhere
    }

    private void Start()
    {
        pooledBalls = new List<GameObject>();
        for (var i = 0; i < ballsAmount; i++)
        {
            var obj = Instantiate(pooledBall);
            obj.SetActive(false);
            pooledBalls.Add(obj);
        }
    }

    private GameObject GetPooledBall()
    {
        ballPoolNum_++;
        if (ballPoolNum_ > (ballsAmount - 1))
        {
            ballPoolNum_ = 0;
        }

        //if we’ve run out of objects in the pool too quickly, create a new one
        if (pooledBalls[ballPoolNum_].activeInHierarchy)
        {
            //create a new bullet and add it to the bulletList
            var obj = Instantiate(pooledBall);
            pooledBalls.Add(obj);
            ballsAmount++;
            ballPoolNum_ = ballsAmount - 1;
        }

        return pooledBalls[ballPoolNum_];
    }

    private void Update()
    {
        cooldown_ -= Time.deltaTime;
        if (cooldown_ <= 0)
        {
            cooldown_ = CooldownLength;
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        var selectedBall = current.GetPooledBall();
        selectedBall.transform.position = transform.position;
        var selectedRigidbody = selectedBall.GetComponent<Rigidbody>();
        selectedRigidbody.velocity = Vector3.zero;
        selectedRigidbody.angularVelocity = Vector3.zero;
        selectedBall.SetActive(true);
    }
}