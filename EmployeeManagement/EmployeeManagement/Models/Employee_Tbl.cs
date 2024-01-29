namespace EmployeeManagement.Models
{
	public class Employee_Tbl
	{
		public int Id { get; set; }
		public string EmployeeName { get; set; }
		public string EmployeeCode { get; set; }
		public char rank { get; set; }
		public int DepartmentID { get; set; }
		public Department_Tbl Department { get; set; }


	}
}
