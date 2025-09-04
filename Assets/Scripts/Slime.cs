using UnityEngine;

public class Slime : MonoBehaviour
{
    public float moveSpeed = 2f; // ความเร็วในการเคลื่อนที่
    public float jumpInterval = 2f; // ระยะเวลาระหว่างการกระโดด
    public float jumpDuration = 0.5f; // ระยะเวลาที่ใช้ในการกระโดด
    private Vector3 moveDirection; // ทิศทางการเคลื่อนที่
    private float timer; // ตัวจับเวลา
    private bool isJumping; // สถานะว่ากำลังกระโดดหรือไม่

    private Animator animator; // ตัวควบคุมแอนิเมชัน

    void Start()
    {
        // กำหนดทิศทางเริ่มต้นแบบสุ่ม
        ChangeDirection();

        // ดึง Animator จาก GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // อัปเดตตัวจับเวลา
        timer += Time.deltaTime;

        if (isJumping)
        {
            // ระหว่างกระโดด ให้เคลื่อนที่
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

            // หากกระโดดครบระยะเวลาแล้ว ให้หยุด
            if (timer >= jumpDuration)
            {
                isJumping = false;
                timer = 0f;

                // เล่นแอนิเมชันหยุดกระโดด
                if (animator != null)
                {
                    animator.SetBool("isJumping", false);
                }
            }
        }
        else
        {
            // หากถึงเวลาที่จะกระโดดใหม่
            if (timer >= jumpInterval)
            {
                isJumping = true;
                timer = 0f;

                // เปลี่ยนทิศทางใหม่
                ChangeDirection();

                // เล่นแอนิเมชันกระโดด
                if (animator != null)
                {
                    animator.SetBool("isJumping", true);
                }
            }
        }
    }

    void ChangeDirection()
    {
        // สุ่มทิศทางใหม่
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        moveDirection = new Vector3(randomX, 0, randomZ).normalized; // ทำให้เวกเตอร์เป็นหน่วย

        // หมุนตัวละครให้หันหน้าไปในทิศทางใหม่
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = targetRotation;
        }
    }
}
