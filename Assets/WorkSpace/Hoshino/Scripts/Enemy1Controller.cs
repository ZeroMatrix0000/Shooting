using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    [Header("MoveSetting")]
    [SerializeField] Vector2 m_moveCenter;    // 移動の中心
    [SerializeField] float m_moveWidth;       // 移動の幅
    [SerializeField] float m_moveCycle;       // 移動の周期
    private float m_moveTimer;       // 移動のタイマー

    [Header("BulletSetting")]
    [SerializeField] GameObject m_bulletPrefab;   // 弾のプレハブ
    [SerializeField] float m_bulletSpeed;         // 弾の速度
    [SerializeField] Vector2 m_bulletDirection;   // 弾の方向

    [Header("ShootSetting")]
    [SerializeField] float m_shootCycle;         // 射撃の周期
    private float m_shootTimer;        // 射撃のタイマー

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_moveTimer += Time.deltaTime;
        m_shootTimer += Time.deltaTime;

        // 移動の計算
        Vector2 pos = this.transform.position;
        pos.y = m_moveCenter.y + Mathf.Sin(m_moveTimer / m_moveCycle * 2 * Mathf.PI) * m_moveWidth;
        this.transform.position = pos;

        // 弾の発射
        if (m_shootTimer >= m_shootCycle)
        {
            m_shootTimer = 0f;

            GameObject bullet = Instantiate(m_bulletPrefab, this.transform.position, Quaternion.identity);
            EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();
            bulletScript.Initialize(m_bulletSpeed, m_bulletDirection);
        }
    }
}
