using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerController�� �÷��̾� ĳ���ͷμ� Player ���� ������Ʈ�� ������
public class PlayerController : MonoBehaviour
{
  
    public float jumpForce = 700f; // ���� ��

    private int jumpCount = 0; // ���� ���� Ƚ��
    private bool isGrounded = false; // �ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false; // ��� ����

    // ����� ������ٵ� ������Ʈ
    private Rigidbody2D playerRigidbody;
    // ����� �ִϸ����� ������Ʈ
    private Animator animator;
    // ����� ����� �ҽ� ������Ʈ


    public int playerLife = 3;
    public GameObject lifes1;
    public GameObject lifes2;
    public GameObject lifes3;

    SpriteRenderer spriteRenderer;


    void Start()
    {
        // �ʱ�ȭ
        // ���� ������Ʈ�κ��� ����� ������Ʈ����
        // ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        switch (playerLife)
        {
            case 2:
                lifes3.SetActive(false);
                break;
            case 1:
                lifes2.SetActive(false);
                break;
            case 0:
                lifes1.SetActive(false);
                break;
        }

        // ����� �Է��� �����ϰ� �����ϴ� ó��
        if (isDead)
        {
            // ��� �� ó���� �� �̻� �������� �ʰ� ����
            return;
        }

        // ���콺 ���� ��ư�� �������� &&
        // �ִ� ���� Ƚ��(2)�� �������� �ʾҴٸ�
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            // ���� Ƚ�� ����
            jumpCount++;
            // ���� ������ �ӵ��� ���������� ����(0,0)�� ����
            playerRigidbody.velocity = Vector2.zero;
            // ������ٵ� �������� �� �ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            // ����� �ҽ� ���

        }
        else if (Input.GetMouseButtonUp(0) &&
            playerRigidbody.velocity.y > 0)
        {
            // ���콺 ���� ��ư���� ���� ���� ���� &&
            // �ӵ��� y ���� ������(���� ��� ��)
            // ��T �ӵ��� �������� ����
            playerRigidbody.velocity =
                playerRigidbody.velocity * 0.5f;
        }

        // �ִϸ������� Grounded �Ķ���͸� isGrounded ������ ����
        animator.SetBool("Grounded", isGrounded);



    }

    private void Die()
    {
        // ��� ó��
        // �ִϸ������� Die Ʈ���� �Ķ���͸� ��
        animator.SetTrigger("Die");
    

        // �ӵ��� ����(0,0)�� ����
        playerRigidbody.velocity = Vector2.zero;
        // ��� ���¸� true�� ����
        isDead = true;

        // ���� �Ŵ����� ���ӿ��� ó�� ����
        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����

        // �浹�� ������ �±װ� Dead�̸�
        // ���� ������� �ʾҴٸ� Die()����

        switch (collision.tag)
        {
            case "Hit":
                playerLife -= 1;
                OnDamaged();
                if (playerLife == 0)
                {
                    Die();
                }
                break;
            case "Coin":
                GameManager.instance.AddScore(100);
                collision.gameObject.SetActive(false);
                break;
            case "Dead":
                Die();
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ٴڿ� ������� �����ϴ� ó��
        // � �ݶ��̴��� �������,
        // �浹 ǥ���� ������ ���� ������
        if (collision.contacts[0].normal.y > 0.7f)
        {
            // isGrounded�� true�� �����ϰ�,
            // ���� ���� Ƚ���� 0���� ����
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // �ٴڿ��� ������� �����ϴ� ó��
        // � �ݶ��̴����� ������ ��� isGrounded�� false�� ����
        isGrounded = false;
    }

    void OnDamaged()
    {
        gameObject.layer = 11;
        spriteRenderer.color = new Color(255, 255, 255, 0.4f);
        Invoke("OffDamaged", 3);

    }

    void OffDamaged()
    {
        gameObject.layer = 10;
        spriteRenderer.color = new Color(255, 255, 255, 255);
    }
}
