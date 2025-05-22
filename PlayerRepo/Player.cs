namespace PlayerRepo{
    public class Player {
        public int Id {get;set;}
        public string? Name{get;set;}
        public string? Avatar{get;set;}
        public bool IsMurderer{get;set;}
        public bool HasVoted{get;set;}
        public bool HasKilled{get;set;}
        public bool IsAlive{get;set;}
        public int VotesRecieved{get;set;}
    }
}

