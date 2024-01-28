public struct GameData
{
    public int score;//����
    public int lastScore;//��������
    public int Days;//����
    public float Money;//��Ǯ
    public float BannedValue;//����ֵ
    public float MaxBannedValue;//����ֵ����
    public float oneDayTime;
    public float currentTime;
    public int normalCommnet;
    public int attrckComment;

    public void init()
    {
        score = 0;
        Days = 0;
        lastScore = 0;
        Money = 100;
        BannedValue = 0;
        MaxBannedValue = 100;
        oneDayTime = 60f;
        currentTime = 0f;
        normalCommnet = 0;
        attrckComment = 0;
    }


    public void Reset()
    {
        currentTime = 0f;
        normalCommnet = 0;
        attrckComment = 0;
        lastScore = score;
    }

    public (float addScore, float addMoney, int days, float dex) Calculate()
    {
        BannedValue -= 20.0f;
        if (BannedValue < 0)
        {
            BannedValue = 0;
        }
        currentTime = 0f;

        float addScore = (score - lastScore);

        float addMoney = addScore % 10;
        if (addMoney < 0)
        {
            addMoney = 0;
        }
        lastScore = score;

        Money += addMoney;
        float dex = 100;

        Money -= dex;

        Days++;
        (float addScore, float addMoney, int days, float dex) temp = (addScore, addMoney, Days, dex);
        return temp;
    }
}