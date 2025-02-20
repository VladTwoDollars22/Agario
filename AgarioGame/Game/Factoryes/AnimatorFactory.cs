using AgarioGame.Engine;
using AgarioGame.Engine.Animation;
using SFML.Graphics;

namespace AgarioGame.Game.Factoryes
{
    public static class AnimatorFactory
    {
        public static Animator InitializePlayerAnimator(Sprite animatedSprite)
        {
            AnimationClip idle = new("Idle", animatedSprite);

            idle.SetFrames(new List<Texture> { 
                Resources.GetTexture("PlayerAnim\\Idle\\idle2.png"),Resources.GetTexture("PlayerAnim\\Idle\\idle3.png"),
            Resources.GetTexture("PlayerAnim\\Idle\\idle4.png"),Resources.GetTexture("PlayerAnim\\Idle\\idle5.png")});
            idle.SetTrigger(0.35f);

            Animator animator = new Animator(animatedSprite, new State(idle, StateType.LoopedAnim, "Idle"));

            AnimationClip move = new("Move", animatedSprite);
            move.SetFrames(new List<Texture> {
                Resources.GetTexture("PlayerAnim\\Move\\move1.png"),Resources.GetTexture("PlayerAnim\\Move\\move2.png"),
            Resources.GetTexture("PlayerAnim\\Move\\move3.png")});
            move.SetTrigger(0.35f);


            AnimationClip eat = new("Eat", animatedSprite);
            eat.SetFrames(new List<Texture> {
                Resources.GetTexture("PlayerAnim\\Eat\\eat1.png"),Resources.GetTexture("PlayerAnim\\Eat\\eat2.png"),
            Resources.GetTexture("PlayerAnim\\Eat\\eat3.png"),Resources.GetTexture("PlayerAnim\\Eat\\eat4.png"),Resources.GetTexture("PlayerAnim\\Eat\\eat5.png")});
            eat.SetTrigger(0.2f);

            animator.CreateState("Move", move, StateType.LoopedAnim);
            animator.CreateState("Eat", eat, StateType.LoopedAnim);

            animator.AddTransition("Idle", "Move");
            animator.AddTransition("Move", "Idle");
            animator.AddTransition("Move", "Eat");
            animator.AddTransition("Eat", "Idle");
            animator.AddTransition("Idle", "Eat");

            Subscriber.SubscribeOnUpdate(animator);

            return animator;
        }
    }
}
