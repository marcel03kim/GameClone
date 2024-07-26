using UnityEngine;
using System.Collections.Generic;

public class ItemList : MonoBehaviour
{
    public Sprite[] itemSprites; // ����Ƽ �����Ϳ��� ������ ��������Ʈ �迭
    private List<ItemData> itemLists;

    private void Awake()
    {
        itemLists = new List<ItemData>
        {
            new ItemData(0, "���", "�ָ����� �� �԰� ���� ����� �븮�� �ָ��� �鸮�� �����̴�. ��Ȥ���ٰ� ��ȥ�� ����� �ǵ鿩 ���ΰ� �ο��� �ϴٰ� �ָ𿡰� �Ѱܳ���.", itemSprites.Length > 0 ? itemSprites[0] : null),
            new ItemData(1, "����", "�ָ��� ���� ���� �湮�ϴ� �մԵ��̴�. Ư���� ���� ���⿡ �ָ�� ���̰� ���� �մԵ��� ��ټ��̴�.", itemSprites.Length > 1 ? itemSprites[1] : null),
            new ItemData(2, "����", "�ָ��� ���� ���� �湮�ϴ� �մԵ��̴�. Ư���� ���� ���⿡ �ָ�� ���̰� ���� �մԵ��� ��ټ��̴�.", itemSprites.Length > 2 ? itemSprites[2] : null),
            new ItemData(3, "��", "������ ��ǰ�� ������ �ִ� ������ ��. ������ Ÿ�� �����̶� �� �ָ��� ���� ������ ���嵵 �����ʰ� �湮�ϴ� ���� ���� �ִ�.", itemSprites.Length > 3 ? itemSprites[3] : null),
            new ItemData(4, "�ֳ�", "ƴ�� ���� �ָ��� �ͼ� ��¥�� ������ ��������� ����. �� ������ ������ �䱸������ �ָ��� ���������� ��¥�� �޾ư� ���� ���ٰ� �Ѵ�(?)", itemSprites.Length > 4 ? itemSprites[4] : null),
            new ItemData(5, "���", "�ָ��� ���ֿ��� ������ ���. �Ź� ������� ��Ȥ ���� �Ѱܳ��� �� �ϻ��̴�. ��ȥ�� ����� �������� �������� �´� ��쵵 �ִٰ��Ѵ�.", itemSprites.Length > 5 ? itemSprites[5] : null),
            new ItemData(6, "��ݾƾ�", "�ָ��� ���ֿ��� ������ ����� ����. �Ź� ������� ��Ȥ ���ϴ� ������ �д� ����� ���� ���� ����� �� �ִ�.", itemSprites.Length > 6 ? itemSprites[6] : null),
            new ItemData(7, "�ָ�", "�ָ�� �ְ��! �ָ�� ����! �ָ��... �� ����", itemSprites.Length > 7 ? itemSprites[7] : null),
            new ItemData(100, "���ɸ�", "�ָ��� ���� ���ɸ�. �Ϲ� ���ɸ��� �޸� �ܸ��� ���� ���� ���ϴ� �մԵ鿡�� ū �α⸦ �����ִ�", itemSprites.Length > 8 ? itemSprites[8] : null),
            new ItemData(101, "�����", "�ָ����� ���� ���� ������ �����̴�. �⸧���⿡ ���ֿ� ���� ���� ���� �����̴�. �� ���� ���̸� ���� ���ɸ��� �Բ� ��������.", itemSprites.Length > 9 ? itemSprites[9] : null),
            new ItemData(102, "��붱", "���ɸ��� ���� �Ա� ���� �����̴�.", itemSprites.Length > 10 ? itemSprites[10] : null),
            new ItemData(103, "����", "���� ���� ������ ���̴�. ���� ���� ������� ã�¸�ŭ ������ ���⿡ ���� ���ϴ� ����� ������ ū�ϳ���.", itemSprites.Length > 11 ? itemSprites[11] : null),
            new ItemData(104, "����", "����� �ε巯������ �α� �ִ� �����̴�.", itemSprites.Length > 12 ? itemSprites[12] : null),
            new ItemData(105, "����", "�Ұ�⸦ ���� ���� �����̴�. ��� �ַ��� ��︮�� ���� ����.", itemSprites.Length > 13 ? itemSprites[13] : null),
            new ItemData(106, "���屹", "���ֺ��ٴ� ���� ���� ������ ���� ã�� �����̴�. ������ �ÿ��԰� �������� ���븦 �ؼ����ش�.", itemSprites.Length > 14 ? itemSprites[14] : null),
            new ItemData(107, "������", "�������� �޴������� ���� ���ϴ� ����� ���� ���� �� �ִ�. ������ �����ϰ� �����ϰ� ���ø� ū�ϳ���.", itemSprites.Length > 15 ? itemSprites[15] : null),
            new ItemData(108, "", "", itemSprites.Length > 16 ? itemSprites[16] : null),
            new ItemData(109, "???", "", itemSprites.Length > 17 ? itemSprites[17] : null),
            new ItemData(110, "", "", itemSprites.Length > 18 ? itemSprites[18] : null)
        };
    }

    public ItemData GetItemData(int index)
    {
        return itemLists.Find(item => item.Id == index) ?? new ItemData(-1, "Unknown", "Item not found", null);
    }
}
