namespace GameState.Records {
    public record GameRecord(int Round);

    public static class RecordHelper{
        public static Game ConvertGameRecord(GameRecord record){
            return new Game{
                Round = record.Round
            };
        }
    }
}

