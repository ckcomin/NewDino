using genie.cast;

namespace enemy.cast {
    class Goal : Actor {

        private int points;

        public Goal(string path, int width = 80, int height = 90,
                        float x = 0, float y = 0,
                        float vx = 0, float vy = 0,
                        float rotation = 0, float rotationVel = 0,
                        float HBwidth = 70, float HBheight = 80,
                        
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
        
        }

        public void SetPoints(int points) {
            this.points = points;
        }

        public int GetPoints() {
            return this.points;
        }


    }
}