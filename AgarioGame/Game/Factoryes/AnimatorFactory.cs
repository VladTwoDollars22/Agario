using AgarioGame.Engine;
using AgarioGame.Engine.Animation;
using AgarioGame.Game.Configs;
using SFML.Graphics;

namespace AgarioGame.Game.Factoryes
{
    public static class AnimatorFactory
    {
        public static Animator InitializePlayerAnimator(Sprite animatedSprite)
        {
            Animator animator = new Animator(animatedSprite, new State(new("Idle",AnimationClipsConfig.Idle), StateType.LoopedAnim, "Idle"));

            animator.CreateState("Move", new("Move", AnimationClipsConfig.Move), StateType.LoopedAnim);
            animator.CreateState("Eat", new("Eat", AnimationClipsConfig.Eat), StateType.LoopedAnim);

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
