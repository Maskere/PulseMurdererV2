namespace GameState{
    public class Game {
        public int Round {get;set;}
        private int nextRound = 0;

        public int NextRound(){
            Round = nextRound++;
            return Round;
        }

        public int ResetRound(){
            Round = 0;
            return Round;
        }
    }
}
