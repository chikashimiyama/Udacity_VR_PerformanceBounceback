using UnityEngine;

public class TrampolineMovement : MonoBehaviour {

	private Vector3 direction_ = new Vector3(1,0,0);
	private readonly float moveSpeed_ = 3.5f;
	private readonly float moveTime_ = 3f;
    private float time_;

	private void Update () {
        time_ += Time.deltaTime;
        if(time_ > moveTime_)
        {
            time_ = 0;
            direction_ = direction_ * -1;
        }
        transform.position += direction_ * Time.deltaTime * moveSpeed_;		
	}
}
