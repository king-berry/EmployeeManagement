namespace EmployeeManagement.Models
{
	public class Department_Tbl
	{
		public int Id { get; set; }
		public string DepartmentName { get; set; }
		public int DepartmentCode { get; set; }
		public string Location { get; set; }
		public int NumberOfPersonals { get; set; }
		public ICollection<Employee_Tbl> Employee { get; set; }
	}
}
