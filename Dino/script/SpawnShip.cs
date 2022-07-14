using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

using enemy.cast;

namespace enemy.script {
    class SpawnShip : genie.script.Action {
        
        private (int x, int y) windowSize;


        public SpawnShip(int priority, (int, int) windowSize) : base(priority) {

        }

    

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {


        //    for(int i=0; i<=2; i++){
            Ship ship = new Ship("Dino/assets/spaceship/green_dino.png", 120, 120, 500/2, 700/10*9, 0, 0, 0);

           cast.AddActor("ship", ship);
           script.RemoveAction("input", this);
           

           
            // script.RemoveAction("input", this);

        }
        
    }
}