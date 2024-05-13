namespace zadanie4.zadanie4;

public interface IAssignmentService
{
    Task<int?> AddAssignment(Assignment dto);
    Task<int?> AddAssignmentProcedure(Assignment dto);
}