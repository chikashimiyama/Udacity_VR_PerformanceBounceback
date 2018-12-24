using UnityEngine;

public class Trampoline : MonoBehaviour {

    private ParticleSystem pSystem_;
    private GameManager scoreScript_;

    private void Start()
    {
        scoreScript_ = GameObject.Find("GameManager").GetComponent<GameManager>();
        pSystem_ = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Throwable")) return;
        
        scoreScript_.score++;
        pSystem_.Play();

    }
}
