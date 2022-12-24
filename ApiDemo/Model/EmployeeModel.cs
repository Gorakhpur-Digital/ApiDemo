namespace ApiDemo.Model
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public int DepartmentId { get; set; }
        public int CreateBy { get; set; }

    }
}
