using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public void ItemData(int index)
    {
        List<ItemData> itemLists = new List<ItemData>();
        switch (index)
        {
            case 0:
                itemLists.Add(new ItemData(0, "���", "�ָ����� ���԰� ���� ����� �븮�� �ָ��� �鸮�� �����̴�. ��Ȥ���ٰ� ��ȥ�� ����� �ǵ鿩 ���ΰ� �ο��� �ϴٰ� �ָ𿡰� �Ѱܳ���."));
                break;
            case 1:
                itemLists.Add(new ItemData(1, "����", "�ָ��� ���� ���� �湮�ϴ� �մԵ��̴�. Ư���� ���� ���⿡ �ָ�� ���̰� ���� �մԵ��� ��ټ��̴�."));
                break;
            case 2:
                itemLists.Add(new ItemData(2, "����", "�ָ��� ���� ���� �湮�ϴ� �մԵ��̴�. Ư���� ���� ���⿡ �ָ�� ���̰� ���� �մԵ��� ��ټ��̴�."));
                break;
            case 3:
                itemLists.Add(new ItemData(3, "��", "������ ��ǰ�� �������ִ� ������ ��. ������ Ÿ�� �����̶� �� �ָ��� ���� ������ ���嵵 �����ʰ� �湮�ϴ����� ���� �ִ�."));
                break;
            case 4:
                itemLists.Add(new ItemData(4, "�ֳ�", "�ָ��� ƴ�� ���� ��¥�� ������ ��������� ����. �ö����� ������ �䱸������ �ָ��� ���������� ��¥�� �޾ư����� ���ٰ��Ѵ�(?)"));
                break;
            case 5:
                itemLists.Add(new ItemData(5, "���(��)", "�ָ��� ���ֿ��� ������ ���. �Ź� ������� ��Ȥ���� �Ѱܳ��°� �ϻ��̴�. ��ȥ�� ����� �������� �������� �´� ��쵵 �ִٰ��Ѵ�."));
                break;
            case 6:
                itemLists.Add(new ItemData(6, "���(��)", "�ָ��� ���ֿ��� ������ ����� ����. �Ź� ������� ��Ȥ���ϴ°� �ϻ��� ������ �д� ����� ���� ���� ����� �� �ִ�."));
                break;
            case 7:
                itemLists.Add(new ItemData(7, "", ""));
                break;
            case 8:
                itemLists.Add(new ItemData(8, "", ""));
                break;
            case 9:
                itemLists.Add(new ItemData(9, "", ""));
                break;
            case 10:
                itemLists.Add(new ItemData(10, "", ""));
                break;
            case 11:
                itemLists.Add(new ItemData(11, "", ""));
                break;
            case 12:
                itemLists.Add(new ItemData(12, "", ""));
                break;
            case 13:
                itemLists.Add(new ItemData(13, "", ""));
                break;
            case 14:
                itemLists.Add(new ItemData(14, "", ""));
                break;
            case 15:
                itemLists.Add(new ItemData(15, "", ""));
                break;
            case 16:
                itemLists.Add(new ItemData(16, "", ""));
                break;
            case 17:
                itemLists.Add(new ItemData(17, "", ""));
                break;
            case 18:
                itemLists.Add(new ItemData(18, "", ""));
                break;
            case 19:
                itemLists.Add(new ItemData(19, "", ""));
                break;
            case 100:
                itemLists.Add(new ItemData(100, "���ɸ�", "�ָ��� ���� ���ɸ��̴�. �Ϲ� ���ɸ��� �ٸ��� �ܸ��� ���� ���� ���ϴ� �մԵ鿡�� ū �α⸦ �����ִ�"));
                break;
            case 101:
                itemLists.Add(new ItemData(101, "�����", "�ָ����� ���� ���� ������ �����̴�. �⸧���⿡ ���ֿ� ���� ���� ���� �����̴�. �׸��� ����³����� ���ɸ��� �԰���� �׷� ������ ��� �����̴�."));
                break;
            case 102:
                itemLists.Add(new ItemData(102, "��붱", "���ɸ��� ���� �Ա� ���� �����̴�."));
                break;
            case 103:
                itemLists.Add(new ItemData(103, "����", "���� ���� ������ �ַ��̴�. ���� ���� ������� ã�� �ַ� ������ ���⿡ ���� ���ϴ� ����� ������ ū�ϳ���."));
                break;
            case 104:
                itemLists.Add(new ItemData(104, "����", "����� �ε巯������ �α��ִ� �����̴�."));
                break;
            case 105:
                itemLists.Add(new ItemData(105, "����", "�Ұ�⸦ ������ ���� �����̴�. ��� �ַ��� ��︮�� ���� ����"));
                break;
            case 106:
                itemLists.Add(new ItemData(106, "���屹", "���ֺ��ٴ� ���� �԰� �������� ���� ã�� �����̴�. ������ �ÿ��԰� �������� ���븦 �ؼ����ش�."));
                break;
            case 107:
                itemLists.Add(new ItemData(107, "", ""));
                break;
            case 108:
                itemLists.Add(new ItemData(108, "", ""));
                break;
            case 109:
                itemLists.Add(new ItemData(109, "", ""));
                break;
            case 110:
                itemLists.Add(new ItemData(110, "", ""));
                break;
            default:
                Debug.Log("Invalid index");
                break;
        }
    }
}

public class ItemData
{
    public int id { get; set; }
    public string name { get; set; }
    public string desc { get; set; }

    public ItemData(int ID, string Name, string Desc)
    {
        id = ID;
        name = Name;
        desc = Desc;
    }
}
