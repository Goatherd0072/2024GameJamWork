public interface IObserver
{
    void OnNotifyGameDate(GameData data);
    void OnNotifyCurrentTime(float time);
}