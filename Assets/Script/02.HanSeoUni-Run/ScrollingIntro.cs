using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������Ʈ�� ��� �������� �����̴� ��ũ��Ʈ
public class ScrollingIntro : MonoBehaviour
{
    public static ScrollingIntro instance;
    public float speed = 10f; // �̵� �ӵ�

    void Update()
    {
        // ���� ������Ʈ�� ���� �ӵ��� �������� �����̵��ϴ� ó��
        // �ʴ� speed�� �ӵ��� �������� �����̵�

           transform.Translate
           (Vector3.left * speed * Time.deltaTime);
        
    }
}
