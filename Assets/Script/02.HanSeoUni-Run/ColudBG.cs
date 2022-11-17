using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������ �̵��� ����� ������ ������ ���ġ�ϴ� ��ũ��Ʈ
public class ColudBG : MonoBehaviour
{
    private float width; // ����� ���� ����

    private void Awake()
    {
        // ���� ���̸� �����ϴ� ó��
        // BoxCollider2 ������Ʈ�� Size �ʵ���
        // X���� ���� ���̷� ���
        BoxCollider2D backgroundCollider = 
            GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    void Update()
    {
        // ���� ��ġ�� �������� ��������
        // width �̻� �̵����� �� ��ġ�� ���ġ
        if(transform.position.x <= -width)
        {
            Reposition();
        }
    }

    // ��ġ�� ���ġ�ϴ� �޼���
    private void Reposition()
    {
        // ���� ��ġ���� ���������� ���� ���� * 2 ��ŭ �̵�
        Vector2 offset = new Vector2(width * 0.7f, 0);
        transform.position = 
            (Vector2)transform.position + offset;
    }
}
