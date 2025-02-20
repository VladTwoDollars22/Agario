using AgarioGame.Engine.Core.Time;
using AgarioGame.Engine.Utilities;
using SFML.Graphics;

namespace AgarioGame.Engine.Animation
{
    public class AnimationClip
    {
        public string AnimationName;

        private float _updateTrigger;
        private int _currentFrame;
        private List<Texture> _frames;
        private Sprite _animableSprite;
        private static int _animID = 0;

        public AnimationClip(string animName,List<Texture> textures)
        {
            _animID++;

            AnimationName = animName+_animID;

            _frames = textures;

            _updateTrigger = 1f / _frames.Count;

            _currentFrame = 0;
        }
        public void SetAnimatedSprite(Sprite sprite)
        {
            _animableSprite = sprite;

            _animableSprite.Texture = _frames[_currentFrame];
        }
        public void PlayLooped()
        {
            TimerManager.Instance.SetInterval(AnimationName,NextFrame,_updateTrigger);
        }
        public void PlayOnce()
        {
            TimerManager.Instance.SetRepeatedInterval(AnimationName, NextFrame, _updateTrigger, _frames.Count);
        }
        public void Stop()
        {
            TimerManager.Instance.StopInterval(AnimationName);
        }
        public void Reset()
        {
            _currentFrame = 0;
        }
        private void NextFrame()
        {
            if (_frames == null)
                return;

            _currentFrame++;

            if (_currentFrame >= _frames.Count)
                _currentFrame = 0;

            _animableSprite.Texture = _frames[_currentFrame];
        }
    }
}
