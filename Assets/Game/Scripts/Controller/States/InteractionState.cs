
public class InteractionState : GameState {
    /**
    * The only state that receives input. AddObserver and RemoveObserver
    * could be inside game state if there are a need of different actions
    * when using the button
    */
    protected override void AddListeners() {
        this.AddObserver(OnInteract, "Interact");
    }

    protected override void RemoveListeners() {
        this.RemoveObserver(OnInteract, "Interact");
    }

    private void OnInteract(object sender, object args) {
        this.Owner.ChangeState<TreeFallState>();
    }
}
