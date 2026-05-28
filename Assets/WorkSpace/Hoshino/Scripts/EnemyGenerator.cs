using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Generate")]
    [SerializeField] float IntervalMin;
    [SerializeField] float IntervalMax;

    [SerializeField] GameObject[] Enemies;
    [SerializeField] Transform CameraTransform;

    private float m_elapsedTime;
    private float m_interval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 範囲0の対策
        if (IntervalMax < IntervalMin) IntervalMax = IntervalMin;

        m_elapsedTime = 0;

        m_interval = Random.Range(IntervalMin, IntervalMax);
    }

    // Update is called once per frame
    void Update()
    {
        m_elapsedTime += Time.deltaTime;

        if (m_elapsedTime >= m_interval)
        {
            m_elapsedTime = 0;

            // ランダムな敵を生成
            int index = Random.Range(0, Enemies.Length - 1);

            var enemy = Instantiate(Enemies[index]);

            enemy.transform.position = new Vector3( CameraTransform.position.x + 13.0f, Random.Range(-5.5f, 5.5f), 0 );

            // 次のインターバルを設定
            m_interval = Random.Range(IntervalMin, IntervalMax);
        }
    }
}
