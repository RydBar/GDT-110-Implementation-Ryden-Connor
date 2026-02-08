using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 0.5f;

    private Vector2 moveDirection;
    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal"); //A/D/<-/->
        float vertical = Input.GetAxis("Vertical"); //W/S/ /\ / \/

        moveDirection = new Vector2(horizontal, vertical);

        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;

        transform.position += movement;
    }
}
