using LoggingWithSerilog_Demo.Models;

namespace LoggingWithSerilog_Demo.DataServices
{
    public class EmployeeServices
    {
        private  List<EmployeeViewModel>? EmpList { get; set; }
        public EmployeeServices()
        {
            EmpList = new List<EmployeeViewModel>()
            {
                new EmployeeViewModel() { Id = 1, Name = "sanjay Singh",Salary=2000,Designation=".Net Developer"},
                new EmployeeViewModel() { Id = 2, Name = "Rahul Singh",Salary=6000,Designation="Java Developer"},
                new EmployeeViewModel() { Id = 3, Name = "Ritik Sharma",Salary=12000,Designation="Python Developer"},
                new EmployeeViewModel() { Id = 4, Name = "Shivam  Choudhary",Salary=5000,Designation="Data Analysist"},
                new EmployeeViewModel() { Id = 5, Name = "Shiva Singh",Salary=45000,Designation="Php Developer"}
            };
        }
        public List<EmployeeViewModel> GetEmployee()
        {
            return EmpList!.ToList();
        }
    }
}
