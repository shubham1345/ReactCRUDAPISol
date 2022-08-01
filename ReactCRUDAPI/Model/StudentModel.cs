using System.ComponentModel.DataAnnotations;

namespace ReactCRUDAPI.Model
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int RollNo { get; set; }
        public string Description { get; set; }
    }
}
