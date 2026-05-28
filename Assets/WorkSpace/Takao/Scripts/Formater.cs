using UnityEngine;

public class Formater : MonoBehaviour
{

    /* インスペクター */

    [Header("Formater")]
    // 速さ
    [SerializeField] private float Speed;

    [Header("Bullet")]
    // 弾を発射するまでの時間
    [SerializeField] private float ShotTime;
    // 発射口の位置
    [SerializeField] private Transform BulletPoint;
    // 弾のプレファブ
    [SerializeField] private GameObject BulletPrefab;


    /* メンバ変数 */

    // プレイヤー
    private Transform m_player;

    // 弾を発射するまでの時間
    private float m_shotTimer;


    /* メンバ関数 */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);

        m_player = GameObject.Find("Player").transform;

        m_shotTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_shotTimer += Time.deltaTime;
        // 弾を発射する時間になったら発射
        if (m_shotTimer > ShotTime)
        {
            // 発射方向
            Vector3 direction = (m_player.transform.position - BulletPoint.position).normalized;

            GameObject obj = Instantiate(BulletPrefab, BulletPoint.position, Quaternion.identity);
            obj.GetComponent<FormaterBullet>().SetDirection(direction);

            m_shotTimer = Mathf.NegativeInfinity;
        }

        // 左に移動
        transform.Translate(Speed * Time.deltaTime * Vector3.left, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer") || collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
