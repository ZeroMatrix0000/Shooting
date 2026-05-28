using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int m_score;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Result;

    float m_elapsedTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Player>().IsDead())
        {
            Result.GetComponent<ResultScreen>().Display(m_score);
        }
        else
        {
            m_elapsedTime += Time.deltaTime;

            if (m_elapsedTime >= 0.1f)
            {
                AddScore(10);
            }
        }
    }

    public void AddScore(int value = 1)
    {
        m_score += value;

        m_score = Mathf.Clamp(m_score, 0, 999999);
    }
}
