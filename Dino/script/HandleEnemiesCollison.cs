using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

namespace enemy.script {
    class HandleEnemiesCollison : genie.script.Action {
         RaylibPhysicsService physicsService;
        // RaylibAudioService audioService;
        private genie.cast.Actor? ship;


        // Constructor
        public HandleEnemiesCollison(int priority, RaylibPhysicsService physicsService) : base(priority) {
            // , RaylibAudioService audioService
            this.ship = null;
            this.physicsService = physicsService;
            // this.audioService = audioService;
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {
            // Grab the ship from the cast
            this.ship = cast.GetFirstActor("ship");

            // Only worry about collision if the ship actually exists
            if (this.ship != null) {
                foreach (Actor actor in cast.GetActors("Enemies")) {
                    //System.Console.WriteLine(this.ship.GetHBTopLeft());
               //     System.Console.WriteLine(this.ship.GetTopLeft());
               //     System.Console.WriteLine(this.ship.GetHBTopLeft());
               //     System.Console.WriteLine(" ");
               //     System.Console.WriteLine(this.ship.GetX());
               //     System.Console.WriteLine(this.ship.GetY());
                    if (this.physicsService.CheckCollision(this.ship, actor)) {
                        cast.RemoveActor("ship", this.ship);
                        cast.RemoveActor("Enemies", actor);
                        // this.audioService.PlaySound("asteroid/assets/sound/explosion-01.wav", (float) 0.1);
                        this.ship = null;
                        break;
                    }
                }
            }
        }
    }
}