using UnityEngine;

public class FormaterManager : MonoBehaviour
{

    /* インスペクター */

    [Header("Formater")]
    // フォーメーターのプレファブ
    [SerializeField] private GameObject FormaterPrefab;
    // 出現する間隔
    [SerializeField] private float SpawnInterval;
    // 出現する遅延
    [SerializeField] private float SpawnDelay;
    // 一度に出現させる量
    [SerializeField] private float SpawnAmount;


    /* メンバ変数 */

    // 出現する間隔
    float m_spawnIntervalTimer;
    // 出現する遅延
    float m_spawnDelayTimer;
    // 出現させた数
    int m_spawnAmount;
    // 出現位置
    float m_spawnPosition;


    /* メンバ関数 */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_spawnIntervalTimer = 0f;
        m_spawnDelayTimer = 0f;
        m_spawnAmount = 0;
        m_spawnPosition = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnIntervalTimer += Time.deltaTime;
        m_spawnDelayTimer += Time.deltaTime;

        // 出現を始める
        if (m_spawnIntervalTimer > SpawnInterval)
        {
            m_spawnIntervalTimer -= SpawnInterval;
            m_spawnDelayTimer = 0f;
            m_spawnAmount = 1;

            m_spawnPosition = Random.Range(-4f, 4f);

            Instantiate(FormaterPrefab, new Vector3(10f, m_spawnPosition, 0f), Quaternion.identity);
        }

        // 等間隔に出現
        if (m_spawnDelayTimer > SpawnDelay && m_spawnAmount % SpawnAmount != 0)
        {
            m_spawnDelayTimer -= SpawnDelay;
            m_spawnAmount++;

            Instantiate(FormaterPrefab, new Vector3(10f, m_spawnPosition, 0f), Quaternion.identity);
        }
    }

}
