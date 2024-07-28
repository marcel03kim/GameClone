using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventData : MonoBehaviour
{
    private List<EventText> TextList;

    private void Awake()
    {
        TextList = new List<EventText>
        {
            new EventText(0, "�� : ���� �ָ� �ڸ� ��ü�� ���� ������ ���� �ڸ��� ������ְڴ°�"),
            new EventText(1, "�ָ� : �մԵ��� ��� ����� �Ұ��Ͽɴϴ�"),
            new EventText(2, "�� : �׷��� �մԵ��� �������� �Ǵ� �� �ƴѰ�? �� ������ �������� �ʰ� �帮�ڴ� �����ϰڳ�"),
            new EventText(3, "���� : (���ƿͼ� �ٴڿ� ��������)"),
            new EventText(4, "�ָ� : ��� �̰� ����, �����ݾ�?"),
            new EventText(5, "���� : (����... ��������...)"),
            new EventText(6, "�ָ� : ��� ���°�����..."),
            new EventText(7, "��� : ��� ��ƾƾƾ�!!!! ���!!!!!"),
            new EventText(8, "�ָ� : �̰� ���� �Ҹ���? ���?"),
            new EventText(9, "��� : (���������� �ָ��� ��������)"),
            new EventText(10, "�ָ� : �̳����? ���� �� ����!?"),
            new EventText(11, "�ֳ� : ���� ���ɸ��� ������ �����Ŷ�"),
            new EventText(12, "�ָ� : ���ɸ��� ����, ���� 300���Դϴ�"),
            new EventText(13, "�ֳ� : ������ ���Ϻ������� �Ź��� ���� ���� �ްڴٰ�? �� �����̳� �����Ŷ�"),
            new EventText(14, "�ָ� : ���� �����ø� �帱 �� �����ϴ�"),
            new EventText(15, "�ֳ� : ���� �����ϴ� �ų�? (Į�� ������)"),
            new EventText(16, "�ָ� : Į�� �̾�? (��û�� ������ ���̸�)"),
            new EventText(17, "�ֳ� : ?????????????"),
            new EventText(18, "�ָ� : ��� �� �� ���� (�ֳ𿡰� �ٰ�����)"),
            new EventText(19, "�ֳ� : ��, ����!!! (�ֳ𿡰Լ� ���� ��Ż�ߴ�!)"),
            new EventText(20, "��� : ���� �� �� ����帮����"),
            new EventText(21, "��� : ��? �ƾ�~ ����~ (�̹� �ܶ� ���� �� ����)"),
            new EventText(22, "��� : ���� ���ĵ� ������... ���� ��Ű���? (���� ������)"),
            new EventText(23, "��� : ����! �翬�� �װ� �� ����! ��° ���� �����ϰ� ����..."),
            new EventText(24, "�ָ� : �� �������� ���⼭ ���ϴ� �ž�"),
            new EventText(25, "�ָ� : ���� �� ����!? (�ְ��� ��� ����)"),
            new EventText(26, "���, ��� : ��, �˼��մϴ�!!")
        };
    }

    public EventText GetTextData(int index)
    {
        return TextList.Find(item => item.Index == index) ?? new EventText(-1, "Unknown");
    }
}

[System.Serializable]
public class EventText
{
    public int Index;
    public string Text;

    public EventText(int index, string eventText)
    {
        Index = index;
        Text = eventText;
    }
}
