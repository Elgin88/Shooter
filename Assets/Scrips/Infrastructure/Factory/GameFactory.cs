﻿using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateGraphy()
        {
            return _assetProvider.Instantiate(AssetPath.Graphy);
        }

        public GameObject CreatePlayer()
        {
            return _assetProvider.Instantiate(AssetPath.Player);
        }

        public GameObject CreateCanvas()
        {
            return _assetProvider.Instantiate(AssetPath.Canvas);
        }
    }
}