using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour
{
    public float moveSpeed = 2f;        // ความเร็วในการเคลื่อนที่
    public float jumpInterval = 2f;     // ระยะเวลาระหว่างการกระโดด
    public float jumpDuration = 0.5f;   // ระยะเวลาที่ใช้ในการกระโดด

    private float timer;                // ตัวจับเวลา
    private bool isJumping;             // สถานะว่ากำลังกระโดดหรือไม่

    private NavMeshAgent agent;         // ตัวควบคุม NavMesh
    public GameObject player;

    public float stopDistance = 1.5f; // ระยะห่างที่หยุดเมื่อเข้าใกล้ผู้เล่น
    public float detectionRange = 10f; // ระยะตรวจจับผู้เล่น

    private Animator animator;          // ตัวควบคุมแอนิเมชัน
    bool isPlayerInRange = false; // ตัวแปรตรวจสอบว่าผู้เล่นอยู่ในระยะตรวจจับหรือไม่
    bool hasReachePlayer = false; // ตัวแปรตรวจสอบว่าถึงผู้เล่นหรือยัง

    void Start()
    {
        // ดึง Animator จาก GameObject
        animator = GetComponent<Animator>();

        // ดึง NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // ตั้งค่าความเร็วเริ่มต้น
        agent.speed = moveSpeed;

        // ปิดการอัปเดตการหมุนอัตโนมัติ (ถ้าอยากให้หมุนด้วย Animator)
        agent.updateRotation = true;
    }

    void Update()
    {

        float distance = Vector3.Distance(transform.position, player.transform.position);
        isPlayerInRange = distance <= detectionRange;


        timer += Time.deltaTime;
        if (isPlayerInRange)
        {
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        if (isJumping)
        {
            // หากกำลังกระโดด → ให้ agent เคลื่อนไปหา player
            if (player != null)
            {
                agent.SetDestination(player.transform.position);
            }

            // เมื่อหมดเวลาการกระโดด → หยุด
            if (timer >= jumpDuration)
            {
                isJumping = false;
                timer = 0f;

                if (animator != null)
                {
                    animator.SetBool("isJumping", false);
                }

                // หยุด agent ชั่วคราว
                agent.isStopped = true;
            }
        }
        else
        {
            // ถ้าถึงเวลาเริ่มกระโดดใหม่
            if (timer >= jumpInterval)
            {
                isJumping = true;
                timer = 0f;

                if (animator != null)
                {
                    animator.SetBool("isJumping", true);
                }

                // เปิด agent เพื่อเคลื่อนที่
                agent.isStopped = false;
            }
        }
    }
}
