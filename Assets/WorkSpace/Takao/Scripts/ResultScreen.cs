using TMPro;
using UnityEngine;

public class ResultScreen : MonoBehaviour
{

    /* インスペクター */

    [SerializeField] private TextMeshProUGUI m_text;


    /* メンバ関数 */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 表示
    public void Display(int score)
    {
        gameObject.SetActive(true);
        m_text.text = $"スコア: {score:000000}";
    }

}
