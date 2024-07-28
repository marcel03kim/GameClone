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
            new EventText(0, "왕 : 여기 주막 자리 전체를 쓰고 싶은데 당장 자리를 만들어주겠는가"),
            new EventText(1, "주모 : 손님들이 계신 관계로 불가하옵니다"),
            new EventText(2, "왕 : 그러면 손님들을 내쫓으면 되는 것 아닌가? 내 보상은 섭섭하지 않게 드리겠다 약조하겠네"),
            new EventText(3, "제비 : (날아와서 바닥에 떨어진다)"),
            new EventText(4, "주모 : 어머 이게 뭐야, 제비잖아?"),
            new EventText(5, "제비 : (끼잉... 끼이이잉...)"),
            new EventText(6, "주모 : 어디가 아픈가보네..."),
            new EventText(7, "까마귀 : 까악 까아아아악!!!! 까악!!!!!"),
            new EventText(8, "주모 : 이게 무슨 소리야? 까마귀?"),
            new EventText(9, "까마귀 : (막무가내로 주막을 더럽힌다)"),
            new EventText(10, "주모 : 이놈들이? 당장 안 나가!?"),
            new EventText(11, "왜놈 : 당장 막걸리와 음식을 내오거라"),
            new EventText(12, "주모 : 막걸리와 음식, 도합 300냥입니다"),
            new EventText(13, "왜놈 : 위대한 대일본제국의 신민인 내게 돈을 받겠다고? 얼른 음식이나 내오거라"),
            new EventText(14, "주모 : 돈이 없으시면 드릴 수 없습니다"),
            new EventText(15, "왜놈 : 지금 반항하는 거냐? (칼을 뽑으며)"),
            new EventText(16, "주모 : 칼을 뽑아? (엄청난 근육을 보이며)"),
            new EventText(17, "왜놈 : ?????????????"),
            new EventText(18, "주모 : 어디 한 번 썰어봐 (왜놈에게 다가간다)"),
            new EventText(19, "왜놈 : 이, 이익!!! (왜놈에게서 돈을 강탈했다!)"),
            new EventText(20, "기생 : 제가 한 잔 따라드리지요"),
            new EventText(21, "양반 : 응? 아아~ 좋지~ (이미 잔뜩 취한 것 같다)"),
            new EventText(22, "기생 : 술과 음식도 좋지만... 저는 어떠신가요? (옷을 벗으며)"),
            new EventText(23, "양반 : 아잇! 당연히 그게 더 좋지! 어째 둘이 은밀하게 어디로..."),
            new EventText(24, "주모 : 이 새끼들이 여기서 뭐하는 거야"),
            new EventText(25, "주모 : 당장 안 나가!? (주걱을 들고 오며)"),
            new EventText(26, "기생, 양반 : 죄, 죄송합니다!!")
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
