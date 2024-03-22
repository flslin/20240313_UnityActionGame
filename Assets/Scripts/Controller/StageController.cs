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
    #region  Field
    public int stagePoint = 10; // ������������ ȹ���� ����Ʈ ����

    public Text PointText; // ����Ʈ ǥ�ÿ�
    #endregion

    #region Singleton
    public static StageController instance; // �������� ��Ʈ�ѷ��� �ν��Ͻ��� �����ϴ� static����
                                            // �ٸ��ڵ� ������ StageController.instance.AddPoint(10)�� ���� ���·� ��� ����

    // 2024.03.15 Awake -> Start�� ����
    public void Start()
    {
        instance = this;
        // �ȳ�â �� ����
        DialogDataAlert alert = new DialogDataAlert("���� ����", "�������� ��� óġ�ϼ���!", delegate () { Debug.Log("OK�� �������ϴ�!"); });
        // �Ŵ����� ���
        DialogManager.Instance.Push(alert);
    }
    #endregion

    public void AddPoint(int point)
    {
        stagePoint += point;
        PointText.text = stagePoint.ToString();
    }

    public void FinishGame()
    {
        //Application.LoadLevel(Application.loadedLevel); // ���� �ڵ�(����� ������)
        DialogDataConfirm confirm = new DialogDataConfirm("�����", "����� �Ͻðڽ��σ���������?",
        delegate (bool yn)
        {
            if (yn)
                SceneManager.LoadScene("Game");
            else
                Application.Quit();

        });

        DialogManager.Instance.Push(confirm);
    }
}

