using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

using enemy.cast;

namespace enemy.script {
    class SpawnGoal : genie.script.Action {
        
        private (int x, int y) windowSize;


        public SpawnGoal(int priority, (int, int) windowSize) : base(priority) {

        }

    

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {


        //    for(int i=0; i<=2; i++){
            Goal goal = new Goal("Dino/assets/egg (3).png", 80, 90, 500/2, 700/10 , 0, 0, 0, 0, 70, 80);
            cast.AddActor("goal", goal);
            script.RemoveAction("input", this);

            // script.RemoveAction("input", this);

        }
        
    }
}