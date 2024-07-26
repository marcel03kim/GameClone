using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    private List<ItemData> itemLists;

    private void Awake()
    {
        itemLists = new List<ItemData>
        {
            new ItemData(0, "기생", "주막에서 술먹고 취한 양반을 노리러 주막에 들리는 진상이다. 간혹가다가 결혼한 양반을 건들여 부인과 싸움을 하다가 주모에게 쫓겨난다."),
            new ItemData(1, "서민", "주막에 가장 많이 방문하는 손님들이다. 특별한 점은 없기에 주모와 사이가 좋은 손님들이 대다수이다."),
            new ItemData(2, "서민", "주막에 가장 많이 방문하는 손님들이다. 특별한 점은 없기에 주모와 사이가 좋은 손님들이 대다수이다."),
            new ItemData(3, "왕", "인자한 성품을 가지고있는 조선의 왕. 하지만 타고난 술꾼이라 이 주막의 술을 먹으러 분장도 하지않고 방문하는일이 자주 있다."),
            new ItemData(4, "왜놈", "주막에 틈만 나면 공짜로 음식을 내놓으라는 진상. 올때마다 음식을 요구하지만 주모의 참교육으로 공짜로 받아간적은 없다고한다(?)"),
            new ItemData(5, "양반(남)", "주막에 자주오는 부유한 양반. 매번 기생한테 유혹당해 쫓겨나는게 일상이다. 결혼한 양반은 부인한테 술병으로 맞는 경우도 있다고한다."),
            new ItemData(6, "양반(여)", "주막에 자주오는 부유한 양반의 부인. 매번 기생한테 유혹당하는게 일상인 남편을 패는 장면을 가장 많이 목격할 수 있다."),
            // 추가적인 아이템 데이터들...
            new ItemData(19, "", ""),
            new ItemData(100, "막걸리", "주막의 수제 막걸리이다. 일반 막걸리와 다르게 단맛이 강해 술을 못하는 손님들에게 큰 인기를 끌고있다"),
            new ItemData(101, "모둠전", "주막에서 가장 많이 나가는 안주이다. 기름지기에 소주와 가장 합이 좋은 안주이다. 그리고 비오는날에는 막걸리와 먹고싶은 그런 느낌이 드는 안주이다."),
            new ItemData(102, "빈대떡", "막걸리와 같이 먹기 좋은 안주이다."),
            new ItemData(103, "소주", "가장 많이 나가는 주류이다. 술을 즐기는 사람들이 찾는 주류 도수가 높기에 술을 못하는 사람이 먹으면 큰일난다."),
            new ItemData(104, "수육", "고기의 부드러움으로 인기있는 음식이다."),
            new ItemData(105, "육포", "소고기를 말려서 만든 안주이다. 모든 주류와 어울리는 만능 안주"),
            new ItemData(106, "해장국", "안주보다는 술을 먹고 다음날에 많이 찾는 음식이다. 국물의 시원함과 따듯함이 숙취를 해소해준다."),
            new ItemData(107, "", ""),
            new ItemData(108, "", ""),
            new ItemData(109, "", ""),
            new ItemData(110, "", "")
        };
    }

    public ItemData GetItemData(int index)
    {
        return itemLists.Find(item => item.Id == index) ?? new ItemData(-1, "Unknown", "Item not found");
    }
}
