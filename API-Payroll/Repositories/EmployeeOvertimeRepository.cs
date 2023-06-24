using API_Payroll.Context;
using API_Payroll.Contracts;
using API_Payroll.Models;
using API_Payroll.ViewModels.Overtimes;
using Microsoft.EntityFrameworkCore;

namespace API_Payroll.Repositories
{
    public class EmployeeOvertimeRepository : GenericRepository<Overtime>, IEmployeeOvertimeRepository
    {
        public EmployeeOvertimeRepository(PayrollOvertimeContext context) : base(context)
        {
        }
        public Overtime CreateRequest(Overtime overtime)
        {
            try
            {                
                var employee = _context.Employees.Where(e => e.Id == overtime.Employee_id).Join(_context.EmployeeLevels, es => es.EmployeeLevel_id, el => el.Id, (es, el) => new { Employee = es, EmployeeLevel = el }).FirstOrDefault();

                var salaryPerHours = employee.EmployeeLevel.Salary * 1 / 173;
                var totalHours = Convert.ToInt32((overtime.EndOvertime - overtime.StartOvertime).TotalHours);
                
                var today = overtime.SubmitDate.DayOfWeek;

                if (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday) {
                    if (totalHours > 11)
                    { 
                        totalHours = 11; 
                    }
                    overtime.Paid = TotalPaidWeekend(totalHours, salaryPerHours);
                                            
                }
                else {
                    if (totalHours > 4)
                    { 
                        totalHours = 4; 
                    }
                    for (int i = 0; i < totalHours; i++)
                    {
                        if (i < 1)
                        {
                            overtime.Paid += Convert.ToInt32(1.5 * salaryPerHours);
                        }
                        else
                        {
                            overtime.Paid += 2 * salaryPerHours;
                        }
                    }
                }
                       
                _context.Set<Overtime>().Add(overtime);
                _context.SaveChanges();
                return overtime;
            }
            catch {
                return null;
            }
            
        }
        public int TotalPaidWeekend(int totalHours, int salaryPerHours) {
            try
            {
                int paid = 0;
                for (int i = 0; i < totalHours; i++)
                {
                    if (i < 8)
                    {
                        paid += 2 * salaryPerHours;
                    }
                    else if (i == 8)
                    {
                        paid += 3 * salaryPerHours;
                    }
                    else
                    {
                        paid += 4 * salaryPerHours;
                    }
                }
                return paid;

            }
            catch {
                return 0;    
            }
        }

        public int ApprovalOvertime(Overtime overtimeRequest, Guid id) {
            try
            {
                var employee = _context.Employees.FirstOrDefault(guid => guid.Id == overtimeRequest.Employee_id);
                var _reportTo = employee.ReportTo;

                if (_reportTo != null && _reportTo == id)
                {
                    _context.Entry(overtimeRequest).State = EntityState.Modified;
                    var result = _context.SaveChanges();
                    return 1;
                }

                return 0;
            }
            catch {
                return 0;
            }
        }

        public List<OvertimeVM> ListOvertimeByIdManager(Guid managerId) {
            try
            {
                var query = _context.Employees
                .Where(e => e.ReportTo == managerId)
                .Join(_context.Overtimes,
                    emp => emp.Id,
                    ov => ov.Employee_id,
                    (emp, ov) => new OvertimeVM
                    {
                        Id = ov.Id,
                        StartOvertime = ov.StartOvertime,
                        EndOvertime = ov.EndOvertime,
                        SubmitDate = ov.SubmitDate,
                        Deskripsi = ov.Deskripsi,
                        Paid = ov.Paid,
                        Status = ov.Status,
                        Employee_id = ov.Employee_id
                    }).Where(sta => sta.Status == 0)
                .ToList();

                return query;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<OvertimeVM> ListOvertimeByIdEmployee(Guid employeeId) {
            try
            {
                var overtimes = _context.Overtimes.Where(e => e.Employee_id == employeeId).Select(e => new OvertimeVM
                {
                    Id = e.Id,
                    StartOvertime = e.StartOvertime,
                    EndOvertime = e.EndOvertime,
                    SubmitDate = e.SubmitDate,
                    Deskripsi = e.Deskripsi,
                    Paid = e.Paid,
                    Status = e.Status,
                    Employee_id = e.Employee_id
                }).ToList();

                return overtimes;
            }
            catch {
                return null;
            }
        }
    
    }
}
