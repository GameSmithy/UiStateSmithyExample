namespace GameSmithyState {
    public interface IState {
        public bool IsPathAllowed(string path);
        public void Enter();
        public void Exit();
    }
}