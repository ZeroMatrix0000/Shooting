using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] const float DESTOROY_BORDER = -10.0f; // ‰æ–ÊŠO‚Éo‚½’e‚ğÁ‚·‹«ŠE

    public float m_speed;     // ’e‚Ì‘¬“x
    public Vector2 m_direction; // ’e‚Ì•ûŒü
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Initialize(float speed, Vector2 direction)
    {
        m_speed = speed;
        m_direction = direction;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = this.transform.position;
        pos += m_direction.normalized * m_speed * Time.deltaTime;
        this.transform.position = pos;

        // ‰æ–ÊŠO‚Éo‚½‚çÁ‚·
        if (pos.x < DESTOROY_BORDER)
        {
            Destroy(this.gameObject);
        }
    }
}