using Player;
using Runtime.Controller;
using Spawner;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace Controller
{
    internal sealed class GameInit
    {
        internal GameInit(Controllers controllers, Data.Data data)
        {
            var playerData = data.PlayerData;
            var cameraData = data.CameraData;
            var uiData = data.UIData;
            var enemyDataList = data.EnemyDataList;
            var mapData = data.MapData;

            var mapView = mapData.Map;
            
            var camera = cameraData.Camera;
            var player = new Player.Player(playerData);
            player.Spawn(mapView.PlayerSpawnPos);
            
            camera.Init(player.PlayerView.transform, cameraData);

            
            var placeForUi = uiData.PlaceForUi;
            var placeForVirtualJoysticks = uiData.PlaceForVirtualJoysticks;
            placeForVirtualJoysticks.Init(player.StarterAssetsInputs);
            placeForVirtualJoysticks.transform.SetParent(placeForUi.transform);




            var enemySpawnController = new EnemySpawnController(new EnemyFactory(enemyDataList), player, mapView);

            var enemiesController = new EnemiesController(enemySpawnController, mapView.AttackPoints);
            
            controllers.Add(enemySpawnController);
            controllers.Add(enemiesController);

            // InitializeData(data, controllers, cameraData, uiData, playerData, enemyDataList, placeForUi);
        }
    }
}