using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score_;
    public int score
    {
        set
        {
            score_ = value;
            if(ScoreUpdated != null)
                ScoreUpdated.Invoke(score_);
        }
        get { return score_; }
    }

    public event Action<int> ScoreUpdated;
}
