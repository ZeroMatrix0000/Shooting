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


    /* コンポーネント */

    private Rigidbody2D m_rigidbody2D;


    /* メンバ関数 */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
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

}
