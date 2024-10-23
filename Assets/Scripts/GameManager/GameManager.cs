using Ebac.Core.Singleton;
using Ebac.StateMachine;
public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        INTRO,
        GAMEPLAY,
        PAUSE,
        WIN,
        LOSE
    }
    public StateMachine<GameStates> stateMachine;
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        stateMachine = new StateMachine<GameStates>();
        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.INTRO, new GMStateIntro());
        stateMachine.RegisterStates(GameStates.GAMEPLAY, new GMStateGameplay());
        stateMachine.RegisterStates(GameStates.PAUSE, new GMStatePause());
        stateMachine.RegisterStates(GameStates.WIN, new GMStateWin());
        stateMachine.RegisterStates(GameStates.LOSE, new GMStateLose());
        stateMachine.SwitchState(GameStates.INTRO);
    }
}