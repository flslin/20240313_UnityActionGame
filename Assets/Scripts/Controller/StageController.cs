using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// �������� ���� ��Ʈ�ѷ�
// �������� ���۰� ������ ó���ϴ� ���
// �������� ������ ȹ���ϴ� ����Ʈ�� ����
public class StageController : MonoBehaviour
{
    public int stagePoint = 10; // ������������ ȹ���� ����Ʈ ����

    public Text PointText; // ����Ʈ ǥ�ÿ�

    public static StageController instance; // �������� ��Ʈ�ѷ��� �ν��Ͻ��� �����ϴ� static����
    // �ٸ��ڵ� ������ StageController.instance.AddPoint(10)�� ���� ���·� ��� ����


    public void Awake()
    {
        instance = this;
    }

    public void AddPoint(int point)
    {
        stagePoint += point;
        PointText.text = stagePoint.ToString();
    }

    public void FinishGame()
    {
        //Application.LoadLevel(Application.loadedLevel); // ���� �ڵ�(����� ������)
        SceneManager.LoadScene("Game");
    }
}
