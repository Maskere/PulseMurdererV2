using PlayerRepo;

namespace PlayersREST.Records {
    public record PlayerRecord(int? Id, string? Name, string? Avatar, bool IsMurderer, bool IsAlive, int? VotesRecieved,bool HasKilled, bool HasVoted);

    public static class RecordHelper {
        public static Player ConvertPlayerRecord(PlayerRecord record) {
            if (record.Id == null) {
                throw new ArgumentNullException("" + record.Id);
            }
            if (record.Name == null) {
                throw new ArgumentNullException("" + record.Name);
            }
            return new Player {
                Id = (int)record.Id,
                Name = record.Name,
                Avatar = record.Avatar,
                IsMurderer = record.IsMurderer,
                IsAlive = record.IsAlive,
                HasKilled = record.HasKilled,
                HasVoted = record.HasVoted,
                VotesRecieved = (int)record.VotesRecieved
            };
        }
    }
}

