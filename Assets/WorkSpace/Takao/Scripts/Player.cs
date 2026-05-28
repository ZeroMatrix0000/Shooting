using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    /* インスペクター */

    // 移動の速さ
    [SerializeField] private float Speed;

    // 発射口の位置
    [SerializeField] private Transform BulletPoint;

    // 弾のプレファブ
    [SerializeField] private GameObject BulletPrefab;

    // 初期HP
    [SerializeField] private int InitialHP;

    bool m_isDead;


    /* コンポーネント */

    private Rigidbody2D m_rigidbody2D;

    /* その他メンバ変数 */

    private int m_hp;

    /* メンバ関数 */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();

        // HPを初期化
        m_hp = InitialHP;

        m_isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 弾を打つ
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(BulletPrefab, BulletPoint.position, Quaternion.identity);
        }

        // 移動方向
        Vector3 direction = Vector3.zero;
        if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
        {
            direction += Vector3.up;
        }
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            direction += Vector3.left;
        }
        if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed)
        {
            direction += Vector3.down;
        }
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            direction += Vector3.right;
        }

        if (direction.magnitude < 1e-6f)
        {
            direction = Vector3.zero;
        }
        else
        {
            direction.Normalize();
        }
        // 移動
        m_rigidbody2D.linearVelocity = Speed * direction;
    }

    // 衝突時
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 敵の弾に当たったら
        if (collision.gameObject.tag == "EnemyBullet")
        {
            // HPを減らす
            m_hp--;

            // 弾を消す
            Destroy(collision.gameObject);

            // ダメージ演出

            // 0以下になったら
            if (m_hp <= 0)
            {
                // ゲームオーバー処理
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<Collider2D>().enabled = false;
                this.GetComponent<ParticleSystem>().Play();

                m_isDead = true;
            }
        }
    }

    public bool IsDead() { return m_isDead; }
}
