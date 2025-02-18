using AgarioGame.Engine;
using AgarioGame.Engine.Animation;
using SFML.Graphics;

namespace AgarioGame.Game.Factoryes
{
    public static class AnimatorFactory
    {
        public static Animator InitializePlayerAnimator(Sprite animatedSprite)
        {
            Animator animator = new Animator(animatedSprite, new State(new AnimationClip("Idle", animatedSprite), StateType.LoopedAnim, "Idle"));

            animator.CreateState("Move", new AnimationClip("Move", animatedSprite), StateType.LoopedAnim);
            animator.CreateState("Eat", new AnimationClip("Eat", animatedSprite), StateType.LoopedAnim);

            animator.AddTransition("Idle", "Move");
            animator.AddTransition("Move", "Idle");
            animator.AddTransition("Move", "Eat");
            animator.AddTransition("Eat", "Idle");

            Subscriber.SubscribeOnUpdate(animator);

            return animator;
        }
    }
}
