
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int playerHealth = 3; // 初始生命值
    public int playerScore = 0; // 对手的分数

    public Text PlayerScoreText;


    void Update()
    {
        PlayerScoreText.text = playerScore.ToString();
    }

    // 其他玩家控制代码...
}

