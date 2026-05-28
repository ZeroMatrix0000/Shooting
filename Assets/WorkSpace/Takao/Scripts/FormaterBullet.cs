using UnityEngine;

public class FormaterBullet : MonoBehaviour
{

    /* インスペクター */

    // 速さ
    [SerializeField] private float Speed;


    /* メンバ変数 */

    // 方向
    private Vector3 m_direction;


    /* メンバ関数 */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime * m_direction);
    }

    // 方向を設定
    public void SetDirection(Vector3 direction)
    {
        m_direction = direction.normalized;
    }

}
