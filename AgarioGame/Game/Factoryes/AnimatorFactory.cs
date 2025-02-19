using AgarioGame.Engine;
using AgarioGame.Engine.Animation;
using SFML.Graphics;

namespace AgarioGame.Game.Factoryes
{
    public static class AnimatorFactory
    {
        public static Animator InitializePlayerAnimator(Sprite animatedSprite)
        {
            AnimationClip aboba1 = new("Idle", animatedSprite);

            aboba1.SetFrames(new List<Texture> { Resources.GetTexture("circle.png") });

            Animator animator = new Animator(animatedSprite, new State(aboba1, StateType.LoopedAnim, "Idle"));

            AnimationClip aboba = new("Move", animatedSprite);
            aboba.SetFrames(new List<Texture> { Resources.GetTexture("Fon.jpg")});
            
            AnimationClip bebra = new("Eat", animatedSprite);
            bebra.SetFrames(new List<Texture> { Resources.GetTexture("circle.png") });

            animator.CreateState("Move", aboba, StateType.LoopedAnim);
            animator.CreateState("Eat", bebra, StateType.LoopedAnim);

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
