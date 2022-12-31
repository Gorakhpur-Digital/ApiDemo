namespace ApiDemo.Model
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public int CreateBy { get; set; }
    }
}
