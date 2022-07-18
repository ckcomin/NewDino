using genie.cast;

namespace enemy.cast {
    class Enemy : Actor {

        private int points;

        public Enemy(string path, int width, int height,
                        float x = 0, float y = 0,
                        float vx = 0, float vy = 0,
                        float rotation = 0, float rotationVel = 0,
                        float HBwidth = 0, float HBheight = 0,
                        
                        // change health
                        // int healthBarYOffset = 0,
                        // int healthBarHeight = 5,
                        // int maxHP = 0,
                        // bool showTextHealth = false,
                        
                        int points = 0) :
        base(path, width, height, x, y, vx, vy, rotation, rotationVel, HBwidth, HBheight
                    ) {
            // healthBarYOffset, healthBarHeight, maxHP, showTextHealth
            this.points = points;
            System.Console.WriteLine(this.GetPath());
        }

        public void SetPoints(int points) {
            this.points = points;
        }

        public int GetPoints() {
            return this.points;
        }
    }
}