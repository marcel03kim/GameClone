using UnityEngine;
using System.Collections.Generic;

public class ItemList : MonoBehaviour
{
    public Sprite[] itemSprites; // 유니티 에디터에서 연결할 스프라이트 배열
    private List<ItemData> itemLists;

    private void Awake()
    {
        itemLists = new List<ItemData>
        {
            new ItemData(0, "기생", "주막에서 술 먹고 취한 양반을 노리러 주막에 들리는 진상이다. 간혹가다가 결혼한 양반을 건들여 부인과 싸움을 하다가 주모에게 쫓겨난다.", itemSprites.Length > 0 ? itemSprites[0] : null),
            new ItemData(1, "서민", "주막에 가장 많이 방문하는 손님들이다. 특별한 점은 없기에 주모와 사이가 좋은 손님들이 대다수이다.", itemSprites.Length > 1 ? itemSprites[1] : null),
            new ItemData(2, "서민", "주막에 가장 많이 방문하는 손님들이다. 특별한 점은 없기에 주모와 사이가 좋은 손님들이 대다수이다.", itemSprites.Length > 2 ? itemSprites[2] : null),
            new ItemData(3, "왕", "인자한 성품을 가지고 있는 조선의 왕. 하지만 타고난 술꾼이라 이 주막의 술을 먹으러 분장도 하지않고 방문하는 일이 자주 있다.", itemSprites.Length > 3 ? itemSprites[3] : null),
            new ItemData(4, "왜놈", "틈만 나면 주막에 와서 공짜로 음식을 내놓으라는 진상. 올 때마다 음식을 요구하지만 주모의 참교육으로 공짜로 받아간 적은 없다고 한다(?)", itemSprites.Length > 4 ? itemSprites[4] : null),
            new ItemData(5, "양반", "주막에 자주오는 부유한 양반. 매번 기생한테 유혹 당해 쫓겨나는 게 일상이다. 결혼한 양반은 부인한테 술병으로 맞는 경우도 있다고한다.", itemSprites.Length > 5 ? itemSprites[5] : null),
            new ItemData(6, "양반아씨", "주막에 자주오는 부유한 양반의 부인. 매번 기생한테 유혹 당하는 남편을 패는 장면을 가장 많이 목격할 수 있다.", itemSprites.Length > 6 ? itemSprites[6] : null),
            new ItemData(7, "주모", "주모는 최고야! 주모는 강해! 주모는... 널 찢어", itemSprites.Length > 7 ? itemSprites[7] : null),
            new ItemData(100, "막걸리", "주막의 수제 막걸리. 일반 막걸리와 달리 단맛이 강해 술을 못하는 손님들에게 큰 인기를 끌고있다", itemSprites.Length > 8 ? itemSprites[8] : null),
            new ItemData(101, "모둠전", "주막에서 가장 많이 나가는 안주이다. 기름지기에 소주와 가장 합이 좋은 안주이다. 비 오는 날이면 문득 막걸리와 함께 생각난다.", itemSprites.Length > 9 ? itemSprites[9] : null),
            new ItemData(102, "빈대떡", "막걸리와 같이 먹기 좋은 안주이다.", itemSprites.Length > 10 ? itemSprites[10] : null),
            new ItemData(103, "소주", "가장 많이 나가는 술이다. 술을 즐기는 사람들이 찾는만큼 도수가 높기에 술을 못하는 사람이 먹으면 큰일난다.", itemSprites.Length > 11 ? itemSprites[11] : null),
            new ItemData(104, "수육", "고기의 부드러움으로 인기 있는 음식이다.", itemSprites.Length > 12 ? itemSprites[12] : null),
            new ItemData(105, "육포", "소고기를 말려 만든 안주이다. 모든 주류와 어울리는 만능 안주.", itemSprites.Length > 13 ? itemSprites[13] : null),
            new ItemData(106, "해장국", "안주보다는 술을 먹은 다음날 많이 찾는 음식이다. 국물의 시원함과 따듯함이 숙취를 해소해준다.", itemSprites.Length > 14 ? itemSprites[14] : null),
            new ItemData(107, "복분자", "복분자의 달달함으로 술을 못하는 사람도 쉽게 먹을 수 있다. 하지만 만만하게 생각하고 마시면 큰일난다.", itemSprites.Length > 15 ? itemSprites[15] : null),
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
