public class GameState : State {
    protected GameBootstrap Owner;

    protected TrunkController TrunkController {
        get {
            return Owner.TrunkController;
        }
    }

    private void Awake() {
        this.Owner = this.GetComponent<GameBootstrap>();
    }
}
