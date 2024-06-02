namespace UniversityManagerAPI.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Year { get; set; }
        public int FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
    }
}
