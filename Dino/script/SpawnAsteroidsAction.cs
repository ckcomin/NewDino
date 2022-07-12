using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

using asteroid.cast;

namespace asteroid.script {
    class SpawnAsteroidsAction : genie.script.Action {
        
        private (int x, int y) windowSize;
        private bool timerStarted;
        private bool asteroidSpawn;
        private DateTime lastSpawn;
        private float spawnInterval_ms;
        private Random randomGenerator;

        public SpawnAsteroidsAction(int priority, (int, int) windowSize, float spawnInterval) : base(priority) {
            // this.windowSize = windowSize;
            // this.timerStarted = false;
            // this.asteroidSpawn = false;
            // this.lastSpawn = new DateTime();
            // this.spawnInterval_ms = spawnInterval * 1000;
            // this.randomGenerator = new Random();
        }

        // private Asteroid CreateAsteroid(int type, int x, int y) {
        //     if (type == 1) {
        //         int velX = x > this.windowSize.x/2 ? -1 : 1;
        //         return new Asteroid("./asteroid/assets/asteroids/asteroid_large.png",
        //                             175, 175,        // Width and height of asteroid
        //                             x, y,            // X and Y of asteroid
        //                             velX, 3,         // vX and vY of asteroid
        //                             0, 1,            // rotation and rotational velocity
        //                             93, 5,           // health bar y-offset and heath bar height
        //                             5, true,         // maxHP and whether to show health text
        //                             5);              // how many points is this asteroid worth?
        //     }
        //     else if (type == 2)
        //     {
        //         int velX = x > this.windowSize.x / 2 ? -2 : 2;
        //         return new Asteroid("./asteroid/assets/asteroids/asteroid_med.png",
        //                             100, 100,        // Width and height of asteroid
        //                             x, y,            // X and Y of asteroid
        //                             velX, 6,         // vX and vY of asteroid
        //                             0, 1,            // rotation and rotational velocity
        //                             55, 5,           // health bar y-offset and heath bar height
        //                             3, true,         // maxHP and whether to show health text
        //                             3);              // how many points is this asteroid worth?
        //     }
        //     else {
        //         int velX = x > this.windowSize.x / 2 ? -3 : 3;
        //         return new Asteroid("./asteroid/assets/asteroids/asteroid_small.png",
        //                             40, 40,        // Width and height of asteroid
        //                             x, y,            // X and Y of asteroid
        //                             velX, 8,         // vX and vY of asteroid
        //                             0, 1,            // rotation and rotational velocity
        //                             25, 5,           // health bar y-offset and heath bar height
        //                             1, true,         // maxHP and whether to show health text
        //                             1);              // how many points is this asteroid worth?
        //     }
        // }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {


           for(int i=0; i<=2; i++){
            Asteroid enemy = new Asteroid("Dino/assets/asteroids/asteroid_small.png", 70, 50, 50, 200+i*50, 10, 0, 0, 0, 1);

           cast.AddActor("Enemies", enemy);
           

           }
            script.RemoveAction("input", this);

        }
    }
}