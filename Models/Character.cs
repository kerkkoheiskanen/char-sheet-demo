namespace HeroGritSheet.Models
{
    public class Character
    {
        public int Id { get; set; }
        // Other properties here
        public string Name { get; set; }
        public int Physique { get; set; }
        public int Fighting { get; set; }
        public int Precision { get; set; }
        public int Instincts { get; set; }
        public int Resolve { get; set; }
        public int Empathy { get; set; }
        public int Intellect { get; set; }
        public string Drives { get; set; }
        public string? Heritage { get; set; }
        public string? Profession { get; set; }
        public string? Inventory { get; set; }
        public int Maxload { get; set; }
        public int? Currentload { get; set; }
        public int? Experience { get; set; }
        public int? CurrentWoundStage { get; set; }
        public int MaxStamina {        get
        {
            return Physique + Resolve;
        }}
        public int? CurrentStamina { get; set; }
        public int? Coin { get; set; }
    }
}