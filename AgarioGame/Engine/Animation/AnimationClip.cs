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

        public AnimationClip(string animName,Sprite sprite)
        {
            _animableSprite = sprite;
            AnimationName = animName;

            _currentFrame = 0;
            _animableSprite.Texture = _frames[_currentFrame];
            _updateTrigger = 1 / _frames.Count;
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
        public List<Texture> LoadFrames(List<string> texturePaths)
        {
            List<Texture> framesList = new List<Texture>();

            foreach (var path in texturePaths)
            {    
               framesList.Add(new Texture(PathUtilite.CalculatePath(path)));    
            }

            return framesList;
        }
        private void NextFrame()
        {
            _currentFrame++;

            if (_currentFrame > _frames.Count)
            {
                _currentFrame = 0;
            }

            _animableSprite.Texture = _frames[_currentFrame];
        }
    }
}
