using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

using enemy.cast;

namespace enemy.script {
    class HandleEnemiesDirectionAction : genie.script.Action {
         public HandleEnemiesDirectionAction(int priority, (int, int) windowSize) : base(priority){

         }
        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {
            List<Actor> enemies = cast.GetActors("Enemies");
            foreach(Actor enemy in enemies){
                if (enemy.GetX() <=0 || enemy.GetX() >=500) { 
                    // float vx= enemy.GetVx();
                    // float newvx = vx*-1;
                    // enemy.SetVx(newvx);
                    
                   enemy.SetVx(enemy.GetVx()*-1);
                   enemy.SetFlipped(!enemy.GetFlipped());

                //    Console.WriteLine(newvx);


                }
            }
            // Console.WriteLine("printed again");
            // foreach(Actor enemy in enemies){
            //     Console.WriteLine(enemy.GetVx);
            // }

        }
    }
}