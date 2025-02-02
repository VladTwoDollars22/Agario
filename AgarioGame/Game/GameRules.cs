﻿using AgarioGame.Game;
using AgarioGame.Game.Controllers;
using AgarioGame.Game.Factoryes;
using SFML.Window;
using AgarioGame.Engine.Core.Input.KeyBind;
using AgarioGame.Engine.Factories;

namespace AgarioGame.Engine
{
    public class GameRules
    {
        private GameLoop _gameLoop;

        private List<AIController> enemyList;
        private List<Food> foodList;

        private PlayerController _player;

        private int _foodCount;
        private int enemyCount;

        private UnitFactory _factory;
        private GameObjectFactory _gameObjFactory;
        public GameRules(GameLoop loop)
        {
            _gameLoop = loop;

            _foodCount = GameConfig.FoodCount;
            enemyCount = GameConfig.EnemyCount;

            enemyList = new();
            foodList = new();

            _gameObjFactory = new(_gameLoop);
            _factory = new(_gameLoop,_gameObjFactory);
        }
        public void Initialisation()
        {
            InitializeConfig();
            InitializeFood();
            InitializeEnemyes();
            InitializePlayer();
        }
        private void InitializeConfig()
        {
            GameConfig.Initialize();
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
            _player = _factory.InstantiatePlayer(this);
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
        public void Swap()
        {
            int randInt = Mathematics.GetRandomNumber(0,enemyCount - 1);

            PlayableObject playerPawn = _player.Pawn;

            _player.SetPawn(enemyList[randInt].Pawn);

            enemyList[randInt].SetPawn(playerPawn);
        }
        public void CheckOccurences()
        {
            foreach (Food f in foodList)
            {
                if (f.ObjectIn(_player.Pawn))
                {
                    f.EatMe();
                    _player.Pawn.Upgrade(f.Reward);
                }
            }

            foreach (Food f in foodList)
            {
                foreach (AIController e in enemyList)
                {
                    if (f.ObjectIn(e.Pawn))
                    {
                        f.EatMe();
                        e.Pawn.Upgrade(f.Reward);
                    }
                }     
            }

            foreach(AIController e in enemyList)
            {
                if (_player.Pawn.ObjectIn(e.Pawn))
                {
                    _player.Pawn.EatMe();
                    e.Pawn.Upgrade(_player.Pawn.Mass);
                }
                else if (e.Pawn.ObjectIn(_player.Pawn))
                {
                    e.Pawn.EatMe();
                    _player.Pawn.Upgrade(e.Pawn.Mass);
                }
            }
        }
    }
}
