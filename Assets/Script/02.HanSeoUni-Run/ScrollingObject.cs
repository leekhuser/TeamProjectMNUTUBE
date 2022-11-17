using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������Ʈ�� ��� �������� �����̴� ��ũ��Ʈ
public class ScrollingObject : MonoBehaviour
{
    public static ScrollingObject instance;
    public float speed = 10f; // �̵� �ӵ�

    void Update()
    {
        // ���� ������Ʈ�� ���� �ӵ��� �������� �����̵��ϴ� ó��
        // �ʴ� speed�� �ӵ��� �������� �����̵�

        // ���ӿ����� �ƴ϶��
        if (!GameManager.instance.isGameover)
        {
            transform.Translate
            (Vector3.left * speed * Time.deltaTime);
        }
    }
}
