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
                itemLists.Add(new ItemData(0, "기생", "주막에서 술먹고 취한 양반을 노리러 주막에 들리는 진상이다. 간혹가다가 결혼한 양반을 건들여 부인과 싸움을 하다가 주모에게 쫓겨난다."));
                break;
            case 1:
                itemLists.Add(new ItemData(1, "서민", "주막에 가장 많이 방문하는 손님들이다. 특별한 점은 없기에 주모와 사이가 좋은 손님들이 대다수이다."));
                break;
            case 2:
                itemLists.Add(new ItemData(2, "서민", "주막에 가장 많이 방문하는 손님들이다. 특별한 점은 없기에 주모와 사이가 좋은 손님들이 대다수이다."));
                break;
            case 3:
                itemLists.Add(new ItemData(3, "왕", "인자한 성품을 가지고있는 조선의 왕. 하지만 타고난 술꾼이라 이 주막의 술을 먹으러 분장도 하지않고 방문하는일이 자주 있다."));
                break;
            case 4:
                itemLists.Add(new ItemData(4, "왜놈", "주막에 틈만 나면 공짜로 음식을 내놓으라는 진상. 올때마다 음식을 요구하지만 주모의 참교육으로 공짜로 받아간적은 없다고한다(?)"));
                break;
            case 5:
                itemLists.Add(new ItemData(5, "양반(남)", "주막에 자주오는 부유한 양반. 매번 기생한테 유혹당해 쫓겨나는게 일상이다. 결혼한 양반은 부인한테 술병으로 맞는 경우도 있다고한다."));
                break;
            case 6:
                itemLists.Add(new ItemData(6, "양반(여)", "주막에 자주오는 부유한 양반의 부인. 매번 기생한테 유혹당하는게 일상인 남편을 패는 장면을 가장 많이 목격할 수 있다."));
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
                itemLists.Add(new ItemData(100, "막걸리", "주막의 수제 막걸리이다. 일반 막걸리와 다르게 단맛이 강해 술을 못하는 손님들에게 큰 인기를 끌고있다"));
                break;
            case 101:
                itemLists.Add(new ItemData(101, "모둠전", "주막에서 가장 많이 나가는 안주이다. 기름지기에 소주와 가장 합이 좋은 안주이다. 그리고 비오는날에는 막걸리와 먹고싶은 그런 느낌이 드는 안주이다."));
                break;
            case 102:
                itemLists.Add(new ItemData(102, "빈대떡", "막걸리와 같이 먹기 좋은 안주이다."));
                break;
            case 103:
                itemLists.Add(new ItemData(103, "소주", "가장 많이 나가는 주류이다. 술을 즐기는 사람들이 찾는 주류 도수가 높기에 술을 못하는 사람이 먹으면 큰일난다."));
                break;
            case 104:
                itemLists.Add(new ItemData(104, "수육", "고기의 부드러움으로 인기있는 음식이다."));
                break;
            case 105:
                itemLists.Add(new ItemData(105, "육포", "소고기를 말려서 만든 안주이다. 모든 주류와 어울리는 만능 안주"));
                break;
            case 106:
                itemLists.Add(new ItemData(106, "해장국", "안주보다는 술을 먹고 다음날에 많이 찾는 음식이다. 국물의 시원함과 따듯함이 숙취를 해소해준다."));
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
