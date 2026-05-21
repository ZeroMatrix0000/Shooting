using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // 弾の速さ
    [SerializeField] private float speed;

    // 画面外
    [SerializeField] private float outside;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += speed * Time.deltaTime * Vector3.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
