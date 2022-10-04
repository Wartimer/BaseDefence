using Player;
using Runtime.Controller;
using Spawner;

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
            var player = new MyPlayer(playerData);
            player.Spawn(mapView.PlayerSpawnPos);
            
            camera.Init(player.PlayerView.transform, cameraData);

            var placeForVirtualJoysticks = uiData.PlaceForVirtualJoysticks;
            placeForVirtualJoysticks.Init(player.StarterAssetsInputs);

            var placeForUi = uiData.PlaceForUi;

            var enemySpawnController = new EnemySpawnController(new EnemyFactory(enemyDataList), mapView);

            var enemiesController = new EnemiesController(enemySpawnController);
            
            controllers.Add(enemySpawnController);
            controllers.Add(enemiesController);

            // InitializeData(data, controllers, cameraData, uiData, playerData, enemyDataList, placeForUi);
        }
    }
}