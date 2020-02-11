
public class InteractionState : GameState {
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
