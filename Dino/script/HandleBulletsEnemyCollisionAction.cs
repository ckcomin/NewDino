using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

using enemy.cast;

namespace enemy.script {
    class HandleBulletsEnemyCollisionAction : genie.script.Action {
        
        // Member Variables
        RaylibPhysicsService physicsService;
        // RaylibAudioService audioService;
        private PlayerScore? score;
        private List<Actor> bullets;


        // Constructor
        public HandleBulletsEnemyCollisionAction(int priority, RaylibPhysicsService physicsService) : base(priority) {
            this.score = null;
            this.physicsService = physicsService;
            // this.audioService = audioService;
            this.bullets = new List<Actor>();
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {
            // Grab the score from the cast
            this.score = (PlayerScore?) cast.GetFirstActor("score");

            // First, get a list of bullets out of the cast
            bullets = cast.GetActors("bullets");

            // Check if any bullet collides with any asteroid
            foreach (Enemy enemy in cast.GetActors("Enemies")) {
                Actor? collidedBullet = this.physicsService.CheckCollisionList(enemy, bullets);
                if (collidedBullet != null) {
                    cast.RemoveActor("bullets", collidedBullet);
                    cast.RemoveActor("Enemies", enemy);
                
                }
            }
        }
    }
}