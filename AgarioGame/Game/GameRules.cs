﻿using AgarioGame.Game;
using AgarioGame.Game.Factoryes;

namespace AgarioGame.Engine
{
    public class GameRules
    {
        private GameLoop _gameLoop;

        private List<Enemy> enemyList;
        private List<Food> foodList;

        private Player _player;

        private int _foodCount;
        private int enemyCount;

        private UnitFactory _factory;
        public GameRules(GameLoop loop)
        {
            _gameLoop = loop;

            _foodCount = GameConfig.FoodCount;
            enemyCount = GameConfig.EmenyCount;

            enemyList = new();
            foodList = new();

            _factory = new(_gameLoop);
        }
        public void Initialisation()
        {
            InitializeFood();
            InitializePlayer();
            InitializeEnemyes();
        }
        private void InitializeFood()
        {
            for (int i = 0; i <= _foodCount; i++)
            {
                foodList.Add(_factory.InstantiateFood());
            }
        }
        private void InitializePlayer()
        {
            _player = _factory.InstantiatePlayer();
        }
        private void InitializeEnemyes()
        {
            for (int i = 0; i <= enemyCount; i++)
            {
                enemyList.Add(_factory.InstantiateEnemy());
            }
        }
        public void Logic()
        {
            CheckOccurences();
        }
        public void CheckOccurences()
        {
            foreach (Food f in foodList)
            {
                if (f.ObjectIn(_player))
                {
                    f.EatMe();
                    _player.Upgrade(f.Reward);
                }
            }

            foreach (Food f in foodList)
            {
                foreach (Enemy e in enemyList)
                {
                    if (f.ObjectIn(e))
                    {
                        f.EatMe();
                        e.Upgrade(f.Reward);
                    }
                }     
            }

            foreach(Enemy e in enemyList)
            {
                if (_player.ObjectIn(e))
                {
                    _player.EatMe();
                    e.Upgrade(_player.Mass);
                }
                else if (e.ObjectIn(_player))
                {
                    e.EatMe();
                    _player.Upgrade(e.Mass);
                }
            }
        }
    }
}
