namespace TeacherDesk.Models
{
    public class Exercise
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Instructions { get; set; } = string.Empty;
        public string Solution { get; set; } = string.Empty;
        public ExerciseType Type { get; set; }
        public List<string> Tags { get; set; } = new();
        public int Order { get; set; }
    }

    public enum ExerciseType
    {
        Practical,    // exercice pratique
        QCM,          // choix multiple
        Reflection,   // question ouverte
        Research      // travail de recherche
    }
}