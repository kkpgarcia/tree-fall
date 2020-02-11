
public class TreeFallState : GameState {
    public override void Enter() {
        this.TrunkController.RemoveNextTrunk(OnFinishInteraction);
    }

    private void OnFinishInteraction(bool isFinished) {
        if (isFinished) {
            this.Owner.ChangeState<InteractionState>();
        }
        else {
            this.Owner.ChangeState<GameInitializeState>();
        }
    }
}
