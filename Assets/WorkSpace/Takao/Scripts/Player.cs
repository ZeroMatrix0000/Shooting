using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    /* インスペクター */

    [SerializeField] private float speed;


    /* メンバ変数 */


    /* メンバ関数 */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
        {
            direction += Vector2.up;
        }
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            direction += Vector2.left;
        }
        if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed)
        {
            direction += Vector2.down;
        }
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            direction += Vector2.right;
        }

        if (direction.magnitude < 1e-6f)
        {
            direction = Vector2.zero;
        }
        else
        {
            direction.Normalize();
        }

        transform.localPosition += (Vector3)direction * speed * Time.deltaTime;
    }

}
