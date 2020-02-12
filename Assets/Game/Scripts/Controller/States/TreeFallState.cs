
public class TreeFallState : GameState {
    public override void Enter() {
        this.TrunkController.RemoveNextTrunk(OnFinishInteraction);
    }

    /**
    * Assess the need of new level.
    */
    private void OnFinishInteraction(bool isFinished) {
        if (isFinished) {
            this.Owner.ChangeState<InteractionState>();
        }
        else {
            this.Owner.ChangeState<GameInitializeState>();
        }
    }
}
