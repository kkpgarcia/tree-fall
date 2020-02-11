public class GameBootstrap : StateMachine {
    public TrunkController TrunkController;
    public void Start() {
        this.ChangeState<GameInitializeState>();
    }    
}
